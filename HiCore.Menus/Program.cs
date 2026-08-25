namespace HiCore.Menus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HiMenu menu = new HiMenu("Critical Infrastructure Monitoring System ( CIMS )");
            Test test = new Test();

            //Dictionary<string, Action> testDictionary = new Dictionary<string, Action>();
            //testDictionary.Add("Succes", () => test.test6());
            //testDictionary.Add("Success", () => test.test6());

            menu.AddOption("All systems Online", ()=> test.test1());
            menu.AddOption("Corrupted", ()=> test.test2());
            menu.AddOption("Viral Activity Detected", () => test.test3());
            menu.AddOption("<404 Not Found>", () => test.test4());
            menu.AddOption("Unavailable", () => test.test5());
            menu.AddOption("Backup Required", () => test.test6());
            //menu.AddMultipleOptions(testDictionary);
            menu.SetSpacing(6);
            menu.titleColor = ConsoleColor.Cyan;
            menu.SetCursor(">UwU>");
            //menu.SetOptionColorByIndex(3, ConsoleColor.Red);
            //menu.SetOptionColorByIndex(4, ConsoleColor.Red);
            menu.SetOptionColors(new List<ConsoleColor>() { ConsoleColor.Green, ConsoleColor.Red,ConsoleColor.DarkRed, ConsoleColor.DarkBlue, ConsoleColor.White,ConsoleColor.Cyan,ConsoleColor.DarkYellow });
            //menu.SetOptionColorByIndex(5, ConsoleColor.DarkCyan);
            menu.returnToMenu = false;
            menu.enterToReturn = false;
            menu.Show();
        }
    }
}
