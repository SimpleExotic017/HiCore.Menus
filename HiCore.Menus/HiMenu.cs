using System;
using System.Collections.Generic;
using System.Text;

namespace HiCore.Menus
{
    internal class HiMenu
    {
        //CLI color styling options
        public ConsoleColor titleColor = ConsoleColor.Yellow;
        private List<ConsoleColor> optionColors = new List<ConsoleColor>();


        //CLI Remaining styling options
        private string cursor = "->";
        private int spacing = 5;
        private string menuTitle = "Quite Exquisite";
        public string customReturnMessage = $"=================\n ENTER To Return\n=================";


        //Original state before menu implementation
        private bool originalcursorvisibility = Console.CursorVisible;
        private ConsoleColor originalColor = Console.ForegroundColor;


        //conditions for looping and requiring input to continue
        public bool returnToMenu = true;
        public bool enterToReturn = true;


        //Backbone of this entire class
        Dictionary<string, Action> options = new Dictionary<string, Action>();


        public HiMenu(string menuTitle)
        {
            this.menuTitle = menuTitle;
            optionColors.Add(ConsoleColor.Yellow);
        }
        private bool exit = false;
        private void Exit()
        {
            exit = true;
        }

        public void AddOption(string optionName, Action optionExecute) 
        {
            if (options.TryAdd(optionName, optionExecute))
            {
                optionColors.Add(ConsoleColor.Yellow);
            }
            else
            {
                throw new OptionAlreadyInMenuException();
            }
        }

        public void AddMultipleOptions(Dictionary<string,Action> optionsToAdd)
        {
            foreach (var item in optionsToAdd)
            {
                AddOption(item.Key,item.Value);
            }
        }
        public void SetCursor(string cursor)
        {
            this.cursor = cursor;
        }
        public void SetSpacing(int spacing)
        {
                this.spacing = spacing;
        }
        public void SetOptionColors(List<ConsoleColor> colorList)
        {
            for (int i = 0; i < colorList.Count && i < optionColors.Count; i++)
            {
                optionColors[i] = colorList[i];
            }
        }

        public void SetOptionColorByIndex(int index, ConsoleColor changecolor)
        {
            ValidateOptionColorList();
            optionColors[index] = changecolor;
        }
        public void Show()
        {
            do
            {
            Console.Clear();
            originalColor = Console.ForegroundColor;
            Console.ForegroundColor = titleColor;
            Console.WriteLine($"{"".PadLeft(spacing)}{"".PadLeft(menuTitle.Length + 4,'=')}");
            Console.WriteLine($"{"".PadLeft(spacing)}- {menuTitle} -");
            Console.WriteLine($"{"".PadLeft(spacing)}{"".PadLeft(menuTitle.Length + 4,'=')}");
            int itemCount = 1;
            options.Remove("Exit");
            options.Add("Exit", () => Exit());
            Action[] optionActions = new Action[options.Count];
            ValidateOptionColorList();
            foreach (var item in options)
            {
                Console.ForegroundColor = optionColors[itemCount-1];
                Console.WriteLine($"\n{"".PadLeft(spacing+cursor.Length)}{itemCount}. {item.Key}");
                optionActions[itemCount - 1] = item.Value;
                itemCount++;
            }
            HandleOptionSelection(optionActions);
            if (!exit && enterToReturn)
            {
                Console.CursorVisible = false;
                Console.WriteLine($"\n{customReturnMessage}");
                Console.ReadLine();
                Console.CursorVisible = originalcursorvisibility;
                }
            } while (!exit && returnToMenu);
            exit = false;
        }

        private void HandleOptionSelection(Action[] optionActions)
        {
            ConsoleKey pressedKey = ConsoleKey.None;
            int cursorpositionInOptions = 0;
            originalcursorvisibility = Console.CursorVisible;
            Console.CursorVisible = false;
            Console.SetCursorPosition(spacing -1 ,Console.CursorTop + 1 - (options.Count*2));
            Console.ForegroundColor = optionColors[0];
            Console.Write(cursor);
            do
            {
                pressedKey = Console.ReadKey().Key;
                if (pressedKey == ConsoleKey.UpArrow && cursorpositionInOptions > 0)
                {
                    cursorpositionInOptions--;
                    MoveCursor(-2, cursorpositionInOptions);
                }
                else if (pressedKey == ConsoleKey.DownArrow && cursorpositionInOptions < options.Count -1)
                {
                    cursorpositionInOptions++;
                    MoveCursor(+2, cursorpositionInOptions);
                }
            } while (pressedKey != ConsoleKey.Enter);
            Console.CursorVisible = originalcursorvisibility;
            Console.Clear();
            Console.ForegroundColor = originalColor;
            optionActions[cursorpositionInOptions].Invoke();
        }
        private void MoveCursor(int verticalOffset, int cursorpositionInOptions)
        {
            Console.CursorLeft = Console.CursorLeft - cursor.Length;
            Console.Write("".PadLeft(cursor.Length));
            Console.SetCursorPosition(spacing - 1, Console.CursorTop + verticalOffset);
            //Console.ForegroundColor = cursorColor;
            Console.ForegroundColor = optionColors[cursorpositionInOptions];
            Console.Write(cursor);
        }
        private void ValidateOptionColorList()
        {
            int diff = options.Count - optionColors.Count;
            if (diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    optionColors.Add(ConsoleColor.Yellow);
                }
            }
        }
    }
}
