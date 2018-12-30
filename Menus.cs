using System;
using System.Collections.Generic;

namespace Textworld {
    public class Menus {
        public List<char> Commands = new List<char>() {
            'C',
            'c',
            'L',
            'l',
            'S',
            's',
            'Q',
            'q'
        };
        public void Display(int id) {
            bool InMenu = true;
            if (id == 0) {
                while (InMenu) {
                    Console.WriteLine("---------HELP---------");
                    Console.WriteLine("Movement:     W/A/S/D");
                    Console.WriteLine("Check Space:  C");
                    Console.WriteLine("Main Menu:    M");
                    Console.WriteLine("Inventory:    I");
                    Console.WriteLine("Player Stats: S");
                    Console.WriteLine("Quit:         Q");
                    Console.WriteLine("Help:         H");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return");
                    char press = (char) Console.Read();
                    press = (char) Console.Read();
                    if (press != ' ') {
                        InMenu = false;
                    }
                }
            } else if (id == 1) {
                while (InMenu) {
                    Console.WriteLine("---------MAIN---------");
                    Console.WriteLine("Continue:     C");
                    Console.WriteLine("Load:         L");
                    Console.WriteLine("Save:         S");
                    Console.WriteLine("Quit:         Q");
                    Console.WriteLine();
                    Console.Write("Enter Command: ");
                    char press = (char) Console.Read();
                    press = (char) Console.Read();
                    if (Commands.Contains(press)) {
                        if (press == Commands[0] || press == Commands[1]) {
                            InMenu = false;
                        } else if (press == Commands[2] || press == Commands[3]) {
                            InMenu = false;
                        } else if (press == Commands[4] || press == Commands[5]) {
                            InMenu = false;
                        } else if (press == Commands[6] || press == Commands[7]) {
                            InMenu = false;
                        }
                    }
                }
            }
        }
    }
}