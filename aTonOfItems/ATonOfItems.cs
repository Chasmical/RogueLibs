using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using BepInEx;
using RogueLibsCore;
using UnityEngine;

namespace aTonOfItems
{
	[BepInPlugin(pluginGUID, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.GUID, "3.0")]
	public class ATonOfItems : BaseUnityPlugin
	{
		public const string pluginGUID = "abbysssal.streetsofrogue.atonofitems";
		public const string pluginName = "a Ton of Items";
		public const string pluginVersion = "0.3";

		public void Awake()
		{
			RogueLibs.AddCustomItem<VoodooBlank>()
				.WithUnlock(new ItemUnlock(nameof(VoodooBlank))
				{
					UnlockCost = 5,
					CharacterCreationCost = 5,
					Prerequisites = new List<string> { "WalkieTalkie" }
				})
				.WithSprite(Properties.Resources.VoodooBlank)
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = "Blank Voodoo Doll",
					[LanguageCode.Russian] = "Непривязанная кукла Вуду"
				})
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Bind the doll to someone and then combine things with it to inflict damage or effects onto that person.",
					[LanguageCode.Russian] = "Привяжите куклу к кому-нибудь и потом совмещайте всякие предметы с ней, чтобы наносить урон или эффекты на этого человека."
				});

			RogueLibs.AddCustomItem<VoodooActive>()
				.WithSprite(Properties.Resources.VoodooActive)
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = "Active Voodoo Doll",
					[LanguageCode.Russian] = "Активированная кукла Вуду"
				}).WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Combine things with the doll to inflict damage or effects onto the victim.",
					[LanguageCode.Russian] = "Совмещайте всякие предметы с куклой для нанесения урона или эффектов жертве."
				});

			RogueLibs.AddCustomName("VoodooBind", "Interface", new CustomNameInfo
			{
				[LanguageCode.English] = "Bind",
				[LanguageCode.Russian] = "Привязать"
			});

			RogueLibs.AddCustomName("VoodooNotAgent", "Interface", new CustomNameInfo
			{
				[LanguageCode.English] = "Select a character!",
				[LanguageCode.Russian] = "Выберите персонажа!"
			});
			RogueLibs.AddCustomName("VoodooDeadAgent", "Interface", new CustomNameInfo
			{
				[LanguageCode.English] = "They're already dead",
				[LanguageCode.Russian] = "Он уже мёртвый"
			});
			RogueLibs.AddCustomName("VoodooElectronic", "Interface", new CustomNameInfo
			{
				[LanguageCode.English] = "This thing doesn't have a soul",
				[LanguageCode.Russian] = "У этой штуки нет души"
			});

			RoguePatcher patcher = new RoguePatcher(this);
			patcher.Postfix(typeof(Gun), nameof(Gun.spawnBullet), new Type[] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });
		}
		public static void Gun_spawnBullet(InvItem myWeapon, Bullet __result)
		{
			VoodooActive voodoo = myWeapon.database.GetItem<VoodooActive>();
			if (voodoo != null) voodoo.LastFiredBullet = __result;
		}
	}
	[ItemCategories(RogueCategories.Usable, RogueCategories.Social, RogueCategories.Stealth, RogueCategories.Weird)]
	public class VoodooBlank : CustomItem, IItemTargetable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 80;
			Item.initCount = 3;
			Item.rewardCount = 3;
			Item.stackable = true;
			Item.hasCharges = true;
			Item.goesInToolbar = true;
		}
		public bool TargetFilter(PlayfieldObject target) => target is Agent agent && !agent.dead && !agent.mechFilled && !agent.mechEmpty;
		public void TargetObject(PlayfieldObject target)
		{
			Inventory.DestroyItem(Item);
			VoodooActive voodoo = Inventory.AddItem<VoodooActive>(Count);
			voodoo.Victim = (Agent)target;
		}
		public CustomTooltip TargetTooltip(PlayfieldObject target)
		{
			if (target is Agent agent)
			{
				if (agent.dead) return gc.nameDB.GetName("VoodooDeadAgent", "Interface");
				if (agent.mechFilled || agent.mechEmpty || agent.statusEffects.hasTrait("Electronic"))
					return gc.nameDB.GetName("VoodooElectronic", "Interface");

				return gc.nameDB.GetName("VoodooBind", "Interface");
			}
			else return gc.nameDB.GetName("VoodooNotAgent", "Interface");
		}
	}
	[ItemCategories(RogueCategories.Social, RogueCategories.Stealth, RogueCategories.Weird)]
	public class VoodooActive : CustomItem, IItemCombinable, IDoUpdate
	{
		public Agent Victim { get; set; }
		public Bullet LastFiredBullet { get; set; }

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 100;
			Item.stackable = true;
			Item.hasCharges = true;
		}

		private int actualCount;
		public float Cooldown;
		public void Update()
		{
			if (Victim.dead || !Victim.isActiveAndEnabled) CombineItems(Item);
			if (Cooldown > 0f)
			{
				Cooldown = Math.Max(Cooldown - Time.deltaTime, 0f);
				int displayCount = (int)(Cooldown * 10);
				Count = displayCount > 0 ? displayCount : actualCount;
			}
		}

		[IgnoreDefaultChecks]
		public bool CombineFilter(InvItem other) => Item == other || other.itemType == ItemTypes.Consumable
			|| other.itemType == ItemTypes.WeaponMelee || other.itemType == ItemTypes.WeaponProjectile;
		public void CombineItems(InvItem other)
		{
			if (Cooldown != 0f) return;
			float cooldown;

			if (Item == other)
			{
				Inventory.DestroyItem(Item);
				if (--Count > 0) Inventory.AddItem<VoodooBlank>(Count);
				return;
			}
			else if (other.itemType == ItemTypes.Consumable)
			{
				new ItemFunctions().UseItem(other, Victim);
				cooldown = Mathf.Clamp(other.itemValue / 50f, 0.5f, 1.5f);
			}
			else if (other.itemType == ItemTypes.WeaponMelee)
			{
				float damage = other.meleeDamage / 2f;
				damage *= 1f + Owner.strengthStatMod / 3f;
				damage *= Owner.agentSpriteTransform.localScale.x;

				if (Owner.statusEffects.hasTrait("Strength")) damage *= 1.5f;
				if (Owner.statusEffects.hasTrait("StrengthSmall")) damage *= 1.25f;
				if (Owner.statusEffects.hasTrait("Weak")) damage *= 0.5f;
				if (Owner.statusEffects.hasTrait("Withdrawal")) damage *= 0.75f;

				Inventory.DepleteMelee(Mathf.Clamp((int)(damage / Owner.agentSpriteTransform.localScale.x), 0, 15), other);

				Quaternion rn = UnityEngine.Random.rotation;
				Victim.statusEffects.ChangeHealth(-(int)damage, Owner);
				Victim.movement.KnockBackBullet(rn, 80f, true, Owner);
				Victim.relationships.SetRel(Owner, "Hateful");
				Victim.relationships.AddRelHate(Owner, 5);

				gc.audioHandler.Play(Victim, other.hitSoundType == "Cut"
					? damage < 12f ? "MeleeHitAgentCutSmall" : "MeleeHitAgentCutLarge"
					: damage < 10f ? "MeleeHitAgentSmall" : "MeleeHitAgentLarge");

				string effect = "BloodHit";
				if (Victim.inhuman) effect += "Yellow";
				if (damage >= 10f) effect += damage < 15f ? "Med" : "Large";
				gc.spawnerMain.SpawnParticleEffect(effect, Victim.tr.position, rn.eulerAngles.z);

				cooldown = Mathf.Clamp(damage / 15, 0.5f, 1f);
			}
			else if (other.itemType == ItemTypes.WeaponProjectile)
			{
				InvItem prev = Inventory.equippedWeapon;
				Inventory.equippedWeapon = other;
				Owner.gun.Shoot(false, false, false);
				Inventory.equippedWeapon = prev;

				Bullet bullet = LastFiredBullet;
				cooldown = Owner.weaponCooldown;

				bullet.curPosition = bullet.transform.position = Victim.curPosition;
				bullet.transform.rotation = Quaternion.FromToRotation(Vector2.zero, Victim.rb.velocity);

				Owner.gun.SubtractBullets(1, other);
			}
			else return;

			actualCount = Count;
			Cooldown = cooldown;
		}
		public CustomTooltip CombineTooltip(InvItem other) => "456";
	}
}
