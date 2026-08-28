# HiCore.Menus

A lightweight, highly customizable CLI selection menu for .NET applications.

Easily create interactive console menus where users can navigate options using the **Up** and **Down** arrow keys and select items using **ENTER**. Supports nested menus for creating submenus, alongside fine-grained styling control over cursors, colors, and layout.

---

## 📦 Installation

Install via the .NET CLI:

```bash
dotnet add package HiCore.Menus
```

Or via the Package Manager Console in Visual Studio:

```powershell
Install-Package HiCore.Menus
```

---

## ✨ Features

- **Intuitive Navigation:** Smooth selection using Arrow Keys and Enter.
- **Multiple Adding Options:** Add single options or pass a `Dictionary<string, Action>` to populate a menu at once.
- **Built-in Key Safety:** Prevents duplicate menu option names within the same menu level.
- **Nested Menus:** Easily attach submenus for multi-level navigation.
- **Custom Styling:** Full control over colors, foregrounds, and overriding the selection cursor string.
- **Zero External Dependencies:** Built natively for .NET.

---

## 🚀 Quick Start

```csharp
using HiCore.Menus;

// 1. Instantiate the menu
HiMenu menu = new HiMenu("Main Menu");

// 2. Add individual options
menu.AddOption("Option 1", () => Console.WriteLine("Executed Option 1"));

// 3. Add multiple options at once using a Dictionary
Dictionary<string, Action> extraOptions = new Dictionary<string, Action>
{
    { "Option 2", () => Console.WriteLine("Executed Option 2") },
    { "Option 3", () => DoSomethingElse() }
};
menu.AddMultipleOptions(extraOptions);

// 4. Display the menu, the user will select an option and the corresponding method will be invoked
menu.Show();
```

---

## 🔒 Built-in Validation

To guarantee a clean UI and unambiguous selections, `HiMenu` automatically enforces unique option labels. Attempting to add a duplicate key to the same menu level will trigger safety validation to prevent unintended behavior.

---

## 🎨 Customization

You can fully customize the look and feel of your menu components:

- Upon initialization choose a title for the menu.
- Change individual item foreground colors.
- Override the default selection cursor string (e.g., set to `>` or `Admin:`).
- Manage looping menus and return confirmation inputs.

---

## 📄 License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).