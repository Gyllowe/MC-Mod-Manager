using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MC_Mod_Manager_Common;

namespace MC_Mod_Manager.Scripts.Menus;

internal sealed class ModMenu {
    public static readonly ModMenu Inst = new();

    public static Dictionary<Mod, Expander?> ModlistExpanders = new();




    public static List<Mod> GetMods() {
        return ModManager.Mods;
    }




    // >>OBSOLETE<<
    // But keepng for the memories :)
    public static string GetModsTextBlock() {
        string text = string.Empty;

        for(int i = 0; i < ModManager.Mods.Count; i++) {
            text += Environment.NewLine;
            text += ModManager.Mods[i].Name;
        }

        return text;
    }
}
