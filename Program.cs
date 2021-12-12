using System;
using System.Text;

namespace CTDL_exam
{
    class Program
    {
        public static BinarySearchTree monhoctree = new BinarySearchTree();
        public static int len = 50;
        // Code hàm chức năng ở dưới Hàm main
        
        static void Themphantu(BinarySearchTree tree)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Clear();
            UI.WriteLine("Thêm phần tử");
            string[] Title = { "Mã môn", "Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            for (int i = 0; i < 7; i++)
            {
                UI.WriteLine(Title[i]);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));

        }

        static void Suaphantu(BinarySearchTree tree,string maMonHoc)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            tree.Remove(maMonHoc);
            UI.WriteLine("Chỉnh sửa môn học có mã môn là: " + maMonHoc);
            string[] Title = { "Mã môn học","Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            Arr[0] = maMonHoc;
            for (int i = 1; i < Arr.Length; i++)
            {
                UI.WriteLine(Title[i]);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
        }

        static void InMenu ()
        {
            UI.DashTop();
            UI.TextCenter("Menu");
            UI.WriteLine("\n1. Hiển thị chi tiết một môn học");
            UI.WriteLine("2. Thêm");
            UI.WriteLine("3. Sửa");
            UI.WriteLine("4. Xóa");
            UI.WriteLine("5. Tìm kiếm theo mã môn");
            UI.WriteLine("6. Tìm kiếm theo giảng viên");
            UI.WriteLine("7. Sắp xếp theo ngày");
            UI.WriteLine("8. Sắp xếp theo TC");
            UI.WriteLine("9. Sắp xếp theo mã môn");
            UI.WriteLine("10. Điểm\n");
            UI.WriteLine("0. Thoát chương trình");
            UI.DashBot();

        }
        static void Main(string[] args)
        {

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            BinarySearchTree tree1;

            // Đọc file text lấy dữ liệu
            FileData.ReadFile(monhoctree);
nhan:       
            Console.Clear();
            UI.DashTop();
            UI.TextCenter("Dữ liệu có sẵn");
            UI.WriteLine(monhoctree.PrintNameInOrder(monhoctree.Root));
            UI.DashBot();

            InMenu();

            UI.DashTop();
            UI.Write("Chọn chức năng: ");
            Console.SetCursorPosition(21, 21 + monhoctree.CountNode(monhoctree.Root));
            int n = int.Parse(Console.ReadLine());

/* 
            1. Hiển thị chi tiết một môn học
            2. Thêm
            3. Sửa
            4. Xóa
            5. Tìm kiếm mã môn
            6. Tìm kiếm giảng viên
            7. Sắp xếp theo ngày
            8. Sắp xếp theo TC
            9. Sắp xếp theo mã môn
            10. Điểm
 */
            switch (n)
            {
                case 1: UI.WriteLine(monhoctree.Detail()); Console.ReadKey(); break;
                case 2: Themphantu(monhoctree); break;
                case 3:UI.Write("Nhập mã môn học cần chỉnh sửa: ");
                string maMonHoc = Console.ReadLine();
                Suaphantu(monhoctree, maMonHoc); break;

                case 4: UI.Write("Nhập mã môn muốn xóa: ");
                string del = Console.ReadLine();
                if (monhoctree.FindTheoMaMon(del) == null)
                    UI.WriteLine("Xóa không thành công. Mã môn học không đúng");
                monhoctree.Remove(del); 
                Console.ReadKey(); break;

                case 5: UI.WriteLine("Nhập vào mã môn học cần tìm kiếm: ");
            string value1 = Console.ReadLine();
            UI.WriteLine(monhoctree.PrintDetail(monhoctree.FindTheoMaMon(value1))); 
            Console.ReadKey(); break;

                case 6:UI.WriteLine("Nhập vào tên giảng viên cần tìm kiếm: ");
            string value2 = Console.ReadLine();
            UI.WriteLine(monhoctree.FindTheoGiangVien(value2));
            Console.ReadKey(); break;

                case 7: tree1 = new BinarySearchTree();
            tree1.SapXepDays(monhoctree.Root,tree1);
            tree1.PrintDetailInOrder(tree1.Root);
            Console.ReadKey(); break;

                case 8: tree1 = new BinarySearchTree();
            tree1.SapXepTC(monhoctree.Root,tree1);
            tree1.PrintDetailInOrder(tree1.Root);
            Console.ReadKey(); break;

                case 9: tree1 = new BinarySearchTree();
            tree1.SapXepID(monhoctree.Root,tree1);
            tree1.PrintDetailInOrder(tree1.Root);
            Console.ReadKey(); break;

                case 10:
                UI.WriteLine(monhoctree.Scoring(monhoctree.Root));
                Console.ReadKey(); break;
                default: break;
            }
            if (n != 0)
                goto nhan;

            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            
        }
    }
}
