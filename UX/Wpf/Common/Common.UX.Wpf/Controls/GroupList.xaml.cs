using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Common.UX.Wpf.Contracts.Models;

namespace Common.UX.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for GroupList.xaml
    /// </summary>
    public partial class GroupList : UserControl
    {
        public static DependencyProperty AvailableGroupsProperty;
        public static DependencyProperty ItemBackgroundProperty;
        public static DependencyProperty ItemForegroundProperty;
        public static DependencyProperty TabsProperty;
        public static DependencyProperty SelectedGroupsProperty;

        static GroupList()
        {
            AvailableGroupsProperty = DependencyProperty.Register("AvailableGroups", typeof(ObservableCollection<string>), typeof(GroupList), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

            ItemForegroundProperty = DependencyProperty.Register("ItemForeground", typeof(Brush), typeof(GroupList));
            ItemBackgroundProperty = DependencyProperty.Register("ItemBackground", typeof(Brush), typeof(GroupList));
            TabsProperty = DependencyProperty.Register("Tabs", typeof(ObservableCollection<GroupListModel>), typeof(GroupList), new FrameworkPropertyMetadata(new ObservableCollection<GroupListModel>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            SelectedGroupsProperty = DependencyProperty.Register("SelectedGroups", typeof(ObservableCollection<string>), typeof(GroupList), new FrameworkPropertyMetadata(new ObservableCollection<string>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }

        public GroupList()
        {
            InitializeComponent();
            if (Tabs != null)
                Tabs.Clear();
        }

        [Bindable(true)]
        public ObservableCollection<string> AvailableGroups
        {
            get => (ObservableCollection<string>)GetValue(AvailableGroupsProperty);
            set => SetValue(AvailableGroupsProperty, value);
        }

        public Brush ItemBackground
        {
            get => (Brush)GetValue(ItemBackgroundProperty);
            set => SetValue(ItemBackgroundProperty, value);
        }

        public Brush ItemForeground
        {
            get => (Brush)GetValue(ItemForegroundProperty);
            set => SetValue(ItemForegroundProperty, value);
        }

        public ObservableCollection<GroupListModel> Tabs
        {
            get => (ObservableCollection<GroupListModel>)GetValue(TabsProperty);
            set
            {
                SetValue(TabsProperty, value);
            }
        }

        [Bindable(true)]
        public ObservableCollection<string> SelectedGroups
        {
            get => (ObservableCollection<string>)GetValue(SelectedGroupsProperty);
            set => SetValue(SelectedGroupsProperty, value);
        }

        private void DropBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SelectedGroups.Add((string)e.AddedItems[0]);
            }

            if (e.RemovedItems.Count > 0)
            {
                SelectedGroups.Remove((string)e.RemovedItems[0]);
            }
            SelectedGroups = SelectedGroups;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tabs.Add(new GroupListModel
            {
                AvailableGroups = new ObservableCollection<string>(AvailableGroups)
            });
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var item = (GroupListModel)button.DataContext;
                var index = Tabs.IndexOf(item);
                if(item.SelectedGroup != null)
                {
                    if (!SelectedGroups.Remove(item.SelectedGroup))
                    {
                        //throw new Exception("Something went wrong, I just don't know what to put here yet");
                    }

                }
                Tabs.Remove(item);
                SelectedGroups = SelectedGroups;
            }
        }
    }
}
