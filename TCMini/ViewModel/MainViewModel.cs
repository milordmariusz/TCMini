using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TCMini.ViewModel
{
    public class MainViewModel
    {
        public PanelViewModel Panel1 { get; set; }
        public PanelViewModel Panel2 { get; set; }

        public MainViewModel()
        {
            Console.WriteLine("PIesio####################");
            Panel1 = new PanelViewModel();
            Panel2 = new PanelViewModel();
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
                            Console.WriteLine(Panel1.IsEnabled);
                            Console.WriteLine(Panel2.PathText);
                            Console.WriteLine(Panel2.IsEnabled);
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
