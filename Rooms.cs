using System;
using System.Collections.Generic;

namespace Textworld {
    public class Rooms {
        Names n = new Names();
        public int TypeInt;
        public char TypeChar;
        public bool HasPlayer = false;
        public Nullable<char> PlayerName;
        public bool HasMob = false;
        public Mob Monster;
        public Dungeon Dungeon;
        public int[] DungeonLevels = {1, 5};
        public bool HasDungeon = false;
        public Oasis Oasis;
        public bool HasOasis = false;
        public Town Town;
        public bool HasTown = false;
        public Rooms() {
            int scale = 500;
            int maxWeight = scale/2;
            Random r = new Random();
            TypeInt = (int) Math.Round(r.Next(0, scale) * 0.01);
            int weight = (int) Math.Round(r.Next(0, maxWeight) * 0.01);
            TypeInt -= weight;
            if (TypeInt < 0) {
                TypeInt = 0;
            }
            if (TypeInt == 1) {
                Monster = new Mob(n.PickName(), n.PickType());
                HasMob = true;
            }
            if (TypeInt == 2) {
                Monster = new Mob(n.PickName(), n.PickType());
                HasMob = true;
            }
            if (TypeInt == 3) {
                Oasis = new Oasis();
                TypeChar = 'O';
                HasOasis = true;
            }
            if (TypeInt == 4) {
                Town = new Town();
                TypeChar = 'T';
                HasTown = true;
            }
            if (TypeInt == 5) {
                Dungeon = new Dungeon(r.Next(0, 5), DungeonLevels);
                TypeChar = 'D';
                HasDungeon = true;
            }
        }
        public void Update(Player player) {
            if (HasPlayer == true) {
                 PlayerName = player.Name;
            } else {
                PlayerName = null;
            }
        }
    }
}