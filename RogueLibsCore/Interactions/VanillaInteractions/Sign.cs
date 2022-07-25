namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Sign()
        {
            PatchInteract<Sign>();

            RogueLibs.CreateCustomName("Read", NameTypes.Interface, new CustomNameInfo
            {
                English = "Read",
                Russian = @"Прочитать",
            });
            RogueInteractions.CreateProvider<Sign>(static h =>
            {
                if (h.Helper.interactingFar) return;
                h.AddImplicitButton("Read", static m =>
                {
                    bool quick = m.gc.challenges.Contains("QuickGame");
                    string text;

                    if (m.Object.isUserCreated && !string.IsNullOrEmpty(m.Object.extraVarString))
                        text = m.Object.extraVarString;
                    else if (!m.gc.serverPlayer && !string.IsNullOrEmpty(m.Object.signTextOnline))
                        text = m.Object.signTextOnline;
                    else if (m.Object.signLocation is 0)
                    {
                        if (m.gc.levelTheme is 5)
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_MayorOffice1", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_MayorOffice2", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_MayorOffice3", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_MayorOffice4", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless is 1)
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_StartGame", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_StartGame2", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless is 2)
                            text = string.Join("\n",
                                               m.gc.nameDB.GetName("Sign_CopRules", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules2", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules3", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules4", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules5", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules6", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_CopRules7", NameTypes.Dialogue),
                                               // Note: 8 is supposed to be missing
                                               m.gc.nameDB.GetName("Sign_CopRules9", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless == (quick ? 3 : 4))
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_Industrial", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Industrial2", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless == (quick ? 5 : 7))
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_Park", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Park2", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Park3", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless == (quick ? 7 : 10))
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_Downtown", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Downtown2", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Downtown3", NameTypes.Dialogue));
                        else if (m.gc.sessionDataBig.curLevelEndless == (quick ? 9 : 13))
                            text = string.Join("\n\n",
                                               m.gc.nameDB.GetName("Sign_Uptown", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Uptown2", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Uptown3", NameTypes.Dialogue),
                                               m.gc.nameDB.GetName("Sign_Uptown4", NameTypes.Dialogue));
                        else text = string.Empty;
                    }
                    else if (m.Object.signLocation is 1)
                    {
                        text = m.gc.nameDB.GetName("Sign_FirstElevator", NameTypes.Dialogue);
                    }
                    else if (m.Object.signLocation is 2)
                    {
                        text = string.Join("\n\n",
                                           m.gc.nameDB.GetName("Sign_InvestMoney", NameTypes.Dialogue),
                                           m.gc.nameDB.GetName("Sign_InvestMoney2", NameTypes.Dialogue),
                                           m.gc.nameDB.GetName("Sign_InvestMoney3", NameTypes.Dialogue));
                    }
                    else text = string.Empty;

                    m.Object.ShowBigImage(text, string.Empty, null);
                });
            });
        }
    }
}
