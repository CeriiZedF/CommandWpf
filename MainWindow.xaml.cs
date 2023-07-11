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

        
    }

    public class MyViewModel : INotifyPropertyChanged
    {
        private int font_size;
        public int FontSize
        { 
            get { return font_size; } 
            set 
            {
                font_size = value;
                OnPropertyChanged("FontSize");
            }
        }
        private string font_family;
        public string Font
        {
            get { return font_family; }
            set
            {
                font_family = value;
                OnPropertyChanged("Font");
            }
        }
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
        #region Practice
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

        #endregion
        private ActionCommand fontBold;
        public ActionCommand FontBold
        {
            get
            {
                return fontBold
                    ?? (fontBold = new ActionCommand(obj =>
                    {
                        MessageBox.Show("Bold");
                        font_family = "Bold";
                        
                    }));
            }

        }
        private ActionCommand fontItalic;
        public ActionCommand FontItalic
        {
            get
            {
                return fontItalic
                    ?? (fontItalic = new ActionCommand(obj =>
                    {
                        font_family = "Italic";
                        MessageBox.Show(font_family.ToString());
                    }));
            }

        }
        private ActionCommand fontSize15;
        public ActionCommand FontSize15
        {
            get
            {
                return fontSize15
                    ?? (fontSize15 = new ActionCommand(obj =>
                    {
                        MessageBox.Show("FontSize 15");
                        FontSize = 15;
                        


                    }));
            }

        }
        private ActionCommand fontSize30;
        public ActionCommand FontSize30
        {
            get
            {
                return fontSize30
                    ?? (fontSize30 = new ActionCommand(obj =>
                    {
                        MessageBox.Show("FontSize 15");
                        FontSize = 30;



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


