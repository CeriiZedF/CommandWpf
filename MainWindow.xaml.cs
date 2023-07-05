using GalaSoft.MvvmLight.Command;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CommandWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        public void SetBackground(SolidColorBrush s)
        {
            this.Background = s;
        }
    }

    public class MyViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public SolidColorBrush myBrush
            {
                get { return brush; }
                set 
                    {
                        brush = value;
                        OnPropertyChanged("myBrush");
                    }
            }

        private ActionCommand blueCommand;
        public ActionCommand BlueCommand
        {
            get
            {
                return blueCommand
                    ?? (blueCommand = new ActionCommand(obj =>
                    {
                        myBrush = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                    }));
            }
            
        }
        private ActionCommand redCommand;
        public ActionCommand RedCommand
        {
            get
            {
                return redCommand
                    ?? (redCommand = new ActionCommand(obj =>
                    {
                        myBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }));
            }

        }
        private ActionCommand greenCommand;
        public ActionCommand GreenCommand
        {
            get
            {
                return greenCommand
                    ?? (greenCommand = new ActionCommand(obj =>
                    {
                        myBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    }));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

    public class ActionCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}


