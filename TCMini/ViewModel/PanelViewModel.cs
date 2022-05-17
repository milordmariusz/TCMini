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
            Drives = Model.GetListOfDrives();
            SelectedDrive = Drives[0];
            PathText = SelectedDrive.ToString();
            Content = Model.GetListOfContent(PathText);
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
                PathText = _SelectedDrive.ToString();
                Content = Model.GetListOfContent(PathText);
                onPropertyChanged(nameof(SelectedDrive));
            }
        }

        private List<string> _Content;
        public List<string> Content
        {
            get { return _Content; }
            set 
            { 
                _Content = value;
                onPropertyChanged(nameof(Content));
            }

        }
    }
}
