using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string login = TxtLogin.Text;
            string password = TxtPassword.Text;

            if (login != "allan123" && password != "1234") 
            {
                MessageBox.Show("Login ou senha inválidos!!");
            }
            else 
            {
                this.Hide(); //oculta o primeiro formulário

                Form2 formularioNovo = new Form2();

                formularioNovo.ShowDialog();

                

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastrar cadastroForm = new Cadastrar();
            cadastroForm.Show();

            this.Hide();
        }
    }
}
