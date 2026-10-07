using System;
using System.Data;
using System.Windows;
using Microsoft.Win32;
using LibMas;   
using Lib_5;    

namespace Prakt1
{
    public partial class MainWindow : Window
    {
        int[] mas = new int[0];    
        DataTable table;         

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowMas()
        {
            table = Massiv.ToDataTable(mas);
            dataGrid.ItemsSource = table.DefaultView;
        } 

        private void ReadMas()
        {
            dataGrid.CommitEdit();
            mas = Massiv.FromDataTable(table);
        }
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(txtCount.Text);   
                int randMax = Convert.ToInt32(txtRange.Text);  
                Massiv.InitMas(out mas, count, randMax);
                ShowMas();
                txtResult.Text = "Результат: ";
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректные целые числа n и диапазон",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Massiv.ClearMas(ref mas);
            ShowMas();
            txtResult.Text = "Результат: ";
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadMas();
                if (mas.Length == 0)
                {
                    MessageBox.Show("Массив пуст. Сначала заполните массив.",
                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int count;
                long result = Calc.MultLessThree(mas, out count);

                if (count == 0)
                {
                    txtResult.Text = "Результат: чисел меньше 3 в массиве нет";
                }
                else
                {
                    txtResult.Text = "Результат: произведение чисел < 3 = " + result +
                                     "  (найдено чисел: " + count + ")";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В таблице есть некорректные значения",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ReadMas();
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы|*.txt|Все файлы (*.*)|*.*";
            save.Title = "Сохранение массива";
            if (save.ShowDialog() == true)
            {
                Massiv.SaveMas(mas, save.FileName);
            }
        } 

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы|*.txt|Все файлы (*.*)|*.*";
            open.Title = "Открытие массива";
            if (open.ShowDialog() == true)
            {
                try
                {
                    mas = Massiv.OpenMas(open.FileName);
                    ShowMas();
                    txtResult.Text = "Результат: ";
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверный формат файла",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Разработчик: Бучмеюк Михаил, группа ИСП-31\n" +
                "Практическая работа №1, вариант 5\n\n" +
                "Задание: Ввести n целых чисел. Найти произведение чисел < 3. " +
                "Результат вывести на экран.",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } 
    } 
} 