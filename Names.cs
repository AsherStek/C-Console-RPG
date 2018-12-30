using System;
using System.Collections.Generic;

namespace Textworld {
    public class Names {
        Random r = new Random();
        public List<string> NAMES = new List<string>() {
            "Jeff",
            "Tom",
            "Galzuldor",
            "Sebas",
            "Kraka",
            "Gobbs",
            "Izzle"
        };
        public List<string> TYPES = new List<string>() {
            "Goblin",
            "Slime",
            "Wolf",
            "Boar",
            "Orc",
        };
        public string PickName() {
            string nm = NAMES[r.Next(0, NAMES.Count)];
            return nm;
        }
        public string PickType() {
            string tp = TYPES[r.Next(0, TYPES.Count)];
            return tp;
        }
    }
}