using System;

using Alchemons.Views;
using Alchemons.Models;
namespace Alchemons.Controllers
{

    public interface Boevka
    {
        public void Fight(Alchemon yourAl, Alchemon enami);
    }

    public class Oktagon 
    {

        Player _player;
        ViewInterface _view;
        InputInterface _input;

        public void Start(Player player, ViewInterface view, InputInterface input)
        {
            _player = player;
            _view = view;
            _input = input;
            if (player._collectionTear2.Count < 1)
            {
                _view.NoAlchemon();
            }
            else
            {
                
                Alchemon VRAG = CreateEname();
                _view.YourEnemi(VRAG);
                Alchemon yourAl = ViberiSvoego();
                Fight(yourAl, VRAG);
            }
            
        }

        public void Fight(Alchemon your, Alchemon vrag)
        {

        }


        private Alchemon CreateEname()
        {
            Random rnd = new Random();
            Alchemon predlAl = AlPedia._all[rnd.Next(AlPedia._all.Count)];
            AlPedia._all.Remove(predlAl);
            Alchemon lAl = (Alchemon)predlAl.Clone();
            Alchemon rAl = AlPedia._all[rnd.Next(AlPedia._all.Count)];
            AlPedia._all.Add(predlAl);
            Alchemon pidor = AlPedia.CreateGibrid(lAl, rAl);
            return pidor;
        }

        private Alchemon ViberiSvoego()
        {
            _view.ViberiAlchimona();
            int num = Convert.ToInt32(_input.StringInput()) - 1;
            return _player._collectionTear2[num];

        }
    }
}
