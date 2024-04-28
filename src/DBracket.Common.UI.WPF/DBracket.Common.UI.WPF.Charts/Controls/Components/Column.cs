using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.WPF.Charts.Controls.Components
{
    public class Column : FrameworkElement
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Column()
        {
            //Points.Add(new Point(100, 0));
            //Points.Add(new Point(100, 0));
            //Points.Add(new Point(150, 0));
            //Points.Add(new Point(150, 0));
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private static void HandleValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = d as Column;
            if (column is not null)
            {
                column.Points[0].AnimatePoint((double)e.NewValue, 100.0);
                column.Points[3].AnimatePoint((double)e.NewValue, 150.0);

                //foreach (var point in column.Points)
                //{
                //    point.AnimatePoint((double)e.NewValue);
                //}
            }
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register(
                "Value", 
                typeof(double),
                typeof(Column),
                new FrameworkPropertyMetadata(
                    2.0, 
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(HandleValueChanged)
                    ));

        public ObservableCollection<Point> Points
        {
            get => (ObservableCollection<Point>)GetValue(PointsProperty);
            private set => SetValue(PointsProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty PointsProperty = 
            DependencyProperty.Register(
                "Points", 
                typeof(ObservableCollection<Point>), 
                typeof(Column), 
                new FrameworkPropertyMetadata(
                    new ObservableCollection<Point> { new Point(100, 0), new Point(100, 0), new Point(150, 0), new Point(150, 0) }));

        //public PointCollection Points { get => _points; set { _points = value; OnMySelfChanged(); } }
        //private PointCollection _points = new();
        //public string Header
        //{
        //    get => (string)GetValue(HeaderProperty);
        //    set => SetValue(HeaderProperty, value);
        //}




        ///// <summary>DataPoint DependencyProperty</summary>
        //public static readonly DependencyProperty HeaderProperty =
        //    DependencyProperty.Register(
        //        "Header",
        //        typeof(string),
        //        typeof(AxisTest),
        //        new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}