using System;

namespace CTDL_exam
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public monhoc Data { get; set; }
    }

    public class BinarySearchTree
    {
        public Node Root { get; set; }

        // Đếm số phần tử trong cây Count
        public static int i;
        private void Count(Node parent)
        {
            if (parent != null)
            {
                Count(parent.LeftNode);
                i++;
                Count(parent.RightNode);
            }
        }

        public int CountNode(Node parent)
        {
            i = 0;
            Count(parent);
            return i;
        }
        
        // Tính điểm trung bình, min max
        float avg, min, max;

        public string Scoring (Node parent)
        {
            avg = 0f; min = 100f; max = 0f;
            int count = CountNode(this.Root);
            Score(parent);
            str = "Điểm trung bình: " + avg/count + "\n";
            str += "Điểm max: " + max + "\n";
            str += "Điểm min: " + min + "\n";
            return str;
        }

        private void Score (Node parent)
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

        //Sắp xếp theo ngày 
        private bool InsertWithDays (monhoc value)
        {
            Node before = null, after = this.Root;
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
            if (this.Root == null) //empty?
                this.Root = newNode;
            else
            {
                if (CompareDay(value.getStart(),before.Data.getStart())==-1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }
        private int CompareDay (string strA, string strB)
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
        public void SapXepDays (Node parent, BinarySearchTree tree1)
        {
            if (parent != null)
            {
                SapXepDays(parent.LeftNode,tree1);
                tree1.InsertWithDays(parent.Data);
                SapXepDays(parent.RightNode,tree1);
            }
        }

        public string PrintDays(Node parent)
        {
            if (parent != null)
            {
                PrintDays(parent.LeftNode);
                str += "\n" + parent.Data.getName().PadRight(20) + parent.Data.getStart();
                PrintDays(parent.RightNode);
            }
            return str;
        }


        //Sắp xếp theo mã TC 
        private bool SapXepTC(monhoc value)
        {
            Node before = null, after = this.Root;
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
            if (this.Root == null) //empty?
                this.Root = newNode;
            else
            {
                if ((int)value.getTC() <= before.Data.getTC())
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }
        public void SapXepTC(Node parent,BinarySearchTree tree1)
        {
            if (parent != null)
            {
                SapXepTC(parent.LeftNode,tree1);
                tree1.SapXepTC(parent.Data);
                SapXepTC(parent.RightNode,tree1);
            }
        }

        public string PrintTC(Node parent)
        {
            if (parent != null)
            {
                PrintTC(parent.LeftNode);
                str += "\n" + parent.Data.getName().PadRight(20) + parent.Data.getTC();
                PrintTC(parent.RightNode);
            }
            return str;
        }
        
        //Sắp xếp theo mã môn học
        private bool SapXepID(monhoc value)
        {
            Node before = null, after = this.Root;
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
            if (this.Root == null) //empty?
                this.Root = newNode;
            else
            {
                if (string.Compare(value.getName(), before.Data.getName()) == -1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }
        public void SapXepID(Node parent,BinarySearchTree tree1)
        {
            if (parent != null)
            {
                SapXepID(parent.LeftNode,tree1);
                tree1.SapXepID(parent.Data);
                SapXepID(parent.RightNode,tree1);
            }
        }
        public string PrintID(Node parent)
        {
            if (parent != null)
            {
                PrintID(parent.LeftNode);
                str += "\n" + parent.Data.getName().PadRight(20) + parent.Data.getID();
                PrintID(parent.RightNode);
            }
            return str;
        }

        // Thêm phần tử
        public bool Insert(monhoc value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                if (string.Compare(value.getID(), after.Data.getID()) == 0)
                    return false;

                before = after;
                if (string.Compare(value.getID(), after.Data.getID()) == -1)
                    after = after.LeftNode; //left? 
                else
                    after = after.RightNode; //right?
            }

            Node newNode = new Node();
            newNode.Data = value;
            if (this.Root == null) //empty?
                this.Root = newNode;
            else
            {
                if (string.Compare(value.getID(), before.Data.getID()) == -1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        // Duyệt nút
        // Duyệt cây theo thứ tự bé -> lớn
        public void PrintDetailInOrder(Node parent)
        {
            if (parent != null)
            {
                PrintDetailInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                PrintDetailInOrder(parent.RightNode);
            }
        }

        public string Detail ()
        {
            UI.WriteLine("Nhập mã môn cần hiển thị: ");
            Console.SetCursorPosition(31, 25 + CountNode(this.Root));

            str = Console.ReadLine();
            if (FindTheoMaMon(str) == null)
                str = "Không tìm thấy mã môn";
            else
                str = PrintDetail(FindTheoMaMon(str));

            return str;
        }
        public string PrintDetail(Node parent)
        {
            if (parent != null)
            {
                str = parent.Data.ToString();
            }
            return str;
        }

        string str;
        public string PrintNameInOrder (Node parent)
        {
            str = "";
            str = PrintName(parent);
            return str;
        }
        private string PrintName (Node parent)
        {
            if (parent != null)
            {
                PrintName(parent.LeftNode);
                str = str + "\n" +  parent.Data.getID().PadRight(6) + parent.Data.getName();
                PrintName(parent.RightNode);
            }
            return str;
        }

        // Tìm kiếm theo mã môn học
        public Node FindTheoMaMon(string value)
        { return this.FindTheoMaMon(value, this.Root); }

        private Node FindTheoMaMon(string value, Node parent)
        {
            if (parent != null)
            {
                if (string.Compare(value.ToLower(), parent.Data.getID().ToLower()) == 0) return parent;
                if (string.Compare(value.ToLower(), parent.Data.getID().ToLower()) == -1)
                    return FindTheoMaMon(value, parent.LeftNode);
                else
                    return FindTheoMaMon(value, parent.RightNode);
            }
            return null;
        }

        //Tìm kiếm theo tên giảng viên
        public string FindTheoGiangVien(string value)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            str = "";
            FindTheoGiangVien(value, this.Root);
            if (str == "")
                str = "Không có giá trị phù hợp";
            return str;
        }

        private Node FindTheoGiangVien(string value, Node parent)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            if (parent != null)
            {
                FindTheoGiangVien(value, parent.LeftNode);
                if (parent.Data.getTeacher().ToLower().Contains(value.ToLower()) == true)
                    str = str + parent.Data.getName() + "\n";
                FindTheoGiangVien(value, parent.RightNode);
            }

            return null;
        }



        // Tìm phần tử min, là phần tử đầu tiên khi duyệt cây, mặc định sắp xếp theo mã môn
        private monhoc MinOfNode(Node node)
        {
            monhoc min = node.Data;
            while (node.RightNode != null)
            {
                min = node.RightNode.Data;
                node = node.RightNode;
            }
            return min;
        }

        // Xóa nút
        public bool Remove(string value)
        {
            if (FindTheoMaMon(value) == null)
            {
                UI.WriteLine("\nKhông tìm thấy " + value);
                return false;
            }
            else
                this.Root = Remove(this.Root, value);
            
            return true;
        }

        private Node Remove(Node parent, string key)
        {
            if (parent == null) return parent;
            if (string.Compare(key.ToLower(), parent.Data.getID().ToLower()) == -1) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (string.Compare(key.ToLower(), parent.Data.getID().ToLower()) == 1) parent.RightNode = Remove(parent.RightNode, key);
            else//Xóa nút hiện tại
            {
                // Nếu nút hiện tại có 1 nút con
                if (parent.LeftNode == null) return parent.RightNode;
                else if (parent.RightNode == null) return parent.LeftNode;
                // Nếu nút có hai nút con: lấy nút nhỏ hơn (bên trái)
                parent.Data = MinOfNode(parent.RightNode);
                parent.RightNode = Remove(parent.RightNode, parent.Data.getID());
            }
            return parent;
        }

        public void Themphantu(BinarySearchTree tree)
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

        public bool Suaphantu(BinarySearchTree tree)
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

        public bool Xoaphantu (BinarySearchTree tree)
        {
            string del = ""; 
            UI.ReadLine("Nhập mã môn muốn xóa", ref del);
            if (Remove(del) == true)
                UI.WriteLine("\nXóa thành công !");
            return true;
        }
    
        public bool Timkiem (BinarySearchTree tree)
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
                    UI.WriteLine(tree.PrintDetail(tree.FindTheoMaMon(value))); 
                    break;

                case 2:
                    UI.ReadLine("Nhập tên giảng viên", ref value);
                    UI.WriteLine(tree.FindTheoGiangVien(value));
                    break;

                default: return false;
            }
            return true;
        }

        public bool Sapxep (BinarySearchTree tree)
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

            switch(val)
            {
                case 1:
                    treeClone.SapXepDays(tree.Root,treeClone);
                    UI.WriteLine(treeClone.PrintDays(treeClone.Root));
                    break;

                case 2:
                    treeClone.SapXepTC(tree.Root,treeClone);
                    UI.WriteLine(treeClone.PrintTC(treeClone.Root));
                    break;
                
                case 3:
                    treeClone.SapXepID(tree.Root,treeClone);
                    UI.WriteLine(treeClone.PrintID(treeClone.Root));
                    break;

                default: return false;
            }

            return true;
        }

    }
}
