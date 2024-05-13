using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

// ToDo:
// - Expand false -> Expand true -> Error when selecting a new item
// - Width of the Menu is static in the animations (300), width needs to adapt automatically
// - Selected Item Background should change
// - Margin of Items needs to change, depending on layer
// - ToggleButton, to expand Menu needs to be correctely styled
// - Mouseover Background needs to be stylized 
// - Submenu expansion animation
// - Sometimes error when selecting item -> Height is NaN, can't use doubleanimation
// 
// - Feature: MenuItemSeparator
// - Feature: SearchBar

namespace DBracket.Common.UI.WPF.Controls
{
    public class SideMenu : ItemsControl
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SideMenuItem _selectedSideMenuItem;

        private System.Windows.Controls.Button _button;
        private Border _border;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SideMenu()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var button = GetTemplateChild("PART_ToggleButton") as System.Windows.Controls.Button;
            if (button is null)
                throw new Exception();
            button.Click += HandleToggleButtonClick;
            _button = button;

            var border = GetTemplateChild("PART_Root") as Border;
            if (border is null)
                throw new Exception();
            _border = border;
        }

        private void HandleToggleButtonClick(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            int menuIndex = 0;
            foreach (SideMenuItem sideMenuItem in Items)
            {
                sideMenuItem.SetParentSideMenu(this, ref menuIndex);
            }
        }

        internal void NewMenuItemSelected(SideMenuItem newSelectedSideMenuItem)
        {
            if (IsExpanded == false)
                return;

            if (newSelectedSideMenuItem == _selectedSideMenuItem)
            {
                if (_selectedSideMenuItem.IsExpanded)
                {
                    SideMenuItem.CollapseMenu(_selectedSideMenuItem);
                }
                else
                {
                    _selectedSideMenuItem.ExpandMenu();
                }
                return;
            }

            DoubleAnimation animation = null;
            var menuWasCollapsed = false;

            // Animate deselection of current Item
            if (_selectedSideMenuItem is not null)
            {
                _selectedSideMenuItem.IsSelected = false;
                menuWasCollapsed = _selectedSideMenuItem.CheckStateAndCollapse(newSelectedSideMenuItem);
                animation = new DoubleAnimation(0, new TimeSpan(0, 0, 0, 0, 200));
                _selectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, animation);
            }
            else
            {
                menuWasCollapsed = true;
            }


            // Animate new Selected Item
            animation = new DoubleAnimation(newSelectedSideMenuItem._button.ActualHeight - 4, new TimeSpan(0, 0, 0, 0, 200));
            newSelectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, animation);
            newSelectedSideMenuItem.IsSelected = true;
            if (menuWasCollapsed)
                newSelectedSideMenuItem.ExpandMenu();

            _selectedSideMenuItem = newSelectedSideMenuItem;

            //PointAnimation animation = new PointAnimation(new System.Windows.Point(xOffset, -value), new TimeSpan(0, 0, 0, 0, 400));
            //this.BeginAnimation(DataProperty, animation);
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
            "IsExpanded", typeof(bool), typeof(SideMenu), new FrameworkPropertyMetadata(true, HandleIsExpandedChanged));

        private static void HandleIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not bool isExpanded)
                return;

            var sideMenu = d as SideMenu;
            if (isExpanded)
            {
                if (sideMenu.Width == double.NaN)
                    sideMenu.Width = 50;
                var animation = new DoubleAnimation(280, new TimeSpan(0, 0, 0, 0, 200));
                sideMenu.BeginAnimation(WidthProperty, animation);
            }
            else
            {
                // Collapse all opened menus
                foreach (var item in sideMenu.Items)
                {
                    if (item is SideMenuItem sideMenuItem)
                    {
                        sideMenuItem.CollapseAllSubMenus();
                    }
                }


                // Select top level menu
                if (sideMenu._selectedSideMenuItem?._parentSideMenuItem is not null)
                {
                    var heightAnimation = new DoubleAnimation(0, new TimeSpan(0, 0, 0, 0, 200));
                    sideMenu._selectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, heightAnimation);
                    sideMenu._selectedSideMenuItem.IsSelected = false;
                    while (sideMenu._selectedSideMenuItem._parentSideMenuItem is not null)
                    {
                        sideMenu._selectedSideMenuItem = sideMenu._selectedSideMenuItem._parentSideMenuItem;
                    }
                    heightAnimation = new DoubleAnimation(sideMenu._selectedSideMenuItem._button.ActualHeight - 4, new TimeSpan(0, 0, 0, 0, 200));
                    sideMenu._selectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, heightAnimation);
                    sideMenu._selectedSideMenuItem.IsSelected = true;
                }


                // Change menu width
                if (sideMenu.Width == double.NaN)
                    sideMenu.Width = 280;
                var animation = new DoubleAnimation(50, new TimeSpan(0, 0, 0, 0, 200));
                sideMenu.BeginAnimation(WidthProperty, animation);
            }
        }

        //public SideMenuItemCollection Entries
        //{
        //    get => (SideMenuItemCollection)GetValue(EntriesProperty);
        //    set => SetValue(EntriesProperty, value);
        //}
        //public static readonly DependencyProperty EntriesProperty = DependencyProperty.Register(
        //    "Entries", typeof(SideMenuItemCollection), typeof(SideMenu), new FrameworkPropertyMetadata(null));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}