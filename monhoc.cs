
using System;

namespace CTDL_exam
{
    class monhoc
    {
        // id, tên môn, số TC, bắt đầu, kết thúc, gv

        private string id;
        private string name;
        private int tc;
        private string start;
        private string end;
        private string gv;

        public monhoc(string id, string name, int tc, string start, string end, string gv)
        {
            this.id = id;
            this.name = name;
            this.tc = tc;
            this.start = start;
            this.end = end;
            this.gv = gv;
        }

        public string getStart()
        {
            return this.start;
        }

        public string getEnd()
        {
            return this.end;
        }

        public string getName()
        {
            return this.name;
        }

        public string getTeacher()
        {
            return this.gv;
        }

        public override string ToString()
        {
            return string.Format("Môn {0}, mã môn học {1}, số tín chỉ {2}\n Giờ bắt đầu {3}, giờ kết thúc {4}\nGiảng viên {5}", this.name, this.id, this.tc, this.start, this.end, this.gv);
        }

    }
}