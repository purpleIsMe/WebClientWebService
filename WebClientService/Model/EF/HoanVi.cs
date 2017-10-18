using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("HoanVi")]
    public class HoanVi
    {
        public int HV1 { set; get; }

        public int HV2 { set; get; }

        public int HV3 { set; get; }

        public int HV4 { set; get; }
    }
}
