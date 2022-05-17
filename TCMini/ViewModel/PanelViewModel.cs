using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                Content = Model.GetListOfContent(PathText);
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

        private string _SelectedItem;
        public string SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                onPropertyChanged(nameof(SelectedItem));
            }
        }

        private ICommand _changeContent;
        public ICommand ChangeContent
        {
            get
            {
                if (_changeContent == null)
                {
                    _changeContent = new RelayCommand(
                        (object o) =>
                        {
                            if (SelectedItem == "..")
                            {
                                PathText = PathText.Substring(0, PathText.LastIndexOf(@"\"));
                                if (PathText.Length == 2)
                                {
                                    PathText += @"\";
                                }
                            }
                            else
                            {
                                Console.WriteLine(SelectedItem);
                                if (!PathText.EndsWith(@"\"))
                                {
                                    PathText += @"\";
                                }
                                PathText += SelectedItem.Substring(3, SelectedItem.Length - 3);
                            }
                            onPropertyChanged(nameof(PathText));
                        },
                        (object o) =>
                        {
                            return SelectedItem.Contains("<D>") || SelectedItem.Contains("..");
                        });
                }
                return _changeContent;
            }
        }
    }
}
