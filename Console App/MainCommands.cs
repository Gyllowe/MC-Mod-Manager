using MC_Mod_Manager_Common;

namespace MC_Mod_Manager_Console_App;

internal class MainCommands {
    public static readonly MainCommands Inst = new();

    static List<string> _commands = new() {
        "List installed mods",
        
        "Check for updates on all installed mods",
        "Inspect mod",
        
        
        "Options",
        "Quit"
    };




    // Methods
    public static void Run() {
        Console.WriteLine("Enter the number for the command you want to run:");

        for(int i = 1; i <= _commands.Count; i++) {
            Console.WriteLine($"  {i} : {_commands[ i - 1 ]}");
        }


        int choise;
        bool choiseAccepted = false;
        while(!choiseAccepted) {
            string? input = Console.ReadLine();

            if(input == "") {
                Console.WriteLine("Please choose a command.");
                continue;
            } else if(int.TryParse(input, out choise) == false) {
                Console.WriteLine($"{input} is not an integer");
                continue;
            }
            
            if(choise < 1 || choise > _commands.Count + 1) {
                Console.WriteLine("Command not found");
                continue;
            }
            choiseAccepted = true;


            switch(_commands[choise - 1]) {
                case "List installed mods":
                    _ListInstalledMods();
                    break;
                case "Check for updates on all installed mods":
                    Console.WriteLine($"{System.Environment.NewLine}method for '{_commands[choise - 1]}'");
                    break;
                case "Inspect mod":
                    Console.WriteLine($"{System.Environment.NewLine}method for '{_commands[choise - 1]}'");
                    break;
                case "Options":
                    Console.WriteLine($"{System.Environment.NewLine}method for '{_commands[choise - 1]}'");
                    break;
                case "Quit":
                    Console.WriteLine($"{System.Environment.NewLine}method for '{_commands[choise - 1]}'");
                    break;
                default:
                    break;
            }
        }
    }

    private static void _ListInstalledMods() {
        Console.WriteLine(Environment.NewLine + "Installed mods:");

        List<Mod> ni;
    }



}
