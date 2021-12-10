using System;
using System.IO;


namespace CTDL_exam
{
    class FileData
    {
        static int p, q = 7;

        // static string[,] monhoc;
        static string file = "text.txt";

        // Ghi file text
        // Chương trình ghi file chính
        public static void WriteFile(BinarySearchTree tree)
        {
            p = tree.CountNode(tree.Root);
            string[,] monhoc = new string[tree.CountNode(tree.Root),7];
            TreeToArray(tree, monhoc, p);

            string[] inputarr = new string[p];
            string[] temp = new string[q];
            
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < q; j++)
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

        static int i = 0;
        // Chương trình phụ: Chương trình con của chuyển cây thành mảng
        private static void WriteInOrder(Node parent, string[,] array)
        {
            if (parent != null)
            {
                WriteInOrder(parent.LeftNode, array);
                array[i,0] = parent.Data.getID();
                array[i,1] = parent.Data.getName();
                array[i,2] = Convert.ToString(parent.Data.getTC());
                array[i,3] = parent.Data.getStart();
                array[i,4] = parent.Data.getEnd();
                array[i,5] = parent.Data.getTeacher();
                array[i,6] = Convert.ToString(parent.Data.getGPA());
                i++;
                WriteInOrder(parent.RightNode, array);  
            }
        }

        // Chương trình phụ: chuyển cây thành mảng
        private static void TreeToArray (BinarySearchTree tree, string[,] array, int p)
        {
            Node parent = tree.Root;
            FileData.WriteInOrder(parent, array);
        }

        // Đọc file text
        // Chương trình đọc file chính
        public static void ReadFile(BinarySearchTree tree)
        {
            StreamReader sr;
            sr = File.OpenText(file);
            string output = sr.ReadToEnd();
            sr.Close();

            string[] outputarr = output.Split('`');
            
            p = outputarr.Length;
            string[,] monhoc = new string[p, 7];

            string[] temp = new string [7];

            for (int i = 0; i < p; i++)
            {
                string a = outputarr[i];
                temp = a.Split('~');
                

                for (int j = 0; j < monhoc.GetLength(1); j++)
                {
                    monhoc[i,j] = temp[j];
                }
            }
            ArrayToTree(tree, monhoc);
        }

        // Chương trình phụ: Chuyển mảng về thành cây
        private static void ArrayToTree (BinarySearchTree tree, string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                tree.Insert(new monhoc (array[i,0], array[i,1], int.Parse(array[i,2]), array[i,3], array[i,4], array[i,5], float.Parse(array[i,6])));
            }
        }


    }
}