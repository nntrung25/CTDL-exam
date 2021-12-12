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
            Console.WriteLine("Thêm phần tử");
            string[] Title = { "Mã môn", "Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(Title[i]);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));

        }

        static void Suaphantu(BinarySearchTree tree,string maMonHoc)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            tree.Remove(maMonHoc);
            Console.WriteLine("Chỉnh sửa môn học có mã môn là: {0}",maMonHoc);
            string[] Title = { "Mã môn học","Tên môn", "Số tín chỉ", "Bắt đầu", "Kết thúc", "Tên giảng viên", "Điểm môn học" };
            string[] Arr = new string[7];
            Arr[0] = maMonHoc;
            for (int i = 1; i < Arr.Length; i++)
            {
                Console.WriteLine(Title[i]);
                Arr[i] = Console.ReadLine();
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
        }

        static void InMenu ()
        {
            UI.DashTop();
            UI.TextCenter("Menu");
            UI.TextNormal("1. Hiển thị chi tiết một môn học");
            UI.TextNormal("2. Thêm");
            UI.TextNormal("3. Sửa");
            UI.TextNormal("4. Xóa");
            UI.TextNormal("5. Tìm kiếm theo mã môn");
            UI.TextNormal("6. Tìm kiếm theo giảng viên");
            UI.TextNormal("7. Sắp xếp theo ngày");
            UI.TextNormal("8. Sắp xếp theo TC");
            UI.TextNormal("9. Sắp xếp theo mã môn");
            UI.TextNormal("10. Điểm\n");
            UI.TextNormal("0. Thoát chương trình");
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
            UI.TextNormal(monhoctree.PrintNameInOrder(monhoctree.Root));
            UI.DashBot();

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
            7. Sắp xếp theo ngày
            8. Sắp xếp theo TC
            9. Sắp xếp theo mã môn
            10. Điểm
 */
            switch (n)
            {
                case 1: monhoctree.PrintDetailInOrder(monhoctree.Root); Console.ReadKey(); break;
                case 2: Themphantu(monhoctree); break;
                case 3:Console.Write("Nhập mã môn học cần chỉnh sửa: ");
                string maMonHoc = Console.ReadLine();
                Suaphantu(monhoctree, maMonHoc); break;

                case 4: Console.Write("Nhập mã môn muốn xóa: ");
                string del = Console.ReadLine();
                if (monhoctree.FindTheoMaMon(del) == null)
                    Console.WriteLine("Xóa không thành công. Mã môn học không đúng");
                monhoctree.Remove(del); 
                Console.ReadKey(); break;

                case 5: System.Console.WriteLine("Nhập vào mã môn học cần tìm kiếm: ");
            string value1 = Console.ReadLine();
            System.Console.WriteLine(monhoctree.FindTheoMaMon(value1).Data); 
            Console.ReadKey(); break;

                case 6:System.Console.WriteLine("Nhập vào tên giảng viên cần tìm kiếm: ");
            string value2 = Console.ReadLine();
            UI.TextNormal(monhoctree.FindTheoGiangVien(value2));
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
            
                case 10: Console.WriteLine("Điểm"); break;
                default: break;
            }
            if (n != 0)
                goto nhan;

            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            
        }
    }
}
