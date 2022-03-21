using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
    public class TeacherSubject_Stage_VM
    {
        public int TeacherId { get; set; }
        public IList<int> LevelId { get; set; }
        public IList<int> SubjectId { get; set; }
        public decimal Price { get; set; }
    }
}
