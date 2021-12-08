using System;
using System.IO;

namespace CTDL_exam
{
    class Program
    {
        static string file = "text.txt";
        static int n = 0, p = 10, q = 7;
        // lớp 10 người p = 10, 7 trường dữ liệu trong 1 môn q = 7

        static string[,] monhoc = new string[p, q];

        // Ghi file

        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            BinarySearchTree monhoctree = new BinarySearchTree();
            
            Console.WriteLine("Nhập số phần tử cây môn học");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập cây môn học");
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Nhập: mã môn, tên môn, số tín chỉ, bắt đầu, kết thúc, giảng viên, điểm ");
                string[] Arr = new string[7];
                for (int j = 0; j < 7; j++)
                {
                    Arr[j] = Console.ReadLine();
                }
                monhoctree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
            }
            Console.WriteLine("count "+monhoctree.CountNode(monhoctree.Root));
            Console.WriteLine("before");
            monhoctree.TraverseInOrder(monhoctree.Root);
            
            FileData.WriteFile(monhoctree);

            monhoc = new string[a, q];
            FileData.ReadFile(monhoctree);
            Console.WriteLine("\nafter");
            monhoctree.TraversePreOrder(monhoctree.Root);

        }
    }
}
