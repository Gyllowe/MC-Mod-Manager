using MC_Mod_Manager_Common;

namespace Console_App;
public abstract class Command {
    public abstract string PrintedName();
    public string HelpText() {
        return "\nThis command does not have a help description given.\n\n";
    }

    public abstract void Run();
}



public class ListInstalledMods : Command {
    public static readonly ListInstalledMods Inst = new();
    public override string PrintedName() => "List installed mods";

    public override void Run() {
        List<Mod> mods = ModManager.Mods;

        if(mods.Count == 0) {
            Console.WriteLine("There are no mods currently installed.\n");
            return;
        }

        Console.WriteLine("\nInstalled mods:");

        int longestModName = "Name".Length;
        int longestModCreator = "Creator".Length;
        foreach(Mod mod in mods) {
            longestModName = mod.Name.Length > longestModName ? mod.Name.Length : longestModName;
            longestModCreator = mod.Creator.Length > longestModCreator ? mod.Creator.Length : longestModCreator;
        }


        int modNameBuffer = longestModName + 6;
        int modCreatorBuffer = longestModCreator + 6;
        Console.WriteLine(
            "{0, -" + modNameBuffer + "}" +
            "{1, -" + modCreatorBuffer + "}" +
            "{2}",
            "Name", "Creator", "\n"
            );

        foreach(Mod mod in mods) {
            Console.WriteLine(
                "{0, -" + modNameBuffer + "}" +
                "{1, -" + modCreatorBuffer + "}",
                mod.Name, mod.Creator
                );
        }
    }
}
public class UpdateAllMods : Command {
    public static readonly UpdateAllMods Inst = new();
    public override string PrintedName() => "Update all mods";

    public override void Run() {
        // do something
    }
}
public class InspectMod : Command {
    public static readonly InspectMod Inst = new();
    public override string PrintedName() => "Inspect mod";

    public override void Run() {
        // do something
    }
}
public class AddNewMod : Command {
    public static readonly AddNewMod Inst = new();
    public override string PrintedName() => "Add new mod";

    public override void Run() {
        Console.WriteLine("\nEnter name for new mod:");
        //string name = 
    }
}
public class AddNoteToMod : Command {
    public static readonly AddNoteToMod Inst = new();
    public override string PrintedName() => "Add note to mod";

    public override void Run() {
        // do something
    }
}
public class AddNoteToModInstance : Command {
    public static readonly AddNoteToModInstance Inst = new();
    public override string PrintedName() => "Add note to mod instance";

    public override void Run() {
        // do something
    }
}
public class OptionsCommand : Command {
    public static readonly OptionsCommand Inst = new();
    public override string PrintedName() => "Options";

    public override void Run() {
        // do something
    }
}
public class QuitCommand : Command {
    public static readonly QuitCommand Inst = new();
    public override string PrintedName() => "Quit";

    public override void Run() {
        // do something
    }
}
