namespace Lib_5
{
 
    public class Calc
    {
        public static long MultLessThree(int[] mas, out int count)
        {
            long result = 1;    
            count = 0;         

            for (int i = 0; i < mas.Length; i++)
            {
             
                if (mas[i] < 3)
                {
                    result = result * mas[i];
                    count++;
                } 
            }

          
            if (count == 0)
            {
                result = 0;
            }
            return result;
        }
    }
}