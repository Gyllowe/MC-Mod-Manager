namespace MC_Mod_Manager_Common;

public sealed class ModManager {
    public static readonly ModManager Inst = new();

    public static List<Mod> Mods { get; private set; } = new();





    // Implement later.
    public static List<Category> GetModCategories(Mod mod) {
        //k
        return new List<Category>();
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
