using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifr_Atbash
{
    public partial class RegistForm : Form
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            //стираем пустые введенные символы
            textBoxLogin.Text = textBoxLogin.Text.Trim();
            textBoxPassword.Text = textBoxPassword.Text.Trim();
            textBoxConfirm.Text = textBoxConfirm.Text.Trim();
            try
            {
                var user = new User(textBoxLogin.Text, textBoxPassword.Text, textBoxConfirm.Text);
                if (user.CorrectUser() && !user.UsernameExist())
                {
                    user.CreateUser();
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.FormClosed += (s, args) => this.Close();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("Имя пользователя уже занято", "Ошибка регистрации",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка регистрации", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
