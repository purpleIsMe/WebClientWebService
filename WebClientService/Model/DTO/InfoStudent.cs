using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class InfoStudent
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDuThi { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        public int MaCaThi { get; set; }

        public int MaDeThi { get; set; }

        public bool TrangThai { get; set; }

        [StringLength(50)]
        public string SoMay { get; set; }

        public bool DaHoanThanh { get; set; }

        public int ThoiGian { get; set; }

        public int TGThi { get; set; }

        public DateTime NgayThi { get; set; }

        public string MonThi { get; set; }
    }
}
