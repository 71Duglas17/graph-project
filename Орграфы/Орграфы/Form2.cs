using System;
using System.IO;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static void MatrixSmejnosti(int[,] graph, string nameFile)
        { // метод для считывания элементов из файла в матрицу смежности
            StreamReader f = new StreamReader(nameFile);
            int elem, i, n;
            string fstr = f.ReadLine(); // считываем из файла первый элемент - количество вершин в графе
            n = Convert.ToInt32(fstr);

            for (i = 0; i < n; i++)
            {
                fstr = f.ReadLine(); // Построчно смотрим файл
                foreach (string stringElement in fstr.Split()) // Затем смотрим поэлементно
                {
                    elem = Convert.ToInt32(stringElement);
                    graph[i, elem - 1] = 1; // единица ставится к той вершине, в которую ВХОДИТ наша вершина
                }
            }
        }

        static void MatrixIncidentnosti(int[,] graph, string nameFile)
        { // метод для считывания элементов из файла в матрицу инцидентности
            StreamReader f = new StreamReader(nameFile);
            int elem, i, n, k = 0;
            string fstr = f.ReadLine(); // считываем из файла первый элемент - количество вершин в графе
            n = Convert.ToInt32(fstr);

            for (i = 0; i < n; i++) // 7 - кол-во столбцов
            {
                fstr = f.ReadLine(); // Построчно смотрим файл
                foreach (string stringElement in fstr.Split()) // Затем смотрим поэлементно
                {
                    elem = Convert.ToInt32(stringElement);
                    graph[i, k] = 1;
                    graph[elem - 1, k] = -1;
                    k++; // сдвигаемся к следующему столбику (след. ребру)
                }
            }
        }

        static void SpisokSmejnosti(int[,] graph, string nameFile)
        { // метод для считывания элементов из файла в список смежности
            StreamReader f = new StreamReader(nameFile);
            int elem, k, i, n;
            string fstr = f.ReadLine(); // считываем из файла первый элемент - количество вершин в графе
            n = Convert.ToInt32(fstr);

            for (i = 0; i < n; i++)
            {
                k = 1;
                fstr = f.ReadLine(); // Построчно смотрим файл
                foreach (string stringElement in fstr.Split()) // Затем смотрим поэлементно
                {
                    elem = Convert.ToInt32(stringElement);
                    graph[i, 0] = i + 1; // первый столбик - вершина, из которой выходит ребро
                    graph[i, k] = elem; // следующий элем. в строке - вершина, в которую входит ребро
                    k++;
                }
            }
        }

        static void SpisokReber(int[,] graph, string nameFile, int kolvoReber)
        { // метод для считывания элементов из файла в список рёбер
            StreamReader f = new StreamReader(nameFile);
            int elem, i, n, k, vershina = 1;
            string fstr = f.ReadLine(); // считываем из файла первый элемент - количество вершин в графе
            n = Convert.ToInt32(fstr);

            for (i = 0; i < kolvoReber; i++)
            {
                k = 0;
                fstr = f.ReadLine(); // Построчно смотрим файл
                foreach (string stringElement in fstr.Split()) // Затем смотрим поэлементно
                {
                    elem = Convert.ToInt32(stringElement);
                    graph[i + k, 0] = vershina; // вершина выхода
                    graph[i + k, 1] = elem; // вершина входа
                    k++; // переменная k нужна, если из вершины идут несколько ребер в другие вершины
                         // тогда заполняем следующую строку массива с той же вeршиной выхода
                         // но уже с другой вершиной входа
                }
                i = i + k - 1; // i+k, чтобы пройти несколько итераций цикла for,
                               // а затем -1, т.к. следующее дейтсвие в цикле for i++
                               // это нужно чтобы не прыгать через следующий элемент
                vershina++;
            }
        }

        static void VisitFalse(bool[] visit, int kolvoVer) // метод для заполнения посещенных вершин значением false
        {
            for (int i = 0; i < kolvoVer; i++)
                visit[i] = false;
        }

        private void button2_Click(object sender, EventArgs e) // кнопка "Вывод матрицы смежности"
        {
            string nameFile;
            if(Convert.ToInt32(textBox6.Text) == 1)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                int[,] firstGraph = new int[6, 6];
                MatrixSmejnosti(firstGraph, nameFile);

                textBox1.Text = " Матрица смежности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "   1  2 3 4 5 6";
                textBox1.Text += Environment.NewLine;
                textBox1.Text += "   _________";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 6; i++)
                {
                    textBox1.Text += i + 1 + " |";
                    for (int j = 0; j < 6; j++)
                        textBox1.Text += firstGraph[i, j] + " ";
                    textBox1.Text += Environment.NewLine;
                }
            }

            else if(Convert.ToInt32(textBox6.Text) == 2)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                int[,] secondGraph = new int[9, 9];
                MatrixSmejnosti(secondGraph, nameFile);

                textBox1.Text = " Матрица смежности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "   1  2 3 4 5 6 7 8 9";
                textBox1.Text += Environment.NewLine;
                textBox1.Text += "   _____________";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 9; i++)
                {
                    textBox1.Text += i + 1 + " |";
                    for (int j = 0; j < 9; j++)
                        textBox1.Text += secondGraph[i, j] + " ";
                    textBox1.Text += Environment.NewLine;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // кнопка "Вывод матрицы инцидентности"
        {
            string nameFile;
            if (Convert.ToInt32(textBox6.Text) == 1)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                int[,] firstGraph = new int[6, 7]; // 7 - кол-во рёбер
                MatrixIncidentnosti(firstGraph, nameFile);

                textBox1.Text = " Матрица инцидентности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "    a   b    c    d   e   f   g";
                textBox1.Text += Environment.NewLine;
                textBox1.Text += "    _________________";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 6; i++)
                {
                    textBox1.Text += i + 1 + " |";
                    for (int j = 0; j < 7; j++)
                        textBox1.Text += firstGraph[i, j] + "   ";
                    textBox1.Text += Environment.NewLine;
                }
            }

            else if (Convert.ToInt32(textBox6.Text) == 2)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                int[,] secondGraph = new int[9, 14]; // 14 - кол-во рёбер
                MatrixIncidentnosti(secondGraph, nameFile);

                textBox1.Text = " Матрица инцидентности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "    a  b    c   d    e    f   g   h    i    j    k    l   m   n";
                textBox1.Text += Environment.NewLine;
                textBox1.Text += "    __________________________________";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 9; i++)
                {
                    textBox1.Text += i + 1 + " |";
                    for (int j = 0; j < 14; j++)
                        textBox1.Text += secondGraph[i, j] + "   ";
                    textBox1.Text += Environment.NewLine;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) // кнопка "Вывод списка смежности"
        {
            string nameFile;
            if (Convert.ToInt32(textBox6.Text) == 1)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                int[,] firstGraph = new int[6, 6];
                SpisokSmejnosti(firstGraph, nameFile);

                textBox1.Text = " Список смежности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                for (int i = 0; i < 6; i++)
                {
                    textBox1.Text += firstGraph[i, 0];
                    for (int j = 1; j < 6; j++)
                    {
                        if (firstGraph[i, j] != 0)
                        {
                            textBox1.Text += " -> " + firstGraph[i, j];
                        }
                    }
                    textBox1.Text += Environment.NewLine;
                }
            }

            else if (Convert.ToInt32(textBox6.Text) == 2)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                int[,] secondGraph = new int[9, 9];
                SpisokSmejnosti(secondGraph, nameFile);

                textBox1.Text = " Список смежности";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                for (int i = 0; i < 9; i++)
                {
                    textBox1.Text += secondGraph[i, 0];
                    for (int j = 1; j < 9; j++)
                    {
                        if (secondGraph[i, j] != 0)
                        {
                            textBox1.Text += " -> " + secondGraph[i, j];
                        }
                    }
                    textBox1.Text += Environment.NewLine;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) // кнопка "Вывод списка рёбер"
        {
            textBox1.Text = ""; // если в поле уже был результат, то он сотрется и появится новый результат
            string nameFile;
            if (Convert.ToInt32(textBox6.Text) == 1)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                int[,] firstGraph = new int[7, 2]; // 7 - это кол-во рёбер в графе
                SpisokReber(firstGraph, nameFile, 7);

                textBox1.Text = " Список рёбер";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "Вершина  " + "  Вершина ";
                textBox1.Text += Environment.NewLine + " выхода  " + "        входа";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 7; i++)
                {
                    textBox1.Text += "    " + firstGraph[i, 0] + "       --->       " + firstGraph[i, 1];
                    textBox1.Text += Environment.NewLine;
                }
            }

            else if (Convert.ToInt32(textBox6.Text) == 2)
            {
                nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                int[,] secondGraph = new int[14, 2]; // 14 - кол-во рёбер в графе
                SpisokReber(secondGraph, nameFile, 14);

                textBox1.Text = " Список рёбер";
                textBox1.Text += Environment.NewLine + Environment.NewLine;
                textBox1.Text += "Вершина  " + "  Вершина ";
                textBox1.Text += Environment.NewLine + " выхода  " + "        входа";
                textBox1.Text += Environment.NewLine;
                for (int i = 0; i < 14; i++)
                {
                    textBox1.Text += "    " + secondGraph[i, 0] + "       --->       " + secondGraph[i, 1];
                    textBox1.Text += Environment.NewLine;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) // кнопка "Выполнить обход в глубину"
        {
            void GLUB(int start, bool[] visit, int[,] graph, int kolvoVer) // метод обхода в глубину
            {
                textBox4.Text += "  " + (start + 1); //вывод одной из вершин,start
                visit[start] = true; //если посещали вершину start
                for (int i = 0; i < kolvoVer; i++)
                {
                    //если есть связь между вершинами графа(graph[st,i]!=0) и 
                    //если не посещали вершину(!visit[i]), то обращение к рекурсивной процедуре

                    if ((graph[start, i] != 0) && (!visit[i]))
                        GLUB(i, visit, graph, kolvoVer);
                }
            }
            try
            {
                textBox4.Text = ""; // если в поле уже был результат, то он сотрется и появится новый результат
                string nameFile;
                if (Convert.ToInt32(textBox6.Text) == 1)
                {
                    nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                    int[,] firstGraph = new int[6, 6];
                    MatrixSmejnosti(firstGraph, nameFile);
                    bool[] visit = new bool[6];
                    VisitFalse(visit, 6);
                    GLUB(Convert.ToInt32(textBox2.Text) - 1, visit, firstGraph, 6);
                }

                else if (Convert.ToInt32(textBox6.Text) == 2)
                {
                    nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                    int[,] secondGraph = new int[9, 9];
                    MatrixSmejnosti(secondGraph, nameFile);
                    bool[] visit = new bool[9];
                    VisitFalse(visit, 9);
                    GLUB(Convert.ToInt32(textBox2.Text) - 1, visit, secondGraph, 9);
                }
            }
            catch
            {
                MessageBox.Show("Число введено неверно! Повторите попытку.", "Ошибка!");
            }
            finally
            {

            }
        }

        private void button9_Click(object sender, EventArgs e) // кнопка "Выполнить обход в ширину"
        {
            void SCHIR(int start, ref Queue<int> ochered, ref bool[] visit, int[,] msg) //метод обхода в ширину
            {
                visit[start] = true; //вершина посещена
                ochered.Enqueue(start);//помещаем вершину в пустую очередь(Enqueue()-метод класса Queue)

                while (ochered.Count != 0) // пока число эл-ов в очереди(метод Сount) не равно нулю - пока очередь не пуста
                {
                    start = ochered.Peek();// берет вершину из начала очереди, НО НЕ УДАЛЯЕТ
                    ochered.Dequeue(); //удаляет вершину из начала очереди
                    textBox5.Text += "  " + (start + 1); //вывод одной из вершин,start

                    //перебираем все вершины, связанные с start
                    for (int i = 0; i < msg.GetLength(0); i++)
                    {
                        //если есть связь между вершинами графа и вершина не пройдена
                        if (msg[start, i] == 1)
                        {
                            if (!visit[i]) //если вершина не посещена
                            {
                                visit[i] = true; //отмечаем вершину i как пройденную
                                ochered.Enqueue(i); //и добавляем вершину в очередь
                            }
                        }
                    }
                }
            }
            try
            {
                textBox5.Text = ""; // если в поле уже был результат, то он сотрется и появится новый результат
                string nameFile;
                if (Convert.ToInt32(textBox6.Text) == 1)
                {
                    nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\firstGraph.txt";
                    int[,] firstGraph = new int[6, 6];
                    MatrixSmejnosti(firstGraph, nameFile);
                    bool[] visit = new bool[6];
                    VisitFalse(visit, 6);
                    Queue<int> ochered = new Queue<int>();
                    SCHIR(Convert.ToInt32(textBox3.Text) - 1, ref ochered, ref visit, firstGraph);
                }

                else if (Convert.ToInt32(textBox6.Text) == 2)
                {
                    nameFile = @"C:\Users\пк\OneDrive\Рабочий стол\Орграфы\Орграфы\secondGraph.txt";
                    int[,] secondGraph = new int[9, 9];
                    MatrixSmejnosti(secondGraph, nameFile);
                    bool[] visit = new bool[9];
                    VisitFalse(visit, 9);
                    Queue<int> ochered = new Queue<int>();
                    SCHIR(Convert.ToInt32(textBox3.Text) - 1, ref ochered, ref visit, secondGraph);
                }
            }
            catch
            {
                MessageBox.Show("Число введено неверно! Повторите попытку.", "Ошибка!");
            }
            finally
            {

            }
        }

        private void button7_Click(object sender, EventArgs e) // кнопка "Назад"
        {
            Form1 FirstForm = new Form1(this); // создаем объект класса Form1
            FirstForm.Show();
            this.Hide(); // скрыть окно меню
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e) // кнопка "Выход"
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

        private void button10_Click(object sender, EventArgs e) // кнопка "Очистить поля"
        {
            Clear();
        }
        private void Clear() // метод для очистки строк
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // поле для ввода вершины в глубину
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // поле для ввода вершины в ширину
        {

        }

    }
}