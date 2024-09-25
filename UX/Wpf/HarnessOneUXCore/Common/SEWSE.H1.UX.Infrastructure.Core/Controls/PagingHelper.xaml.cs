using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEWSE.H1.UX.Infrastructure.Core.Controls
{
    /// <summary>
    /// Interaction logic for PagingHelper.xaml
    /// </summary>
    public partial class PagingHelper : UserControl, INotifyPropertyChanged
    {

        //private int _pageNo = 1;
        //public int PageNo
        //{
        //    get { return _pageNo; }
        //    set
        //    {
        //        #region Enable/Disable Buttons
        //        if (value < 1)
        //            return;

        //        if (value > TotalNumberOfPages)
        //            return;

        //        if (value <= 1)
        //        {
        //            FirstButtonIsEnabled = false;
        //            OnPropertyChanged("FirstButtonIsEnabled");
        //            PreviousButtonIsEnabled = false;
        //            OnPropertyChanged("PreviousButtonIsEnabled");
        //        }
        //        else
        //        {
        //            FirstButtonIsEnabled = true;
        //            OnPropertyChanged("FirstButtonIsEnabled");
        //            PreviousButtonIsEnabled = true;
        //            OnPropertyChanged("PreviousButtonIsEnabled");
        //        }

        //        if (value >= TotalNumberOfPages)
        //        {
        //            LastButtonIsEnabled = false;
        //            OnPropertyChanged("LastButtonIsEnabled");
        //            NextButtonIsEnabled = false;
        //            OnPropertyChanged("NextButtonIsEnabled");
        //        }
        //        else
        //        {
        //            LastButtonIsEnabled = true;
        //            OnPropertyChanged("LastButtonIsEnabled");
        //            NextButtonIsEnabled = true;
        //            OnPropertyChanged("NextButtonIsEnabled");
        //        }
        //        #endregion

        //        _pageNo = value;
        //        OnPropertyChanged("PageNo");
        //    }
        //}


        public int PageNo
        {
            get { return (int)GetValue(PageNodp); }
            set
            {
                #region Enable/Disable Buttons
                if (value < 1)
                    return;

                if (value > TotalNumberOfPages)
                    return;
                //if (value <= 1)
                //{
                //    FirstButtonIsEnabled = false;
                //    OnPropertyChanged("FirstButtonIsEnabled");
                //    PreviousButtonIsEnabled = false;
                //    OnPropertyChanged("PreviousButtonIsEnabled");
                //}
                //else
                //{
                //    FirstButtonIsEnabled = true;
                //    OnPropertyChanged("FirstButtonIsEnabled");
                //    PreviousButtonIsEnabled = true;
                //    OnPropertyChanged("PreviousButtonIsEnabled");
                //}

                //if (value >= TotalNumberOfPages)
                //{
                //    FirstButtonIsEnabled = true;
                //    OnPropertyChanged("FirstButtonIsEnabled");
                //    PreviousButtonIsEnabled = true;
                //    OnPropertyChanged("PreviousButtonIsEnabled");
                //    LastButtonIsEnabled = false;
                //    OnPropertyChanged("LastButtonIsEnabled");
                //    NextButtonIsEnabled = false;
                //    OnPropertyChanged("NextButtonIsEnabled");
                //}
                //else
                //{
                //    LastButtonIsEnabled = true;
                //    OnPropertyChanged("LastButtonIsEnabled");
                //    NextButtonIsEnabled = true;
                //    OnPropertyChanged("NextButtonIsEnabled");
                //}

                if (value > 1 && value < TotalNumberOfPages)
                {
                    FirstButtonIsEnabled = true;
                    OnPropertyChanged("FirstButtonIsEnabled");
                    PreviousButtonIsEnabled = true;
                    OnPropertyChanged("PreviousButtonIsEnabled");
                    LastButtonIsEnabled = true;
                    OnPropertyChanged("LastButtonIsEnabled");
                    NextButtonIsEnabled = true;
                    OnPropertyChanged("NextButtonIsEnabled");
                }
                else if (value <= 1)
                {
                    FirstButtonIsEnabled = false;
                    OnPropertyChanged("FirstButtonIsEnabled");
                    PreviousButtonIsEnabled = false;
                    OnPropertyChanged("PreviousButtonIsEnabled");
                    LastButtonIsEnabled = true;
                    OnPropertyChanged("LastButtonIsEnabled");
                    NextButtonIsEnabled = true;
                    OnPropertyChanged("NextButtonIsEnabled");
                }
                else if (value >= TotalNumberOfPages)
                {
                    FirstButtonIsEnabled = true;
                    OnPropertyChanged("FirstButtonIsEnabled");
                    PreviousButtonIsEnabled = true;
                    OnPropertyChanged("PreviousButtonIsEnabled");
                    LastButtonIsEnabled = false;
                    OnPropertyChanged("LastButtonIsEnabled");
                    NextButtonIsEnabled = false;
                    OnPropertyChanged("NextButtonIsEnabled");
                }
                #endregion

                SetValue(PageNodp, value);

            }
        }
        public static readonly DependencyProperty PageNodp =
            DependencyProperty.Register("PageNo", typeof(int), typeof(PagingHelper), new PropertyMetadata(0));


        //private int _selectedPageSize;
        //public int SelectedPageSize
        //{
        //    get { return _selectedPageSize; }
        //    set
        //    {
                 
        //        _selectedPageSize = value;
        //        OnPropertyChanged("SelectedPageSize");
        //        PageNo = 1;
        //    }
        //}





        public int SelectedPageSize
        {
            get { return (int)GetValue(SelectedPageSizedp); }
            set { SetValue(SelectedPageSizedp, value); PageNo = 1; }
        }
        public static readonly DependencyProperty SelectedPageSizedp =
            DependencyProperty.Register("SelectedPageSize", typeof(int), typeof(PagingHelper), new PropertyMetadata(0));



        //private List<int> _pageSizeList;
        //public List<int> PageSizeList
        //{
        //    get { return _pageSizeList; }
        //    set
        //    {
        //        _pageSizeList = value;
        //        OnPropertyChanged("PageSizeList");
        //    }
        //}




        public List<int> PageSizeList
        {
            get { return (List<int>)GetValue(PageSizeListdp); }
            set { SetValue(PageSizeListdp, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeListdp =
            DependencyProperty.Register("PageSizeList", typeof(List<int>), typeof(PagingHelper), new PropertyMetadata(default(List<int>)));



        //private int _totalNumberOfPages;
        //public int TotalNumberOfPages
        //{
        //    get { return _totalNumberOfPages; }
        //    set
        //    {
        //        _totalNumberOfPages = value;
        //        OnPropertyChanged("TotalNumberOfPages");
        //    }
        //}

        public int TotalNumberOfPages
        {
            get { return (int)GetValue(TotalNumberOfPagesdp); }
            set {

               
                if (value > 1)
                {
                    LastButtonIsEnabled = true;
                    OnPropertyChanged("LastButtonIsEnabled");
                    NextButtonIsEnabled = true;
                    OnPropertyChanged("NextButtonIsEnabled");
                }
                if (value <= 1)
                {
                    FirstButtonIsEnabled = false;
                    OnPropertyChanged("FirstButtonIsEnabled");
                    PreviousButtonIsEnabled = false;
                    OnPropertyChanged("PreviousButtonIsEnabled");
                    LastButtonIsEnabled = false;
                    OnPropertyChanged("LastButtonIsEnabled");
                    NextButtonIsEnabled = false;
                    OnPropertyChanged("NextButtonIsEnabled");
                }
                SetValue(TotalNumberOfPagesdp, value);
            }
        }
        public static readonly DependencyProperty TotalNumberOfPagesdp =
            DependencyProperty.Register("TotalNumberOfPages", typeof(int), typeof(PagingHelper), new PropertyMetadata(0));


        //private int _pageIndex = 1;
        //public int PageIndex
        //{
        //    get { return _pageIndex; }
        //    set
        //    {
        //        _pageIndex = value;
        //        OnPropertyChanged("PageIndex");
        //        if (_pageIndex <= 1)
        //        {
        //            FirstButtonIsEnabled = false;
        //            OnPropertyChanged("FirstButtonIsEnabled");
        //            PreviousButtonIsEnabled = false;
        //            OnPropertyChanged("PreviousButtonIsEnabled");
        //        }
        //        else
        //        {
        //            FirstButtonIsEnabled = true;
        //            OnPropertyChanged("FirstButtonIsEnabled");
        //            PreviousButtonIsEnabled = true;
        //            OnPropertyChanged("PreviousButtonIsEnabled");
        //        }
        //    }
        //}

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexdp); }
            set { SetValue(PageIndexdp, value); }
        }
        public static readonly DependencyProperty PageIndexdp =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(PagingHelper), new PropertyMetadata(0));


        private bool _firstButtonIsEnabled = false;
        public bool FirstButtonIsEnabled
        {
            get { return _firstButtonIsEnabled; }
            set
            {
                _firstButtonIsEnabled = value;
                OnPropertyChanged("FirstButtonIsEnabled");
            }
        }

        private bool _previousButtonIsEnabled = false;
        public bool PreviousButtonIsEnabled
        {
            get { return _previousButtonIsEnabled; }
            set
            {
                _previousButtonIsEnabled = value;
                OnPropertyChanged("PreviousButtonIsEnabled");
            }
        }

        private bool _nextButtonIsEnabled = true;
        public bool NextButtonIsEnabled
        {
            get { return _nextButtonIsEnabled; }
            set
            {
                _nextButtonIsEnabled = value;
                OnPropertyChanged("NextButtonIsEnabled");
            }
        }

        private bool _lastButtonIsEnabled = true;
        public bool LastButtonIsEnabled
        {
            get { return _lastButtonIsEnabled; }
            set
            {
                _lastButtonIsEnabled = value;
                OnPropertyChanged("LastButtonIsEnabled");
            }
        }
        
        //public static readonly DependencyProperty NextButtonCommandProperty = DependencyProperty.Register("NextButtonCommand", typeof(ICommand), typeof(PagingHelper));
        //public ICommand NextButtonCommand
        //{
        //    get { return (ICommand)GetValue(NextButtonCommandProperty); }
        //    set { SetValue(NextButtonCommandProperty, value); }
        //}

        public PagingHelper()
        {            
            try
            {
                InitializeComponent();
                LayoutRoot.DataContext = this;
               // PageSizeList = new List<int>() {5000, 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000, 80000, 85000, 90000, 95000, 100000 };
                //SelectedPageSize = PageSizeList.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public event RoutedEventHandler FirstPageButtonClick;
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            PageNo = 1;
            SetSizeAndTotalNoOfPages();
            if (this.FirstPageButtonClick != null)
            {
                this.FirstPageButtonClick(this, e);
            }
        }

        public event RoutedEventHandler PreviousPageButtonClick;
        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            PageNo = PageNo - 1;
            SetSizeAndTotalNoOfPages();
            if (this.PreviousPageButtonClick != null)
            {
                this.PreviousPageButtonClick(this, e);
            }
        }

        public event RoutedEventHandler NextPageButtonClick;
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            PageNo = PageNo + 1;
            SetSizeAndTotalNoOfPages();

            if (this.NextPageButtonClick != null)
            {
                this.NextPageButtonClick(this, e);
            }
        }

        public event RoutedEventHandler LastPageButtonClick;
        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            PageNo = TotalNumberOfPages;
            SetSizeAndTotalNoOfPages();
            if (this.LastPageButtonClick != null)
            {
                this.LastPageButtonClick(this, e);
            }
        }

        public void SetSizeAndTotalNoOfPages()
        {
            PageIndex = PageNo;
        }

        public event RoutedEventHandler PageSizeComboSelectionChanged;
        private void cmbPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PageSizeComboSelectionChanged != null)
            {
                this.PageSizeComboSelectionChanged(this, e);
            }
        }

        public event RoutedEventHandler CurrentPageNoKeyDown;
        private void txtCurrentPageNo_KeyDown(object sender, KeyEventArgs e)
        {
            PageNo = PageNo;
            SetSizeAndTotalNoOfPages();
            if (this.CurrentPageNoKeyDown != null)
            {
                this.CurrentPageNoKeyDown(this, e);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
