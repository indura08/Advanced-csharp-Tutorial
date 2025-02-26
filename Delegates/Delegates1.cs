using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates
{
    class Delegates1
    {
        public delegate void LogDel(string text);

        public static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        public static void LogTextFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
