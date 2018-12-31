using System;
using System.Collections.Generic;

namespace Textworld {
    public class Dungeon {
        Random r = new Random();
        Names n = new Names();
        public List<Mob> Inhabitants = new List<Mob>();
        public Dungeon(int size, int[] levels) {
            for (int i = 0; i < size; i++) {
                Inhabitants.Add(new Mob(n.PickName(), n.PickType()));
            }
        }
    }
}