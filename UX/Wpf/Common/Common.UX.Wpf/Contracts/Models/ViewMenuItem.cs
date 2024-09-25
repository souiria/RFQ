using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Common.UX.Wpf.Contracts.Models
{
    public class ViewMenuItem : INotifyPropertyChanged
    {
        private string _viewHeader;
        public string ViewHeader
        {
            get => _viewHeader;
            set
            {
                if (_viewHeader == value) return;

                _viewHeader = value;
                OnPropertyChanged("ViewHeader");
            }
        }

        private string _viewName;
        public string ViewName
        {
            get => _viewName;
            set
            {
                if (_viewName != value)
                {
                    _viewName = value;
                    OnPropertyChanged("ViewName");
                }
            }
        }
        private string _viewSecurityGroup;
        public string ViewSecurityGroup
        {
            get { return _viewSecurityGroup; }
            set
            {
                if (_viewSecurityGroup != value)
                {
                    _viewSecurityGroup = value;
                    OnPropertyChanged("ViewSecurityGroup");
                }
            }
        }

        private bool _viewIsSelected;
        public bool ViewIsSelected
        {
            get { return _viewIsSelected; }
            set
            {
                if (_viewIsSelected != value)
                {
                    _viewIsSelected = value;
                    OnPropertyChanged("ViewIsSelected");
                }
            }
        }

        private BitmapImage _viewMenuIcon;
        public BitmapImage ViewMenuIcon
        {
            get { return _viewMenuIcon; }
            set
            {
                if (_viewMenuIcon != value)
                {
                    _viewMenuIcon = value;
                    OnPropertyChanged("ViewMenuIcon");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(sender, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}