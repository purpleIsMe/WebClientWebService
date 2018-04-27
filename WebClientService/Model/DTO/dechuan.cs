using System;

namespace Model.DTO
{
    public class dechuan
    {
        public int MaDeChuan { get; set; }

        public string TenDeChuan { get; set; }

        public Guid MaMon { get; set; }

        public int MaCaThi { get; set; }

        public int SoDeHoanVi { get; set; }

        public bool? TrangThaiTron { get; set; }

        public int ThoiGian { get; set; }

        public bool? Lock { get; set; }
    }
}
