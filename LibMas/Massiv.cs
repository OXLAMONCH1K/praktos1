using System;
using System.Data;
using System.IO;

namespace LibMas
{
    public class Massiv
    {
        public static void InitMas(out int[] mas, int count, int randMax)
        {
            Random rnd = new Random();
            mas = new int[count];
            for (int i = 0; i < count; i++)
            {
                mas[i] = rnd.Next(-randMax, randMax + 1);
            }
        } 
        public static void ClearMas(ref int[] mas)
        {
            mas = new int[0];
        }
        public static void SaveMas(int[] mas, string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            file.WriteLine(mas.Length);
            for (int i = 0; i < mas.Length; i++)
            {
                file.WriteLine(mas[i]);
            }
            file.Close();
        }

        public static int[] OpenMas(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            int len = Convert.ToInt32(file.ReadLine());
            int[] mas = new int[len];
            for (int i = 0; i < len; i++)
            {
                mas[i] = Convert.ToInt32(file.ReadLine());
            }
            file.Close();
            return mas;
        }

        public static DataTable ToDataTable(int[] mas)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < mas.Length; i++)
            {
                table.Columns.Add(i.ToString(), typeof(int));
            }
            DataRow row = table.NewRow();
            for (int i = 0; i < mas.Length; i++)
            {
                row[i] = mas[i];
            }
            table.Rows.Add(row);
            return table;
        }

        public static int[] FromDataTable(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
            {
                return new int[0];
            }
            int[] mas = new int[table.Columns.Count];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Convert.ToInt32(table.Rows[0][i]);
            }
            return mas;
        }
    }
}