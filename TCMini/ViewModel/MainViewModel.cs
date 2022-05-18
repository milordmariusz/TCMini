using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TCMini.Model;

namespace TCMini.ViewModel
{
    public class MainViewModel : BaseViewModel
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
                            try
                            {
                                if (Copy.Panel == 1)
                                {
                                    Console.WriteLine("Kopiuję: " + Panel1.PathText + Panel1.SelectedItem + " do: " + Panel2.PathText);
                                    File.Copy(Panel1.PathText + Panel1.SelectedItem, Panel2.PathText + Panel1.SelectedItem);
                                }
                                else if (Copy.Panel == 2)
                                {
                                    Console.WriteLine("Kopiuję: " + Panel2.PathText + Panel2.SelectedItem + " do: " + Panel1.PathText);
                                    File.Copy(Panel2.PathText + Panel2.SelectedItem, Panel1.PathText + Panel2.SelectedItem);
                                }
                                Panel1.PathText = Panel1.PathText;
                                Panel2.PathText = Panel2.PathText;
                            }
                            catch (DirectoryNotFoundException)
                            {
                                MessageBoxResult result = MessageBox.Show("Nie odnaleziono ścieżki docelowej","Error", MessageBoxButton.OK);
                            }
                            catch (ArgumentException)
                            {
                                MessageBoxResult result = MessageBox.Show("Nieprawidłowy plik", "Error", MessageBoxButton.OK);
                            }
                            catch (IOException)
                            {
                                MessageBoxResult result = MessageBox.Show("Plik o takiej nazwie już istnieje", "Error", MessageBoxButton.OK);
                            }
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
