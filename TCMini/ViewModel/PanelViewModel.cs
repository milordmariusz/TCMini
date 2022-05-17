using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMini.Model;

namespace TCMini.ViewModel
{
    public class PanelViewModel : BaseViewModel
    {
        public PanelModel Model;
        public List<string> Drives { get; set; }

        public PanelViewModel()
        {
            Console.WriteLine("Siema tu konstruktor panelu");
            Model = new PanelModel();
            Drives = Model.getListOfDrives();
            SelectedDrive = Drives[0];
            PathText = SelectedDrive.ToString();
        }

        private string _PathText;
        public string PathText
        {
            get { return _PathText; }
            set 
            { 
                _PathText = value; 
                onPropertyChanged(nameof(PathText));
            }
        }

        private string _SelectedDrive;
        public string SelectedDrive
        {
            get { return _SelectedDrive; }
            set 
            {
                _SelectedDrive = value; 
                onPropertyChanged(nameof(SelectedDrive));
            }
        }
    }
}
