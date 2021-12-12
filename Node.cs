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
        
        
        //Sắp xếp theo ngày 
        private bool SapXepDays (monhoc value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                if (string.Compare(value.getStart(),after.Data.getStart())==0)
                    return false;

                before = after;
                if (string.Compare(value.getStart(),after.Data.getStart())==-1)
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
                if (string.Compare(value.getStart(),after.Data.getStart())==-1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }
        public void SapXepDays (Node parent, BinarySearchTree tree1)
        {
            if (parent != null)
            {
                SapXepDays(parent.LeftNode,tree1);
                tree1.SapXepDays(parent.Data);
                SapXepDays(parent.RightNode,tree1);
            }
        }


        //Sắp xếp theo mã TC 
        private bool SapXepTC(monhoc value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                if ((int)value.getTC() == after.Data.getTC())
                    return false;

                before = after;
                if ((int)value.getTC() < after.Data.getTC())
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
                if ((int)value.getTC() < before.Data.getTC())
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
                str = str + "\n" + parent.Data.getName();
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
            str = "";
            FindTheoGiangVien(value, this.Root);
            if (str == "")
                str = "Không có giá trị phù hợp";
            return str;
        }

        private Node FindTheoGiangVien(string value, Node parent)
        {
            if (parent != null)
            {
                FindTheoGiangVien(value, parent.LeftNode);
                if (parent.Data.getTeacher().ToLower().Contains(value.ToLower()))
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
        public void Remove(string value)
        {
            this.Root = Remove(this.Root, value);
            if (Remove(this.Root, value) == null)
            {
                Console.WriteLine("Xóa không thành công");
            }
            else Console.WriteLine("Xóa xong");
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


    }

}
