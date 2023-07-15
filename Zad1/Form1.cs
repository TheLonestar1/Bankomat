using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Zad1
{
    public partial class Form1 : Form
    {
        Formatter formatter;

        public Form1()
        {
            InitializeComponent();
            formatter = new Formatter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
            formatter.pathLoad = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();
            textBox3.Text = saveFileDialog.FileName;
            formatter.pathSave = saveFileDialog.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            if (textBox1.Text.All(x => char.IsDigit(x)))
                formatter.maxLength = Convert.ToInt32(textBox1.Text);
            else
                label4.Text = "¬ведите корректную длинну слов";
            if (String.IsNullOrEmpty(textBox2.Text))
                label4.Text = "”кажите файл дл€ загрузки";
            if (String.IsNullOrEmpty(textBox3.Text))
                label4.Text = "”кажите файл дл€ сохранени€";
            formatter.isDelete = checkBox1.Checked;
            if (string.IsNullOrEmpty(label4.Text))
                formatter.StartFormatter();

        }
    }
}