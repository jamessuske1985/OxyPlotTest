using System;
using System.ComponentModel;
using OxyPlot;
using Xamarin.Forms;

namespace OxyPlotTest.Classes
{
    public class ReportsClass : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public int kidid { get; set; }
        public int rowNumber { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int grade { get; set; }
        public int AssignedTask { get; set; }
        public int CompletedTasks { get; set; }
        public int correctAnswers { get; set; }
        public int incorrectAnswers { get; set; }
        public string imagePath { get; set; }
        public ImageSource image { get; set; }
        //public PlotModel chart { get; set; }
        public PlotModel chart
        {
            get => _chart;
            set
            {
                _chart = value;
                if (_chart.PlotView == null && value.PlotView == null)
                {
                    OnPropertyChanged("chart");
                }

            }
        }
        public PlotModel _chart;
        /*public PlotModel chart
        {
            get
            {
                PlotModel model = new PlotModel();

                CategoryAxis xaxis = new CategoryAxis();
                xaxis.Position = AxisPosition.Bottom;
                xaxis.MajorGridlineStyle = LineStyle.None;
                xaxis.MinorGridlineStyle = LineStyle.None;
                xaxis.MinorTickSize = 0;
                xaxis.MajorTickSize = 0;
                xaxis.TextColor = OxyColors.Gray;
                xaxis.FontSize = 10.0;
                xaxis.Labels.Add("S");
                xaxis.Labels.Add("M");
                xaxis.Labels.Add("T");
                xaxis.Labels.Add("W");
                xaxis.Labels.Add("T");
                xaxis.Labels.Add("F");
                xaxis.Labels.Add("S");
                xaxis.GapWidth = 10.0;
                xaxis.IsPanEnabled = false;
                xaxis.IsZoomEnabled = false;


                LinearAxis yaxis = new LinearAxis();
                yaxis.Position = AxisPosition.Left;
                yaxis.MajorGridlineStyle = LineStyle.None;
                xaxis.MinorGridlineStyle = LineStyle.None;
                yaxis.MinorTickSize = 0;
                yaxis.MajorTickSize = 0;
                yaxis.TextColor = OxyColors.Gray;
                yaxis.FontSize = 10.0;
                yaxis.FontWeight = FontWeights.Bold;
                yaxis.IsZoomEnabled = false;
                yaxis.IsPanEnabled = false;


                ColumnSeries s2 = new ColumnSeries();
                s2.TextColor = OxyColors.White;

                s2.Items.Add(new ColumnItem
                {
                    Value = Sunday,
                    Color = OxyColor.Parse("#02cc9d")
                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Monday,
                    Color = OxyColor.Parse("#02cc9d")
                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Tuesday,
                    Color = OxyColor.Parse("#02cc9d")
                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Wednesday,
                    Color = OxyColor.Parse("#02cc9d")
                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Thursday,
                    Color = OxyColor.Parse("#02cc9d")

                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Friday,
                    Color = OxyColor.Parse("#02cc9d")
                });
                s2.Items.Add(new ColumnItem
                {
                    Value = Saturday,
                    Color = OxyColor.Parse("#02cc9d")
                });

                model.Axes.Add(xaxis);
                model.Axes.Add(yaxis);
                model.Series.Add(s2);
                model.PlotAreaBorderColor = OxyColors.Transparent;

                return model;
            }
        }*/
        public string currentTask { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }
        public double rewards { get; set; }
        public double actualRewards
        {
            get
            {
                return (double)rewards / 1000;
            }
        }
        public bool isCurrentTaskVisuable
        {

            get
            {
                if (currentTask == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                if (this.chart.PlotView == null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
        }
    }
}
