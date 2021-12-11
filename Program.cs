using System;

namespace CTDL_exam
{
    class Program
    {
        public static BinarySearchTree monhoctree = new BinarySearchTree();
        public static int len = 40;
        // Code hàm chức năng ở dưới Hàm main
        
        static void Themphantu(BinarySearchTree tree)
        {
            Console.Clear();
            Console.WriteLine("Thêm phần tử");
            string[] Title = { "Mã môn", "Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(i * 15, 1);
                Console.WriteLine(Title[i]);
                Console.SetCursorPosition(i * 15, 2);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));

        }

        static void Suaphantu(BinarySearchTree tree,string maMonHoc)
        {
            tree.Remove(maMonHoc);
            Console.WriteLine("Chỉnh sửa môn học có mã môn là: {0}",maMonHoc);
            string[] Title = { "Mã môn học","Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            Arr[0] = maMonHoc;
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine(Title[i]);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
        }

        static void Main(string[] args)
        {

            //Console.Clear();
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("CTDL exam");

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
            // Sửa môn học
            Console.Write("\nCó muốn sửa môn học không ? (1: có, 0: không): ");
            a = int.Parse(Console.ReadLine());

            if(a==1)
            {
            Console.Write("Nhập mã môn học cần chỉnh sửa: ");
            string maMonHoc = Console.ReadLine();
            Suaphantu(monhoctree, maMonHoc);
            Console.WriteLine("Các môn sau khi sửa");
            monhoctree.TraverseInOrder(monhoctree.Root);
            }
            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            
            System.Console.WriteLine("____________________");
            //Sắp xếp theo Ngày
            System.Console.WriteLine("Sắp xếp theo ngày ");
            BinarySearchTree tree3=new BinarySearchTree();
            FileData.ReadFile(tree3);
            tree3.TraversePostOrder1(tree3.Root,tree3);
            tree3.TraversePostOrder(tree3.Root);
            
            System.Console.WriteLine("____________________");
            //Sắp xếp theo TC
            System.Console.WriteLine("Sắp xếp theo TC ");
            BinarySearchTree tree2=new BinarySearchTree();
            FileData.ReadFile(tree2);
            tree2.TraversePreOrder1(tree2.Root,tree2);
            tree2.TraversePreOrder(tree2.Root);
            
            Console.WriteLine("____________________");
            //Săp xêp theo mã môn học
            System.Console.WriteLine("Sắp xếp theo mã môn học ");
            BinarySearchTree tree1=new BinarySearchTree();
            FileData.ReadFile(tree1);
            tree1.TraverseInOrder1(monhoctree.Root,tree1);
            tree1.TraverseInOrder(tree1.Root);
            
            Console.WriteLine("____________________\n");
            
            //Tìm kiếm theo mã môn học
            System.Console.WriteLine("Nhập vào mã môn học cần tìm kiếm: ");
            string value1 = Console.ReadLine();
            System.Console.WriteLine(monhoctree.FindTheoMaMon(value1).Data);

            //Tìm kiếm theo tên giảng viên
            System.Console.WriteLine("Nhập vào tên giảng viên cần tìm kiếm: ");
            string value2 = Console.ReadLine();
            System.Console.WriteLine(monhoctree.FindTheoGiangVien(value2).Data); 
            
            


        }
    }
}
