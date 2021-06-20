using BepInEx;
using RogueLibsCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static tk2dCameraSettings;

namespace aTonOfMutators
{
	internal static class Patches
	{
		public static void Patch(ATOMPlugin plugin)
		{
			RoguePatcher patcher = new RoguePatcher(plugin, typeof(Patches));

			RogueLibsInternals.InvItemFactories.Add(new ItemModifier());

			patcher.Prefix(typeof(Movement), nameof(Movement.KnockForward), new Type[] { typeof(Quaternion), typeof(float), typeof(bool) });
			patcher.Postfix(typeof(Melee), nameof(Melee.Attack), new Type[] { typeof(bool) });
			patcher.Postfix(typeof(Bullet), nameof(Bullet.SetupBullet), new Type[] { });
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnBullet),
				new Type[] { typeof(Vector3), typeof(bulletStatus), typeof(PlayfieldObject), typeof(int) });
			patcher.Postfix(typeof(Gun), nameof(Gun.SetWeaponCooldown), new Type[] { typeof(float), typeof(InvItem) });
			patcher.Postfix(typeof(Explosion), nameof(Explosion.SetupExplosion), new Type[] { });
			patcher.Prefix(typeof(Gun), nameof(Gun.spawnBullet),
				new Type[] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });
		}

		public static void Movement_KnockForward(ref float strength) => ATOMMutator.UseMultiplier(ref strength, ATOMType.MeleeLunge);
		public static void Melee_Attack(Melee __instance)
		{
			ATOMMutator.UseMultiplier(ref __instance.agent.weaponCooldown, ATOMType.MeleeSpeed);
			float speed = __instance.meleeContainerAnim.speed;
			ATOMMutator.UseMultiplier(ref speed, ATOMType.MeleeSpeed);
			__instance.meleeContainerAnim.speed = speed;
		}
		public static void Bullet_SetupBullet(Bullet __instance)
		{
			ATOMMutator.UseMultiplier(ref __instance.damage, ATOMType.RangedDamage);
			ATOMMutator.UseMultiplier(ref __instance.speed, ATOMType.ProjectileSpeed);
		}
		public static void SpawnerMain_SpawnBullet(ref bulletStatus bulletType)
		{
			if (ATOMMutator.IsActive(ATOMType.ProjectileRockets))
				bulletType = bulletStatus.Rocket;
			else if (ATOMMutator.IsActive(ATOMType.ProjectileRandom))
				do bulletType = (bulletStatus)new System.Random().Next(1, 22); // [1;21]
				while (bulletType == bulletStatus.ZombieSpit || bulletType == bulletStatus.Laser || bulletType == bulletStatus.MindControl);
		}
		public static void Gun_SetWeaponCooldown(Gun __instance)
		{
			ATOMMutator.UseMultiplier(ref __instance.agent.weaponCooldown, ATOMType.RangedFirerate, true);
			__instance.agent.weaponCooldown = Mathf.Max(__instance.agent.weaponCooldown, 0.05f);
		}
		public static void Explosion_SetupExplosion(Explosion __instance)
		{
			ATOMMutator.UseMultiplier(ref __instance.damage, ATOMType.ExplosionDamage);
			float power = __instance.circleCollider2D.radius;
			ATOMMutator.UseMultiplier(ref power, ATOMType.ExplosionPower);
			__instance.circleCollider2D.radius = Mathf.Sqrt(power);
		}
		public static void Gun_spawnBullet(ref bulletStatus bulletType, ref string myStatusEffect)
		{
			if (ATOMMutator.IsActive(ATOMType.ProjectileEffects) || (bulletType == bulletStatus.WaterPistol && string.IsNullOrEmpty(myStatusEffect)))
			{
				bulletType = bulletStatus.WaterPistol;
				List<string> list = new List<string>()
				{
					"Poisoned", "Drunk", "Slow", "Fast", "Strength", "Weak", "Paralyzed", "Accurate",
					"RegenerateHealth", "Acid", "Invincible", "Invisible", "Confused", "FeelingUnlucky",
					"Resurrection", "AlwaysCrit", "Shrunk", "ElectroTouch", "BadVision", "BlockDebuffs",
					"DecreaseAllStats", "Dizzy", "DizzyB", "Enraged", "FeelingLucky", "WerewolfEffect",
					"Frozen", "HearingBlocked", "Nicotine", "Tranquilized", "Electrocuted", "Giant",
					"IncreaseAllStats", "KillerThrower", "MindControlled", "NiceSmelling", "Cyanide"
				};
				int rand = new System.Random().Next(list.Count);
				myStatusEffect = list[rand];
			}
		}

	}
	internal class ItemModifier : HookFactoryBase<InvItem>
	{
		public override bool TryCreate(InvItem item, out IHook<InvItem> hook)
		{
			if (item.itemType == ItemTypes.WeaponMelee)
			{
				ATOMMutator.UseMultiplier(ref item.meleeDamage, ATOMType.MeleeDamage);

				ATOMMutator.UseMultiplier(ref item.initCount, ATOMType.MeleeDurability);
				ATOMMutator.UseMultiplier(ref item.initCountAI, ATOMType.MeleeDurability);
				ATOMMutator.UseMultiplier(ref item.rewardCount, ATOMType.MeleeDurability);
			}
			else if (item.itemType == ItemTypes.WeaponThrown)
			{
				ATOMMutator.UseMultiplier(ref item.throwDamage, ATOMType.ThrownDamage);

				ATOMMutator.UseMultiplier(ref item.initCount, ATOMType.ThrownCount);
				ATOMMutator.UseMultiplier(ref item.initCountAI, ATOMType.ThrownCount);
				ATOMMutator.UseMultiplier(ref item.rewardCount, ATOMType.ThrownCount);

				ATOMMutator.UseMultiplier(ref item.throwDistance, ATOMType.ThrownDistance);
			}
			else if (item.itemType == ItemTypes.WeaponProjectile)
			{
				ATOMMutator.UseMultiplier(ref item.initCount, ATOMType.RangedAmmo);
				ATOMMutator.UseMultiplier(ref item.initCountAI, ATOMType.RangedAmmo);
				ATOMMutator.UseMultiplier(ref item.rewardCount, ATOMType.RangedAmmo);
				ATOMMutator.UseMultiplier(ref item.itemValue, ATOMType.RangedAmmo, true);

				if (ATOMMutator.IsActive(ATOMType.RangedFullAuto)) item.rapidFire = true;
			}
			hook = null;
			return false;
		}
	}
}
