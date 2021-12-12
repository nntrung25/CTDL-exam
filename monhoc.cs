
using System;

namespace CTDL_exam
{
    public class monhoc
    {
        // id, tên môn, số TC, bắt đầu, kết thúc, gv

        private string id;
        private string name;
        private int tc;
        private string start;
        private string end;
        private string gv;
        private float gpa;
        

        // Định nghĩa kiểu dữ liệu monhoc
        public monhoc(string id, string name, int tc, string start, string end, string gv, float gpa)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            
            this.id = id;
            this.name = name;
            this.tc = tc;
            this.start = start;
            this.end = end;
            this.gv = gv;
            this.gpa = gpa;
        }

        // Get các phần tử trong monhoc
        public string getID()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public int getTC()
        {
            return this.tc;
        }

        public string getStart()
        {
            return this.start;
        }

        public string getEnd()
        {
            return this.end;
        }

        public string getTeacher()
        {
            return this.gv;
        }

        public float getGPA()
        {
            return this.gpa;
        }


        // In ra màn hình class monhoc
        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            
            string a;
            a = string.Format("\nMôn {0}, mã môn {1}, {2} tín chỉ", this.name, this.id, this.tc);
            a += string.Format("\nBắt đầu {0}, kết thúc {1}", this.start, this.end);
            a += string.Format("\nGiảng viên {0}\n", this.gv);
            a += string.Format("Điểm: {0}", this.gpa);
            return a;
        }

    }
}