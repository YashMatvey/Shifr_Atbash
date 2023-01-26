using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifr_Atbash
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Открытие файла
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            //OpenFile.Filter = "Файлы txt|*.txt|";
            if (OpenFile.ShowDialog() == DialogResult.OK )
            {
                
                richTextBox1.Text = File.ReadAllText(OpenFile.FileName);
                
            }
        }
        // Сохранение файла
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (richTextBoxOut.Text != "" && richTextBoxOut.Text != null && richTextBoxOut.Text != " ")
            {
                    SaveFileDialog SFD = new SaveFileDialog();
                SFD.DefaultExt = ".txt";
                SFD.Filter = "Test fiels|*.txt";
                if(SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK && SFD.FileName.Length>0)
                {
                    using(StreamWriter SW = new StreamWriter(SFD.FileName, true))
                    {
                        SW.WriteLine(richTextBoxOut.Text);
                        SW.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы пытаетесь сохранить пустой файл!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Шифрованиие 
        private void button1_Click_1(object sender, EventArgs e)
        {
            string Text = richTextBox1.Text;
            var Chifr = new CifrAtbash();
            richTextBoxOut.Text = Chifr.ChifrA(Text);
        }
        // Отчистка текста
        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить весь текст?", "Сообщение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)  
                richTextBox1.Clear(); 
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBoxOut.Text);
            MessageBox.Show("Текст скопирован","Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        Point LastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void CloseBatton_MouseLeave(object sender, EventArgs e)
        {
            CloseBatton.ForeColor = Color.White;
        }

        private void CloseBatton_MouseEnter(object sender, EventArgs e)
        {
            CloseBatton.ForeColor = Color.DarkRed;
        }

        private void CloseBatton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            string text = "Шифр Атбаш\n"+
             "Для шифрации введенного текста в данной программе используется алгоритм \"Шифр Атбаш\" - " +
             "простой шифр подстановки для алфавитного письма.\n"+"\n" +
             "\nДля шифрации или дешифрации текста необходимо ввести текст в верхнее окно ввода, после чего нажать на кнопку" +
             "\"Зашифровать или Расшифровать\". Далее в нижнем поле выведется результат шифрования.\n" +
             "Чтобы сохранить полученый результат, необходимо нажать на кнопку \"Сохранить файл\"\n" +
             "Результат будет сохранен в формате txt.\n"+"\n"+
             "Если это необходимо можно открыть файл с результатом шифрования для дальнейшей раьоты с ним.\n"+
             "Так же есть возможность полностью отчистить поле ввода(верхнего поля), и скопировать текст из нижнего поля.";
             string handler = "О программе";
            MessageBox.Show(text, handler, MessageBoxButtons.OK,
           MessageBoxIcon.Information);

        }
    }
}
