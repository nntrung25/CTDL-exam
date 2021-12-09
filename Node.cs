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
        
        public static int i;
        private void Count(Node parent)
        {
            if (parent != null)
            {
                Count(parent.LeftNode);
                i++;
                Count(parent.RightNode);
            }
        }

        public int CountNode(Node parent)
        {
            i = 0;
            Count(parent);
            return i + 1;
        }

        // Thêm nút
        public bool Insert(monhoc value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                if (string.Compare(value.getID(), after.Data.getID()) == 0)
                    return false;
                
                before = after;
                if ( string.Compare(value.getID(), after.Data.getID()) == -1)
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
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }
        
        
/* //
        // Tìm nút có điểm min
        private float MinValueOfNode(Node node)
        {
            float minv = node.Data.getGPA();
            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data.getGPA();
                node = node.LeftNode;
            }
            return minv;
        }
        public float FindMin()
        {
            return MinValueOfNode(this.Root);
        }

        // Tìm nút min kết hợp 2 hàm trên
        public float FindMin2()
        {
            Node current = Root;
            while (current.LeftNode != null)
                current = current.LeftNode;
            return current.Data.getGPA();
        }

        // Tìm nút có điểm max
        private float MaxValueOfNode(Node node)
        {
            float maxv = node.Data.getGPA();
            while (node.RightNode != null)
            {
                maxv = node.RightNode.Data.getGPA();
                node = node.RightNode;
            }
            return maxv;
        }
        public float FindMax()
        {
            return MaxValueOfNode(this.Root);
        }

        // Tìm nút max kết hợp 2 hàm trên
        public float FindMax2()
        {
            Node current = Root;
            while (current.RightNode != null)
                current = current.RightNode;
            return current.Data.getGPA();
        }

        // Độ sâu của cây (chiều dài cây)
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }
// */

        // Tìm nút
        public Node Find(string value)
        {  return this.Find(value, this.Root); }
        
        private Node Find(string value, Node parent)
        {
            if (parent != null)
            {
                if (string.Compare(value, parent.Data.getID()) == 0) return parent;
                if (string.Compare(value, parent.Data.getID()) == -1)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }
            return null;
        }

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
        { this.Root = Remove(this.Root, value); }
        
        private Node Remove(Node parent, string key)
        {   
            if (parent == null) return parent;
            if (string.Compare(key, parent.Data.getID()) == -1) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (string.Compare(key, parent.Data.getID()) == 1) parent.RightNode = Remove(parent.RightNode, key);
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
