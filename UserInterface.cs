using System;

namespace CTDL_exam
{
    class UI
    {
        public static int len = Program.len;

        // Gạch đầu ở trên
        public static void DashTop ()
        {
            string str = "";
            str = str.PadRight(len - 2, '_');
            str = " " + str;
            Console.WriteLine(str);
            WriteLine("");
        }

        // Gạch chân ở dưới
        public static void DashBot ()
        {
            string str = "";
            str = str.PadRight(len - 2, '_');
            str = "|" + str + "|";
            Console.WriteLine(str);
        }

        // UI.WriteLine
        // Căn trái
        public static void WriteLine (string str)
        {
            string[] strarr = str.Split('\n');
            for (int i = 0; i < strarr.Length; i++)
            {
                Text(strarr[i]);
            }

        }

        private static void Text (string str)
        {
            str = "    " + str;
            str = str.PadRight(len - 2);
            str = "|" + str + "|";
            Console.WriteLine(str);
        }

        // Căn giữa
        public static void TextCenter (string str)
        {
            int i = str.Length;
            if (i%2 == 1)
            {
                i++;
                str = str + " ";
            }
            
            string space = "";
            space = space.PadRight((len-2-i)/2);

            str = "|" + space + str + space + "|";
            Console.WriteLine(str);
        }

        // Đọc dữ liệu
        public static void ReadLine (string content, ref string data)
        {
            content = "|" + "    " + content + ": ";
            Console.Write(content);
            data = Console.ReadLine();
        }
    }
}