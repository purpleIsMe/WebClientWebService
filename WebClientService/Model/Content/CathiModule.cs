using Model.EF;
using System.Collections.Generic;

namespace Model.Content
{
    public class CathiModule
    {
        public string SelectedKhoaThi { get; set; }
        public List<KHOATHI> KhoaThies { get; set; }
    }
}
