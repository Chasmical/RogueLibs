namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Window()
        {
            Patch<Window>(Params1);
            PatchInteract<Window>();

            RogueInteractions.CreateProvider<Window>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (!h.Agent.interactionHelper.TriggerList.Contains(h.Object.windowHelper.tr.Find("ObjectSprite").gameObject)
                    && !h.gc.tileInfo.IsIndoors(h.Agent.tr.position, false))
                {
                    h.AddButton("RapOnWindow", static m =>
                    {
                        m.Object.RapOnWindow();
                        m.StopInteraction();
                    });
                }
                InvItem? windowCutter = h.Agent.inventory.FindItem("WindowCutter");
                if (windowCutter is not null)
                {
                    h.AddButton("UseWindowCutter", $" ({windowCutter.invItemCount})",
                                static m => m.StartOperating("WindowCutter", 2f, true, "Cutting"));
                }
                if (h.Object.broken && h.gc.levelType != "Tutorial")
                {
                    h.AddButton("SlipThroughWindow", h.gc.challenges.Contains("LowHealth") ? " - 7 HP" : " - 15 HP",
                                static m => m.Object.SlipThroughWindow(m.Agent));
                }
            });
        }
    }
}
