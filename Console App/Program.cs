// See https://aka.ms/new-console-template for more information

using MC_Mod_Manager_Console_App;

string intro =
@"Welcome to Gyllowe's Minecraft Mod Manager!";





Startup();

Console.WriteLine(
    System.Environment.NewLine + System.Environment.NewLine
    + intro
    + System.Environment.NewLine);

MainCommands.Run();






// Methods
// Ran once at program startup
static void Startup() {
    Console.WriteLine("Starting up...");
}








// Structs

// Enums
