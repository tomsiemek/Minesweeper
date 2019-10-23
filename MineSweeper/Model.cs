using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Model
    {
        public Board board;
        private Random random = new Random();
        public readonly int NumberOfBombs = 10;
        private int markedItems;
        public Model()
        {
            Init();
        }
        public void Init()
        {
            board = new Board();
            markedItems = 0;
            Lost = false;
            Won = false;
            boardInitiated = false;
        }
        private bool boardInitiated = false;
        public bool Lost {  get; private set; }
        public bool Won { get; private set; }
        public void HandleClick(int x, int y)
        {
            if(!boardInitiated)
            {
                Initiate(x,y);
                boardInitiated = true;
            }
            if(!board.board[x][y].isMarked)
            {
                if(board.board[x][y].isBomb)
                {
                    Lost = true;
                }
                else
                {
                    if(board.board[x][y].bombsAround == 0)
                    {
                        RevealRegions(x, y);
                    }
                }
                board.board[x][y].isRevealed = true;
                if (IsEverythingRevealed())
                {
                    Won = true;
                }
            }
        }
        private void RevealRegions(int x, int y)
        {
            if(MakesSenseToCheck(x,y) && !board.board[x][y].isRevealed)
            {
                board.board[x][y].isRevealed = true;
                if(board.board[x][y].bombsAround == 0)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if( i != 0 || j != 0)
                            {
                                RevealRegions(x + i, y + j);
                            }
                        }
                    }
                }

            }
        }

        private bool IsEverythingRevealed()
        {
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    if(!board.board[i][j].isRevealed && !board.board[i][j].isMarked)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int HandleMark(int x, int y)
        {
            if(board.board[x][y].isMarked)
            {
                board.board[x][y].isMarked = false;
                markedItems--;
            }
            else if(markedItems != NumberOfBombs && !board.board[x][y].isRevealed)
            {
                board.board[x][y].isMarked = true;
                markedItems++;
            }
            if (IsEverythingRevealed())
            {
                Won = true;
            }
            return markedItems;
        }

        private bool IsInVicinity(int x, int y, int x0, int y0)
        {
            if( Math.Abs(x-x0) <= 1 && Math.Abs(y - y0) <= 1)
            {
                return true;
            }
            return false;
        }

        private void PopulateBombs(int x, int y)
        {
            int width = board.Width; int height = board.Height;
            for (int i = 0; i < NumberOfBombs; i++)
            {
                int rX = random.Next(width);
                int rY = random.Next(height);
                while (IsInVicinity(rX, rY, x, y))
                {
                     rX = random.Next(width);
                     rY = random.Next(height);
                }
                board.board[rX][rY].isBomb = true;
            }
        }

        private bool MakesSenseToCheck(int x, int y)
        {
            if(x < 0 || y < 0 || x == board.Width || y == board.Height)
            {
                return false;
            }
            return true;
        }
        private int IsBomb(int x, int y)
        {
            if(MakesSenseToCheck(x,y))
            {
                if(board.board[x][y].isBomb)
                {
                    return 1;
                }
            }
            return 0;
        }

        private int CountBombs(int x, int y)
        {
            int sum = 0;
            sum += IsBomb(x - 1, y - 1);
            sum += IsBomb(x, y - 1);
            sum += IsBomb(x + 1, y - 1);
            sum += IsBomb(x + 1, y);
            sum += IsBomb(x + 1, y + 1);
            sum += IsBomb(x, y + 1);
            sum += IsBomb(x - 1, y + 1);
            sum += IsBomb(x - 1, y);
            return sum;
        }

        private void MarkFields()
        {
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if( !board.board[x][y].isBomb )
                    {
                        board.board[x][y].bombsAround = CountBombs(x, y);
                    }
                }
            }
        }
        private void Initiate(int x, int y)
        {
            PopulateBombs(x, y);
            MarkFields();
        }
    }
}
