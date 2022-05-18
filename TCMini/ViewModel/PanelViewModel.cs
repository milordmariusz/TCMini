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

        public int Number;

        public CopyModel Copy;

        public PanelViewModel(CopyModel copy, int number)
        {
            Model = new PanelModel();
            Drives = Model.GetListOfDrives();
            SelectedDrive = Drives[0];
            PathText = SelectedDrive.ToString();
            Content = Model.GetListOfContent(PathText);
            Number = number;
            Copy = copy;
        }

        #region Zmienne
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
        #endregion

        #region Commands
        private ICommand _changeContent;
        public ICommand ChangeContent
        {
            get
            {
                return _changeContent ?? (_changeContent = new RelayCommand(
                        (object o) =>
                        {
                            if (SelectedItem == "..")
                            {
                                PathText = PathText.Remove(PathText.Length - 1);
                                PathText = PathText.Substring(0, PathText.LastIndexOf(@"\"));
                                if (PathText.Length == 2)
                                {
                                    PathText += @"\";
                                }
                            }
                            else
                            {
                                if (!PathText.EndsWith(@"\"))
                                {
                                    PathText += @"\";
                                }
                                PathText += SelectedItem.Substring(3, SelectedItem.Length - 3) + @"\";
                            }
                            Content = Model.GetListOfContent(PathText);
                            onPropertyChanged(nameof(PathText), nameof(Content));
                        },
                        (object o) =>
                        {
                            return SelectedItem.Contains("<D>") || SelectedItem.Contains("..");
                        }));
            }
        }

        private ICommand _focusChange;
        public ICommand FocusChange
        {

            get
            {
                return _focusChange ?? (_focusChange = new RelayCommand(
                    o =>
                    {
                        Copy.ActivePanel = Number;
                    },
                    o => true
                    ));
            }
        }
        #endregion
    }
}
