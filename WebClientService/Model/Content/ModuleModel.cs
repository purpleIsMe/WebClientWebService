using Model.EF;
using System.Collections.Generic;

namespace Model.Content
{
    public class ModuleModel
    {
        public int SelectedModule { get; set; }
        public List<QClass> Modules { get; set; }
    }
}
