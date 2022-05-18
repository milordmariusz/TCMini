using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMini.Model
{
    public class PanelModel
    {
        public string PathText { get; set; }
        public List<String> Drives = new List<string>();
        public List<String> Content = new List<string>();

        public int Panel = 0;

        public List<String> GetListOfDrives()
        {
            Drives = Directory.GetLogicalDrives().ToList();
            return Drives;
        }

        public List<string> GetListOfContent(string path)
        {
            var contents = new List<string>();
            if (path.Length > 3)
            {
                contents.Add("..");
            }
            try
            {
                var directories = Directory.GetDirectories(path);
                contents.AddRange(directories.Select(directory => directory.Replace(directory.Substring(0, directory.LastIndexOf(@"\") + 1), "<D>")));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                var files = Directory.GetFiles(path);
                contents.AddRange(files.Select(file => file.Replace(path, "")));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return contents;
        }
    }
}
