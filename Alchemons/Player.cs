using System;
using System.Collections.Generic;
using Alchemons.Models;
namespace Alchemons
{
    public class Player
    {
        public string name { get; set; }
        public List<Alchemon> _collectionTear1 = new List<Alchemon>();
        public List<Alchemon> _collectionTear2 = new List<Alchemon>();
        public int groshni { get; set; }
        public Player()
        {
        }
    }
}
