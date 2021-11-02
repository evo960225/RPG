using hoshi_lib.HLib;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace hoshi_lib.View {

    public class MatrixControl : HControlCollection, IMatrixControl {

        public IHControl[,] Controls { get; set; }
        public string[,] Description { get; set; }
        public MatrixSize MatrixSize { get; protected set; }
        public IHControl PopupView { get; set; }
        private Popup popup;


        public MatrixControl(MatrixSize matrixSize) {
            this.MatrixSize = matrixSize;
            this.Size = MatrixSize.Point.ToSize();
            CreateMatrix();
            Description = new string[MatrixSize.Y, MatrixSize.X];
            PopupInit();
        }
        private void CreateMatrix() {
            Controls = new HControl[MatrixSize.Y, MatrixSize.X];
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    Controls[i, j] = new HControl();
                    Controls[i, j].Size = MatrixSize.BlockSize;
                    Controls[i, j].Location = MatrixSize.GetBlockPoint(j, i);
                    this.AddControl(Controls[i, j].This);
                }
            }
        }
        private void PopupInit() {
            popup = new Popup();
            PopupView = new HControl() { Size = new Size(60, 30) , Opacity = 0.6};
            popup.Child = PopupView.This;
            popup.Placement = PlacementMode.Mouse;
                    
        }
        private void InitDescription(int x, int y) {
            Controls[y, x].AddMouseEvent(MouseEvent.Enter,
                      delegate {
                          string des = Description[y, x];
                          if (des != null) {
                              PopupView.Text = des;
                              popup.IsOpen = true;
                          }
                      });
            Controls[y, x].AddMouseEvent(MouseEvent.Leave,
               delegate { popup.IsOpen = false; });
        }
        
        public void SetDescription(params string[] text) {
            int index = 0;
            int len = text.Length;
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (index == len) return;
                    Description[i, j] = text[index];
                    InitDescription(j, i);
                    ++index;
                }
            }
        }
        public void SetDescription(string text, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Description[i, j] = text;
                        InitDescription(j, i);
                    }
                }
            }
        }
        public void SetText(params string[] text) {
            int index = 0;
            int len = text.Length;
            foreach (var it in Controls) {
                if (index == len) return;
                it.Text = text[index];
                ++index;
            }
        }
        public void SetText(string text, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Controls[i, j].Text = text;
                    }
                }
            }
        }
        public void SetImage(BitmapImage bmp , Func<int,int,bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Controls[i, j].Image = bmp;
                    }
                }
            }
        }
        public void SetColor(Brush brush, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Controls[i, j].BackColor = brush;
                    }
                }
            }
        }
        public void SetDoing(Action<IHControl> doing, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        doing(Controls[i, j]);
                    }
                }
            }
        }
        public IHControl GetItem(int number) {
            if (number < 0 || number >= Controls.Length) return null;
            int x = number % MatrixSize.X;
            int y = number / MatrixSize.X;
            return Controls[y, x];
        }

        
    }

    public class MatrixControl<T> : HControlCollection,IMatrixControl<T> where T : IHoshiView,new() {

        public T[,] Controls { get;  set; }
        public string[,] Description { get; set; }
        public MatrixSize MatrixSize { get; protected set; }
        public IHControl PopupView { get; set; }
        private Popup popup;

        public MatrixControl(MatrixSize matrixSize) {
            this.MatrixSize = matrixSize;
            this.Size = MatrixSize.Point.ToSize();
            Description = new string[MatrixSize.Y, MatrixSize.X];
            PopupInit();
            CreateMatrix();
            
        }
        public MatrixControl(MatrixSize matrixSize, Func<T> objAssign) {
            this.MatrixSize = matrixSize;
            this.Size = MatrixSize.Point.ToSize();
            Description = new string[MatrixSize.Y, MatrixSize.X];
            PopupInit();
            CreateMatrix(objAssign);
        }
        private void CreateMatrix() {
            Controls = new T[MatrixSize.Y, MatrixSize.X];
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    Controls[i, j] = new T();
                    Controls[i, j].Size = MatrixSize.BlockSize;
                    Controls[i, j].Location = MatrixSize.GetBlockPoint(j, i);
                    this.AddHControl(Controls[i, j]);
                }
            }
        }
        private void CreateMatrix(Func<T> objAssign) {
            Controls = new T[MatrixSize.Y, MatrixSize.X];
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    Controls[i, j] = objAssign();
                    Controls[i, j].Size = MatrixSize.BlockSize;
                    Controls[i, j].Location = MatrixSize.GetBlockPoint(j, i);
                    this.AddHControl(Controls[i, j]);
                }
            }
        }
        private void PopupInit() {
            popup = new Popup();
            PopupView = new HControl() { Size = new Size(30, 50) };
            popup.Child = PopupView.This;
            popup.Placement = PlacementMode.Mouse;

        }
        private void InitDescription(int x, int y) {
            Controls[y, x].AddMouseEvent(MouseEvent.Enter,
                      delegate {
                          string des = Description[y, x];
                          if (des != null) {
                              PopupView.Text = des;
                              popup.IsOpen = true;
                          }
                      });
            Controls[y, x].AddMouseEvent(MouseEvent.Leave,
               delegate { popup.IsOpen = false; });
        }

        public void SetDescription(params string[] text) {
            int index = 0;
            int len = text.Length;
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (index == len) return;
                    Description[i, j] = text[index];
                    InitDescription(j, i);
                    ++index;
                }
            }
        }
        public void SetDescription(string text, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Description[i, j] = text;
                        InitDescription(j, i);
                    }
                }
            }
        }
        public void SetImage(BitmapImage bmp, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Controls[i, j].Image = bmp;
                    }
                }
            }
        }
        public void SetColor(Brush brush, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        Controls[i, j].BackColor = brush;
                    }
                }
            }
        }
        public void SetDoing(Action<T> doing, Func<int, int, bool> equation = null) {
            for (int i = 0; i < MatrixSize.Y; ++i) {
                for (int j = 0; j < MatrixSize.X; ++j) {
                    if (equation == null || equation(j, i)) {
                        doing(Controls[i, j]);
                    }
                }
            }
        }
        public T GetItem(int number) {
            int x = number % MatrixSize.X;
            int y = number / MatrixSize.X;
            return Controls[y, x];
        }
    }
}
