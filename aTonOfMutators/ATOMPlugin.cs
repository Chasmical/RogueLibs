using BepInEx;
using RogueLibsCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace aTonOfMutators
{
	[BepInPlugin(pluginGUID, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.GUID, "3.0")]
	public class ATOMPlugin : BaseUnityPlugin
	{
		public const string pluginGUID = "abbysssal.streetsofrogue.atonofmutators";
		public const string pluginName = "a Ton of Mutators";
		public const string pluginVersion = "1.4";

		public static int ATOMOffset = -1299;

		public void Awake()
		{
			#region Melee Mutators
			ATOMCategory category = CreateCategory(ATOMType.MeleeCategory);

			CreateMutatorGroup(category, ATOMType.MeleeDamage,
				new float[] { 0f, float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f, 999f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Melee Damage x.",
					[LanguageCode.Russian] = "Урон оружия ближнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All melee weapons deal [0|1|.x more|.x less] damage.",
					[LanguageCode.Russian] = "Всё оружие ближнего боя наносит [0 урона|1 урон|в .x больше урона|в .x меньше урона].",
				})
				.AddConflicts("NoMelee");

			CreateMutatorGroup(category, ATOMType.MeleeDurability,
				new float[] { float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Melee Durability x.",
					[LanguageCode.Russian] = "Прочность оружия ближнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All melee weapons have [|1|.x more|.x less] durability.",
					[LanguageCode.Russian] = "У всего оружия ближнего боя [|1 прочность|в .x больше прочности|в .x меньше прочности].",
				})
				.AddConflicts("NoMelee", "InfiniteMeleeDurability");

			CreateMutatorGroup(category, ATOMType.MeleeSpeed,
				new float[] { 0.125f, 0.25f, 0.5f, 2f, 4f, 8f, 999f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Melee Speed x.",
					[LanguageCode.Russian] = "Скорость оружия ближнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All melee weapons attack [||.x faster|.x slower].",
					[LanguageCode.Russian] = "Всё оружие ближнего боя бьёт [||в .x быстрее|в .x медленнее].",
				})
				.AddConflicts("NoMelee");

			CreateMutatorGroup(category, ATOMType.MeleeLunge,
				new float[] { 0f, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Melee Lunge x.",
					[LanguageCode.Russian] = "Выпады у оружия ближнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All melee weapons [don't lunge||have .x longer lunges|have .x shorter lunges]",
					[LanguageCode.Russian] = "У всего оружия ближнего боя [нет выпадов||выпады в .x длиннее|выпады в .x короче]",
				})
				.AddConflicts("NoMelee");
			#endregion

			#region Thrown Mutators
			category = CreateCategory(ATOMType.ThrownCategory);

			CreateMutatorGroup(category, ATOMType.ThrownDamage,
				new float[] { 0f, float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f, 999f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Thrown Damage x.",
					[LanguageCode.Russian] = "Урон кидательного оружия x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All thrown weapons deal [0|1|.x more|.x less] damage.",
					[LanguageCode.Russian] = "Всё кидательное оружие наносит [0 урона|1 урон|в .x больше урона|в .x меньше урона].",
				});

			CreateMutatorGroup(category, ATOMType.ThrownCount,
				new float[] { float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f, 999f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Thrown Count x.",
					[LanguageCode.Russian] = "Количество кидательного оружия x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All thrown weapons appear [|stacks of 1|.x larger stacks|.x smaller stacks].",
					[LanguageCode.Russian] = "Всё кидательное оружие появляется в [|стаках по 1|.x больших стаках|в .x меньших стаках].",
				});

			CreateMutatorGroup(category, ATOMType.ThrownDistance,
				new float[] { 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Thrown Distance x.",
					[LanguageCode.Russian] = "Дальность кидательного оружия x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All thrown weapons can be thrown at [||.x larger|.x smakker] distance.",
					[LanguageCode.Russian] = "Всё кидательное оружие может быть кинуто на [||в .x большее|в .x меньшее] расстояние.",
				});
			#endregion

			#region Ranged Mutators
			category = CreateCategory(ATOMType.RangedCategory);

			CreateMutatorGroup(category, ATOMType.RangedDamage,
				new float[] { 0f, float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f, 999f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Ranged Damage x.",
					[LanguageCode.Russian] = "Урон оружия дальнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All ranged weapons deal [0|1|.x more|.x less] damage.",
					[LanguageCode.Russian] = "Всё оружие дальнего боя наносит [0 урона|1 урон|в .x больше урона|в .x меньше урона].",
				})
				.AddConflicts("NoGuns");

			CreateMutatorGroup(category, ATOMType.RangedAmmo,
				new float[] { float.Epsilon, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Ranged Ammo x.",
					[LanguageCode.Russian] = "Боезапас оружия дальнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All ranged weapons have [|1|.x more|.x less] ammo.",
					[LanguageCode.Russian] = "У всего оружия дальнего боя [|1 снаряд|в .x больше боеприпасов|в .x меньше боеприпасов].",
				})
				.AddConflicts("NoGuns", "InfiniteAmmo");

			CreateMutatorGroup(category, ATOMType.RangedFirerate,
				new float[] { 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Ranged Firerate x.",
					[LanguageCode.Russian] = "Скорострельность оружия дальнего боя x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All ranged weapons have [||.x faster|.x slower] rate of fire.",
					[LanguageCode.Russian] = "Всё оружие дальнего боя стреляет [||в .x быстрее|в .x медленнее].",
				})
				.AddConflicts("NoGuns");

			CreateMutator(ATOMType.RangedCategory | ATOMType.RangedFullAuto, null, 25,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Fully Automatic Ranged Weapons",
					[LanguageCode.Russian] = "Автоматическое оружие дальнего боя",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All ranged weapons are fully automatic",
					[LanguageCode.Russian] = "Всё оружие дальнего боя автоматическое",
				}).Cancellations.Add("NoGuns");
			#endregion

			#region Projectile Mutators
			category = CreateCategory(ATOMType.ProjectileCategory);

			CreateMutatorGroup(category, ATOMType.ProjectileSpeed,
				new float[] { 0f, 0.125f, 0.25f, 0.5f, 2f, 4f, 8f }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Projectile Speed x.",
					[LanguageCode.Russian] = "Скорость снарядов x.",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All projectiles are [||.x faster|.x slower].",
					[LanguageCode.Russian] = "Все снаряды в [||.x быстрее|.x медленнее].",
				});

			CreateMutator(ATOMType.ProjectileRockets, null, 15,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Rocket Projectiles",
					[LanguageCode.Russian] = "Ракетные снаряды",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All projectiles are rockets.",
					[LanguageCode.Russian] = "Все снаряды - ракеты.",
				});

			CreateMutator(ATOMType.ProjectileEffects, null, 15,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Effect Projectiles",
					[LanguageCode.Russian] = "Эффектные снаряды",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All projectiles are water pistol bullets.",
					[LanguageCode.Russian] = "Все снаряды - пули водяного пистолета.",
				});

			CreateMutator(ATOMType.ProjectileRandom, null, 15,
				new CustomNameInfo
				{
					[LanguageCode.English] = "Random Projectiles",
					[LanguageCode.Russian] = "Рандомные снаряды",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "All projectiles are random.",
					[LanguageCode.Russian] = "Все снаряды случайные.",
				});
			#endregion









			/*
			CreateMutatorGroup(ATOMType.MeleeCategory | ATOMType.MeleeSpeed,
				new float[] { }, null,
				new CustomNameInfo
				{
					[LanguageCode.English] = "",
					[LanguageCode.Russian] = "",
				},
				new CustomNameInfo
				{
					[LanguageCode.English] = "",
					[LanguageCode.Russian] = "",
				});
			*/
			Patches.Patch(this);
		}
		public ATOMCategory CreateCategory(ATOMType type)
		{
			ATOMCategory category = new ATOMCategory(type);
			RogueLibs.CreateCustomUnlock(category);
			category.SortingOrder = ATOMOffset++;
			category.SortingIndex = -1;
			return category;
		}
		public List<ATOMMutator> CreateMutatorGroup(ATOMCategory category, ATOMType type, float[] multipliers, int[] unlockCosts, CustomNameInfo name, CustomNameInfo description)
		{
			type |= category.Category;
			if (multipliers is null) throw new ArgumentNullException(nameof(multipliers));
			if (unlockCosts is null)
			{
				int[] newUnlockCosts = new int[multipliers.Length];
				for (int i = 0; i < newUnlockCosts.Length; i++)
					newUnlockCosts[i] = multiplierDefaultCosts.TryGetValue(multipliers[i], out int cost) ? cost
						: throw new ArgumentOutOfRangeException(nameof(multipliers));
				unlockCosts = newUnlockCosts;
			}
			if (multipliers.Length != unlockCosts.Length)
				throw new ArgumentOutOfRangeException(nameof(multipliers));

			List<ATOMMutator> list = new List<ATOMMutator>(multipliers.Length);
			for (int i = 0; i < multipliers.Length; i++)
			{
				float multiplier = multipliers[i];

				string replacer = multiplier == 0f ? "$1"
						: multiplier == float.Epsilon ? "$2"
						: multiplier > 1 ? "$3" : "$4";
				string multiplierStr = multiplier == float.Epsilon ? "=1" : "x" + multiplier.ToString(CultureInfo.InvariantCulture);
				string multiplierText = (multiplier > 1 ? multiplier : 1f / multiplier).ToString(CultureInfo.InvariantCulture) + "x";

				CustomNameInfo newName = new CustomNameInfo(name.Select(pair => new KeyValuePair<LanguageCode, string>(pair.Key,
					"[aToM] " + pair.Value.Replace("x.", multiplierStr).Replace(".x", multiplierText))));
				CustomNameInfo newDescription = new CustomNameInfo(description.Select(pair => new KeyValuePair<LanguageCode, string>(pair.Key,
					regex.Replace(pair.Value, replacer).Replace("x.", multiplierStr).Replace(".x", multiplierText))));

				ATOMMutator mutator = CreateMutator(type, multiplier, unlockCosts[i], newName, newDescription);
				mutator.SortingOrder = category.SortingOrder;
				mutator.SortingIndex = category.Count++;
				mutator.IgnoreStateSorting = true;
				list.Add(mutator);
			}
			return list;
		}
		public ATOMMutator CreateMutator(ATOMType type, float? multiplier, int cost, CustomNameInfo name, CustomNameInfo description)
		{
			ATOMMutator mutator = multiplier != null ? new ATOMMutator(type, multiplier.Value) : new ATOMMutator(type);
			mutator.UnlockCost = cost;
			RogueLibs.CreateCustomUnlock(mutator, name, description);
			return mutator;
		}
		private static readonly Dictionary<float, int> multiplierDefaultCosts = new Dictionary<float, int>
		{
			[0f] = 20,
			[float.Epsilon] = 20,
			[0.125f] = 15,
			[0.25f] = 10,
			[0.5f] = 5,
			[2f] = 5,
			[4f] = 10,
			[8f] = 15,
			[999f] = 20
		};
		private static readonly Regex regex = new Regex(@"\[(.*)\|(.*)\|(.*)\|(.*)\]");
	}
	public class ATOMMutator : MutatorUnlock
	{
		public ATOMType MyType { get; }
		public float Multiplier { get; }

		public ATOMMutator(ATOMType type)
			: base(GetName(type))
		{
			MyType = type;
			Mutators.Add(this);
			IsAvailable = false;
		}
		public ATOMMutator(ATOMType type, float multiplier)
			: base(GetName(type, multiplier))
		{
			MyType = type;
			Multiplier = multiplier;
			Mutators.Add(this);
			IsAvailable = false;
		}
		private static string GetName(ATOMType type) => $"ATOM:{type & ATOMType.Values}";
		private static string GetName(ATOMType type, float multiplier) => $"ATOM:{type & ATOMType.Values}:{(multiplier == float.Epsilon ? "=1" : "x" + multiplier.ToString(CultureInfo.InvariantCulture))}";

		public override void OnPushedButton()
		{
			if (IsUnlocked && Menu.Type == UnlocksMenuType.MutatorMenu)
			{
				PlaySound("ClickButton");
				if (IsEnabled = !IsEnabled)
				{
					foreach (DisplayedUnlock du in GetCancellations())
						du.IsEnabled = false;
					ATOMMutator mutator = GetActiveOfType(MyType);
					if (mutator != null)
					{
						mutator.IsEnabled = false;
						mutator.UpdateButton();
					}
				}
				SendAnnouncementInChat(IsEnabled ? "AddedChallenge" : "RemovedChallenge", Name);
				UpdateButton();
				UpdateMenu();
			}
			else base.OnPushedButton();
		}

		private static readonly List<ATOMMutator> Mutators = new List<ATOMMutator>();
		public static IEnumerable<ATOMMutator> GetOfType(ATOMType type) => Mutators.Where(m => (m.MyType & ATOMType.Values) == type);
		public static IEnumerable<ATOMMutator> GetOfCategory(ATOMType category) => Mutators.Where(m => (m.MyType & category) != 0);
		public static ATOMMutator GetActiveOfType(ATOMType type) => Mutators.Find(m => (m.MyType & ATOMType.Values) == type && m.IsEnabled);
		public static bool IsActive(ATOMType type) => GetActiveOfType(type) != null;
		public static void UseMultiplier(ref float value, ATOMType type, bool inverse = false)
		{
			ATOMMutator mutator = GetActiveOfType(type);
			if (mutator is null) return;
			float multiplier = inverse ? 1f / mutator.Multiplier : mutator.Multiplier;
			if (multiplier == float.Epsilon) value = 1f;
			else value *= multiplier;
		}
		public static void UseMultiplier(ref int value, ATOMType type, bool inverse = false)
		{
			ATOMMutator mutator = GetActiveOfType(type);
			if (mutator is null) return;
			float multiplier = inverse ? 1f / mutator.Multiplier : mutator.Multiplier;
			value = multiplier == float.Epsilon ? 1 : (int)Mathf.Ceil(value * multiplier);
		}
	}
	public static class ATOMExtensions
	{
		public static void AddConflicts(this List<ATOMMutator> mutators, params string[] conflicts)
		{
			foreach (ATOMMutator mutator in mutators)
				mutator.Cancellations.AddRange(conflicts);
		}
	}
	public class ATOMCategory : MutatorUnlock
	{
		public ATOMType Category { get; }
		public int Count { get; set; }

		public ATOMCategory(ATOMType category) : base($"ATOM:{category}", true)
		{
			Category = category;
			Categories.Add(this);
		}

		public static readonly List<ATOMCategory> Categories = new List<ATOMCategory>();

		private bool isExpanded;
		public bool IsExpanded
		{
			get => isExpanded;
			set
			{
				if (isExpanded != (isExpanded = value))
				{
					foreach (ATOMMutator mutator in ATOMMutator.GetOfCategory(Category))
						mutator.IsAvailable = value;
					if (value)
						foreach (ATOMCategory category in Categories)
							if (category != this) category.IsExpanded = false;
				}
			}
		}
		public override void UpdateButton() => UpdateButton(IsExpanded);
		public override void OnPushedButton()
		{
			if (Menu.Type == UnlocksMenuType.MutatorMenu)
			{
				PlaySound("ClickButton");
				IsExpanded = !IsExpanded;
				((CustomScrollingMenu)Menu).Menu.OpenScrollingMenu();
			}
			else base.OnPushedButton();
		}
	}
	[Flags]
	public enum ATOMType
	{
		None = 0,

		MeleeDamage,
		MeleeDurability,
		MeleeSpeed,
		MeleeLunge,

		RangedDamage,
		RangedAmmo,
		RangedFirerate,
		RangedFullAuto,

		ThrownDamage,
		ThrownCount,
		ThrownDistance,

		ProjectileSpeed,
		ProjectileRockets,
		ProjectileRandom,
		ProjectileEffects,

		ExplosionDamage,
		ExplosionPower,

		WoodenWalls,
		StoneWalls,
		MetalWalls,
		GlassWalls,
		HedgeWalls,
		RandomWalls,
		NoWalls,

		GameplaySpeed,
		GlobalSpeed,

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1157:Composite enum value contains undefined flag.", Justification = "<Pending>")]
		Values = 0x00_FFFF,

		MeleeCategory = 0x01_0000,
		RangedCategory = 0x02_0000,
		ThrownCategory = 0x04_0000,
		ProjectileCategory = 0x08_0000,
		ExplosionCategory = 0x10_0000,
		LevelCategory = 0x20_0000,
		OtherCategory = 0x40_0000
	}
}
