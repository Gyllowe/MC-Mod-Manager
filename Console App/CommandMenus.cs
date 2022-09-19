namespace Console_App;
public static class CommandMenus {
    public static readonly List<Command> MainMenu = new() {
        ListInstalledMods.Inst,

        UpdateAllMods.Inst,
        InspectMod.Inst,
        // compare mods?
        // check mod compatibility?

        AddNewMod.Inst,

        AddNoteToMod.Inst,
        AddNoteToModInstance.Inst,

        OptionsCommand.Inst,
        QuitCommand.Inst
    };



    public static void Open(List<Command> menu) {
        // Writing out the commands
        Console.WriteLine("Enter the number for the command you want to run:");
        for(int i = 1; i <= menu.Count; i++) {
            Console.WriteLine("  {0} : {1}", i, menu[i - 1].PrintedName());
        }

        // User input for choosing command and verifying that it's valid
        int choise = 0;
        bool choiseAccepted = false;
        while(!choiseAccepted) {
            string? input = Console.ReadLine();

            // Validating user input
            if(input == "") {
                Console.WriteLine("Please choose a command.");
                continue;
            } else if(int.TryParse(input, out choise) == false) {
                Console.WriteLine($"{input} is not an integer");
                continue;
            }
            if(choise < 1 || choise > menu.Count + 1) {
                Console.WriteLine("Command not found");
                continue;
            }
            choiseAccepted = true;
        }

        menu[choise - 1].Run();
    }

}