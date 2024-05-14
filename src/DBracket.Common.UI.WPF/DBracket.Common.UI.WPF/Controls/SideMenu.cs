using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

// ToDo:
// - Margin of Items needs to change, depending on layer
// - ToggleButton, to expand Menu needs to be correctely styled
// - Submenu expansion animation
// - When Expanded Item is click again -> Collapse
// - When not Expanded -> MenuItems as actual MenuItems
// 
// - Feature: MenuItemSeparator
// - Feature: SearchBar
// __ __ CLEAN UP __ __

// Done:
// - Sometimes error when selecting item -> Height is NaN, can't use doubleanimation -> Before collapsing the menu, animate the indicator for the new selectedmenuitem
// - Expand false -> Expand true -> Error when selecting a new item
// - Width of the Menu is static in the animations (300), width needs to adapt automatically
// - Selected Item Background should change
// - Mouseover Background needs to be stylized 


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
        private double GetWidthOfWidestSideMenuItemIconContent()
        {
            var iconWidth = 0.0;
            foreach (var item in Items)
            {
                if (item is SideMenuItem sideMenuItem)
                {
                    var tmp= sideMenuItem._iconPresenter.ActualWidth + 20;
                    if (tmp > iconWidth)
                        iconWidth = tmp;
                }
            }
            return iconWidth;
        } 

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
                if (_selectedSideMenuItem._isSelectedIndicator.Height == double.NaN)
                    _selectedSideMenuItem._isSelectedIndicator.Height = _selectedSideMenuItem.ActualHeight;
                animation = new DoubleAnimation(0, new TimeSpan(0, 0, 0, 0, 200));
                _selectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, animation);

                _selectedSideMenuItem.IsSelected = false;
                menuWasCollapsed = _selectedSideMenuItem.CheckStateAndCollapse(newSelectedSideMenuItem);
            }
            else
            {
                menuWasCollapsed = true;
            }


            // Animate new Selected Item
            if (newSelectedSideMenuItem._isSelectedIndicator.Height == double.NaN)
                newSelectedSideMenuItem._isSelectedIndicator.Height = newSelectedSideMenuItem.ActualHeight;
            animation = new DoubleAnimation(newSelectedSideMenuItem._button.ActualHeight - 4, new TimeSpan(0, 0, 0, 0, 200));
            newSelectedSideMenuItem._isSelectedIndicator.BeginAnimation(HeightProperty, animation);
            newSelectedSideMenuItem.IsSelected = true;
            if (menuWasCollapsed)
                newSelectedSideMenuItem.ExpandMenu();

            _selectedSideMenuItem = newSelectedSideMenuItem;
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
            var iconWidth = sideMenu.GetWidthOfWidestSideMenuItemIconContent();

            if (isExpanded)
            {
                if (sideMenu.Width == double.NaN)
                    sideMenu.Width = iconWidth;
                var animation = new DoubleAnimation(((SideMenuItem)sideMenu.Items[0]).Width, new TimeSpan(0, 0, 0, 0, 200));
                sideMenu.BeginAnimation(WidthProperty, animation);
                foreach (var item in sideMenu.Items)
                {
                    if (item is SideMenuItem sideMenuItem)
                        sideMenuItem.RemoveSubItemsAsMenuItems();
                }
            }
            else
            {
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


                // Collapse all opened menus and move SubMenus in _button
                foreach (var item in sideMenu.Items)
                {
                    if (item is SideMenuItem sideMenuItem)
                    {
                        sideMenuItem.CollapseAllSubMenus();
                        sideMenuItem.SetSubItemsAsMenuItems();
                    }
                }


                // Change menu width
                if (sideMenu.Width == double.NaN)
                    sideMenu.Width = ((SideMenuItem)sideMenu.Items[0]).Width;
                var animation = new DoubleAnimation(iconWidth, new TimeSpan(0, 0, 0, 0, 200));
                sideMenu.BeginAnimation(WidthProperty, animation);
            }
        }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}