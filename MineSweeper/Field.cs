using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Field
    {
        public bool isBomb = false;
        public bool isRevealed = false;
        public bool isMarked = false;
        public int bombsAround = 0;
    }
}
