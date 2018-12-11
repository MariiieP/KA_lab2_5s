using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelingSalesman
{
    public static class Method
    {
        public static int[] reduce(int[] array, int min)   //вычитает минимальное значение в строке из строки
        {
            // уменьшаем на min
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = array[j] - min;
            }
            // Возвращаем измененный массив
            return array;
        }

        public static int Minimum(int[] array)
        {
            // Объявление значения по умолчанию как нечто меньшее, чем бесконечность, но превышающее допустимые значения
            int min = 9000;
            // находим минимальное значение
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            // Если минимум не изменился, то возвращаем ноль
            if (min == 9000)
            {
                return 0;
            }
            // иначе возвращаем минимальное значение
            else
            {
                return min;
            }
        }

        public static void expand(List<Solution> l, Solution sltn)
        {
            // Число пройденных городов
            int length = sltn.remainingcity.Length;
            for (int i = 0; i < length; i++)
            {
                if (sltn.remainingcity[i] == 0) continue;
                int cost = 0;
                cost = sltn.cost;
                int city = sltn.city;

                List<Int32> st = new List<int>();
                for (int st_i = 0; st_i < sltn.stack.Count(); st_i++)
                {
                    int k = sltn.stack.ElementAt(st_i);
                    st.Add(k);
                }
                st.Add(sltn.remainingcity[i]);
                int[,] temparray = new int[sltn.matrix.GetLength(0), sltn.matrix.GetLength(0)];
                for (int i_1 = 0; i_1 < temparray.GetLength(0); i_1++)
                {
                    for (int i_2 = 0; i_2 < temparray.GetLength(0); i_2++)
                    {
                        temparray[i_1, i_2] = sltn.matrix[i_1, i_2];
                    }
                }
                cost = cost + temparray[city, sltn.remainingcity[i]];
                for (int j = 0; j < temparray.GetLength(0); j++)
                {
                    temparray[city, j] = 9999;
                    temparray[j, sltn.remainingcity[i]] = 9999;
                }
                temparray[sltn.remainingcity[i], 0] = 9999;
                //Уменьшение этой матрицы в соответствии с указанными правилами
                int cost1 = reduceAll(temparray, cost);

                Solution finall = new Solution(sltn.matrix.GetLength(0));
                finall.city = sltn.remainingcity[i];
                finall.cost = cost1;
                finall.matrix = temparray;
                int[] temp_array = new int[sltn.remainingcity.Length];
                // Ограничение расширения в случае обратного слежения
                for (int i_3 = 0; i_3 < temp_array.Length; i_3++)
                {
                    temp_array[i_3] = sltn.remainingcity[i_3];
                }
                temp_array[i] = 0;
                finall.remainingcity = temp_array;
                finall.city_left_to_expand = sltn.city_left_to_expand - 1;
                finall.stack = st;
                l.Add(finall);
            }
        }

        public static int reduceAll(int[,] array, int cost)
        {
            // Массивы для хранения строк и столбцов для уменьшения
            int[] array_to_reduce = new int[array.GetLength(0)];
            int[] reduced_array = new int[array.GetLength(0)];
            // Переменная для хранения обновленного веса
            int new_cost = cost;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array_to_reduce[j] = array[i, j];
                }

                int minimum = Minimum(array_to_reduce);
                if (minimum != 0)
                {
                    // Обновляем вес
                    new_cost = minimum + new_cost;
                    // Уменьшаем строку
                    reduced_array = reduce(array_to_reduce, minimum);
                    // Кладем уменьшенную строку обратно в исходный массив
                    for (int k = 0; k < array.GetLength(0); k++)
                    {
                        array[i, k] = reduced_array[k];
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array_to_reduce[j] = array[j, i];
                }

                int minimum = Minimum(array_to_reduce);
                if (minimum != 0)
                {
                    // Обновляем текущий вес
                    new_cost = minimum + new_cost;
                    // Уменьшаем столбец
                    reduced_array = reduce(array_to_reduce, minimum);
                    // Кладем уменьшенный столбец обратно в исходный массив
                    for (int k = 0; k < array.GetLength(0); k++)
                    {
                        array[k, i] = reduced_array[k];
                    }
                }
            }
            return new_cost;
        }

        public static int[] decreasing_sort(int[] temp)
        {
            int[] y = new int[temp.Length];
            // Извлечение содержимого массива
            for (int j = 0; j < temp.Length; j++)
            {
                y[j] = temp[j];
            }

            // Сортируем
            Array.Sort(y);
            Array.Reverse(y);

            int[] to_be_returned = new int[temp.Length];
            // Возврат отсортированного содержимого в массив
            for (int j = 0; j < temp.Length; j++)
            {
                for (int j1 = 0; j1 < temp.Length; j1++)
                {
                    if (temp[j] == y[j1])
                    {
                        to_be_returned[j] = j1;
                    }
                }
            }
            return to_be_returned;
        }
    }
}
