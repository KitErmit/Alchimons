using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Alchemons.Models
{
    public static class AlPedia
    {
        public static List<Alchemon> _all = new List<Alchemon>();
        public static string Path = "/Users/kitaermit/Projects/Alchemons/Alchemons/Models/Bestiariy.txt";

        public static async Task Load()
        {
            List<string> bestiari = new List<string>();
            string? text;
            using(StreamReader reader = new StreamReader(Path))
            {

                while ((text = await reader.ReadLineAsync()) != null)
                {
                    if (text.StartsWith("АлИмя")) continue;
                    bestiari.Add(text);
                }
                
                foreach(string bes in bestiari)
                {
                    string[] position = bes.Split(',');
                    string alname = position[0];
                    string em = position[1];
                    int hp = Convert.ToInt32(position[2]);
                    int dm = Convert.ToInt32(position[3]);
                    int agi = Convert.ToInt32(position[4]);
                    string noise = position[5];

                    _all.Add(new Alchemon(alname, em, hp, dm, agi, noise));

                }
                int i = 1;


#if DEBUG
                Console.WriteLine("Загрузка закончена:");
                foreach (var it in _all)
                {
                    Console.WriteLine($"{i}) {it.AlName}, {it.Emoji}, {it._hp}, {it._dmg}, {it._agi};");
                    i++;
                }
#endif
            }
        }


        public static Alchemon CreateGibrid(Alchemon leftAl, Alchemon rightAl)
        {
            string alName;
            if ((leftAl.AlName == "паук" || leftAl.AlName == "свин") && (rightAl.AlName == "паук" || rightAl.AlName == "свин"))
                alName = "свин-паук";

            else alName = leftAl.AlName + "о" + rightAl.AlName;
            string emoji = leftAl.Emoji + rightAl.Emoji;
            int hp = leftAl._hp + rightAl._hp;
            int dmg = leftAl._dmg + rightAl._dmg;
            int agi = leftAl._agi + rightAl._agi;
            string noise = leftAl._noise + " и " + rightAl._noise;
            Alchemon newAl = new Alchemon(alName, emoji, hp, dmg, agi, noise);
            newAl._tear++;
            return newAl;
        }

        
    }
}
