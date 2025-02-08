namespace Nero_Network
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.bGive = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.lGuess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lEpoch = new System.Windows.Forms.Label();
            this.lRight = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.ListBox();
            this.bTeachTest = new System.Windows.Forms.Button();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.bHelp = new System.Windows.Forms.Button();
            this.bStartTesting = new System.Windows.Forms.Button();
            this.lEpsilon = new System.Windows.Forms.Label();
            this.nudEpsilon = new System.Windows.Forms.NumericUpDown();
            this.tEpsilon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFuncCoef = new System.Windows.Forms.NumericUpDown();
            this.lEpsilonError = new System.Windows.Forms.Label();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbScale = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tHiddenNeuronSize = new System.Windows.Forms.TextBox();
            this.bHiddenHeuronSizeChange = new System.Windows.Forms.Button();
            this.cbSamples = new System.Windows.Forms.ComboBox();
            this.bSamples = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bMegaTraining = new System.Windows.Forms.Button();
            this.bData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNMax = new System.Windows.Forms.NumericUpDown();
            this.bResultsFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpsilon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuncCoef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNMax)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Enabled = false;
            this.pbMain.Location = new System.Drawing.Point(258, 9);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(100, 100);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            // 
            // bGive
            // 
            this.bGive.Enabled = false;
            this.bGive.Location = new System.Drawing.Point(264, 120);
            this.bGive.Name = "bGive";
            this.bGive.Size = new System.Drawing.Size(88, 24);
            this.bGive.TabIndex = 1;
            this.bGive.Text = "Дать";
            this.bGive.UseVisualStyleBackColor = true;
            this.bGive.Click += new System.EventHandler(this.bGive_Click);
            // 
            // bClear
            // 
            this.bClear.Enabled = false;
            this.bClear.Location = new System.Drawing.Point(264, 150);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(88, 24);
            this.bClear.TabIndex = 1;
            this.bClear.Text = "Очистить";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // lGuess
            // 
            this.lGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGuess.Location = new System.Drawing.Point(98, 9);
            this.lGuess.Name = "lGuess";
            this.lGuess.Size = new System.Drawing.Size(157, 100);
            this.lGuess.TabIndex = 2;
            this.lGuess.Text = "Близнецы";
            this.lGuess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Альфа";
            // 
            // lEpoch
            // 
            this.lEpoch.AutoSize = true;
            this.lEpoch.Location = new System.Drawing.Point(12, 126);
            this.lEpoch.Name = "lEpoch";
            this.lEpoch.Size = new System.Drawing.Size(37, 13);
            this.lEpoch.TabIndex = 7;
            this.lEpoch.Text = "Эпохи";
            // 
            // lRight
            // 
            this.lRight.AutoSize = true;
            this.lRight.Location = new System.Drawing.Point(12, 165);
            this.lRight.Name = "lRight";
            this.lRight.Size = new System.Drawing.Size(44, 13);
            this.lRight.TabIndex = 7;
            this.lRight.Text = "Угадал";
            // 
            // logs
            // 
            this.logs.FormattingEnabled = true;
            this.logs.Location = new System.Drawing.Point(10, 207);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(348, 251);
            this.logs.TabIndex = 8;
            // 
            // bTeachTest
            // 
            this.bTeachTest.Enabled = false;
            this.bTeachTest.Location = new System.Drawing.Point(10, 9);
            this.bTeachTest.Name = "bTeachTest";
            this.bTeachTest.Size = new System.Drawing.Size(82, 64);
            this.bTeachTest.TabIndex = 5;
            this.bTeachTest.Text = "Обучение и тест";
            this.bTeachTest.UseVisualStyleBackColor = true;
            this.bTeachTest.Click += new System.EventHandler(this.bTeachTest_Click);
            // 
            // nudAlpha
            // 
            this.nudAlpha.DecimalPlaces = 2;
            this.nudAlpha.Enabled = false;
            this.nudAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Location = new System.Drawing.Point(382, 226);
            this.nudAlpha.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.nudAlpha.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(68, 20);
            this.nudAlpha.TabIndex = 3;
            this.nudAlpha.Value = new decimal(new int[] {
            30,
            0,
            0,
            131072});
            // 
            // bHelp
            // 
            this.bHelp.Enabled = false;
            this.bHelp.Location = new System.Drawing.Point(367, 463);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(118, 24);
            this.bHelp.TabIndex = 11;
            this.bHelp.Text = "Напоминалка";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // bStartTesting
            // 
            this.bStartTesting.Enabled = false;
            this.bStartTesting.Location = new System.Drawing.Point(10, 79);
            this.bStartTesting.Name = "bStartTesting";
            this.bStartTesting.Size = new System.Drawing.Size(82, 30);
            this.bStartTesting.TabIndex = 1;
            this.bStartTesting.Text = "Тест";
            this.bStartTesting.UseVisualStyleBackColor = true;
            this.bStartTesting.Click += new System.EventHandler(this.bStartTesting_Click);
            // 
            // lEpsilon
            // 
            this.lEpsilon.AutoSize = true;
            this.lEpsilon.Location = new System.Drawing.Point(384, 308);
            this.lEpsilon.Name = "lEpsilon";
            this.lEpsilon.Size = new System.Drawing.Size(50, 13);
            this.lEpsilon.TabIndex = 13;
            this.lEpsilon.Text = "Эпсилон";
            // 
            // nudEpsilon
            // 
            this.nudEpsilon.Enabled = false;
            this.nudEpsilon.Location = new System.Drawing.Point(432, 324);
            this.nudEpsilon.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudEpsilon.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.nudEpsilon.Name = "nudEpsilon";
            this.nudEpsilon.Size = new System.Drawing.Size(18, 20);
            this.nudEpsilon.TabIndex = 14;
            this.nudEpsilon.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudEpsilon.ValueChanged += new System.EventHandler(this.nudEpsilon_ValueChanged);
            // 
            // tEpsilon
            // 
            this.tEpsilon.Enabled = false;
            this.tEpsilon.Location = new System.Drawing.Point(382, 324);
            this.tEpsilon.Name = "tEpsilon";
            this.tEpsilon.Size = new System.Drawing.Size(51, 20);
            this.tEpsilon.TabIndex = 15;
            this.tEpsilon.TextChanged += new System.EventHandler(this.tEpsilon_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Коэффициент";
            // 
            // nudFuncCoef
            // 
            this.nudFuncCoef.DecimalPlaces = 1;
            this.nudFuncCoef.Enabled = false;
            this.nudFuncCoef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudFuncCoef.Location = new System.Drawing.Point(382, 275);
            this.nudFuncCoef.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFuncCoef.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudFuncCoef.Name = "nudFuncCoef";
            this.nudFuncCoef.Size = new System.Drawing.Size(68, 20);
            this.nudFuncCoef.TabIndex = 16;
            this.nudFuncCoef.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lEpsilonError
            // 
            this.lEpsilonError.AutoSize = true;
            this.lEpsilonError.Location = new System.Drawing.Point(13, 145);
            this.lEpsilonError.Name = "lEpsilonError";
            this.lEpsilonError.Size = new System.Drawing.Size(50, 13);
            this.lEpsilonError.TabIndex = 18;
            this.lEpsilonError.Text = "Эпсилон";
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(191, 161);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(52, 17);
            this.rbNormal.TabIndex = 25;
            this.rbNormal.Text = "Выкл";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(191, 138);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(59, 17);
            this.rbCenter.TabIndex = 25;
            this.rbCenter.Text = "Центр.";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbScale
            // 
            this.rbScale.AutoSize = true;
            this.rbScale.Checked = true;
            this.rbScale.Location = new System.Drawing.Point(191, 115);
            this.rbScale.Name = "rbScale";
            this.rbScale.Size = new System.Drawing.Size(74, 17);
            this.rbScale.TabIndex = 25;
            this.rbScale.TabStop = true;
            this.rbScale.Text = "Масштаб.";
            this.rbScale.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(113, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(245, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Выводить результаты активации нейронов";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tHiddenNeuronSize
            // 
            this.tHiddenNeuronSize.Enabled = false;
            this.tHiddenNeuronSize.Location = new System.Drawing.Point(382, 27);
            this.tHiddenNeuronSize.Name = "tHiddenNeuronSize";
            this.tHiddenNeuronSize.Size = new System.Drawing.Size(100, 20);
            this.tHiddenNeuronSize.TabIndex = 28;
            this.tHiddenNeuronSize.TextChanged += new System.EventHandler(this.tHiddenHeuronSize_TextChanged);
            // 
            // bHiddenHeuronSizeChange
            // 
            this.bHiddenHeuronSizeChange.Enabled = false;
            this.bHiddenHeuronSizeChange.ForeColor = System.Drawing.Color.Black;
            this.bHiddenHeuronSizeChange.Location = new System.Drawing.Point(382, 53);
            this.bHiddenHeuronSizeChange.Name = "bHiddenHeuronSizeChange";
            this.bHiddenHeuronSizeChange.Size = new System.Drawing.Size(100, 23);
            this.bHiddenHeuronSizeChange.TabIndex = 29;
            this.bHiddenHeuronSizeChange.Text = "Изменить";
            this.bHiddenHeuronSizeChange.UseVisualStyleBackColor = true;
            this.bHiddenHeuronSizeChange.Click += new System.EventHandler(this.bHiddenHeuronSizeChange_Click);
            // 
            // cbSamples
            // 
            this.cbSamples.FormattingEnabled = true;
            this.cbSamples.Items.AddRange(new object[] {
            "Зодиак",
            "Алхимия",
            "Цифры"});
            this.cbSamples.Location = new System.Drawing.Point(382, 111);
            this.cbSamples.Name = "cbSamples";
            this.cbSamples.Size = new System.Drawing.Size(100, 21);
            this.cbSamples.TabIndex = 30;
            // 
            // bSamples
            // 
            this.bSamples.Location = new System.Drawing.Point(382, 139);
            this.bSamples.Name = "bSamples";
            this.bSamples.Size = new System.Drawing.Size(100, 23);
            this.bSamples.TabIndex = 31;
            this.bSamples.Text = "Загрузить";
            this.bSamples.UseVisualStyleBackColor = true;
            this.bSamples.Click += new System.EventHandler(this.bSamples_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Выборка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Скрытый слой";
            // 
            // bMegaTraining
            // 
            this.bMegaTraining.Enabled = false;
            this.bMegaTraining.Location = new System.Drawing.Point(10, 464);
            this.bMegaTraining.Name = "bMegaTraining";
            this.bMegaTraining.Size = new System.Drawing.Size(348, 23);
            this.bMegaTraining.TabIndex = 34;
            this.bMegaTraining.Text = "Мега-обучение";
            this.bMegaTraining.UseVisualStyleBackColor = true;
            this.bMegaTraining.Click += new System.EventHandler(this.bMegaTraining_Click);
            // 
            // bData
            // 
            this.bData.Location = new System.Drawing.Point(382, 168);
            this.bData.Name = "bData";
            this.bData.Size = new System.Drawing.Size(100, 23);
            this.bData.TabIndex = 35;
            this.bData.Text = "Вывести данные";
            this.bData.UseVisualStyleBackColor = true;
            this.bData.Click += new System.EventHandler(this.bData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Ограничение";
            // 
            // nudNMax
            // 
            this.nudNMax.Enabled = false;
            this.nudNMax.Location = new System.Drawing.Point(382, 376);
            this.nudNMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNMax.Name = "nudNMax";
            this.nudNMax.Size = new System.Drawing.Size(68, 20);
            this.nudNMax.TabIndex = 36;
            this.nudNMax.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // bResultsFolder
            // 
            this.bResultsFolder.Location = new System.Drawing.Point(367, 417);
            this.bResultsFolder.Name = "bResultsFolder";
            this.bResultsFolder.Size = new System.Drawing.Size(118, 40);
            this.bResultsFolder.TabIndex = 38;
            this.bResultsFolder.Text = "Папка с результатами";
            this.bResultsFolder.UseVisualStyleBackColor = true;
            this.bResultsFolder.Click += new System.EventHandler(this.bResultsFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(497, 492);
            this.Controls.Add(this.bResultsFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudNMax);
            this.Controls.Add(this.bData);
            this.Controls.Add(this.bMegaTraining);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bSamples);
            this.Controls.Add(this.cbSamples);
            this.Controls.Add(this.bHiddenHeuronSizeChange);
            this.Controls.Add(this.tHiddenNeuronSize);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rbScale);
            this.Controls.Add(this.rbCenter);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.lEpsilonError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudFuncCoef);
            this.Controls.Add(this.tEpsilon);
            this.Controls.Add(this.nudEpsilon);
            this.Controls.Add(this.lEpsilon);
            this.Controls.Add(this.bHelp);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.lRight);
            this.Controls.Add(this.lEpoch);
            this.Controls.Add(this.bTeachTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.lGuess);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bStartTesting);
            this.Controls.Add(this.bGive);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нейронка";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpsilon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuncCoef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button bGive;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label lGuess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lEpoch;
        private System.Windows.Forms.Label lRight;
        private System.Windows.Forms.ListBox logs;
        private System.Windows.Forms.Button bTeachTest;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Button bHelp;
        private System.Windows.Forms.Button bStartTesting;
        private System.Windows.Forms.Label lEpsilon;
        private System.Windows.Forms.NumericUpDown nudEpsilon;
        private System.Windows.Forms.TextBox tEpsilon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudFuncCoef;
        private System.Windows.Forms.Label lEpsilonError;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbScale;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tHiddenNeuronSize;
        private System.Windows.Forms.Button bHiddenHeuronSizeChange;
        private System.Windows.Forms.ComboBox cbSamples;
        private System.Windows.Forms.Button bSamples;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bMegaTraining;
        private System.Windows.Forms.Button bData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNMax;
        private System.Windows.Forms.Button bResultsFolder;
    }
}

