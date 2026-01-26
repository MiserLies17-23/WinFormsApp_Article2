namespace WinFormsApp_Article
{
    partial class Article_Form
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
            HeadingLabel = new Label();
            HashLabel = new Label();
            HashComboBox = new ComboBox();
            CompareButton = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            SizeNumericUpDown = new NumericUpDown();
            TitleColumn = new DataGridViewTextBoxColumn();
            TimeColumn = new DataGridViewTextBoxColumn();
            CompareColumn = new DataGridViewTextBoxColumn();
            FoundColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // HeadingLabel
            // 
            HeadingLabel.AutoSize = true;
            HeadingLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            HeadingLabel.Location = new Point(191, 9);
            HeadingLabel.Name = "HeadingLabel";
            HeadingLabel.Size = new Size(436, 28);
            HeadingLabel.TabIndex = 0;
            HeadingLabel.Text = "Сравнение методов разрешения коллизий";
            // 
            // HashLabel
            // 
            HashLabel.AutoSize = true;
            HashLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            HashLabel.Location = new Point(24, 74);
            HashLabel.Name = "HashLabel";
            HashLabel.Size = new Size(208, 25);
            HashLabel.TabIndex = 1;
            HashLabel.Text = "Алгоритм хеширования";
            // 
            // HashComboBox
            // 
            HashComboBox.FormattingEnabled = true;
            HashComboBox.Items.AddRange(new object[] { "Метод деления", "Метод середины квадрат", "Метод свёртывания", "Метод умножения" });
            HashComboBox.Location = new Point(238, 75);
            HashComboBox.Name = "HashComboBox";
            HashComboBox.Size = new Size(151, 28);
            HashComboBox.TabIndex = 2;
            // 
            // CompareButton
            // 
            CompareButton.Location = new Point(345, 397);
            CompareButton.Name = "CompareButton";
            CompareButton.Size = new Size(94, 29);
            CompareButton.TabIndex = 5;
            CompareButton.Text = "Сравнить";
            CompareButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TitleColumn, TimeColumn, CompareColumn, FoundColumn });
            dataGridView1.Location = new Point(39, 187);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(687, 188);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(471, 74);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 7;
            label1.Text = "Размер массива";
            // 
            // SizeNumericUpDown
            // 
            SizeNumericUpDown.Location = new Point(621, 74);
            SizeNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            SizeNumericUpDown.Name = "SizeNumericUpDown";
            SizeNumericUpDown.Size = new Size(150, 27);
            SizeNumericUpDown.TabIndex = 8;
            SizeNumericUpDown.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // TitleColumn
            // 
            TitleColumn.HeaderText = "Метод разрешения коллизий";
            TitleColumn.MinimumWidth = 6;
            TitleColumn.Name = "TitleColumn";
            TitleColumn.Width = 225;
            // 
            // TimeColumn
            // 
            TimeColumn.HeaderText = "Время";
            TimeColumn.MinimumWidth = 6;
            TimeColumn.Name = "TimeColumn";
            TimeColumn.Width = 125;
            // 
            // CompareColumn
            // 
            CompareColumn.HeaderText = "Сравнения";
            CompareColumn.MinimumWidth = 6;
            CompareColumn.Name = "CompareColumn";
            CompareColumn.Width = 125;
            // 
            // FoundColumn
            // 
            FoundColumn.HeaderText = "найдено";
            FoundColumn.MinimumWidth = 6;
            FoundColumn.Name = "FoundColumn";
            FoundColumn.Width = 125;
            // 
            // Article_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SizeNumericUpDown);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(CompareButton);
            Controls.Add(HashComboBox);
            Controls.Add(HashLabel);
            Controls.Add(HeadingLabel);
            Name = "Article_Form";
            Text = "Article_Form";
            Load += Article_Form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SizeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeadingLabel;
        private Label HashLabel;
        private ComboBox HashComboBox;
        private Button CompareButton;
        private DataGridView dataGridView1;
        private Label label1;
        private NumericUpDown SizeNumericUpDown;
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn CompareColumn;
        private DataGridViewTextBoxColumn FoundColumn;
    }
}