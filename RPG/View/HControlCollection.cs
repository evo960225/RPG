using System.Windows.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
namespace hoshi_lib.View {

    public class HControlCollection : Grid, IHControlCollection {
        private BitmapImage image;
        public BitmapImage Image {
            get { return image; }
            set {
                image = value;
                base.Background = new ImageBrush(value);
            }
        }
        public Size Size {
            get { return new Size((int)this.Width, (int)this.Height); }
            set { this.Width = value.Width; this.Height = value.Height; }
        }
        public Point Location {
            get { return new Point((int)this.Margin.Left, (int)this.Margin.Top); }
            set { this.Margin = value.GetThickness(); }
        }
        public Brush BackColor {
            get { return this.Background; }
            set { this.Background = value; }
        }
        public bool Visible {
            get { return this.Visibility == Visibility.Visible; }
            set { this.Visibility = value ? Visibility.Visible : Visibility.Hidden; }
        }
        public Grid This { get { return this; } }
        public FrameworkElement Net {
            get { return this; }
        }

        public HControlCollection() {
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            Size = new Size(800, 600);
        }

        public void AddControl(UIElement control) {
            this.Children.Add(control);
        }
        public void AddHControl(IHoshiView control) {
            this.Children.Add(control.Net);
        }
        public void AddHControl(IHControl control) {
            this.Children.Add(control.This);
        }
        public void AddHControl(IHControlCollection collection) {
            this.Children.Add(collection.This);
        }
        public void RemoveControl(UIElement control) {
            this.Children.Remove(control);
        }
        public void RemoveHControl(IHoshiView control) {
            this.Children.Remove(control.Net);
        }
        public void RemoveHControl(IHControl control) {
            this.Children.Remove(control.This);
        }
        public void RemoveHControl(IHControlCollection collection) {
            this.Children.Remove(collection.This);
        }

        public void AddMouseEvent(MouseEvent mEvent, MouseEventHandler addEventHandler) {
            switch (mEvent) {
                case MouseEvent.Enter:
                    this.MouseEnter += addEventHandler; break;
                case MouseEvent.Leave:
                    this.MouseLeave += addEventHandler; break;
                case MouseEvent.Move:
                    this.MouseMove += addEventHandler; break;
            }
        }
        public void AddMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler addEventHandler) {
            switch (mbEvent) {
                case MouseButtomEvent.Down:
                    this.MouseDown += addEventHandler; break;
                case MouseButtomEvent.Up:
                    this.MouseUp += addEventHandler; break;
                case MouseButtomEvent.LeftButtonDown:
                    this.MouseLeftButtonDown += addEventHandler; break;
                case MouseButtomEvent.LeftButtonUp:
                    this.MouseLeftButtonUp += addEventHandler; break;
                case MouseButtomEvent.RightButtonDown:
                    this.MouseRightButtonDown += addEventHandler; break;
                case MouseButtomEvent.RightButtonUp:
                    this.MouseRightButtonUp += addEventHandler; break;
            }
        }
        public void RemoveMouseEvent(MouseEvent mEvent, MouseEventHandler removeEventHandler) {
            try {
                switch (mEvent) {
                    case MouseEvent.Enter:
                        this.MouseEnter -= removeEventHandler;
                        break;
                    case MouseEvent.Leave:
                        this.MouseLeave -= removeEventHandler;
                        break;
                    case MouseEvent.Move:
                        this.MouseMove -= removeEventHandler;
                        break;
                }
            } catch { }
        }
        public void RemoveMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler removeEventHandler) {
            try {
                switch (mbEvent) {
                    case MouseButtomEvent.Down:
                        this.MouseDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.LeftButtonDown:
                        this.MouseLeftButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.LeftButtonUp:
                        this.MouseLeftButtonUp -= removeEventHandler;
                        break;
                    case MouseButtomEvent.RightButtonDown:
                        this.MouseRightButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.RightButtonUp:
                        this.MouseRightButtonUp -= removeEventHandler;
                        break;
                }
            } catch { }
        }








        public void RemoveControl(IHoshiView control) {
            throw new NotImplementedException();
        }


        public void AddRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler) {
            throw new NotImplementedException();
        }

        public void RemoveRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler) {
            throw new NotImplementedException();
        }
    }
}
