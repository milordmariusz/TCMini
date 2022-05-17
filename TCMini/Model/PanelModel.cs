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

        public List<String> getListOfDrives()
        {
            Console.WriteLine("Siema tu konstruktor modelu");
            Drives = Directory.GetLogicalDrives().ToList();
            return Drives;
        }
    }
}
