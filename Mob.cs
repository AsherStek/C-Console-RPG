using System;

namespace Textworld {
    public class Mob {
        Random r = new Random();
        public int Level;
        public string Name;
        public string Type;
        public int Strength;
        public int Hp;
        public int Defense;
        public int XpReward;
        public Mob(string name, string type) {
            Name = name;
            Type = type;
        }
        public void SetLevel(int level) {
            Strength = (int) Math.Round(10 + (Level * 4.5));
            Hp = (int) Math.Round(20 + (Level * 5.5));
            Defense = (int) Math.Round(5 + (Level * 1.3));
            XpReward = (int) Math.Round(20 + (Level * 10.5));
        }
        public void NAttack(ref Player player) {
            int dmg = r.Next(0, Strength) - player.Defense;
            if (dmg < 0) {
                dmg = 0;
            }
            player.CurrentHp -= dmg;
        }
        public void MAttack(ref Player player) {
            int dmg = 0;
            float chance = 0.7f;
            int outOf = 100;
            if (r.Next(0, outOf) >= outOf * chance) {
                dmg = (int) r.Next(Strength, Strength + (Level * 5)) - player.Defense;
            }
            if (dmg < 0) {
                dmg = 0;
            }
            player.CurrentHp -= dmg;
        }
        public void MakeChoice(ref Player player) {
            int choice = r.Next(0, 1);
            if (choice == 0) {
                NAttack(ref player);
            } else if (choice == 1) {
                MAttack(ref player);
            }
        }
    }
}