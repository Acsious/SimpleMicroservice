using System;
using System.Windows.Forms;
using ServiceReference1;

namespace ClientApplication
{
    public partial class Form1 : Form
    {
        Service1Client client = new Service1Client();

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
        }
        /// <summary>
        /// Расчет суммы заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Text = "";
                return;
            }

            switch (comboBox1.SelectedItem)
            {
                case "RTX 3090":
                    textBox2.Text = (await client.multiplyAsync(Convert.ToInt32(textBox1.Text), 100000)).ToString();
                    break;
                case "RTX 3060":
                    textBox2.Text = (await client.multiplyAsync(Convert.ToInt32(textBox1.Text), 40000)).ToString();
                    break;
                case "RTX 2060":
                    textBox2.Text = (await client.multiplyAsync(Convert.ToInt32(textBox1.Text), 28000)).ToString();
                    break;
                case "GTX 1660 Super":
                    textBox2.Text = (await client.multiplyAsync(Convert.ToInt32(textBox1.Text), 22000)).ToString();
                    break;
                case "GTX 1050Ti":
                    textBox2.Text = (await client.multiplyAsync(Convert.ToInt32(textBox1.Text), 12000)).ToString();
                    break;
                case "":
                    break;
            }
        }

        /// <summary>
        /// Запрет на ввод букв в поле колличества заказываемых товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Запрет на ввод в поле результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) || Char.IsDigit(ch)) 
            {
                e.Handled = true;
            }
        }
    }
}
