using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateKeepIfEmptyF
{
    class Program
    {
        static List<string> emptyDics = new List<string>();
        static void Main(string[] args)
        {
            string appDic = System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("directory:" + appDic);
            DirectoryInfo di = new DirectoryInfo(appDic);
            var dics = di.GetDirectories();
            string allEmpty = GetDirectLoop(dics);
            Console.WriteLine("empty dics：" + allEmpty);
            Console.ReadLine();
        }
        private static string GetDirectLoop(DirectoryInfo[] direcInfoArr)
        {

            foreach (var d in direcInfoArr)
            {
                var subDirec = d.GetDirectories();
                if (subDirec.Length > 0)
                {
                    GetDirectLoop(subDirec);
                }
                else if (d.GetFiles().Length == 0)
                {
                    emptyDics.Add(d.FullName);
                    var fs = File.Create(d.FullName + "/.keep");
                    fs.Close();
                }
            }
            return string.Join("\n\r", emptyDics.ToArray());
        }
    }
}
