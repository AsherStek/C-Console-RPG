using System;
using System.Collections.Generic;

namespace Textworld {
    public class Player {
        Random r = new Random();
        public char Name;
        public int Index;
        public int Level;
        public int TotalHp;
        public int CurrentHp;

        public int Strength;
        public int Defense;
        public int Xp;
        public int ToNext;
        public Player(Char n) {
            Name = n;
            Level = 1;
            Strength = (int) Math.Round(10 + (Level * 4.5));
            TotalHp = (int) Math.Round(20 + (Level * 5.5));
            CurrentHp = TotalHp;
            Defense = (int) Math.Round(5 + (Level * 1.3));
            Xp = 0;
            ToNext = 20;
        }
        public void Place(List<Rooms> map) {
            Index = r.Next(0, map.Count);
            map[Index].HasPlayer = true;
            map[Index].HasMob = false;
            map[Index].PlayerName = Name;
            map[Index].TypeInt = 0;
            map[Index].Update(this);
        }
        public string Check(World wr) {
            if (wr.Map[Index].HasMob) {
                return "mob";
            }
            if (wr.Map[Index].HasDungeon) {
                return "dungeon";
            }
            if (wr.Map[Index].HasOasis) {
                return "oasis";
            }
            if (wr.Map[Index].HasTown) {
                return "Town";
            }
            return null;
        }
        public void Move(char dir, World wr) {
            if (dir == 'D' || dir == 'd') {
                int temp = Index;
                Index += 1;
                try {
                    wr.Map[Index].HasPlayer = true;
                    wr.Map[temp].HasPlayer = false;
                }
                catch (System.ArgumentOutOfRangeException) {
                    Index -= 1;
                    wr.Map[Index].HasPlayer = true;
                }
            } else if (dir == 'A' || dir == 'a') {
                int temp = Index;
                Index -= 1;
                try {
                    wr.Map[Index].HasPlayer = true;
                    wr.Map[temp].HasPlayer = false;
                }
                catch (System.ArgumentOutOfRangeException) {
                    Index += 1;
                    wr.Map[Index].HasPlayer = true;
                }
            } else if (dir == 'W' || dir == 'w') {
                int temp = Index;
                Index -= wr.Width;
                try {
                    wr.Map[Index].HasPlayer = true;
                    wr.Map[temp].HasPlayer = false;
                }
                catch (System.ArgumentOutOfRangeException) {
                    Index += wr.Width;
                    wr.Map[Index].HasPlayer = true;
                }
            } else if (dir == 'S' || dir == 's') {
                int temp = Index;
                Index += wr.Width;
                try {
                    wr.Map[Index].HasPlayer = true;
                    wr.Map[temp].HasPlayer = false;
                }
                catch (System.ArgumentOutOfRangeException) {
                    Index -= wr.Width;
                    wr.Map[Index].HasPlayer = true;
                }
            }
        }
        public void LevelUp() {
            Level += 1;
            Strength = (int) Math.Round(10 + (Level * 4.5));
            TotalHp = (int) Math.Round(20 + (Level * 5.5));
            CurrentHp = TotalHp;
            Defense = (int) Math.Round(5 + (Level * 1.3));
            Xp = 0;
            ToNext = (int) Math.Round(20 + (Level * 15.5));
        }
        public void NAttack(Mob mb) {
            int dmg = r.Next(0, Strength) - mb.Defense;
            if (dmg < 0) {
                dmg = 0;
            }
            mb.Hp -= dmg;
        }
        public void MAttack(Mob mb) {
            int dmg = 0;
            float chance = 0.7f;
            int outOf = 100;
            if (r.Next(0, outOf) >= outOf * chance) {
                dmg = (int) r.Next(Strength, Strength + (Level * 5)) - mb.Defense;
            }
            if (dmg < 0) {
                dmg = 0;
            }
            mb.Hp -= dmg;
        }
        public void Reset() {
            Level = 0;
            LevelUp();
        }
    }
}