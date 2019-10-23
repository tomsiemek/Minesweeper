namespace MineSweeper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFace = new System.Windows.Forms.Button();
            this.labelMarked = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.boardPanel.ColumnCount = 2;
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.boardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.boardPanel.Location = new System.Drawing.Point(19, 80);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.RowCount = 2;
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.boardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.boardPanel.Size = new System.Drawing.Size(400, 400);
            this.boardPanel.TabIndex = 0;
            // 
            // buttonFace
            // 
            this.buttonFace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonFace.Font = new System.Drawing.Font("Arial Narrow", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFace.Location = new System.Drawing.Point(189, 8);
            this.buttonFace.Name = "buttonFace";
            this.buttonFace.Size = new System.Drawing.Size(60, 60);
            this.buttonFace.TabIndex = 1;
            this.buttonFace.Text = "😊";
            this.buttonFace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonFace.UseVisualStyleBackColor = true;
            this.buttonFace.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMarked
            // 
            this.labelMarked.AutoSize = true;
            this.labelMarked.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarked.Location = new System.Drawing.Point(23, 19);
            this.labelMarked.Name = "labelMarked";
            this.labelMarked.Size = new System.Drawing.Size(85, 58);
            this.labelMarked.TabIndex = 2;
            this.labelMarked.Text = "Marked:\r\n 0 / 10";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 492);
            this.Controls.Add(this.labelMarked);
            this.Controls.Add(this.buttonFace);
            this.Controls.Add(this.boardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel boardPanel;
        private System.Windows.Forms.Button buttonFace;
        private System.Windows.Forms.Label labelMarked;
    }
}

