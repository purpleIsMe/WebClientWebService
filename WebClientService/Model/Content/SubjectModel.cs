using Model.EF;
using System.Collections.Generic;

namespace Model.Content
{
    public class SubjectModel
    {
        public int SelectedSubject { get; set; }
        public List<Subject> Subjects{ get; set; }
        public int SelectedModule { get; set; }
        public List<QClass> Modules { get; set; }
        public string nameModule { get; set; }
        public string Link { get; set; }
    }
}
