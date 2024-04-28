using DBracket.Common.UI.WPF.Charts.Controls.Components;
using DBracket.Common.UI.WPF.Charts.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DBracket.Common.UI.WPF.Charts.Controls
{
    public class ColumnChart : Control
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ColumnChart()
        {
            //Task.Run(() =>
            //{
            //    UpdateChart();
            //});

            SizeChanged += HandleSizeChanged;

            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
        }

        private void HandleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                // Handle Width Changed
            }

            if (e.NewSize.Height != e.PreviousSize.Height)
            {
                // Handle Height Changed
                var height = e.NewSize.Height - 20;
                var t = 0.0;
                int lines = (int)height / 50;
                HorizontalGrid.Clear();
                for (int i = 0; i < lines; i++)
                {
                    HorizontalGrid.Add("s");
                }

            }
        }
        #endregion

        //protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        //{
        //    base.OnRenderSizeChanged(sizeInfo);
        //    var width = Width;
        //}
        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void UpdateChart()
        {
            //while (true)
            //{
            Point1 = new System.Windows.Point(-DataPoint.Value, 0);
            Point2 = new System.Windows.Point(-DataPoint.Value, 50);
            //    Task.Delay(100).Wait();
            //}
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private async static void UpdatePoints(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chart = d as ColumnChart;
            if (chart is null)
                return;

            chart.DataPoints.CollectionChanged += (s, e) =>
            {
                var pointCollection = s as ObservableCollection<ChartDataPoint>;
                if (pointCollection is null)
                    return;

                foreach (var point in pointCollection)
                {
                    //point.PropertyChanged += (s, e) =>
                    //{
                    PointAnimation animation = new PointAnimation(new System.Windows.Point(0, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
                        chart.BeginAnimation(Point1Property, animation);
                    PointAnimation animation2 = new PointAnimation(new System.Windows.Point(50, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
                        chart.BeginAnimation(Point2Property, animation2);


                    //};
                }

            };
            //if (chart is not null)
            //{
            //    PointAnimation animation = new PointAnimation(new Point(0, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
            //    chart.BeginAnimation(Point1Property, animation);
            //    PointAnimation animation2 = new PointAnimation(new Point(50, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
            //    chart.BeginAnimation(Point2Property, animation2);
            //}
            //if (chart is not null)
            //{
            //    PointAnimation animation = new PointAnimation(new Point(0, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
            //    chart.BeginAnimation(Point1Property, animation);
            //    PointAnimation animation2 = new PointAnimation(new Point(50, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
            //    chart.BeginAnimation(Point2Property, animation2);
            //}
        }

        private async static void UpdatePoint(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chart = d as ColumnChart;
            if (chart is not null)
            {
                PointAnimation animation = new PointAnimation(new System.Windows.Point(0, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
                chart.BeginAnimation(Point1Property, animation);
                PointAnimation animation2 = new PointAnimation(new System.Windows.Point(50, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
                chart.BeginAnimation(Point2Property, animation2);








                //var index = 500;
                //var step = chart.DataPoint.Value / index;
                //var val = 0.0;
                //while (true)
                //{

                //    val += step;
                //    chart.Point1 = new Point(0, -val);
                //    chart.Point2 = new Point(50, -val);
                //    await Task.Delay(1);
                //    index--;
                //    if (index == 0)
                //        break;
                //}






                //chart.Point1 = new Point(0,-chart.DataPoint.Value);
                //chart.Point1 = new Point(-chart.DataPoint.Value,50);
                //chart.Point1 = new Point(0, -50);
                //chart.Point1 = new Point(-chart.DataPoint.Value, 50);

                //chart.DataPoint.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler ((object? sender, PropertyChangedEventArgs e) =>
                //{

                //});
            }
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<ChartDataPoint> DataPoints
        {
            get => (ObservableCollection<ChartDataPoint>)GetValue(DataPointsProperty);
            set => SetValue(DataPointsProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty DataPointsProperty = DependencyProperty.Register(
            "DataPoints", typeof(ObservableCollection<ChartDataPoint>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<ChartDataPoint>(), UpdatePoints));

        public ObservableCollection<Column> Columns
        {
            get => (ObservableCollection<Column>)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns", typeof(ObservableCollection<Column>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<Column>()));






        public AxisTest YAxis
        {
            get => (AxisTest)GetValue(YAxisProperty);
            set => SetValue(YAxisProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty YAxisProperty = DependencyProperty.Register(
            "YAxis", typeof(AxisTest), typeof(ColumnChart), new FrameworkPropertyMetadata(null));






        public ObservableCollection<string> HorizontalGrid
        {
            get => (ObservableCollection<string>)GetValue(HorizontalGridProperty);
            set => SetValue(HorizontalGridProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty HorizontalGridProperty = DependencyProperty.Register(
            "HorizontalGrid", typeof(ObservableCollection<string>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ChartDataPoint DataPoint
        {
            get => (ChartDataPoint)GetValue(DataPointProperty);
            set => SetValue(DataPointProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty DataPointProperty = DependencyProperty.Register(
            "DataPoint", typeof(ChartDataPoint), typeof(ColumnChart), new FrameworkPropertyMetadata(null, UpdatePoint));



        public System.Windows.Point Point1
        {
            get => (System.Windows.Point)GetValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty Point1Property = DependencyProperty.Register(
            "Point1", typeof(System.Windows.Point), typeof(ColumnChart), new FrameworkPropertyMetadata(new System.Windows.Point()));

        public System.Windows.Point Point2
        {
            get => (System.Windows.Point)GetValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty Point2Property = DependencyProperty.Register(
            "Point2", typeof(System.Windows.Point), typeof(ColumnChart), new FrameworkPropertyMetadata(new System.Windows.Point(50, 0)));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}