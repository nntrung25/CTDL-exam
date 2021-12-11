using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace CTDL_exam
{
    class Program
    {
        public static BinarySearchTree monhoctree = new BinarySearchTree();
        // Code hàm chức năng ở dưới Hàm main

        //Tìm kiếm theo tên môn học
        static bool SearchTheoMonHoc(Node node,string value)
        {
            FileData.ReadFile(monhoctree);
            if (monhoctree.Root == null)
            {
                return false;
            }
            else
            {
                if (monhoctree.Root.Data.getName() == value)
                {
                    return true;
                }
                else if (string.Compare(value, monhoctree.Root.Data.getName()) == -1)
                {
                    return SearchTheoMonHoc(monhoctree.Root.LeftNode, value);
                }
                else
                {
                    return SearchTheoMonHoc(monhoctree.Root.RightNode, value);
                }
            }
        }


        static void SapxepAphabet(BinarySearchTree tree,string value )
        {

            FileData.ReadFile(tree);
               if(string.Compare(value,tree.Root.Data.getName())==0)
              {
                  tree.SapxepTruoc(tree.Root);
              } else{
                  if(string.Compare(value,tree.Root.Data.getName())==-1)
                  {
                      tree.TraverseInOrder(tree.Root);
                  } else{
                      tree.Sapxepsau(tree.Root);
                  }
              }
              
        }

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
            
            Console.Clear();
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
            
            // Xong nhớ ghi file vào text
            FileData.WriteFile(monhoctree);
            
            //Săp xếp theo môn chữ cái
            System.Console.WriteLine("Săp xếp Môn theo chữ cái mà bạn muốn tìm ");
            System.Console.WriteLine("====================================");
            System.Console.WriteLine("Mời Bạn Nhập Kí Tự");
            string apha=Console.ReadLine();
            SapxepAphabet(monhoctree,apha);
            
            //Tìm kiếm theo tên môn học
            System.Console.WriteLine("Nhập vào môn học cần tìm kiếm: ");
            string value = Console.ReadLine();
            if (SearchTheoMonHoc(monhoctree.Root, value) == true)
            {
                System.Console.WriteLine("Môn " + monhoctree.Root.Data.getName());
                System.Console.WriteLine("Mã môn học " + monhoctree.Root.Data.getID());
                System.Console.WriteLine("Số tín chỉ " + monhoctree.Root.Data.getTC());
                System.Console.WriteLine("Giờ bắt đầu " + monhoctree.Root.Data.getStart());
                System.Console.WriteLine("Giờ kết thúc " + monhoctree.Root.Data.getEnd());
                System.Console.WriteLine("Giảng viên " + monhoctree.Root.Data.getTeacher());
                System.Console.WriteLine("Điểm " + monhoctree.Root.Data.getGPA());
            }
            
        }
    }
}