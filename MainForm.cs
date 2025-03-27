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
            openFileDialog.Filter = "Excel Files|*.xlsx";
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
            ProcessOrders();
        }

        private void ProcessOrders()
        {
            try
            {
                var fileList = orderProcessor.ProcessOrders(textBoxFilePath.Text, textBoxOutputDir.Text);
                var files = String.Join(Environment.NewLine, fileList);
                MessageBox.Show($"Cформированы отчеты:{Environment.NewLine}{files}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при генерации отчетов:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFolderBrouse_Click(object sender, EventArgs e)
        {
            var outputDir = SelectOutputDir(textBoxOutputDir.Text);

            if (outputDir == null)
            {
                return;
            }

            textBoxOutputDir.Text = outputDir;
            textBoxOutputDir.SelectionStart = textBoxOutputDir.Text.Length;
        }

        private static string? SelectOutputDir(string lastSelectedDir)
        {
            // Создаем диалог выбора файла
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            // Устанавливаем начальную папку (если ранее уже выбирали)
            if (!string.IsNullOrEmpty(lastSelectedDir) && Directory.Exists(lastSelectedDir))
            {
                folderDialog.SelectedPath = NormalizePath(lastSelectedDir);
            }
            else
            {
                // Можно установить папку по умолчанию (например, "Мои документы")
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            folderDialog.Description = "Выберите папку для сохранения заявок";
            folderDialog.ShowNewFolderButton = true; // Разрешаем создание новых папок

            if (folderDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return NormalizePath(folderDialog.SelectedPath);
        }

        private static string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;

            return Path.GetFullPath(path)
                      .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                      + Path.DirectorySeparatorChar;
        }
    }
}
