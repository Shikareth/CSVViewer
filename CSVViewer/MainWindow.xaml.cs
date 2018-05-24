using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CSVViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields

        private string windowTitle = string.Empty;
        private List<string> lines = new List<string>(); 

        #endregion

        #region Properties

        public string WindowTitle
        {
            get => windowTitle;
            set { windowTitle = value; NotifyPropertyChanged("WindowTitle"); }
        }
        public List<string> Lines
        {
            get => lines;
            set { lines = value; NotifyPropertyChanged("Lines"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Task.Run(() => {
                while (true)
                {
                    Thread.Sleep(50);
                    WindowTitle = DateTime.Now.ToString();
                }
            });
        }
    }
}
