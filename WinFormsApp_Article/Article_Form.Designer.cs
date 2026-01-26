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
            MOCLabel = new Label();
            MOALabel = new Label();
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
            HashLabel.Location = new Point(48, 70);
            HashLabel.Name = "HashLabel";
            HashLabel.Size = new Size(208, 25);
            HashLabel.TabIndex = 1;
            HashLabel.Text = "Алгоритм хеширования";
            // 
            // HashComboBox
            // 
            HashComboBox.FormattingEnabled = true;
            HashComboBox.Location = new Point(309, 71);
            HashComboBox.Name = "HashComboBox";
            HashComboBox.Size = new Size(151, 28);
            HashComboBox.TabIndex = 2;
            // 
            // MOCLabel
            // 
            MOCLabel.AutoSize = true;
            MOCLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MOCLabel.Location = new Point(320, 125);
            MOCLabel.Name = "MOCLabel";
            MOCLabel.Size = new Size(149, 25);
            MOCLabel.TabIndex = 3;
            MOCLabel.Text = "Метод цепочек";
            // 
            // MOALabel
            // 
            MOALabel.AutoSize = true;
            MOALabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MOALabel.Location = new Point(259, 187);
            MOALabel.Name = "MOALabel";
            MOALabel.Size = new Size(259, 25);
            MOALabel.TabIndex = 4;
            MOALabel.Text = "Метод открытой адресации";
            // 
            // Article_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MOALabel);
            Controls.Add(MOCLabel);
            Controls.Add(HashComboBox);
            Controls.Add(HashLabel);
            Controls.Add(HeadingLabel);
            Name = "Article_Form";
            Text = "Article_Form";
            Load += Article_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeadingLabel;
        private Label HashLabel;
        private ComboBox HashComboBox;
        private Label MOCLabel;
        private Label MOALabel;
    }
}