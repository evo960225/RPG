using hoshi_lib.Game._2D;
using hoshi_lib.Game._2D.RPG;
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

    public partial class SkillItem : HControlCollection {
        public int Cost {
            get { return int.Parse(HCost.Text); }
            set { HCost.Text = value.ToString(); }
        }
        public int Level {
            get { return int.Parse(HLevel.Text); }
            set { HLevel.Text = value.ToString(); }
        }
        public string SkillName {
            get { return HName.Text; }
            set { HName.Text = value; }
        }
        public double CD {
            get { return HImage.CircleRunTime; }
            set { HImage.CircleRunTime = value; }
        }
        public Skill Skill {
            get { return skill; }
            set { 
                skill = value;
                LoadSkill();
            }
        }
        public bool PlusEnable {
            get { return plusEnable; }
            set { 
                plusEnable = value;
                if (value) {
                    ButtonPlus.BackColor = Brushes.LightGray;
                    ButtonPlus.LeaveBrush = Brushes.LightGray;
                    ButtonPlus.BorderBrush = Brushes.LightSeaGreen;
                } else {
                    ButtonPlus.BackColor = Brushes.DarkGray;
                    ButtonPlus.LeaveBrush = Brushes.DarkGray;
                    ButtonPlus.BorderBrush = Brushes.DarkGray;
                }
            }
        }
        private bool plusEnable = false;

        private Skill skill;
        public SkillItem() {
            InitializeComponent();
        }
        public SkillItem(MouseButtomEvent useMethod) {
            InitializeComponent();
            //HImage.AddMouseEvent(useMethod, delegate { Use(); });
        }
     
        private void LoadSkill() {
            Cost = skill.CostSp;
            SkillName = skill.Name;
            Level = 1;
            CD = skill.CD;
            HImage.SetContent(skill);
        }
    }
}
