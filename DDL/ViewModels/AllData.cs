using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ViewModels
{
   public class AllData
    {
        public List<AllStage> AllStage { get; set; }
        public bool Check { get; set; }

    }
    public class AllStage
    {
        public int StageID { get; set; }
        public string StageName { get; set; }
        public bool Check { get; set; }
        public List<AllLevels> AllLevels { get; set; }
    }
    public class AllLevels
    {
        public int LevelId { get; set; }
        public string Level_Name { get; set; }
        public bool Check { get; set; }
        public List<AllSup> AllSup { get; set; }
    }
    public class AllSup
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int LevelId { get; set; }
        public bool Check { get; set; }
    }

}
