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
using System.Collections;
namespace travelingSalesman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            increaseVertex.Maximum = int.MaxValue;
        }
        public int vertecesCount = 0;
        public int cellsNumber = 0;

        static int d = (int)DateTime.Now.Ticks;
        Random rnd = new Random(d);

        private void Form1_Load(object sender, EventArgs e)
        {
            increaseVertex_ValueChanged(sender, e);
        }

        private void increaseVertex_ValueChanged(object sender, EventArgs e)
        {

            vertecesCount = (int)increaseVertex.Value;
            cellsNumber = (int)increaseVertex.Value + 1;

            gridMatrix.ColumnCount = cellsNumber;
            gridMatrix.RowCount = cellsNumber;

            gridMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[0, i].Value = i;
                gridMatrix[0, i].Style.BackColor = Color.LightGray;
                gridMatrix[i, 0].Value = gridMatrix[0, i].Value;
                gridMatrix[i, 0].Style.BackColor = gridMatrix[0, i].Style.BackColor;
            }

            //заполнение диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[i, i].Value = 0;
                gridMatrix[i, i].Style.BackColor = Color.Bisque;
            }
        }

        private void gridMatrix_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //запрет на изменение значений по диагонали
            if (e.RowIndex == e.ColumnIndex)
                e.Cancel = true;

            //запрет на редактирование ячеек
            //отвечающих за нумерацию строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                if (e.RowIndex == 0 && e.ColumnIndex == i || (e.RowIndex == i && e.ColumnIndex == 0))
                    e.Cancel = true;
            }
        }

        private void gridMatrix_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }


        }

        private void gridMatrix_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridMatrix.BeginEdit(true);
        }

        private void btnRandomly_Click(object sender, EventArgs e)
        {
            vertecesCount = (int)increaseVertex.Value;
            cellsNumber = (int)increaseVertex.Value + 1;

            gridMatrix.ColumnCount = cellsNumber;
            gridMatrix.RowCount = cellsNumber;

            gridMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            //нумерация строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[0, i].Value = i;
                gridMatrix[0, i].Style.BackColor = Color.LightGray;
                gridMatrix[i, 0].Value = gridMatrix[0, i].Value;
                gridMatrix[i, 0].Style.BackColor = gridMatrix[0, i].Style.BackColor;
            }

            //заполнение диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[i, i].Value = 0;
                gridMatrix[i, i].Style.BackColor = Color.Bisque;
            }

            //случайное заполнение матрицы
            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = 1; j < cellsNumber; j++)
                {
                    if (i == j)
                        gridMatrix[i, i].Value = 0;
                    else
                        gridMatrix[i, j].Value = rnd.Next(1, 21);
                }
            }
        }

        private void btnPathFind_Click(object sender, EventArgs e)
        {
            int[,] array = new int[vertecesCount,vertecesCount];

            for (int j = 0; j < vertecesCount; j++)
                for (int k = 0; k < vertecesCount; k++)
                    array[j, k] = Convert.ToInt32(gridMatrix.Rows[j+1].Cells[k+1].Value);

            // Выполнение первого сокращения веса матрицы
            int x = 0;
            x = Method.reduceAll(array, x);
            Solution sltn = new Solution(vertecesCount);

            //Корень дерева начинается с города 0
            sltn.city = 0;
            sltn.cost = x;
            sltn.matrix = array;
            sltn.stack.Add(0);
            sltn.remainingcity = new int[vertecesCount - 1];
            sltn.city_left_to_expand = vertecesCount - 1;

            for (int o = 0; o < vertecesCount - 1; o++)
            {
                sltn.remainingcity[o] = o + 1;
            }
            //переменная для отслеживания количества пройденных узлов
            int count = 0;
            //Список для сохранения элементов дерева
            List<Solution> s = new List<Solution>();
            //Кладем корень в список
            s.Add(sltn);
            //Временная переменная для хранения наилучшего найденного решения
            Solution temp_best_solution = new Solution(vertecesCount);
            int current_best_cost = 100000;
      
            while (s.Count != 0)
            {
                List<Solution> main = new List<Solution>();
                Solution elem_sltn = new Solution(vertecesCount);

                elem_sltn = s.ElementAt(s.Count - 1);
                s.RemoveAt(s.Count - 1);

                //Расширяем список только в том случае, если узел не является листом, и если его вес лучше, 
                //чем лучший до сих пор
                if (elem_sltn.city_left_to_expand == 0)
                {
                    //Сравнение веса этого узла с лучшими и, при необходимости, обновление
                    if (elem_sltn.cost <= current_best_cost)
                    {
                        temp_best_solution = elem_sltn;
                        current_best_cost = temp_best_solution.cost;
                    }
                }
                else if (elem_sltn.city_left_to_expand != 0)
                {
                    if (elem_sltn.cost <= current_best_cost)
                    {
                        count++;
                        // Расширение последнего элемента, вытащенного из списка
                        Method.expand(main, elem_sltn);

                        //Определение порядка, в котором узлы должны быть занесены в список
                        int[] order = new int[main.Count];
                        for (int pi = 0; pi < main.Count; pi++)
                        {
                            Solution help = (Solution)main[pi];
                            order[pi] = help.cost;
                        }
                        // Сортировка узлов в порядке убывания в зависимости от их веса
                        int[] temp = Method.decreasing_sort(order);
                        for (int pi = 0; pi < temp.Length; pi++)
                        {
                            // Кладем узлы в список в обратном порядке
                            s.Add((Solution)main[temp[pi]]);
                        }
                    }
                }
            }

            // Проверяем, что, если найдено лучшее решение
            if (temp_best_solution.stack.Count == vertecesCount & temp_best_solution.cost < 9000)
            {
                int cnt = temp_best_solution.stack.Count;
                for (int st_i = 0; st_i < cnt; st_i++)
                {
                    int k = temp_best_solution.stack.ElementAt(0);
                    temp_best_solution.stack.RemoveAt(0);
                    textBox1.Text += k+1 + ", ";
                }
                textBox1.Text += " 1."+'\r'+'\n';
                textBox1.Text += current_best_cost;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
