using System.Text;

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
    public static readonly List<Command> ChooseMod = new() {
        ListInstalledMods.Inst
        // filters (category, version, modloader...)
    };



    public static void Open(List<Command> menu, List<Command>? additionalCommands = null) {
        if(additionalCommands != null)
            menu.AddRange(additionalCommands);

        // Writing out the commands
        Console.WriteLine("Enter the number for the command you want to run:");
        for(int i = 1; i <= menu.Count; i++) {
            Console.WriteLine("  {0} : {1}", i, menu[i - 1].PrintedName());
        }

        // User input for choosing command and verifying that it's valid
        int choice = 0;
        bool choiceAccepted = false;
        while(!choiceAccepted) {
            string input = Console.ReadLine() ?? "";

            // Validating user input
            if(input == "") {
                Console.WriteLine("Please choose a command.");
                continue;
            } else if(int.TryParse(input, out choice) == false) {
                Console.WriteLine($"{input} is not an integer");
                continue;
            }
            if(choice < 1 || choice > menu.Count) {
                Console.WriteLine("Command not found");
                continue;
            }
            choiceAccepted = true;
        }

        menu[choice - 1].Run();
    }

    public static int? SelectSingle(List<string> prints) => SelectMultiple(prints, 1)?[0];

    public static List<int>? SelectMultiple(List<string> prints, int maxChoose = 0, int minChoose = 0) {
        if(maxChoose == 1) {
            Console.WriteLine("Enter the number for the item you want to choose:");
        } else if(maxChoose < 1) {
            Console.WriteLine("Enter the numbers for the items you want to choose with a space between.\nE.g. 5 7 10 0");
        } else {
            Console.WriteLine("Enter the numbers for the items you want to choose with a space between."
            + $" Max {maxChoose} items.\nE.g: 5 7 10 1");
        }

        for(int i = 0; i < prints.Count; i++)
            Console.WriteLine("  {0} : {1}", i + 1, prints[i]);


        // User input for choosing items and verifying that it's valid
        List<int> choiceNumbers = new();
        bool choiceAccepted = false;
        while(!choiceAccepted) {
            choiceAccepted = true;
            string input = Console.ReadLine() ?? "";

            // continue; if no input given
            if(input == "") {
                Console.WriteLine(maxChoose == 1 ?
                    "Please choose an item." :
                    maxChoose < 1 ?
                    "Please choose any number of items." :
                    "Please choose up to {maxChoose} items.");
                choiceAccepted = false;
                continue;
            }

            // Extracting numbers from input
            choiceNumbers.Clear();
            List<string> nonIntChoices = new();
            string buildingChoise = "";
            foreach(char c in input) {
                if(char.IsWhiteSpace(c)) {
                    // Skip consecutive whitespaces
                    if(buildingChoise == "")
                        continue;
                    if(int.TryParse(buildingChoise, out int i)) {
                        if(!choiceNumbers.Contains(i))
                            choiceNumbers.Add(i);
                    } else if(!nonIntChoices.Contains(buildingChoise)) {
                        nonIntChoices.Add(buildingChoise);
                    }
                    buildingChoise = "";
                    continue;
                }

                buildingChoise += c;
            }



            // Printing non-int inputs
            StringBuilder nonIntPrint = new();
            if(nonIntChoices.Count != 0) {
                if(nonIntChoices.Count == 1) {
                    nonIntPrint.Append($"This is not an integer: {nonIntChoices[0]}");
                } else {
                    nonIntPrint.Append($"These are not intagegers: {nonIntChoices[0]}");
                    for(int i = 1; i < nonIntChoices.Count; i++) {
                        nonIntPrint.Append(", " + nonIntChoices[i]);
                    }
                }
                Console.WriteLine(nonIntPrint.ToString());
                choiceAccepted = false;
            }

            // Invalid choices are added to choicesNotFound
            List<int> choicesNotFound = new();
            foreach(int number in choiceNumbers) {
                if( (number < 1 || number < prints.Count) && !choicesNotFound.Contains(number) )
                    choicesNotFound.Add(number);
            }
            // Printing invalid int choices
            StringBuilder notFoundPrint = new();
            if(choicesNotFound.Count != 0) {
                if(choicesNotFound.Count == 1) {
                    nonIntPrint.Append($"Item not found: {choicesNotFound[0]}");
                } else {
                    nonIntPrint.Append($"Items not found: {choicesNotFound[0]}");
                    for(int i = 1; i < choicesNotFound.Count; i++) {
                        nonIntPrint.Append(", " + choicesNotFound[i]);
                    }
                }
                Console.WriteLine(nonIntPrint.ToString());
                choiceAccepted = false;
            }

            // Verifying number of choices
            if(maxChoose > 0 && choiceNumbers.Count > maxChoose) {
                Console.WriteLine($"Too many items chosen, max is {maxChoose}");
                choiceAccepted = false;
            }
            if(minChoose > 0 && choiceNumbers.Count > minChoose) {
                Console.WriteLine($"Too few items chosen, minimum is {minChoose}");
                choiceAccepted = false;
            }

        }

        return choiceNumbers.Count > 0 ? choiceNumbers : null;
    }

}
