using System;
using System.Collections.Generic;
using Alchemons.Controllers;
using Alchemons.Models;
using System.Threading;

namespace Alchemons.Views
{

    public interface ViewInterface
    {
        public const string valuta = "бублей";
        public const int ping = 2000;
        public void Inventar();
        public void SeeHarachters(Alchemon al);
        public void MagazMenu();
        public void NoMoney();
        public void AlchemonBorn(Alchemon alchemon);

        public void NoGibridIngridient();
        public void CreateGibrid1(List<Alchemon> list);
        public void CreateGibrid2(List<Alchemon> list);
        public void CreateGibrid3(Alchemon lAl, Alchemon rAl);
        public void CreateGibridEnd(Alchemon newAl);


        public void NoAlchemon();
        public void YourEnemi(Alchemon VRAG);
        public void ViberiAlchimona();

    }

    public class MyInterface : ViewInterface
    {
        public Player _player;
        static MyInterface instance;

        public static MyInterface GetInstance(Player player)
        {
            if(instance == null)
            {
                instance = new MyInterface(player);
            }
            return instance;
        }



        public static bool _seeMenu = false;

        private MyInterface(Player player)
        {
            _player = player;
        }

        public void Inventar()
        {
            if(_seeMenu)
            {
                Console.WriteLine($"\n\n\n");
            }

            Console.WriteLine("МОЁ МЕНЮ:\n1. Пойти в магаз\n\n");
            Exit();
            if(!_seeMenu)
            {
                _seeMenu = true;
            }



        }

        public void SeeHarachters(Alchemon alchemon)
        {
            Console.WriteLine($"\nHP - {alchemon._hp};\nDMG - {alchemon._dmg}\nAgility - {alchemon._agi}\n");
        }


        public void MagazMenu()
        {
            Console.WriteLine($"\n\n\nЗдарова, дорогой {_player.name}. Чего желаешь?\n\n1. Случайное животное. ({Magaz.AlchemonPrise} {ViewInterface.valuta})\n2.Создать алхимона. ({Magaz.GibridPrise} {ViewInterface.valuta})");
            Console.WriteLine();
            Console.WriteLine($"В кармане: {_player.groshni}");
            Exit();
        }


        public void NoMoney()
        {
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("НЕДОСТАТОЧНО СРЕДСТВ");
            Console.ForegroundColor = defColor;
        }

        public void AlchemonBorn(Alchemon alchemon)
        {
            Console.WriteLine("Ахмед достает странную коробку...");
            Thread.Sleep(ViewInterface.ping);
            Console.WriteLine("Вы слишите смесь хрюкания, пукания и щебетания...");
            Thread.Sleep(ViewInterface.ping);
            Console.WriteLine($"Но все звуки затихают. И остается только {alchemon._noise}...");
            Thread.Sleep(ViewInterface.ping);
            Console.Write("К тебе выходит ");
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(alchemon.AlName.ToUpper() + alchemon.Emoji);
            Console.ForegroundColor = defColor;
            Console.WriteLine($"!!! Поздравляю!\n\nХарактеристики:\nHP - {alchemon._hp};\nDMG - {alchemon._dmg}\nAgility - {alchemon._agi}\n");
            Console.WriteLine("Как назовешь?");
           
        }

        public void NoGibridIngridient()
        {
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("НЕДОСТАТОЧНО ЖИВОТНЫХ\n");
            Console.ForegroundColor = defColor;
        }


        public void CreateGibrid1(List<Alchemon> list)
        {
            Console.WriteLine("Выбери, с кем распрощаешься:\n");
            int i = 1;
            foreach(var bes in list)
            {
                Console.WriteLine($"{i}) {bes.Name}. {bes.AlName} {bes.Emoji}");
                i++;
            }
            Console.WriteLine("введите номер животного...");
        }
        public void CreateGibrid2(List<Alchemon> list)
        {
            Console.WriteLine("Теперь второй пациент:\n");
            int i = 1;
            foreach (var bes in list)
            {
                Console.WriteLine($"{i}) {bes.Name}. {bes.AlName} {bes.Emoji}");
                i++;
            }
            Console.WriteLine("введите номер животного...");
        }
        public void CreateGibrid3(Alchemon lAl, Alchemon rAl)
        {
            Console.WriteLine("Ахмет кивает и уносит ваших животных куда-то за прилавок...");
            Thread.Sleep(ViewInterface.ping);
            Console.WriteLine($"Вы слышите, как {lAl._noise} и {rAl._noise} смешиваются, пораждая новый звук...");
            Thread.Sleep(ViewInterface.ping);
            string[] kakoi = new string[] { "агрессивный", "низкий", "глубокий", "сумасшедший", "монструозный"};
            Random rnd = new Random();
            string takoi = kakoi[rnd.Next(kakoi.Length)];
            Console.WriteLine($"Более {takoi}... Как бы ты описал его одним словом?(крик, рык или свой вариант)");
        }

        public void CreateGibridEnd(Alchemon newAl)
        {
            Console.WriteLine($"Наконец из-за прилавка выходит твой новый алхемон...");
            Thread.Sleep(ViewInterface.ping);
            Console.Write("Поздравляю, у тебя ");
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{newAl.AlName.ToUpper()} { newAl.Emoji}");
            Console.ForegroundColor = defColor;
            Console.WriteLine("!!!");
            Console.WriteLine("Характеристики:");
            Console.WriteLine($"HP - {newAl._hp}\nDMG - {newAl._dmg}\nAgility - {newAl._agi}\n");
            Console.WriteLine("Как назовешь?");
            
        }



        public void NoAlchemon()
        {
            Console.WriteLine("У тебя нет алхемонов");
        }


        public void YourEnemi(Alchemon VRAG)
        {
            Console.WriteLine($"Из темноты ты слышишь {VRAG._noise}...");
            Thread.Sleep(ViewInterface.ping);
            Console.Write("Перед тобой ");
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{VRAG.AlName.ToUpper()}");
            Console.ForegroundColor = defColor;
            Console.WriteLine($"{VRAG.Emoji}!");

            Console.WriteLine("\nХарактеристики:\n");
            SeeHarachters(VRAG);
            Thread.Sleep(ViewInterface.ping);
        }

        public void ViberiAlchimona()
        {
            Console.WriteLine("\nКого против него выставишь ты?");
            Console.WriteLine();
            int i = 1;
            foreach(var a in _player._collectionTear2)
            {
                Console.WriteLine($"{i}. {a.Name} ({a.AlName} {a.Emoji})");
                i++;
            }
        }















        private void Exit()
        {
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("q. - вернуться\n");
            Console.ForegroundColor = defColor;
        }





        
    }
}
