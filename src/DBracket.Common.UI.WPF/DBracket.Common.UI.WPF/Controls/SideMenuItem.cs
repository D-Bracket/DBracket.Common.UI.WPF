using DBracket.Common.UI.WPF.Utils;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DBracket.Common.UI.WPF.Controls
{
    public class SideMenuItem : ItemsControl
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SideMenu _parentSideMenu;
        internal MenuItem _button;
        internal ContentPresenter _iconPresenter;
        internal SideMenuItem _parentSideMenuItem;
        internal int _menuIndex = -1;
        internal Border _isSelectedIndicator;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SideMenuItem()
        {
            SubItems = [];
            if (SubItems is not null)
            {
                SubItems.CollectionChanged += HandleCollectionChanged;
            }

            var t = VisualTreeUtils.FindParent(this, nameof(SideMenu));
        }

        internal void SetParentSideMenu(SideMenu parent, ref int menuIndex, int layer)
        {
            _parentSideMenu = parent;
            this.Width = _parentSideMenu.Width - 20;
            _menuIndex = menuIndex;
            menuIndex++;
            Layer = layer;

            foreach (var sideMenu in SubItems)
            {
                sideMenu.SetParentSideMenu(parent, ref menuIndex, layer + 1);
            }
        }

        private void HandleCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var t = Header;
            if (SubItems?.Count > 0)
            {
                HasItems = true;
                return;
            }
            HasItems = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var button = GetTemplateChild("ExpandButton") as System.Windows.Controls.MenuItem;
            if (button is null)
                return;
            button.Click += HandleButtonClick;
            _button = button;


            var border = GetTemplateChild("IsSelectedIndicator") as Border;
            if (border is null)
                return;
            _isSelectedIndicator = border;


            var iconPresenter = GetTemplateChild("PART_IconPresenter") as ContentPresenter;
            if (iconPresenter is null)
                return;
            _iconPresenter = iconPresenter;


            var parentSideMenuItem = VisualTreeUtils.FindParent(this, "SideMenuItem") as SideMenuItem;
            _parentSideMenuItem = parentSideMenuItem;
        }

        private void HandleButtonClick(object sender, RoutedEventArgs e)
        {
            _parentSideMenu.NewMenuItemSelected(this);
            Command?.Execute(CommandParameter);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        internal void ExpandMenu()
        {
            if (HasItems)
            {
                if (SubItems?.Count > 0)
                {
                    if (Items is null || Items.Count == 0)
                    {
                        foreach (var newItem in SubItems)
                        {
                            Items.Add(newItem);
                        }
                        IsExpanded = true;
                    }
                    else
                    {
                        Items.Clear();
                        IsExpanded = false;
                    }
                }
            }
        }

        internal bool CheckStateAndCollapse(SideMenuItem newSelectedItem)
        {
            if (newSelectedItem._parentSideMenuItem is not null)
            {
                // Still inside the same branch

                // Check if an Item in the same subsection of the branch was selected, if yes, collapse nothing
                if (newSelectedItem._parentSideMenuItem._menuIndex == _menuIndex ||
                    newSelectedItem._parentSideMenuItem._menuIndex == _parentSideMenuItem?._menuIndex)
                {
                    return newSelectedItem.HasItems;
                }

                // Collapse menus until correct layer reached
                var parent = _parentSideMenuItem;
                while(parent._menuIndex != newSelectedItem._parentSideMenuItem._menuIndex)
                {
                    SideMenuItem.CollapseMenu(parent);
                    parent = parent._parentSideMenuItem;
                }
            }
            else
            {
                // Inside a new Branch, collapse the complete tree
                var parent = this;
                while (parent is not null)
                {
                    SideMenuItem.CollapseMenu(parent);
                    parent = parent._parentSideMenuItem;
                }
            }

            return true;
        }

        internal static void CollapseMenu(SideMenuItem sideMenuItem)
        {
            sideMenuItem.Items.Clear();
            sideMenuItem.IsExpanded = false;
        }

        internal void CollapseAllSubMenus()
        {
            Items.Clear();
            IsExpanded = false;

            foreach (var subItem in SubItems)
            {
                subItem.CollapseAllSubMenus();
            }
        }

        internal void SetSubItemsAsMenuItems()
        {
            if (SubItems.Count > 0)
            {
                //foreach (var subItem in SubItems)
                //{
                //    var newMenuItem = new MenuItem
                //    {
                //        Header = subItem.Header
                //    };
                //    _button.Items.Add(newMenuItem);
                //    subItem.SetSubItemsAsMenuItems();
                //}
            }
        }

        internal void RemoveSubItemsAsMenuItems()
        {
            if (SubItems.Count > 0)
            {
                foreach (var subItem in SubItems)
                {
                    _button.Items.Clear();
                    subItem.SetSubItemsAsMenuItems();
                }
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private static void HandleIsSelectedStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not bool isSelected)
                return;

            var sideMenuItem = d as SideMenuItem;
            if (sideMenuItem is null)
                return;

        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(SideMenuItem), new FrameworkPropertyMetadata(string.Empty));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
            "IsExpanded", typeof(bool), typeof(SideMenuItem), new FrameworkPropertyMetadata(false));

        public bool HasItems
        {
            get => (bool)GetValue(HasItemsProperty);
            set => SetValue(HasItemsProperty, value);
        }
        public static readonly DependencyProperty HasItemsProperty = DependencyProperty.Register(
            "HasItems", typeof(bool), typeof(SideMenuItem), new FrameworkPropertyMetadata(false));

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected", typeof(bool), typeof(SideMenuItem), new FrameworkPropertyMetadata(false, HandleIsSelectedStateChanged));

        public ObservableCollection<SideMenuItem> SubItems
        {
            get => (ObservableCollection<SideMenuItem>)GetValue(SubItemsProperty);
            set => SetValue(SubItemsProperty, value);
        }
        public static readonly DependencyProperty SubItemsProperty = DependencyProperty.Register(
            "SubItems", typeof(ObservableCollection<SideMenuItem>), typeof(SideMenuItem));




        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(SideMenuItem), new FrameworkPropertyMetadata(null));

        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter", typeof(object), typeof(SideMenuItem), new FrameworkPropertyMetadata(null));



        public object IconContent
        {
            get => (object)GetValue(IconContentProperty);
            set => SetValue(IconContentProperty, value);
        }
        public static readonly DependencyProperty IconContentProperty = DependencyProperty.Register(
            "IconContent", typeof(object), typeof(SideMenuItem), new FrameworkPropertyMetadata(null));


        public double ItemHeight
        {
            get => (double)GetValue(ItemHeightProperty);
            set => SetValue(ItemHeightProperty, value);
        }
        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register(
            "ItemHeight", typeof(double), typeof(SideMenuItem), new FrameworkPropertyMetadata(40.0));

        public double Layer
        {
            get => (double)GetValue(LayerProperty);
            set => SetValue(LayerProperty, value);
        }
        public static readonly DependencyProperty LayerProperty = DependencyProperty.Register(
            "Layer", typeof(double), typeof(SideMenuItem), new FrameworkPropertyMetadata(0.0));
        #region "--------------------------------- Colors ----------------------------------"
        public Brush BackgroundIsSelected
        {
            get => (Brush)GetValue(BackgroundIsSelectedProperty);
            set => SetValue(BackgroundIsSelectedProperty, value);
        }
        public static readonly DependencyProperty BackgroundIsSelectedProperty = DependencyProperty.Register(
            "BackgroundIsSelected", typeof(Brush), typeof(SideMenuItem), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), FrameworkPropertyMetadataOptions.Inherits));
        #endregion
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}