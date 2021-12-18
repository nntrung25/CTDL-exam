using System;

namespace CTDL_exam
{
    class Function
    {
        static BinarySearchTree tree = Program.monhoctree;

        static string str = "";
        // Tính điểm trung bình, min max
        static float avg, min, max;
        public static string Scoring (Node parent)
        {
            avg = 0f; min = 100f; max = 0f;
            int count = tree.CountNode(tree.Root);
            Score(parent);
            str = "Điểm trung bình: " + avg/count + "\n";
            str += "Điểm max: " + max + "\n";
            str += "Điểm min: " + min + "\n";
            return str;
        }
        private static void Score (Node parent)
        {
            if (parent != null)
            {
                Score(parent.LeftNode);
                float GPA = parent.Data.getGPA();
                avg += GPA;
                min = min > GPA ? GPA : min ;
                max = max < GPA ? GPA : max ;
                Score(parent.RightNode);
            }
        }


        // SẮP XẾP
        //Sắp xếp theo ngày 
        private static int CompareDay (string strA, string strB)
        {
            string[] A , B;
            A = strA.Split('/');
            B = strB.Split('/');
            if (string.Compare(A[2], B[2]) != 0)
                return string.Compare(A[2], B[2]);
            
            else
            if (string.Compare(A[1], B[1]) != 0)
                return string.Compare(A[1], B[1]);
            
            else
                return string.Compare(A[0], B[0]);
        }
        private static bool SapXepDays (monhoc value)
        {
            Node before = null, after = tree.Root;
            while (after != null)
            {
                if (CompareDay(value.getStart(),after.Data.getStart())==0)
                    return false;

                before = after;
                if (CompareDay(value.getStart(),after.Data.getStart())==-1)
                    after = after.LeftNode; //left? 
                else
                    after = after.RightNode; //right?
            }

            Node newNode = new Node();
            newNode.Data = value;
            if (tree.Root == null) //empty?
                tree.Root = newNode;
            else
            {
                if (CompareDay(value.getStart(),before.Data.getStart())==-1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        //Sắp xếp theo mã TC 
        private static bool SapXepTC(monhoc value)
        {
            Node before = null, after = tree.Root;
            while (after != null)
            {
                before = after;
                if ((int)value.getTC() <= after.Data.getTC())
                    after = after.LeftNode; //left? 
                else
                    after = after.RightNode; //right?
            }

            Node newNode = new Node();
            newNode.Data = value;
            if (tree.Root == null) //empty?
                tree.Root = newNode;
            else
            {
                if ((int)value.getTC() <= before.Data.getTC())
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        //Sắp xếp theo mã môn học
        private static bool SapXepID(monhoc value)
        {
            Node before = null, after = tree.Root;
            while (after != null)
            {
                if (string.Compare(value.getName(), after.Data.getName()) == 0)
                    return false;

                before = after;
                if (string.Compare(value.getName(), after.Data.getName()) == -1)
                    after = after.LeftNode; //left? 
                else
                    after = after.RightNode; //right?
            }

            Node newNode = new Node();
            newNode.Data = value;
            if (tree.Root == null) //empty?
                tree.Root = newNode;
            else
            {
                if (string.Compare(value.getName(), before.Data.getName()) == -1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        // Hàm tổng sắp xếp
        public static void HamSapXep (Node parent, BinarySearchTree tree1, int val)
        {
            if (parent != null)
            {
                HamSapXep(parent.LeftNode,tree1, val);
                switch (val)
                {
                    case 1: SapXepDays(parent.Data); break;
                    case 2: SapXepTC(parent.Data); break;
                    case 3: SapXepID(parent.Data); break;
                }
                HamSapXep(parent.RightNode,tree1, val);
            }
        }

        // In sắp xếp
        public static string PrintSapXep(Node parent, int val)
        {
            if (parent != null)
            {
                PrintSapXep(parent.LeftNode, val);
                str += "\n" + parent.Data.getName().PadRight(20);
                switch(val)
                {
                    case 1: str += parent.Data.getStart(); break;
                    case 2: str += parent.Data.getTC(); break;
                    case 3: str += parent.Data.getID(); break;
                }
                PrintSapXep(parent.RightNode, val);
            }
            return str;
        }


        // Duyệt nút
        // Duyệt cây theo thứ tự bé -> lớn
        private static string PrintDetail(Node parent)
        {
            if (parent != null)
            {
                str = parent.Data.ToString();
            }
            return str;
        }
        public static string Detail ()
        {
            UI.WriteLine("Nhập mã môn cần hiển thị: ");
            Console.SetCursorPosition(31, 5);

            str = Console.ReadLine();
            if (tree.FindID(str) == null)
                str = "Không tìm thấy mã môn";
            else
                str = PrintDetail(tree.FindID(str));

            return str;
        }


        // In tên cho menu
        public static string PrintNameInOrder (Node parent)
        {
            str = "";
            str = PrintName(parent);
            return str;
        }
        private static string PrintName (Node parent)
        {
            if (parent != null)
            {
                PrintName(parent.LeftNode);
                str = str + "\n" +  parent.Data.getID().PadRight(6) + parent.Data.getName();
                PrintName(parent.RightNode);
            }
            return str;
        }

        // Các hàm chức năng
        public static void Themphantu(BinarySearchTree tree)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            UI.WriteLine("\nThêm môn");
            string[] Title = { "  Mã môn", "  Tên môn", "  Số tín chỉ", "  Bắt đầu", "  Kết thúc", "  Tên giảng viên", "  Điểm môn học" };
            string[] Arr = new string[7];
            for (int i = 0; i < 7; i++)
            {
                UI.ReadLine(Title[i], ref Arr[i]);
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
            UI.WriteLine("Thêm môn thành công !");
        }

        public static bool Suaphantu(BinarySearchTree tree)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            string maMonHoc = "";
            UI.ReadLine("Nhập mã môn cần sửa", ref maMonHoc);

            if (tree.Remove(maMonHoc) == false )
            {
                UI.WriteLine("Sửa môn thất bại !");
                return false;
            }
            else
            UI.WriteLine("Chỉnh sửa môn " + maMonHoc);
            string[] Title = { "  Mã môn", "  Tên môn", "  Số tín chỉ", "  Bắt đầu", "  Kết thúc", "  Tên giảng viên", "  Điểm môn học" };
            string[] Arr = new string[7];
            Arr[0] = maMonHoc;
            for (int i = 1; i < Arr.Length; i++)
            {
                UI.ReadLine(Title[i], ref Arr[i]);
            }
            tree.Insert(new monhoc(Arr[0], Arr[1], int.Parse(Arr[2]), Arr[3], Arr[4], Arr[5], float.Parse(Arr[6])));
            UI.WriteLine("Sửa môn thành công !");
            return true;
        }

        public static bool Xoaphantu (BinarySearchTree tree)
        {
            string del = ""; 
            UI.ReadLine("Nhập mã môn muốn xóa", ref del);
            if (tree.Remove(del) == true)
                UI.WriteLine("\nXóa thành công !");
            return true;
        }

        //Tìm kiếm theo tên giảng viên
        public static string FindTheoGiangVien(string value)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            str = "";
            str = FindTheoGiangVien(value, tree.Root);
            if (str == "")
                str = "Không có giá trị phù hợp";
            return str;
        }
        private static string FindTheoGiangVien(string value, Node parent)
        {
            if (parent != null)
            {
                FindTheoGiangVien(value, parent.LeftNode);
                
                if (parent.Data.getTeacher().ToLower().Contains(value.ToLower()) == true)
                {
                    if (str != "")
                        str += "\n";
                    
                    str = str + parent.Data.getName().PadRight(20) + parent.Data.getTeacher();
                }
                FindTheoGiangVien(value, parent.RightNode);
            }

            return str;
        }

        public static bool Timkiem (BinarySearchTree tree)
        {
            UI.TextCenter("Giá trị tìm kiếm");
            UI.WriteLine("1. Theo mã môn");
            UI.WriteLine("2. Theo tên giảng viên");
            string value = "";
            UI.ReadLine("Chọn loại giá trị", ref value);
            int val = int.Parse(value);
            switch(val)
            {
                case 1:
                    UI.ReadLine("Nhập mã môn", ref value);
                    UI.WriteLine(PrintDetail(tree.FindID(value))); 
                    break;

                case 2:
                    FindTheoGiangVien("");
                    UI.ReadLine("Nhập tên giảng viên", ref value);
                    str = FindTheoGiangVien(value);
                    UI.WriteLine(str);
                    break;

                default: return false;
            }
            return true;
        }

        public static bool Sapxep (BinarySearchTree tree)
        {
            str = "";
            BinarySearchTree treeClone;
            treeClone = new BinarySearchTree();

            UI.TextCenter("Giá trị sắp xếp");
            UI.WriteLine("1. Theo ngày");
            UI.WriteLine("2. Theo tín chỉ");
            UI.WriteLine("3. Theo mã môn");
            string value = "";
            UI.ReadLine("Chọn loại giá trị", ref value);
            int val = int.Parse(value);

            if (val != 1 && val != 2 && val != 3)
            {
                UI.WriteLine("\nĐã xảy ra lỗi...");
                return false;
            }
            HamSapXep(tree.Root ,treeClone, val);
            
            UI.WriteLine(PrintSapXep(treeClone.Root, val));

            return true;
        }


    }
}
