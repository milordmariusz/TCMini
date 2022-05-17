using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TCMini.Model;

namespace TCMini.ViewModel
{
    public class MainViewModel
    {
        public PanelViewModel Panel1 { get; set; }
        public PanelViewModel Panel2 { get; set; }

        public CopyModel Copy = new CopyModel();

        public MainViewModel()
        {
            Console.WriteLine("PIesio####################");
            Panel1 = new PanelViewModel(Copy,1);
            Panel2 = new PanelViewModel(Copy,2);
        }

        private ICommand _copy;
        public ICommand copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(
                        (object o) =>
                        {
                            Console.WriteLine("PIesio####################");
                            Console.WriteLine(Panel1.PathText);
                            Console.WriteLine(Panel1.SelectedItem);
                            Console.WriteLine(Copy.Panel);

                            Console.WriteLine("-----------------");

                            Console.WriteLine(Panel2.PathText);
                            Console.WriteLine(Panel2.SelectedItem);
                            Console.WriteLine(Copy.Panel);
                        },
                        (object o) =>
                        {
                            return true;
                        });
                }
                return _copy;
            }
        }
    }
}
