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
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
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
            orderProcessor.ProcessOrder(textBoxFilePath.Text);
        }
    }
}
