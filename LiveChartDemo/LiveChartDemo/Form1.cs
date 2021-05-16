using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers

namespace LiveChartDemo
{
    public partial class Form1 : Form
    {

        private Random rand = new Random(0);
        

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // generate some random Y data
            int pointCount = 50;
            double[] ys1 = RandomWalk(pointCount);
            double[] ys2 = RandomWalk(pointCount);
            double[] ys3 = RandomWalk(pointCount);

            // create series and populate them with data
            var series1 = new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Group A",
                Values = new LiveCharts.ChartValues<double>(ys1)
            };

            var series2 = new LiveCharts.Wpf.ColumnSeries()
            {
                Title = "Group B",
                Values = new LiveCharts.ChartValues<double>(ys2)
            };

            var series3 = new LiveCharts.Wpf.ColumnSeries()
            {
                Title = "Group C",
                Values = new LiveCharts.ChartValues<double>(ys3)

            };
            

            // display the series in the chart control
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(series1);
            cartesianChart1.Series.Add(series2);
            cartesianChart1.Series.Add(series3);
            cartesianChart1.Zoom = LiveCharts.ZoomingOptions.Xy;



            var series4 = new LiveCharts.Wpf.LineSeries
            {
                Title = "Group A",
                Values = new LiveCharts.ChartValues<double>(ys1)
            };

            // display the series in the chart control
            cartesianChart2.Series.Clear();
            cartesianChart2.Series.Add(series4);
            cartesianChart2.Zoom = LiveCharts.ZoomingOptions.Xy;


        }

        private double[] RandomWalk(int points = 5, double start = 100, double mult = 50)
        {
            // return an array of difting random numbers
            double[] values = new double[points];
            values[0] = start;
            for (int i = 1; i < points; i++)
                values[i] = values[i - 1] + (rand.NextDouble() - .5) * mult;
            return values;
        }


    }
            
    
}
