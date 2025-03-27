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
            // ������� ������ ������ �����
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            // ����������� ������ ��� ������
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "�������� ����� ��� ��������";
            openFileDialog.Multiselect = false;

            // ���������� ������
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            // ���������, ���������� �� ����
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
                MessageBox.Show($"C����������� ������:{Environment.NewLine}{files}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������ ��� ��������� �������:{Environment.NewLine}{ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ������� ������ ������ �����
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            // ������������� ��������� ����� (���� ����� ��� ��������)
            if (!string.IsNullOrEmpty(lastSelectedDir) && Directory.Exists(lastSelectedDir))
            {
                folderDialog.SelectedPath = NormalizePath(lastSelectedDir);
            }
            else
            {
                // ����� ���������� ����� �� ��������� (��������, "��� ���������")
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            folderDialog.Description = "�������� ����� ��� ���������� ������";
            folderDialog.ShowNewFolderButton = true; // ��������� �������� ����� �����

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
