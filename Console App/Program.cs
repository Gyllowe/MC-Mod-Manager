// See https://aka.ms/new-console-template for more information

using Console_App;

string intro =
@"Welcome to Gyllowe's Minecraft Mod Manager!";





Startup();

Console.WriteLine($"\n\n{intro}\n");

CommandMenus.Open  (CommandMenus.MainMenu);






// Methods
// Ran once at program startup
static void Startup() {
    Console.WriteLine("Starting up...");
}








// Structs

// Enums
