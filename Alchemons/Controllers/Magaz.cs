using System;
using Alchemons.Views;
using Alchemons.Models;
using System.Collections.Generic;
using System.Linq;
using Alchemons.Services;

namespace Alchemons.Controllers
{
    public class Magaz
    {

        public const int AlchemonPrise = 100;
        public const int GibridPrise = 300;
        public const string path = "Magaz@";


        private ViewInterface _view;
        private IViewService _view2;
        private InputInterface _input;
        private static Magaz inst;
        private Magaz(ViewInterface view, InputInterface input, IViewService view2)
        {
            _view = view;
            _input = input;
            _view2 = view2;
        }
        public static Magaz GetInst(ViewInterface view, InputInterface input, IViewService view2)
        {
            if(inst == null)
            {
                inst = new Magaz(view, input, view2);
            }
            return inst;
        }


        public void MagazMenu(Player player)
        {
            char v = ' ';
            while (v != 'q')
            {
                _view2.MassageLoader(path + "MagazMenu");
                v = _input.MenuInput();

                switch (v)
                {
                    case '1':
                        BuyRandom(player);
                        break;
                    case '2':
                        Gibrid(player);
                        break;
                }
            }
        }

        public void BuyRandom(Player player)
        {
            if(player.groshni - AlchemonPrise <0)
                _view.NoMoney();

            else
            {
                player.groshni -= AlchemonPrise;
                Random rnd = new Random();
                int num = rnd.Next(AlPedia._all.Count);
                Alchemon nuwAl = (Alchemon)AlPedia._all[num].Clone();
                _view.AlchemonBorn(nuwAl);
                string name = _input.StringInput();
                nuwAl.Name = name;
                player._collectionTear1.Add(nuwAl);

            }
        }

        public void Gibrid(Player player)
        {
            if (player.groshni - GibridPrise < 0) _view.NoMoney();
            else if (player._collectionTear1.Count < 2) _view.NoGibridIngridient();
            else
            {
                
                player.groshni -= GibridPrise;

                List<Alchemon> gibridable = player._collectionTear1;

                _view.CreateGibrid1(gibridable);
                int leftNum = Convert.ToInt32(_input.StringInput()) - 1;
                Alchemon leftAl = gibridable[leftNum];
                player._collectionTear1.Remove(leftAl);

                List<Alchemon> gibridble2 = gibridable.Where(a => a.AlName != leftAl.AlName).ToList();

                _view.CreateGibrid2(gibridble2);
                int rightNum = Convert.ToInt32(_input.StringInput()) - 1;
                Alchemon rightAl = gibridble2[rightNum];
                player._collectionTear1.Remove(rightAl);
                Alchemon newAl = AlPedia.CreateGibrid(leftAl, rightAl);
                _view.CreateGibrid3(leftAl, rightAl);
                string noise = _input.StringInput();
                _view.CreateGibridEnd(newAl);
                string name = _input.StringInput();
                newAl._noise = noise;
                newAl.Name = name;
                player._collectionTear1.Add(newAl);
            }
        }

    }
}
