using System;
using System.Text;

namespace CTDL_exam
{
    class Program
    {
        public static BinarySearchTree monhoctree = new BinarySearchTree();
        public static int len = 50;
        public static string data;

        // In menu
        static void InMenu ()
        {
            Console.Clear();

            UI.DashTop();
            UI.TextCenter("SỬ DỤNG");
            for (int i = 0; i < 13; i++)
            {
                UI.WriteLine("");
            }
            UI.DashBot();

            UI.DashTop();
            UI.TextCenter("MENU");
            UI.WriteLine("\n1. Hiển thị chi tiết một môn học");
            UI.WriteLine("2. Thêm");
            UI.WriteLine("3. Sửa");
            UI.WriteLine("4. Xóa");
            UI.WriteLine("5. Tìm kiếm");
            UI.WriteLine("6. Sắp xếp");
            UI.WriteLine("7. Điểm\n");
            UI.WriteLine("0. Thoát chương trình");
            UI.DashBot();

            UI.DashTop();
            UI.TextCenter("DỮ LIỆU");
            UI.WriteLine(monhoctree.PrintNameInOrder(monhoctree.Root));
            UI.DashBot();

        }
        
        static void Main(string[] args)
        {

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            // Đọc file text lấy dữ liệu
            FileData.ReadFile(monhoctree);
nhan:       
            InMenu();

            Console.SetCursorPosition(0, 4);
            UI.ReadLine("Chọn chức năng", ref data);

/* 
            1. Hiển thị chi tiết một môn học
            2. Thêm
            3. Sửa
            4. Xóa
            5. Tìm kiếm mã môn + giảng viên
            6. Sắp xếp theo ngày + TC + mã môn
            7. Điểm
 */
            switch (data)
            {
                case "1": UI.WriteLine(monhoctree.Detail());  break;
                case "2": monhoctree.Themphantu(monhoctree); break;
                case "3": monhoctree.Suaphantu(monhoctree); break;
                case "4": monhoctree.Xoaphantu(monhoctree); break;
                case "5": monhoctree.Timkiem(monhoctree); break;
                case "6": monhoctree.Sapxep(monhoctree); break;

                case "7": UI.WriteLine(monhoctree.Scoring(monhoctree.Root)); break;

                default: if (data != "0") UI.WriteLine("Nhập lỗi..."); break;
            }

            if (data != "0")
            {
                Console.ReadKey();
                goto nhan;
            }

            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            Console.Clear();
            Console.WriteLine("-----Kết thúc chương trình-----");
            
        }
    }
}
