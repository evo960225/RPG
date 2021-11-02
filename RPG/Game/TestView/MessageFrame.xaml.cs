using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// MessageFrame.xaml 的互動邏輯
    /// </summary>
    public partial class MessageFrame : HControlCollection {
        public string MessageText {
            get { return Content.Text; }
            set { Content.Text = value; }
        }
        public string SpeakerName {
            get { return HSpeaker.Text; }
            set { HSpeaker.Text = value; }
        }
        public IList<string> MessageList { get; set; }
        public int MessageIndex{get;set;}

        public MessageFrame() {
            InitializeComponent();
            MessageList = new List<string>();
        }
        public void Next() {
            if (MessageList!=null && MessageIndex < MessageList.Count) {
                MessageText = MessageList[MessageIndex];
                ++MessageIndex;
            } else {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
