using System.Collections.Specialized;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DBracket.Common.UI.WPF.Controls
{
    public class SideMenu : ItemsControl
    {
        #region "----------------------------- Private Fields ------------------------------"
        private SideMenuItem _selectedSideMenuItem;
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
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
            if (newSelectedSideMenuItem == _selectedSideMenuItem)
                return;

            DoubleAnimation animation = null;
            var menuWasCollapsed = false;

            // Animate deselection of current Item
            if (_selectedSideMenuItem is not null)
            {
                _selectedSideMenuItem.IsSelected = false;
                menuWasCollapsed = _selectedSideMenuItem.CollapseIfNotParentIDMenu(newSelectedSideMenuItem);
                //if (_selectedSideMenuItem._parentSideMenuItem is not null)
                //{
                //    menuWasCollapsed = _selectedSideMenuItem.CollapseIfNotParentIDMenu(newSelectedSideMenuItem);
                //}
                //else
                //{
                //    menuWasCollapsed = _selectedSideMenuItem.CollapseIfNotParentIDMenu(newSelectedSideMenuItem);
                //}
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