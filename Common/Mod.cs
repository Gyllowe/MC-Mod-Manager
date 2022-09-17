using System.Collections.Generic;

namespace MC_Mod_Manager_Common;

public class Mod {
    public string Name { get; private set; } = string.Empty;
    public string Creator { get; private set; } = string.Empty;


    // Modinstances saved in library, string is the ModInstance's version
    public Dictionary<string, ModInstance> Modfiles { get; private set; } = new Dictionary<string, ModInstance>();

    public List<Mod> Depenencies { get; private set; } = new();

    public List<Mod> Incombatibilities { get; private set; } = new();
    public List<Category> Categories { get { return ModManager.GetModCategories(this); } }

    public Dictionary<ModDownloadSource, string>
        DownloadSources { get; private set; } = new();

    public List<string> Notes { get; private set; } = new();
    public Dictionary<string, List<string>> NotesOnMods_Mod = new();




    public Mod(string name) {
        Name = name;
    }


    //
    public void RenameMod(string newName) {
        Name = newName;
    }

    // TODO: Implement
    public void AddInstance(ModInstance instance) { }


    // Adding notes
    public void AddNote(string note) {
        Notes.Add(note);
    }
    // Adding notes tied to other mods
    public void AddNote(Mod mod, string note) {
        if(NotesOnMods_Mod.ContainsKey(mod.Name)) {
            NotesOnMods_Mod[mod.Name].Add(note);
            return;
        }
        NotesOnMods_Mod.Add(mod.Name, new List<string> { note });
    }
}

public struct ModInstance {
    public readonly Mod ParentMod;
    public string FileName { get; private set; } = string.Empty;

    public Modloader? Mod_Loader = null;
    public List<string> McVersions;
    public List<Mod> SpecialCompatibilities;

    public List<string> Notes = new();
    public Dictionary<string, List<string>> NotesOnMods_Instance = new();



    public ModInstance(Mod parentMod, string file, List<string> mcVersions, List<Mod>? compatibilities = null) {
        ParentMod = parentMod;
        FileName = file;
        McVersions = mcVersions;

        compatibilities ??= new();
        SpecialCompatibilities = compatibilities;
    }

    // TODO: Implement
    public void RenameFile(string newName) { }

    // Adding notes
    public void AddNote(string note) {
        Notes.Add(note);
    }
    // Adding notes to a mod
    public void AddNote(Mod mod, string note) {
        if(NotesOnMods_Instance.ContainsKey(mod.Name)) {
            NotesOnMods_Instance[mod.Name].Add(note);
            return;
        }
        NotesOnMods_Instance.Add(mod.Name, new List<string> { note });
    }
}


public enum ModDownloadSource {
    Modrinth, Github, Curseforge
}
public enum Modloader {
    Forge, Fabric, Quilt
}
