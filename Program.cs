using System;

namespace CTDL_exam
{
    class Program
    {
        static void Themphantu (BinarySearchTree tree)
        {
            Console.Clear();
            Console.WriteLine("Thêm phần tử");
            string[] Title = {"Mã môn", "Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học"};
            string[] Arr = new string[7];
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(i*15, 1);
                Console.WriteLine(Title[i]);
                Console.SetCursorPosition(i*15, 2);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));

        }

        static void Main(string[] args)
        {
<<<<<<< HEAD
            Console.WriteLine("Hello Trung");

=======
            Console.WriteLine("Hi World");
>>>>>>> 08816dc73a2dd37d588e15abf5322f6f65412132


            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            BinarySearchTree monhoctree = new BinarySearchTree();

            // Đọc file text lấy dữ liệu
            FileData.ReadFile(monhoctree);
            Console.WriteLine("Dữ liệu có sẵn");
            monhoctree.TraverseInOrder(monhoctree.Root);

            Console.Write("\nCó muốn thêm môn học không ? (1: có, 0: không): ");
            int a = int.Parse(Console.ReadLine());

            if (a == 1)
            {
                Themphantu(monhoctree);
                Console.WriteLine("Các môn sau khi thêm");
                monhoctree.TraverseInOrder(monhoctree.Root);
            }


            Console.Write("\nCó muốn xóa môn học không ? (1: có, 0: không): ");
            a = int.Parse(Console.ReadLine());

            if (a == 1)
            {
                Console.Write("Nhập mã môn muốn xóa: ");
                string del = Console.ReadLine();
                monhoctree.Remove(del);
                Console.WriteLine("Các môn sau khi xóa");
                monhoctree.TraverseInOrder(monhoctree.Root);
            }
            
            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
        }
    }
}
