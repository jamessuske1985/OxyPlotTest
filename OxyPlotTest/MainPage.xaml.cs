using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;
using OxyPlotTest.Classes;
using OxyPlot.Series;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using OxyPlot;

namespace OxyPlotTest
{
    public partial class MainPage : ContentPage
    {

        WebServiceClass webServiceClass = new WebServiceClass();

        DateTime currentDate = DateTime.Now;

        Expander expander;

        ObservableCollection<ReportsClass> kids = new ObservableCollection<ReportsClass>();

        public MainPage()
        {

            InitializeComponent();

            PreviousDateRange.CornerRadius = 20;
            NextDateRange.CornerRadius = 20;

            DateTime firstDate = currentDate.StartOfWeek(DayOfWeek.Sunday);
            DateTime secondDate = currentDate.AddDays(7).StartOfWeek(DayOfWeek.Saturday);

            DateRange.Text = firstDate.ToString("MMMM d") + " - " + secondDate.ToString("MMMM d");

            getKids();

        }

        public async void getKids()
        {


            kids = await webServiceClass.Reports(6, currentDate.StartOfWeek(DayOfWeek.Sunday), currentDate.AddDays(7).StartOfWeek(DayOfWeek.Saturday));

            Kids.ItemsSource = kids;
        }

        void PreviousDateRange_Clicked(System.Object sender, System.EventArgs e)
        {

            currentDate = currentDate.AddDays(-7);

            DateTime firstDate = currentDate.StartOfWeek(DayOfWeek.Sunday);
            DateTime secondDate = currentDate.AddDays(7).StartOfWeek(DayOfWeek.Saturday);

            DateRange.Text = firstDate.ToString("MMMM d") + " - " + secondDate.ToString("MMMM d");

            getKids();

        }

        void NextDateRange_Clicked(System.Object sender, System.EventArgs e)
        {

            currentDate = currentDate.AddDays(7);

            DateTime firstDate = currentDate.StartOfWeek(DayOfWeek.Sunday);
            DateTime secondDate = currentDate.AddDays(7).StartOfWeek(DayOfWeek.Saturday);

            DateRange.Text = firstDate.ToString("MMMM d") + " - " + secondDate.ToString("MMMM d");

            getKids();


        }

        void DetachModelFromView(OxyPlot.PlotModel model)
        {
            var plotModel = model as OxyPlot.IPlotModel;
            if (plotModel != null)
            {
                plotModel.AttachPlotView(null);
            }
        }

        void Expander_Tapped(System.Object sender, System.EventArgs e)
        {
            if (ReferenceEquals(sender, expander))
            {
                // User is tapping the existing expander. Don't do anything special.
                return;
            }

            if (expander != null)
            {
                expander.IsExpanded = false;
            }

            expander = sender as Expander;

            int id = Convert.ToInt32(expander.ClassId);

            ReportsClass item = kids[id];


            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                if (item.chart == null)
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
                        Value = item.Sunday,
                        Color = OxyColor.Parse("#02cc9d")
                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Monday,
                        Color = OxyColor.Parse("#02cc9d")
                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Tuesday,
                        Color = OxyColor.Parse("#02cc9d")
                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Wednesday,
                        Color = OxyColor.Parse("#02cc9d")
                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Thursday,
                        Color = OxyColor.Parse("#02cc9d")

                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Friday,
                        Color = OxyColor.Parse("#02cc9d")
                    });
                    s2.Items.Add(new ColumnItem
                    {
                        Value = item.Saturday,
                        Color = OxyColor.Parse("#02cc9d")
                    });

                    model.Axes.Add(xaxis);
                    model.Axes.Add(yaxis);
                    model.Series.Add(s2);
                    model.PlotAreaBorderColor = OxyColors.Transparent;

                    item.chart = model;
                }

                return false;
            });

        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
