using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDuwu_Project_Mk1
{
   public  class Tasks: ICloneable
    {
        public static int ID=0;
        public static String TaskName = "";
        public static String TaskDescription = "";
        public static DateTime dueDateTime = new DateTime();
        public static Boolean delete = false;
        public static Boolean complete = false;
        public static String group = "";
        public Tasks()
        {
            ID++;
               }
        public void addName(String x)
        {
            TaskName = x;
        }
        public void addDescription(String whatItIS)
        {
            TaskDescription = whatItIS;
        }
        public void setGroup(String g)
        {
            group = g;
        }
        public void setDueDate(DateTime y)
        {
            dueDateTime = y;
        }
        public void completeTask()
        {
            complete = true;
        }
        public void deleteTask()
        {
            delete = true;
        }

        public object Clone()
        {
            var task = (Task)MemberwiseClone();
            return task;
         }
    }
}