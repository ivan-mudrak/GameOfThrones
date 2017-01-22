namespace game
{
    partial class GameOfThrones
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.BattleField = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(414, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(97, 32);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_OnClick);
            // 
            // BattleField
            // 
            this.BattleField.BackColor = System.Drawing.Color.White;
            this.BattleField.Location = new System.Drawing.Point(12, 12);
            this.BattleField.Name = "BattleField";
            this.BattleField.Size = new System.Drawing.Size(396, 338);
            this.BattleField.TabIndex = 1;
            // 
            // GameOfThrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 362);
            this.Controls.Add(this.BattleField);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameOfThrones";
            this.Text = "GameOfThrones";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel BattleField;
    }
}

