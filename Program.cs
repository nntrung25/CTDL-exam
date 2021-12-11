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

        static void InMenu ()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Hiển thị chi tiết một môn học");
            Console.WriteLine("2. Thêm");
            Console.WriteLine("3. Sửa");
            Console.WriteLine("4. Xóa");
            Console.WriteLine("5. Tìm kiếm theo mã môn");
            Console.WriteLine("6. Tìm kiếm theo giảng viên");
            Console.WriteLine("7. Sắp xếp");
            Console.WriteLine("8. Điểm\n");

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

            InMenu();
            Console.Write("Chọn chức năng: ");
            int n = int.Parse(Console.ReadLine());

/* 
            1. Hiển thị chi tiết một môn học
            2. Thêm
            3. Sửa
            4. Xóa
            5. Tìm kiếm mã môn
            6. Tìm kiếm giảng viên
            7. Sắp xếp
            8. Điểm
 */
            switch (n)
            {
                case 1: 
                case 2: Themphantu(monhoctree); break;
                case 3:Console.Write("Nhập mã môn học cần chỉnh sửa: ");
                string maMonHoc = Console.ReadLine();
                Suaphantu(monhoctree, maMonHoc); break;
                case 4: Console.Write("Nhập mã môn muốn xóa: ");
                string del = Console.ReadLine();
                monhoctree.Remove(del); break;
                case 5: System.Console.WriteLine("Nhập vào mã môn học cần tìm kiếm: ");
            string value1 = Console.ReadLine();
            System.Console.WriteLine(monhoctree.FindTheoMaMon(value1).Data); break;
                case 6:System.Console.WriteLine("Nhập vào tên giảng viên cần tìm kiếm: ");
            string value2 = Console.ReadLine();
            System.Console.WriteLine(monhoctree.FindTheoGiangVien(value2).Data); break;
                case 7:
                default: break;
            }
            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            
            System.Console.WriteLine("____________________");
            //Sắp xếp theo Ngày
            System.Console.WriteLine("Sắp xếp theo ngày ");
            BinarySearchTree tree3=new BinarySearchTree();
            FileData.ReadFile(tree3);
            tree3.TraversePostOrder1(tree3.Root,tree3);
            tree3.TraverseInOrder(tree3.Root);
            
            System.Console.WriteLine("____________________");
            //Sắp xếp theo TC
            System.Console.WriteLine("Sắp xếp theo TC ");
            BinarySearchTree tree2=new BinarySearchTree();
            FileData.ReadFile(tree2);
            tree2.TraversePreOrder1(tree2.Root,tree2);
            tree2.TraverseInOrder(tree2.Root);
            
            Console.WriteLine("____________________");
            //Săp xêp theo mã môn học
            System.Console.WriteLine("Sắp xếp theo mã môn học ");
            BinarySearchTree tree1=new BinarySearchTree();
            FileData.ReadFile(tree1);
            tree1.TraverseInOrder1(monhoctree.Root,tree1);
            tree1.TraverseInOrder(tree1.Root);
            
        }
    }
}
