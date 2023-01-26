using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Shifr_Atbash
{
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }

        private void CloseBatton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseBatton_MouseEnter(object sender, EventArgs e)
        {
            CloseBatton.ForeColor = Color.DarkRed;
        }

        private void CloseBatton_MouseLeave(object sender, EventArgs e)
        {
            CloseBatton.ForeColor = Color.White;
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }


        private void buttonRegist_Click(object sender, EventArgs e)
        {
            RegistForm sf = new RegistForm();
            sf.FormClosed += (s, args) => this.Close();
            this.Hide();
            sf.Show();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            //Стираем введенные пустые символы
            textBoxLogin.Text = textBoxLogin.Text.Trim();
            textBoxPassword.Text = textBoxPassword.Text.Trim();
            try
            {
                User user = new User(textBoxLogin.Text, textBoxPassword.Text);
                if (user.CorrectUser() && user.UserValid())
                {
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.FormClosed += (s, args) => this.Close();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка авторизации", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else

            {
                textBoxPassword.UseSystemPasswordChar = true;
            }

        }
    }
}
