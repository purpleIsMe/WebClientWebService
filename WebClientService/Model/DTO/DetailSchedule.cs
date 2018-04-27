using System;

namespace Model.DTO
{
    public class DetailSchedule
    {
        public int ID { get; set; }
        
        public string MaKhoaThi { get; set; }
        public int IDChiTietCa { get; set; }

        public string MaChiTietCa { get; set; }

        public Guid SubjectID { get; set; }
        public int IDMon { get; set; }
        public string NameSubject { get; set; }
    }
}
