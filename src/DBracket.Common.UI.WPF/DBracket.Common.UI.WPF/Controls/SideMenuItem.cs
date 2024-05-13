using DBracket.Common.UI.WPF.Utils;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Controls
{
    public class SideMenuItem : ItemsControl
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SideMenu _parentSideMenu;
        internal System.Windows.Controls.MenuItem _button;
        
        internal SideMenuItem _parentSideMenuItem;
        internal int _menuIndex = -1;
        internal Border _isSelectedIndicator;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SideMenuItem()
        {
            SubItems = new ObservableCollection<SideMenuItem>();
            if (SubItems is not null)
            {
                SubItems.CollectionChanged += HandleCollectionChanged;
            }

            var t = VisualTreeUtils.FindParent(this, nameof(SideMenu));
        }

        internal void SetParentSideMenu(SideMenu parent, ref int menuIndex)
        {
            _parentSideMenu = parent;
            _menuIndex = menuIndex;
            menuIndex++;

            foreach (var sideMenu in SubItems)
            {
                sideMenu.SetParentSideMenu(parent, ref menuIndex);
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
            var button = GetTemplateChild("ExpandButton") as System.Windows.Controls.MenuItem ;
            if (button is null)
                return;
            button.Click += HandleButtonClick;
            _button = button;

            var border = GetTemplateChild("IsSelectedIndicator") as Border;
            if (border is null)
                return;
            _isSelectedIndicator = border;

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
            var selectionCase = GetSelectionCase(newSelectedItem);

            switch (selectionCase)
            {
                case 1:
                    CollapseMenu(this);
                    return true;

                case 2:
                    CollapseMenu(_parentSideMenuItem);
                    return true;

                case 3:
                    return false;

                case 4:
                    return false;

                case 5:
                    return true;

                case 6:
                    return false;

                default:
                    throw new Exception();
            }
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


        internal int GetSelectionCase(SideMenuItem newSelectedItem)
        {
            // Check for Case 1:
            // Selected:
            // Expanded Item selected

            // New Selection:
            // Item, outside of Expanded Item selected, that also needs to expand
            if (IsExpanded &&
                newSelectedItem._parentSideMenuItem?._menuIndex != _menuIndex)
            {
                return 1;
            }


            // Check for Case 2:
            // Selected:
            // SubItem, of Expanded Item selected

            // New Selection:
            // Item, outside of Expanded Item selected
            var t = _parentSideMenuItem?.IsExpanded;
            bool t2 = t is null ? false : (bool)t ? true : false;
            if (t2 &&
                newSelectedItem._menuIndex != _menuIndex &&
                newSelectedItem._parentSideMenuItem?._menuIndex != _menuIndex &&
                newSelectedItem._parentSideMenuItem?._menuIndex != _parentSideMenuItem?._menuIndex)
            {
                return 2;
            }


            // Check for Case 3:
            // Selected:
            // SubItem, of Expanded Item selected

            // New Selection:
            // Parent Item, that is expanded, selected
            if (t2 &&
                newSelectedItem._menuIndex == _parentSideMenuItem?._menuIndex)
            {
                return 3;
            }


            // Check for Case 4:
            // Selected:
            // SubItem, of Expanded Item selected

            // New Selection:
            // Other SubItem, of Expanded Item selected
            if (t2 &&
                newSelectedItem._parentSideMenuItem?._menuIndex == _parentSideMenuItem?._menuIndex)
            {
                return 4;
            }


            // Check for Case 5:

            if (_parentSideMenuItem is null &&
                HasItems == false &&
                newSelectedItem._menuIndex != _menuIndex)
            {
                return 5;
            }


            // Check for Case 6:
            if (_parentSideMenuItem is null &&
                newSelectedItem._parentSideMenuItem?._menuIndex == _menuIndex)
                return 6;

            // Unkown case, error
            return -1;
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
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}