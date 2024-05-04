using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Орграфы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // кнопка "Начать работу"
        {
            Form2 SecondForm = new Form2(this); // создаем объект класса Form2
            SecondForm.Show();
            this.Hide(); // скрыть окно главного меню
        }
        public Form1(Form2 f)
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // кнопка "Выход"
        {
            DialogResult r = MessageBox.Show("Вы действительно хотите завершить работу?",
                "Завершение работы", MessageBoxButtons.YesNo); // кнопки Да/Нет

            if (r == DialogResult.Yes) //Если нажата “Да”
            {
                Application.Exit(); // Закрыть приложение
            }

            if (r == DialogResult.No) //Если нажата “Нет”
            {
                // продолжаем работу
            }
        }
    }
}
