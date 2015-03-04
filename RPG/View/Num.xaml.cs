using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.View {
    /// <summary>
    /// CardCount.xaml 的互動邏輯
    /// </summary>
    public partial class Num : UserControl {

        private int maxNum = 100;
        private int minNum = 0;
        public int MaxNum {
            get { return maxNum; }
            set { if (value > minNum) maxNum = value; else maxNum = minNum; }
        }
        public int MinNum {
            get { return minNum; }
            set { if (value < maxNum) minNum = value; else minNum = maxNum; }
        }

        public Num() {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            Grid grid = (Grid)sender;
        }

        private void Polygon_MouseDown_Left(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)l.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0,0,0);

            Change_text((Convert.ToInt32(TBnum.Text) - 1));
        }
        private void Polygon_MouseUp_Left(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)l.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0xFF,0x00,0xDD);
        }
        private void Polygon_MouseDown_Right(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)r.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0, 0, 0);

            Change_text((Convert.ToInt32(TBnum.Text) + 1));
        }
        private void Polygon_MouseUp_Right(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)r.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0xFF, 0x00, 0xDD);
        }

        public void Change_text(int s){
            if (s < minNum) s = minNum;
            if (s > maxNum) s = maxNum;
            TBnum.Text = s.ToString();
        }

        public int GetValue() {
            return int.Parse(TBnum.Text);
        }



    }
}
