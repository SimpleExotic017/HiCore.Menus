using System;
using System.Collections.Generic;
using System.Text;

namespace HiCore.Menus
{
    internal class OptionAlreadyInMenuException : ApplicationException
    {
        public OptionAlreadyInMenuException() : base("This option already exists in this current menu, please use another key value")
        {
        }
    }
}
