using System;
using System.Collections.Generic;

namespace Textworld {
    public class Battle {

        public List<char> Commands = new List<char>() {
            'N', // Normal
            'n', // Normal
            'M', // Major
            'm', // Major
            'S', // Skill
            's', // Skill
            'R', // Run
            'r' // Run
        };
        public char Press;
        public string Fight(ref Player player, Rooms rm) {
            Console.Clear();
            Console.WriteLine($"-------BATTLE-------");
            Console.WriteLine($"Enemy:");
            Console.WriteLine($"{rm.Monster.Name} the {rm.Monster.Type}");
            Console.WriteLine($"HP: {rm.Monster.Hp}");
            Console.WriteLine($"--------------------");
            Console.WriteLine($"Player:");
            Console.WriteLine($"{player.Name} the Hero");
            Console.WriteLine($"HP: {player.TotalHp}");
            Console.WriteLine($"------COMMANDS------");
            Console.WriteLine($"N. Attack: {Commands[0]}/{Commands[1]}");
            Console.WriteLine($"M. Attack: {Commands[2]}/{Commands[3]}");
            Console.WriteLine($"Skill:     {Commands[4]}/{Commands[5]}");
            Console.WriteLine($"Run:       {Commands[6]}/{Commands[7]}");
            Console.WriteLine($"");
            Console.Write($"Enter Choice: ");
            char choice = (char) Console.Read();
            choice = (char) Console.Read();
            if (Commands.Contains(choice)) {
                if (choice == Commands[0] || choice == Commands[1]) {
                    player.NAttack(rm.Monster);
                    rm.Monster.MakeChoice(ref player);
                } else if (choice == Commands[2] || choice == Commands[3]) {
                    player.MAttack(rm.Monster);
                    rm.Monster.MakeChoice(ref player);
                } else if (choice == Commands[4] || choice == Commands[5]) {

                } else if (choice == Commands[6] || choice == Commands[7]) {

                }
            }
            if (player.CurrentHp <= 0) {
                Console.Clear();
                Console.WriteLine($"-------DEFEAT-------");
                Console.WriteLine($"Press to restart game");
                char press = (char) Console.Read();
                press = (char) Console.Read();
                if (press != ' ') {
                    return "mob";
                }
            } else if (rm.Monster.Hp <= 0) {
                bool leveled = false;
                player.Xp += rm.Monster.XpReward;
                if (player.Xp >= player.ToNext) {
                    int temp = player.Xp - player.ToNext;
                    player.LevelUp();
                    player.Xp += temp;
                    leveled = true;
                }
                Console.Clear();
                Console.WriteLine($"-------Victory-------");
                if (leveled) {
                    Console.WriteLine($"Leveled Up!");
                }
                Console.WriteLine($"Xp: {player.Xp}/100");
                if (leveled) {
                    Console.WriteLine($"Strength: {player.Strength}");
                    Console.WriteLine($"Defense: {player.Defense}");
                    Console.WriteLine($"Total HP: {player.TotalHp}");
                }
                Press = (char) Console.Read();
                Press = (char) Console.Read();
                if (Press != ' ') {
                    rm.HasMob = false;
                    rm.TypeInt = 0;
                    return "player";
                } 
            }
            return "null";
        }
    }
}