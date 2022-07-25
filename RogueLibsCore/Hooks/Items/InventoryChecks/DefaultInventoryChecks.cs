namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The collection of default inventory checks.</para>
    /// </summary>
    public static class DefaultInventoryChecks
    {
        internal static void SubscribeChecks()
        {
            InventoryChecks.AddItemUsingCheck("Ghost", GhostCheck);
            InventoryChecks.AddItemUsingCheck("PeaBrained", PeaBrainedCheck);
            InventoryChecks.AddItemUsingCheck("OnlyOil", OnlyOilCheck);
            InventoryChecks.AddItemUsingCheck("OnlyOilMedicine", OnlyOilMedicineCheck);
            InventoryChecks.AddItemUsingCheck("OnlyBlood", OnlyBloodCheck);
            InventoryChecks.AddItemUsingCheck("OnlyBloodMedicine", OnlyBloodMedicineCheck);
            InventoryChecks.AddItemUsingCheck("OnlyCharge", OnlyChargeCheck);
            InventoryChecks.AddItemUsingCheck("OnlyChargeMedicine", OnlyChargeMedicineCheck);
            InventoryChecks.AddItemUsingCheck("OnlyHumanFlesh", OnlyHumanFleshCheck);
            InventoryChecks.AddItemUsingCheck("FullHealth", FullHealthCheck);
        }

        /// <summary>
        ///   <para>Prevents ghost agents from using items.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void GhostCheck(OnItemUsingArgs e)
        {
            if (e.User.ghost)
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"Ghost\" inventory check.");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Pea-Brained" agents from using non-Food items.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void PeaBrainedCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType != ItemTypes.Food && e.User.HasTrait("CantInteract"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"PeaBrained\" inventory check.");
                e.User.SayDialogue("CantInteract");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Oil-Reliant" agents from consuming food.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyOilCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType == ItemTypes.Food && (e.Item.Categories.Contains("Food") || e.Item.Categories.Contains("Alcohol"))
                && e.User.HasTrait("OilRestoresHealth"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyOil\" inventory check.");
                e.User.SayDialogue("OnlyOilGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Oil-Reliant" agents from using medicine.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyOilMedicineCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health")
                && e.User.HasTrait("OilRestoresHealth"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyOilMedicine\" inventory check.");
                e.User.SayDialogue("OnlyOilGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Jugularious" agents from consuming food.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyBloodCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType == ItemTypes.Food && (e.Item.Categories.Contains("Food") || e.Item.Categories.Contains("Alcohol"))
                && e.User.HasTrait("BloodRestoresHealth"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyBlood\" inventory check.");
                e.User.SayDialogue("OnlyBloodGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Jugularious" agents from using medicine.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyBloodMedicineCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health")
                && e.User.HasTrait("BloodRestoresHealth") && !e.Item.Categories.Contains("Blood"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyBloodMedicine\" inventory check.");
                e.User.SayDialogue("OnlyBloodGivesHealth2");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Electronic" agents from consuming food.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyChargeCheck(OnItemUsingArgs e)
        {
            if (e.User.electronic && e.Item.itemType == ItemTypes.Food && e.Item.Categories.Contains("Food"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyCharge\" inventory check.");
                e.User.SayDialogue("OnlyChargeGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Electronic" agents from using medicine.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyChargeMedicineCheck(OnItemUsingArgs e)
        {
            if (e.User.electronic && e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyChargeMedicine\" inventory check.");
                e.User.SayDialogue("OnlyChargeGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents "Strict Cannibal" agents from consuming non-alcohol food.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void OnlyHumanFleshCheck(OnItemUsingArgs e)
        {
            if (e.Item.itemType == ItemTypes.Food && e.Item.Categories.Contains("Food")
                && e.User.HasTrait("CannibalizeRestoresHealth"))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"OnlyHumanFlesh\" inventory check.");
                e.User.SayDialogue("OnlyCannibalizeGivesHealth");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
        /// <summary>
        ///   <para>Prevents agents with full health from consuming healing items.</para>
        /// </summary>
        /// <param name="e">The item usage event args.</param>
        public static void FullHealthCheck(OnItemUsingArgs e)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (e.Item.healthChange > 0 && e.User.health == e.User.healthMax)
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                    RogueFramework.LogDebug("---- Triggered \"FullHealth\" inventory check.");
                e.User.SayDialogue("HealthFullCantUseItem");
                e.User.gc.audioHandler.Play(e.User, "CantDo");
                e.Cancel = e.Handled = true;
            }
        }
    }
}
