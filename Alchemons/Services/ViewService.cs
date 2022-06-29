using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Threading;

using Alchemons.Models;
using Alchemons.Controllers;

namespace Alchemons.Services
{

    // cделать чтобы он из текста понимал, какую часть текста окрашивать ИИИ задержку ИИИ показывать, что показывать (типа тут будет алнейм) иииии создавать рандомайзер
    public interface IViewService
    {
        public const string valuta = "бублей";
        public const int ping = 2000;
        public void MassageLoader(string Path);
        public void MassegeWithObjLoader(string Path, object Vidimi);
    }


    /*
     * #PlayerName#
     * #PlayerGroshi#
     * #AlchemonPrise#
     * #Valyta#
     * #GibridPrise#
     * 
     */


    public class ConsoleViewer : IViewService
    {
        public const string alchimonV = "alchimonus";
        public const string alListV = "alList";


        public const string valuta = "бублей";

        public const int ping = 2000;
        private ConsoleColor _defTextColor = ConsoleColor.Yellow;
        private const string _otdelitel = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  ";

        readonly string _path = "/Users/kitaermit/Projects/Alchemons/Alchemons/Views/Text/"; 
        private Player _player;


        public ConsoleViewer(Player player)
        {
            _player = player;
        }


        public void MassageLoader(string Path)
        {
            List<string> stroki = new List<string>();
            string? text;

            string[] subjectName = Path.Split('@');
            string thisPath = _path + subjectName[0] + ".txt";
            using (StreamReader reader = new StreamReader(thisPath))
            {
                while ((text = reader.ReadLine()) != null)
                {
                    if(text.StartsWith(subjectName[1]))
                    {
                        while(!(text = reader.ReadLine()).StartsWith("}"))
                        {
                            stroki.Add(text);
                        }
                        break;
                    }
                }
            }

            if (stroki.Count < 1) Console.WriteLine("Не могу найти текст по пути " + thisPath + " " + subjectName[1]);


            OnlyStringWriter(stroki);

        }

        public void OnlyStringWriter(List<string> lines)
        {
            string bufer;
            Console.ForegroundColor = _defTextColor;

            Console.WriteLine(_otdelitel);
            foreach (string line in lines)
            {
                if (line == "ping") { Thread.Sleep(ping); continue; }
                else if(line.Contains("</") || line.Contains(">/"))
                {
                    ColorWriter(line);
                    continue;
                }
                bufer = line;
                bufer = bufer.Replace("#PlayerName#", $"{_player.name}");
                bufer = bufer.Replace("#PlayerGroshi#", $"{_player.groshni}");
                bufer = bufer.Replace("#AlchemonPrise#", $"{Magaz.AlchemonPrise}");
                bufer = bufer.Replace("#GibridPrise#", $"{Magaz.GibridPrise}");
                bufer = bufer.Replace("#Valyta#", $"{valuta}");
                Console.WriteLine(bufer);
            }
            Console.WriteLine(_otdelitel);

        }

        public void ColorWriter(string line)
        {
            string[] words = line.Split(" ");
            foreach(string word in words)
            {
                if(word.StartsWith("</"))
                {
                    switch(word)
                    {
                        case "</red":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "</green":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "</blue":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                    }
                    continue;
                }
                else if(word == ">/")
                {
                    Console.ForegroundColor = _defTextColor;
                    continue;
                }
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }



        public void MassegeWithObjLoader(string Path, object Vidimi)
        {
            List<string> stroki = new List<string>();
            string? text;

            string[] subjectName = Path.Split('@');
            string thisPath = _path + subjectName[0] + ".txt";
            using (StreamReader reader = new StreamReader(thisPath))
            {
                while ((text = reader.ReadLine()) != null)
                {
                    if (text.StartsWith(subjectName[1]))
                    {
                        while (!(text = reader.ReadLine()).StartsWith("}"))
                        {
                            stroki.Add(text);
                        }
                        break;
                    }
                }
            }

            
            switch (subjectName[2])
            {
                case alchimonV:
                    //stroki = 
                    break;
            }
            if (stroki.Count < 1) Console.WriteLine("Не могу найти текст по пути " + thisPath + " " + subjectName[1]);


            OnlyStringWriter(stroki);

        }

/*
        public List<string> HaveAlchimon(List<string> lines, Alchemon alchemon)
        {
            List<string> newLines = new List<string>();
            string bufer;
            foreach(string line in lines)
            {
                bufer = line;
                bufer = bufer.Replace("#PlayerName#", $"{_player.name}");

            }
        }
*/
    }
}
