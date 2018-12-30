using System;

namespace Textworld {
    public class Oasis {
        public int Level;
        public int HealAmnt;
        public void CalcOasis(Player player) {
            Level = player.Level;
            HealAmnt = (int) Math.Round(10 + (Level * 3.75));
        }
        public void Heal(Player player) {
            player.CurrentHp += HealAmnt;
            if (player.CurrentHp > player.TotalHp) {
                player.CurrentHp = player.TotalHp;
            }
        }
    }
}