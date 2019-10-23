using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    
    public partial class MainForm : Form, IView
    {
        public Board GameBoard { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        public event Action<int, int, bool> FieldSelected;
        public event Action ResetGame;
        public int Bombs { get; set; }
        public int MarkedFields { get; set; }


        private void SetUpBoard()
        {
            boardPanel.Controls.Clear();
            boardPanel.RowStyles.Clear();
            boardPanel.ColumnStyles.Clear();

            boardPanel.RowCount = GameBoard.Width;
            boardPanel.ColumnCount = GameBoard.Height;

            for (int i = 0; i < GameBoard.Width; i++)
            {
                boardPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }
            for (int j = 0; j < GameBoard.Height; j++)
            {
                boardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            }
        }
        public void ShowBoard()
        {
            labelMarked.Text = $"Marked: {MarkedFields} / {Bombs}";
            for (int x = 0; x < GameBoard.Width; x++)
            {
                for (int y = 0; y < GameBoard.Height; y++)
                {
                    var button = (Button)boardPanel.GetControlFromPosition(y, x);
                    SetButton(button, GameBoard.board[x][y]);
                }
            }
        }
        private void MakeButtonsInactive()
        {
            for (int x = 0; x < GameBoard.Width; x++)
            {
                for (int y = 0; y < GameBoard.Height; y++)
                {
                    var button = (Button)boardPanel.GetControlFromPosition(y, x);
                    button.Enabled = false;
                }
            }
        }
        public void ShowLose()
        {
            MessageBox.Show("You lost!");
            buttonFace.Text = "😒";
            MakeButtonsInactive();
        }
        public void ShowWin()
        {
            MessageBox.Show("You won!");
            buttonFace.Text = "😎";
            MakeButtonsInactive();
        }
    
        private void SetButton(Button button, Field f)
        {
            button.Text = "";
            if(!f.isRevealed)
            {
                MakeUnreavealedButton(button);
                if (f.isMarked)
                {
                    MakeMarkedButton(button);
                }

            }
            else
            {
                if( f.isBomb )
                {
                    MakeBombButton(button);
                }
                else
                {
                    MakeNumberTileButton(button, f.bombsAround);
                }
                
            }
        }
        private void MakeNumberTileButton(Button btn, int number)
        {
            btn.BackColor = Color.White;
            if(number != 0)
            {
                btn.Text = number.ToString();                
            }
        }
        private void MakeBombButton(Button btn)
        {
            btn.BackColor = Color.Red;
        }
        private void MakeUnreavealedButton(Button btn)
        {
            btn.BackColor = Color.LightGray;
        }
        private void MakeMarkedButton(Button btn)
        {
            btn.BackColor = Color.Blue;
        }

        private void buttonFieldClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            Point location = (Point)button.Tag;
            int x = location.X; int y = location.Y;
            if (e.Button == MouseButtons.Left)
            {
                FieldSelected?.Invoke(x, y, false);
            }
            else if (e.Button == MouseButtons.Right)
            {
                FieldSelected?.Invoke(x, y, true);
            }
        }
        public void CreateBoard()
        {
            SetUpBoard();
            buttonFace.Text = "😊";
            MarkedFields = 0;
            labelMarked.Text = $"Marked: {MarkedFields} / {Bombs}";
            for (int i = 0; i < GameBoard.Width; i++)
            {
                for (int j = 0; j < GameBoard.Height; j++)
                {
                    var button = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = Padding.Empty,
                        Tag = new Point(i, j),
                        //BackgroundImageLayout = ImageLayout.Stretch
                    };
                    MakeUnreavealedButton(button);
                    button.MouseDown += buttonFieldClick;
                    boardPanel.Controls.Add(button, j, i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame?.Invoke();
        }
    }
}
