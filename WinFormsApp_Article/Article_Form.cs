using System;

namespace WinFormsApp_Article
{
    public partial class Article_Form : Form
    {
        

        public Article_Form()
        {
            InitializeComponent();
            
        }

        private void Article_Form_Load(object sender, EventArgs e)
        {
            DataInitilize();
        }

        private void DataInitilize()
        {
            dataGridView1.RowCount = 4;
            dataGridView1.Rows[0].Cells[0].Value = "Метод цепочек";
            dataGridView1.Rows[1].Cells[0].Value = "Линейное пробирование";
            dataGridView1.Rows[2].Cells[0].Value = "Квадратичное пробирование";
            dataGridView1.Rows[3].Cells[0].Value = "Двойное хеширование";
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
