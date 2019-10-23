using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Board
    {
        public Field[][] board;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Board(int x = 9, int y = 9)
        {
            board = new Field[x][];
            Height = y;
            Width = x;
            for (int i = 0; i < Width; i++)
            {
                board[i] = new Field[y];             
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    board[i][j] = new Field();
                }
            }
        }

    }
}
