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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.BattleFieldView = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelTargaryens = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelBaratheons = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelStarks = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLannisters = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(453, 378);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(97, 32);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_OnClick);
            // 
            // BattleFieldView
            // 
            this.BattleFieldView.BackColor = System.Drawing.Color.White;
            this.BattleFieldView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BattleFieldView.Location = new System.Drawing.Point(12, 12);
            this.BattleFieldView.Name = "BattleFieldView";
            this.BattleFieldView.Size = new System.Drawing.Size(400, 400);
            this.BattleFieldView.TabIndex = 1;
            this.BattleFieldView.Paint += new System.Windows.Forms.PaintEventHandler(this.battleFieldView_OnPaint);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_OnTick);
            // 
            // labelTargaryens
            // 
            this.labelTargaryens.AutoSize = true;
            this.labelTargaryens.Location = new System.Drawing.Point(450, 27);
            this.labelTargaryens.Name = "labelTargaryens";
            this.labelTargaryens.Size = new System.Drawing.Size(60, 13);
            this.labelTargaryens.TabIndex = 2;
            this.labelTargaryens.Text = "Targaryens";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(434, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 11);
            this.panel1.TabIndex = 3;
            // 
            // labelBaratheons
            // 
            this.labelBaratheons.AutoSize = true;
            this.labelBaratheons.Location = new System.Drawing.Point(450, 53);
            this.labelBaratheons.Name = "labelBaratheons";
            this.labelBaratheons.Size = new System.Drawing.Size(61, 13);
            this.labelBaratheons.TabIndex = 4;
            this.labelBaratheons.Text = "Baratheons";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(434, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 11);
            this.panel2.TabIndex = 5;
            // 
            // labelStarks
            // 
            this.labelStarks.AutoSize = true;
            this.labelStarks.Location = new System.Drawing.Point(450, 79);
            this.labelStarks.Name = "labelStarks";
            this.labelStarks.Size = new System.Drawing.Size(37, 13);
            this.labelStarks.TabIndex = 6;
            this.labelStarks.Text = "Starks";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(434, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 11);
            this.panel3.TabIndex = 7;
            // 
            // labelLannisters
            // 
            this.labelLannisters.AutoSize = true;
            this.labelLannisters.Location = new System.Drawing.Point(450, 106);
            this.labelLannisters.Name = "labelLannisters";
            this.labelLannisters.Size = new System.Drawing.Size(55, 13);
            this.labelLannisters.TabIndex = 8;
            this.labelLannisters.Text = "Lannisters";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(434, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 11);
            this.panel4.TabIndex = 8;
            // 
            // GameOfThrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 422);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelLannisters);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelStarks);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelBaratheons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTargaryens);
            this.Controls.Add(this.BattleFieldView);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameOfThrones";
            this.Text = "GameOfThrones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel BattleFieldView;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelTargaryens;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelBaratheons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelStarks;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelLannisters;
        private System.Windows.Forms.Panel panel4;
    }
}

