using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace hoshi_lib.Image {

    public class ImageManager {

        public Dictionary<string,BitmapImage> Images;

        public ImageManager(int ImageCount = 100) {
            Images = new Dictionary<string, BitmapImage>(ImageCount);
        }
        public ImageManager(string directory ,int ImageCount = 100) {
            Images = new Dictionary<string, BitmapImage>(ImageCount);
            AddImageFromDirectory(directory);
        }
        public ImageManager(string directory, IEnumerable<string> names, IEnumerator<string> keys, int ImageCount = 100) {
            Images = new Dictionary<string, BitmapImage>(ImageCount);
            AddImage(directory, names, keys);
        }

        public void AddImage(string key, string path) {
            if (path.Length - path.LastIndexOf('.') > 3) path += ".png";
            if (!File.Exists(path)) throw new Exception("Image Path Error!");
            Images[key] = new BitmapImage(new Uri(path,UriKind.Relative));
        }
        public void AddImage(string key, Uri uri) {
            Images[key] = new BitmapImage(uri);
        }
        public void AddImage(string key, BitmapImage bitmapImage) {
            Images[key] = bitmapImage;
        }
       
   
        private void AddImageFromDirectory(string path) {
            if (Directory.Exists(path)) {
                foreach (var fname in Directory.GetFiles(path)) {
                    var key = fname.Substring(fname.LastIndexOf('/')+1, fname.LastIndexOf('.') - fname.LastIndexOf('/')-1);
                    this.AddImage(key, new Uri(fname,UriKind.Relative));
                }
            } else {
                throw new Exception("找不到Image路徑");
            }
        }
        private void AddImageFromDirectory(string path, IEnumerator<string> keys) {

            if (Directory.Exists(path)) {
                foreach (var fname in Directory.GetFiles(path)) {
                    keys.MoveNext();
                    if (keys.Current == null) throw new Exception("Key錯誤");
                    this.AddImage(keys.Current, new Uri(fname, UriKind.Relative));
                }
            } else {
                throw new Exception("找不到Image路徑");
            }
        }
        public void AddImage(string directory, IEnumerable<string> fileName, IEnumerator<string> keys) {
            foreach (var it in fileName) {
                keys.MoveNext();
                if (keys.Current == null) throw new Exception("Key錯誤");
                if (!File.Exists(directory + it + ".png")) {
                    MessageBox.Show("Image位置錯誤!");
                    File.Create(directory + it + ".png");
                }
                this.AddImage(keys.Current, new Uri(directory + it + ".png", UriKind.Relative));
            }
        }

    }

}
