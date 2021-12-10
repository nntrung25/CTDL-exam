using System;

namespace CTDL_exam
{
    class UI
    {
        public static int len = Program.len;
        public static void DashTop ()
        {
            string str = "";
            str = str.PadRight(len - 2, '_');
            str = " " + str;
            Console.WriteLine(str);
        }

        public static void DashBot ()
        {
            string str = "";
            str = str.PadRight(len - 2, '_');
            str = "|" + str + "|";
            Console.WriteLine(str);
        }

        public static void TextNormal (string str)
        {
            str = "    " + str;
            str = str.PadRight(len - 2);
            str = "|" + str + "|";
            Console.WriteLine(str);
        }

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
    }
}