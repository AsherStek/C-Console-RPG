using System;
using System.Collections.Generic;

namespace Textworld {
    class Game {
        static int WIDTH = 20;
        static int HEIGHT = 10;
        static bool Running = true;
        static List<char> Movement = new List<char>() {
            'D', // Right
            'd', // Right
            'A', // Left
            'a', // Left
            'W', // Up
            'w', // Up
            'S', // Down
            's' // Down
        };
        static List<char> Quit = new List<char>() {
            'Q', // Quit
            'q' // Quit
        };
        static List<char> Choices = new List<char>() {
            'Y', // Yes
            'y', // Yes
            'N', // No
            'n' // No
        };
        static List<char> Menus = new List<char>() {
            'M', // Main Menu
            'm', // Main Menu
            'I', // Ineventory
            'i', // Inventory
            'P', // Player Stats
            'p', // Player Stats
            'H', // Help
            'h' // Help
        };
        static List<char> Actions = new List<char>() {
            'C',
            'c'
        };

        static List<Rooms> Blank = new List<Rooms>();
        static World WR = new World(Blank, WIDTH, HEIGHT);
        static Player Play;
        static Battle Bat;
        static Menus Menu;

        static void PossibleCommands(Rooms rm) {
            Console.WriteLine("Choices: ");
            if (rm.HasMob) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("C: Fight Mob");
            }
            if (rm.HasDungeon) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("C: Challenge Dungeon");
            }
            if (rm.HasTown) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("C: Enter Town");
            }
            if (rm.HasOasis) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("C: Enter Oasis");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
        }
        static void Main(string[] args) {
            // Yes Comments, Deal with them
            // Initialize and place the player in the world
            Console.Write("Player Char: ");
            char name = (char) Console.Read();
            Play = new Player(name);
            Bat = new Battle();
            Menu = new Menus();
            Play.Place(WR.Map);
            WR.Display(WIDTH, HEIGHT);

            // Main Game loop
            while (Running) {
                char pause;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                PossibleCommands(WR.Map[Play.Index]);
                Console.Write("Enter Command: ");
                char cmd = (char) Console.Read();
                if (Movement.Contains(cmd)) {
                    Play.Move(cmd, WR);
                } else if (Quit.Contains(cmd)) {
                    bool qLoop = true;
                    while (qLoop) {
                        Console.Write("Quit?: ");
                        char choice = (char) Console.Read();
                        if (Choices.Contains(choice)) {
                            if (choice == Choices[0] || choice == Choices[1]) {
                                qLoop = false;
                                Running = false;
                                Console.WriteLine("Goodbye");
                            }
                        }
                    }
                } else if (Menus.Contains(cmd)) {
                    int id = 0;
                    if (cmd == Menus[0] || cmd == Menus[1]) {
                        id = 1;
                    } else if (cmd == Menus[2] || cmd == Menus[3]) {
                        id = 3;
                    } else if (cmd == Menus[4] || cmd == Menus[5]) {
                        id = 4;
                    } else if (cmd == Menus[6] || cmd == Menus[7]) {
                        id = 0;
                    }
                    Menu.Display(id);
                } else if (Actions.Contains(cmd)) {
                    string check = Play.Check(WR);
                    if (cmd == Actions[0] || cmd == Actions[1] && check != null) {
                        if (check == "mob") {
                            bool fight = true;
                            while (fight) {
                                string result = Bat.Fight(ref Play, WR.Map[Play.Index]);
                                if (result == "player") {
                                    fight = false;
                                    WR.Display(WIDTH, HEIGHT);
                                } else if (result == "mob") {
                                    fight = false;
                                    WR.Reset();
                                    Play.Reset();
                                }
                            }
                        } else if (check == "dungeon") {

                        } else if (check == "oasis") {
                            if (WR.Map[Play.Index].Oasis.Used == false) {
                                WR.Map[Play.Index].Oasis.CalcOasis(Play);
                                Console.WriteLine("------OAIS------");
                                Console.WriteLine($"Healed for {WR.Map[Play.Index].Oasis.HealAmnt}");
                                WR.Map[Play.Index].Oasis.Heal(Play);
                                pause = (char) Console.Read();
                                pause = (char) Console.Read();
                            } else {
                                Console.WriteLine("------OAIS------");
                                Console.WriteLine($"You've Already used this one up");
                                pause = (char) Console.Read();
                                pause = (char) Console.Read();
                            }
                        } else if (check == "town") {

                        }
                    }
                }
                WR.Update(Play);
                WR.Display(WIDTH, HEIGHT);
            }
        }
    }
}