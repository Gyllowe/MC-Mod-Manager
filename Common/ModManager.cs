using System.Collections.Generic;

namespace MC_Mod_Manager_Common;

public sealed class ModManager {
    public static readonly ModManager Inst = new();

    public static List<Mod> Mods { get; private set; } = new();





    // TODO: Implement
    public static List<Category> GetModCategories(Mod mod) {
        //k
        return new List<Category>();
    }

    // TODO: Implement
    public static List<Mod> GetModsByCategory(Category[] categories) {
        //k
        return new List<Mod>();
    }



    public static void NewMod(string name) {
        Mods.Add(new Mod(name));
    }

    // Implement later.
    public void RemoveMod(Mod mod) { }
}


public enum Category {
    none,
    TrueOptimization,
    Optimization,
    AlteringOptimization,
    //
    TinyFix,
    TinyChange,
    //
    VanillaPlusContent,
    NonVanillaContent,
    //
    VisualAddition,
    VisualChange,
    //
    Gameplay,
    TechnicalChange,
    //
    MenuImprovement
}
