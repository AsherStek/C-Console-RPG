using System;

namespace Textworld {
    public class Oasis {
        public int Level;
        public int HealAmnt;
        public bool Used = false;
        public void CalcOasis(Player player) {
            Level = player.Level;
            HealAmnt = (int) Math.Round(10 + (Level * 3.75));
        }
        public void Heal(Player player) {
            if (Used == false) {
                player.CurrentHp += HealAmnt;
                if (player.CurrentHp > player.TotalHp) {
                    player.CurrentHp = player.TotalHp;
                }
                Used = true;
            }
        }
    }
}