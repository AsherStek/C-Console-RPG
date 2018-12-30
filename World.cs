using System;
using System.Collections.Generic;

namespace Textworld {
    public class World {
        public List<Rooms> Map = new List<Rooms>();
        public int Width;
        public int Height;
        public World(List<Rooms> map, int w, int h) {
            Map = map;
            Width = w;
            Height = h;
            Generate(Width, Height);
        }
        public void Generate(int width, int height) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Map.Add(new Rooms());
                    //Console.WriteLine($"Map[{x}, {y}]: {Map[x + y]}");
                }
            }
        }
        public void Display(int width, int height) {
            Console.Clear();
            for (int y = 0; y < height; y++) {
                //Console.Write($"Row[{y}]: ");
                for (int x = 0; x < width; x++) {
                    if (Map[x + (width * y)].HasPlayer == true) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Map[x + (width * y)].PlayerName);
                    } else if (Map[x + (width * y)].TypeChar == 'O') {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(Map[x + (width * y)].TypeChar);
                    } else if (Map[x + (width * y)].TypeChar == 'T') {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Map[x + (width * y)].TypeChar);
                    } else if (Map[x + (width * y)].TypeChar == 'D') {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Map[x + (width * y)].TypeChar);
                    } else if (Map[x + (width * y)].TypeInt == 1) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Map[x + (width * y)].TypeInt);
                    } else if (Map[x + (width * y)].TypeInt == 2) {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Map[x + (width * y)].TypeInt);
                    }  else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Map[x + (width * y)].TypeInt);
                    }
                }
                Console.WriteLine(" ");
            }
        }
        public void Update(Player player) {
            foreach (Rooms room in Map) {
                room.Update(player);
            }
        }
        public void Reset() {
            for (int i = 0; i < Map.Count; i++) {
                Map.RemoveAt(i);
            }
            Generate(Width,Height);
        }
    }
}