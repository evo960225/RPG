using System.Windows.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
namespace hoshi_lib.View {
    public class HControlCollection : IH<Grid> {

        public Size Size {
            get { return new Size(grid.Width, grid.Height); }
            set { grid.Width = value.Width; grid.Height = value.Height;}
        }
        public Location Location {
            get { return new Location(grid.Margin.Left, grid.Margin.Top); }
            set { grid.Margin = value.GetThickness(); }
        }

        private Grid grid;
        public int ControlsCount = 0;

        public HControlCollection() {
            grid = new Grid();
            Size = new Size(800, 600);
            SetAbsoluteLoaction();
        }
        public HControlCollection(Grid grid) {
            this.grid = grid;
            SetAbsoluteLoaction();
        }

        public void AddControl(UserControl control) {
            grid.Children.Add(control);
            ++ControlsCount;
        }
        public void AddHControl(HControl control) {
            grid.Children.Add(control.ToNET());
            ++ControlsCount;
        }
        public void AddHControlCollection(HControlCollection collection) {
            grid.Children.Add(collection.ToNET());
            ++ControlsCount;
        }
        private void SetAbsoluteLoaction() {
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
        }


        public Grid ToNET() {
            return grid;
        }
    }
}
