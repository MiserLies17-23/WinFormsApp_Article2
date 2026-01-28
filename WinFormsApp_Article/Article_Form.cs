using System;
using System.Windows.Forms;

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
                Func<int, int, int> currentMethod = getCurrentMethod();
                int size = (int)SizeNumericUpDown.Value;
                
                DataService service = new DataService();
                var results = service.Run(size, currentMethod);
                DisplayData(results);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Func<int, int, int> getCurrentMethod()
        {
            string methodName = HashComboBox.Text;
            return methodName switch
            {
                "Метод деления" => (Func<int, int, int>)Algorithms.HashAlgorithms.DivisionMethod,
                "Метод середины квадрата" => (Func<int, int, int>)Algorithms.HashAlgorithms.MidsquareMethod,
                "Метод умножения" => (Func<int, int, int>)Algorithms.HashAlgorithms.MultiplicationMethod,
                "Метод свёртывания" => (Func<int, int, int>)Algorithms.HashAlgorithms.FoldingMethod,
                _ => throw new ArgumentException("Метод не распознан!"),
            };
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
                    result.Сomparisons
                );
            }
        }
    }
}
