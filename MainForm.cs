using System.Reflection;

namespace ZayavkaTom1Tom2
{
    public partial class MainForm : Form
    {

        private readonly OrderProcessor orderProcessor;

        public MainForm(OrderProcessor orderProcessor)
        {
            InitializeComponent();
            this.orderProcessor = orderProcessor;

            this.Text = Assembly.GetEntryAssembly()?.GetName().Name;
        }

        private void buttonFileBrowse_Click(object sender, EventArgs e)
        {

            var fileName = SelectSourceFile();

            if (fileName == null)
            {
                return;
            }

            textBoxFilePath.Text = fileName;
            textBoxFilePath.SelectionStart = textBoxFilePath.Text.Length;
        }

        private static string? SelectSourceFile()
        {
            // Создаем диалог выбора файла
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настраиваем фильтр для файлов
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.Title = "Выберите Форму для Загрузки";
            openFileDialog.Multiselect = false;

            // Показываем диалог
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            // Проверяем, существует ли файл
            if (!File.Exists(openFileDialog.FileName))
            {
                return null;
            }

            return openFileDialog.FileName;
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            orderProcessor.ProcessOrder(textBoxFilePath.Text);
        }
    }
}
