using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDuwu_Project_Mk1
{
    class Tasks
    {
        public int Id { get; set; }
        public string User { get; set; }
        public  string TaskName { get; set; }
        public  string TaskDescription  { get; set; }
        public  DateTime DueDate { get; set; }
        public float Difficulty { get; set; }
        public string Group { get; set; }
    }
}