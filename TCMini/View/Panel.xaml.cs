using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TCMini.View
{
    /// <summary>
    /// Logika interakcji dla klasy ActivePanel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        public Panel()
        {
            InitializeComponent();
        }

        //////// Path Section \\\\\\\\\
        public static readonly DependencyProperty PathTextProperty =
            DependencyProperty.Register(
                nameof(PathText),
                typeof(string),
                typeof(Panel));

        public string PathText
        {
            get { return (string)GetValue(PathTextProperty); }
            set { SetValue(PathTextProperty, value); }
        }

        //////// Drives Section \\\\\\\\\
        public static readonly DependencyProperty DrivesProperty =
            DependencyProperty.Register(
                nameof(Drives),
                typeof(List<string>),
                typeof(Panel));

        public List<string> Drives
        {
            get { return (List<string>)GetValue(DrivesProperty); }
            set { SetValue(DrivesProperty, value); }
        }

        public static readonly DependencyProperty SelectedDriveProperty =
            DependencyProperty.Register(
                nameof(SelectedDrive),
                typeof(string),
                typeof(Panel));

        public string SelectedDrive
        {
            get { return (string)GetValue(SelectedDriveProperty); }
            set { SetValue(SelectedDriveProperty, value); }
        }

        //////// Content Section \\\\\\\\\
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(List<string>),
                typeof(Panel));

        public List<string> Content
        {
            get { return (List<string>)GetValue(DrivesProperty); }
            set { SetValue(DrivesProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(string),
                typeof(Panel));

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        //////// ListBox DoubleClick \\\\\\\\\
        public static readonly RoutedEvent LbDoubleClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(LbDoubleClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(Panel));

        public event RoutedEventHandler LbDoubleClick
        {
            add { AddHandler(LbDoubleClickEvent, value); }
            remove { RemoveHandler(LbDoubleClickEvent, value); }
        }

        public void RaiseLbDoubleClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(Panel.LbDoubleClickEvent);
            RaiseEvent(newEventArgs);
        }
        private void lb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RaiseLbDoubleClick();
        }


        //////// ComboBox Click \\\\\\\\\
        public static readonly RoutedEvent CbClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(CbClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(Panel));

        public event RoutedEventHandler CbClick
        {
            add { AddHandler(CbClickEvent, value); }
            remove { RemoveHandler(CbClickEvent, value); }
        }

        public void RaiseCbClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(Panel.CbClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void cb_DropDownOpened(object sender, EventArgs e)
        {
            RaiseCbClick();
        }
    }
}
