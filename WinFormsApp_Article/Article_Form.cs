using System;
using System.Windows.Forms;
using WinFormsApp_Article.BenchMark;
using WinFormsApp_Article.Services;
using WinFormsApp_Article.Utils;

namespace WinFormsApp_Article
{
    /// <summary>
    /// UI-компонент для взаимодействия с пользователем
    /// </summary>
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
            try
            {
                Func<int, int, int> currentMethod = GetMethodsUtil.GetCurrentMethod(HashComboBox.Text);
                int size = (int)SizeNumericUpDown.Value;
                
                MainService service = new();
                var results = service.Run(size, currentMethod);
                DisplayData(results);
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.TargetSite} {ex.StackTrace}",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void DisplayData(List<MethodResults> results)
        {
            dataGridView1.Rows.Clear();
            foreach (var result in results)
            {
                dataGridView1.Rows.Add(
                    result.AlgorithmName,
                    result.InsertTime,
                    result.SearchTime,
                    result.Сomparisons,
                    result.TotalMemory
                );
            }
        }
    }
}
