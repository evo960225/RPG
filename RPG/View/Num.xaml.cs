using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.View {
    /// <summary>
    /// CardCount.xaml 的互動邏輯
    /// </summary>
    partial class UNum : UserControl {

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
        public int Value { get; protected set; }

        public UNum() {
            InitializeComponent();
            Value = 0;
            TBnum.Text = Value.ToString();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
        }
        private void Polygon_MouseDown_Left(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)ButL.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0,0,0);

            SetValue(Value-1);
        }
        private void Polygon_MouseUp_Left(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)ButL.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0xFF,0x00,0xDD);
        }
        private void Polygon_MouseDown_Right(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)ButR.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0, 0, 0);

            SetValue(Value+1);
        }
        private void Polygon_MouseUp_Right(object sender, MouseButtonEventArgs e) {
            LinearGradientBrush br = (LinearGradientBrush)ButR.Fill;
            br.GradientStops[1].Color = Color.FromRgb(0xFF, 0x00, 0xDD);
        }

        public void SetValue(int value){
            if (value < minNum) value = minNum;
            if (value > maxNum) value = maxNum;
            Value = value;
            TBnum.Text = value.ToString();
        }

        public int GetValue() {
            return int.Parse(TBnum.Text);
        }

    }

    public class Num:HControl {
        UNum num;
        public int MaxNum {
            get { return num.MaxNum; }
            set { num.MaxNum = value; }
        }
        public int MinNum {
            get { return num.MinNum; }
            set { num.MinNum = value; }
        }
        public int Value {
            get { return num.Value; }
            set { num.SetValue(value); }
        }
        public bool Enable {
            get { return num.IsEnabled; }
            set { num.IsEnabled = value; }
        }
        public bool LButtonEnable {
            get { return num.ButL.IsEnabled; }
            set { num.ButL.IsEnabled = value; }
        }
        public bool RButtonEnable {
            get { return num.ButR.IsEnabled; }
            set { num.ButR.IsEnabled = value; }
        }
        public Num(UNum num) {
            this.control = num;
            this.num = num;
            this.Size = new Size(num.Width,num.Height);
        }

    }
}
