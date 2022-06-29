using System;
using Alchemons.Views;
using Alchemons.Services;
using System.Collections.Generic;
using Alchemons.Models;


namespace Alchemons.Controllers
{
    public class PlayerController
    {
        public Player _player;
        public Magaz _magaz;
        public InputInterface _input;
        private IViewService _view;

        public PlayerController(Player player, IViewService view, Magaz magaz, InputInterface input)
        {
            _player = player;
            this._view = view;
            _magaz = magaz;
            _input = input;
        }

        public void Start()
        {
            _player.name = "Емеля";
            _player.groshni = 1_000_000_000;
            TestMenu();
        }

        public void TestMenu()
        {
            char inp = ' ';
            while(inp != 'q')
            {
                _view.MassageLoader("Player@Test");
                inp = _input.MenuInput();
                switch(inp)
                {
                    case '1':
                        _magaz.MagazMenu(_player);
                        break;
                }
            }
            

        }

        public void Test()
        {
            Console.WriteLine("Проверка");
            string inp = _input.StringInput();
            Console.WriteLine("Tesr");
        }





        

    }
}
