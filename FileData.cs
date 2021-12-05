using System;
using System.IO;


namespace nhap0
{
    class FileData
    {
        static int n = 0, p = 10, q = 7;

        static string[,] monhoc;
        static string file = "text.txt";


        public static void WriteFile(string[,] monhoc)
        {
            string[] inputarr = new string[p];
            string[] temp = new string[q];
            
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < monhoc.GetLength(1); j++)
                {
                    temp[j] = monhoc[i,j];
                }

                inputarr[i] = string.Join("~",temp);

            }

            string input = string.Join("`",inputarr);

            StreamWriter sw;
            sw = File.CreateText(file);
            sw.Write(input);
            sw.Close();
        }

        public static void ReadFile(string[,] monhoc)
        {
            StreamReader sr;
            sr = File.OpenText(file);
            string output = sr.ReadToEnd();
            sr.Close();

            string[] outputarr = output.Split('`');
            
            
            string[] temp;
            for (int i = 0; i < p; i++)
            {
                string a = outputarr[i];
                temp = a.Split('~');

                for (int j = 0; j < monhoc.GetLength(1); j++)
                {
                    monhoc[i,j] = temp[j];
                }
            }
        }



    }
}