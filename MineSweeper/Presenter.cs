using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Presenter
    {
        Model model;
        IView view;
        public Presenter(Model m, IView v)
        {
            model = m;
            view = v;          
            v.FieldSelected += FieldSelection;
            v.ResetGame += ResetGame;
            InitBoard();
        }
        private void InitBoard()
        {
            model.Init();
            view.GameBoard = model.board;
            view.Bombs = model.NumberOfBombs;
            view.CreateBoard();
        }

        private void FieldSelection(int x, int y, bool marking)
        {
            if(marking)
            {
                view.MarkedFields = model.HandleMark(x, y);
            }
            else
            {
                model.HandleClick(x, y);
            }
            view.ShowBoard();
            if(model.Won)
            {
                view.ShowWin();
            }
            if(model.Lost)
            {
                view.ShowLose();
            }

        }
        private void ResetGame()
        {
            InitBoard();
        }

    }
}
