using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    interface IView
    {
        void CreateBoard();
        void ShowBoard();
        void ShowLose();
        void ShowWin();
        int Bombs { get; set; }
        int MarkedFields { get; set; }
        Board GameBoard { get; set; }
        event Action<int, int, bool> FieldSelected;
        event Action ResetGame;

    }
}
