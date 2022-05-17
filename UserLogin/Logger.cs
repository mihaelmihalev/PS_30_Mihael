using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public  class Logger
    {
        private static  List<string> Log = new List<string>();
        private const string LogFileName = "log.txt";

        //public static void GetCurrentSessionActivities() 
       // {
            
       // }
        public static void LogActivity(string activity)
        {
            UserContext userContext = new UserContext();

            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;

            Log.Add(activityLine);
            if (File.Exists("test.txt"))
            {
                File.WriteAllText("test.txt", activityLine);
            }

            
            var msg = DateTime.Now + " | " + LoginValidation.currentUsername + " | " + LoginValidation.currentUserRole + " | " + activity;
            Log.Add(msg);
            StreamWriter log = new StreamWriter(LogFileName);
            log.WriteLine(msg);
            log.Close();
        }

        public static IEnumerable<string> ReadFullLog()
        {
            StreamReader log = new StreamReader(LogFileName);
            List<string> listLog = new List<string>();
            while (true)

            {
                var l = log.ReadLine();
                if (l != null) listLog.Add(l);
                else break;
            }

            return listLog;
        }
    
        public static void ReadCurrentLog()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var line in Log)
                sb.AppendLine(line);
            Console.WriteLine(sb);
        }
    }
}
    
