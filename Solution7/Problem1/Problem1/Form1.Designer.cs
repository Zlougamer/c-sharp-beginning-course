
namespace Problem1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCommand_1 = new System.Windows.Forms.Button();
            this.btnCommand_2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.totalCommandsTxt = new System.Windows.Forms.Label();
            this.totalCommandsNum = new System.Windows.Forms.Label();
            this.enterNumTxt = new System.Windows.Forms.Label();
            this.enterNum = new System.Windows.Forms.Label();
            this.gameOver = new System.Windows.Forms.Label();
            this.undoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommand_1
            // 
            this.btnCommand_1.Location = new System.Drawing.Point(186, 40);
            this.btnCommand_1.Name = "btnCommand_1";
            this.btnCommand_1.Size = new System.Drawing.Size(75, 23);
            this.btnCommand_1.TabIndex = 0;
            this.btnCommand_1.Text = "+1";
            this.btnCommand_1.UseVisualStyleBackColor = true;
            this.btnCommand_1.Click += new System.EventHandler(this.btnCommand_1_Click);
            // 
            // btnCommand_2
            // 
            this.btnCommand_2.Location = new System.Drawing.Point(186, 94);
            this.btnCommand_2.Name = "btnCommand_2";
            this.btnCommand_2.Size = new System.Drawing.Size(75, 23);
            this.btnCommand_2.TabIndex = 1;
            this.btnCommand_2.Text = "x2";
            this.btnCommand_2.UseVisualStyleBackColor = true;
            this.btnCommand_2.Click += new System.EventHandler(this.btnCommand_2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(186, 147);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(24, 59);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(38, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "label1";
            // 
            // totalCommandsTxt
            // 
            this.totalCommandsTxt.AutoSize = true;
            this.totalCommandsTxt.Location = new System.Drawing.Point(24, 157);
            this.totalCommandsTxt.Name = "totalCommandsTxt";
            this.totalCommandsTxt.Size = new System.Drawing.Size(90, 13);
            this.totalCommandsTxt.TabIndex = 4;
            this.totalCommandsTxt.Text = "Commands num";
            // 
            // totalCommandsNum
            // 
            this.totalCommandsNum.AutoSize = true;
            this.totalCommandsNum.Location = new System.Drawing.Point(120, 157);
            this.totalCommandsNum.Name = "totalCommandsNum";
            this.totalCommandsNum.Size = new System.Drawing.Size(112, 13);
            this.totalCommandsNum.TabIndex = 5;
            this.totalCommandsNum.Text = "totalCommandsNum";
            // 
            // enterNumTxt
            // 
            this.enterNumTxt.AutoSize = true;
            this.enterNumTxt.Location = new System.Drawing.Point(27, 22);
            this.enterNumTxt.Name = "enterNumTxt";
            this.enterNumTxt.Size = new System.Drawing.Size(80, 13);
            this.enterNumTxt.TabIndex = 7;
            this.enterNumTxt.Text = "Enter number:";
            // 
            // enterNum
            // 
            this.enterNum.AutoSize = true;
            this.enterNum.Location = new System.Drawing.Point(114, 22);
            this.enterNum.Name = "enterNum";
            this.enterNum.Size = new System.Drawing.Size(38, 13);
            this.enterNum.TabIndex = 8;
            this.enterNum.Text = "label1";
            // 
            // gameOver
            // 
            this.gameOver.AutoSize = true;
            this.gameOver.Location = new System.Drawing.Point(27, 190);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(0, 13);
            this.gameOver.TabIndex = 9;
            // 
            // undoBtn
            // 
            this.undoBtn.Location = new System.Drawing.Point(186, 190);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 23);
            this.undoBtn.TabIndex = 10;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 248);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.gameOver);
            this.Controls.Add(this.enterNum);
            this.Controls.Add(this.enterNumTxt);
            this.Controls.Add(this.totalCommandsNum);
            this.Controls.Add(this.totalCommandsTxt);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand_2);
            this.Controls.Add(this.btnCommand_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand_1;
        private System.Windows.Forms.Button btnCommand_2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label totalCommandsTxt;
        private System.Windows.Forms.Label totalCommandsNum;
        private System.Windows.Forms.Label enterNumTxt;
        private System.Windows.Forms.Label enterNum;
        private System.Windows.Forms.Label gameOver;
        private System.Windows.Forms.Button undoBtn;
    }
}

