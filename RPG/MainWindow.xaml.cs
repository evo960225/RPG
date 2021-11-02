using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using hoshi_lib.View;
using hoshi_lib.HLib;
using hoshi_lib.Game._2D;
using hoshi_lib.Input;
using hoshi_lib.Game;
using hoshi_lib.Game.TestView;
using hoshi_lib.Game.RPG;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Data;

namespace hoshi_lib {
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window {

        #region 主視窗初始化
        IScreen screen;
        public MainWindow() {
            InitializeComponent();
            WindowController.Window = this;
            screen = new Screen(new Size(1024, 650));
            WindowController.Screen = screen;

            MapTest();   
        }
        #endregion
        #region 控制項測試
        public void MainScreen() {
            ITitleScreen tit = new TitleScreen(new Size(1024, 650), "test");
            tit.CreateButtons(3, "start", "load", "exit");
            tit.SetStandardSytle();
            Array.ForEach(tit.Buttons, (x) => x.EnterBrush = Brushes.Chocolate);
        }
        public void MatrixTest() {
            MatrixSize matrixPoint = new MatrixSize(3, 3) {
                BlockSize = new Size(30, 30),
                SpanX = 3,
                SpanY = 3
            };
            IMatrixControl mat = new MatrixControl(matrixPoint);
            mat.Location = new Point(5, 5);
            mat.SetColor(Brushes.LightGray);
            mat.SetColor(Brushes.Aqua, (x, y) => x + y == 2);
            mat.SetColor(Brushes.Beige, (x, y) => x == y);
            screen.AddHControl(mat);

            IMatrixControl<HButton> mat2 = new MatrixControl<HButton>(matrixPoint,
                delegate {
                    var but = new HButton();
                    but.BackColor = Brushes.Cyan;
                    but.EnterBrush = Brushes.LightSalmon;
                    return but;
                });
            mat2.Location = new Point(120, 5);
            screen.AddHControl(mat2);

        }
        # endregion
        #region 主物件
        MapView mapview;
        MapView mapview2;
        BioView bioview;
        EventMaker eventTree;
        WorldCommand world;
        KeyDelegate key;
        #endregion

        #region 設定環境
        private void InitOpreation() {
            InitFunctionalSquare();
            InitStuff();
            InitSkill();
        }
        private void InitFunctionalSquare() {
            FunctionalSquare.ButtonRightFunc = delegate(IGameItem item) {
                if (item == null) return;
                if (item is IUsed) {
                    var u = (item as IUsed);
                    u.Used(bioview);
                } else if (item is Equipment) {
                    var accout = (item as Equipment);
                    accoutermentManager.Change(accout);
                }
            };
        }
        private void InitStuff() {
            Stuff.RelatDirectoryFormat = "../../Images/Stuff/{1}.png";
        }
        private void InitSkill() {
            Skill.RelatDirectoryFormat = "../../Images/Skill/{1}.png";
        }
        #endregion
        BioLoader bioload = new BioLoader();
        StuffLoader stuffload = new StuffLoader();
        public void MapTest() {
            InitOpreation();

            eventTree = new EventMaker();
            EventTreeTest();
            
            mapview = new MapView( "../../Map/map1.txt", "../../Images/Map/", new TerrainManager("../../Map/texture.txt", "../../Map/terrain_type.txt"), new Size(50, 50));
            mapview2 = new MapView("../../Map/map2.txt", "../../Images/Map/", new TerrainManager("../../Map/texture.txt", "../../Map/terrain_type.txt"), new Size(50, 50));
            mapview.SetTransmiss(mapview2, Direction.Right ,(p1) => (p1.X == 23) ? new MatrixPoint(0, p1.Y) : null);
            mapview2.SetTransmiss(mapview, Direction.Left, (p1) => (p1.X == 0) ? new MatrixPoint(23, p1.Y) : null);
            world = new WorldCommand(screen, mapview, eventTree);


            SetUser();
            
            SetCamera();
            MainTimer.Start();
            SetKey();
            SkillTest();
            PanelTest();
            ConsumableTest();
            LevelUpTest();
        }
       
        private void SetUser() {
            BioView.RelatDirectoryFormat = "../../Images/Role/{1} {2}{3}.png";
            BioView.SingleDirectionCount = 3;
            RoleLoader load = new RoleLoader();
            bioview = load.LoadRole(1, new Size(50, 50));
            bioview.AttackCD = 0.5;
            bioview.Money = 5000;
            world.AddBio(bioview, new MatrixPoint(12, 16));
        }
        private void SetAI() {
            var ai = bioload.LoadBio(1, new Size(50, 50));
            ai.SetMoveImage(Direction.Left, "../../Images/Bio/小毛.png");
            ai.SetMoveImage(Direction.Up, "../../Images/Bio/小毛.png");
            ai.SetMoveImage(Direction.Down, "../../Images/Bio/小毛.png");
            ai.SetMoveImage(Direction.Right, "../../Images/Bio/小毛.png");
            ai.ThrowStuff.Add(stuffload.LoadStuff(1));
            world.AddBio(ai, new MatrixPoint(8, 12));
        }
        private void SetAI2() {
            var ai = bioload.LoadBio(3, new Size(50, 50));
            ai.SetMoveImage(Direction.Left, "../../Images/Bio/小毛(藍).png");
            ai.SetMoveImage(Direction.Up, "../../Images/Bio/小毛(藍).png");
            ai.SetMoveImage(Direction.Down, "../../Images/Bio/小毛(藍).png");
            ai.SetMoveImage(Direction.Right, "../../Images/Bio/小毛(藍).png");
            ai.ThrowStuff.Add(stuffload.LoadStuff(3));
            world.AddBio(ai, new MatrixPoint(1, 12));
        }
        private void SetKey() {
            key = new KeyDelegate(WindowController.Window);
            key.AddPressEvent(Key.Left, () => bioview.MoveCommand(Direction.Left));
            key.AddPressEvent(Key.Up, () => bioview.MoveCommand(Direction.Up));
            key.AddPressEvent(Key.Down, () => bioview.MoveCommand(Direction.Down));
            key.AddPressEvent(Key.Right, () => bioview.MoveCommand(Direction.Right));
            key.AddEvent(Key.A, () => bioview.AttackCommand());
            key.AddEvent(Key.S, () => world.ThrowCommand(bioview, stuffload.LoadStuff(1)));
            key.AddEvent(Key.I, () => stuffWin.Visibility = Visibility.Visible);
            var skill = new Skill(1, "攻1", bioview, (ski, val) => val.ATK + 5) { Description = "很厲害的斬擊" };
            skill.EffectRegion = (p1, p2) => ((p1.Y == p2.Y && (p1.X == p2.X + 1 || p1.X == p2.X - 1)) || (p1.X == p2.X && (p1.Y == p2.Y + 1 || p1.Y == p2.Y - 1)));
        }
        private void EventTreeTest() {
            MatrixPoint point;
            eventTree.AddEvent(1, delegate {
                mapview.BiosLocation.TryGetValue(bioview.GetHashCode(), out point);
                if (point != null) return point.X == 1;
                return false;
            }, () => storewin.Show(),5);
            eventTree.AddEvent(2, delegate {
                mapview.BiosLocation.TryGetValue(bioview.GetHashCode(), out point);
                if (point != null) return point.Y == 6;
                return false;
            }, () => world.ShowDamage("ok!", bioview),3);
            eventTree.AddEvent(3, delegate {
                mapview.BiosLocation.TryGetValue(bioview.GetHashCode(), out point);
                if (point != null) return point.Y == 7;
                return false;
            }, () => SetAI(), 2, 4);
            eventTree.AddEvent(4, delegate {
                mapview.BiosLocation.TryGetValue(bioview.GetHashCode(), out point);
                if (point != null) return point.Y == 8;
                return false;
            }, () => SetAI2());
            eventTree.AddEvent(5, delegate {
                mapview.BiosLocation.TryGetValue(bioview.GetHashCode(), out point);
                if (point != null) return point.X != 1;
                return false;
            }, () => storewin.Hide(), 1);
            eventTree.StartEvent(1, 3);
        }
        private void SetCamera() {
            world.Camera.Lock(bioview);
        }

        #region Panel測試
        private void PanelTest(){
            StuffPanelTest();
            RoleWinTest();
            AccoutermentWinTest();
            SkillPanelTest();
            PointPanelTest();
            QuickPanelTest();
            MessageFrameTest();
            StoreTest();
        }
        SubWindow roleWin;
        SubWindow stuffWin;
        SubWindow storewin;
        StuffManager stuffmanager;
        SkillManager skillManager;
        EquipmentManager accoutermentManager;
        private void StuffPanelTest() {
            var size = new MatrixSize(5, 6) {
                SpanX = 2,
                SpanY = 2
            };
            size.BlockSize = new Size(32, 32);

            stuffmanager = new StuffManager();
            StuffPanel stuff;
            stuff = new StuffPanel(stuffmanager, size) { BackColor = Brushes.LightSalmon, Location = new Point(20, 20) };

            stuffmanager.Add(new Stuff(0, "1") { Description = "This is 1" });
            
            stuffWin = new SubWindow(stuff);
            stuffWin.SetTitle("物品欄");
            screen.AddHControl(stuffWin);
            bioview.StuffManager = stuffmanager;
            
        }
        private void RoleWinTest() {
            RoleInfoPanel panel = new RoleInfoPanel(bioview);
            panel.Lv = 1;
            roleWin = new SubWindow(panel);
            roleWin.SetTitle("角色資訊欄");
            screen.AddHControl(roleWin);
            MainTimer.Tick += delegate { panel.Update(); };
        }
        private void AccoutermentWinTest() {
            accoutermentManager = new EquipmentManager(bioview);
            Stuff g = new Stuff(2, "硬硬的頭盔") { Description = "感覺髒髒，體驗超棒!", IsCountable = false };
            Stuff g2 = new Stuff(3, "棉褲") { Description = "舒適、安心的褲子", IsCountable = false };
            Equipment gun = new Equipment(g, new BattleValue(0, 1, 4, 0), EquipmentType.Head, null);
            Equipment gun2 = new Equipment(g2, new BattleValue(0, 1, 0, 0), EquipmentType.Leg, null);
            Addenda ruby = new Addenda(new Stuff(4,"ruby1"), new BattleValue(0, 0, 1, 0), null);
            Addenda ruby2 = new Addenda(new Stuff(5, "ruby2"), new BattleValue(0, 0, 0, 0), (x) => new BattleValue(0, x.ATK.Base *2/5, 0, 0));
            gun.Add(ruby);
            gun2.Add(ruby2);
            accoutermentManager.Equip(gun);
            accoutermentManager.Equip(gun2);

            AccoutermentPanel panel = new AccoutermentPanel(accoutermentManager);
            SubWindow win = new SubWindow(panel);
            win.SetTitle("裝備欄");
            screen.AddHControl(win);
            bioview.BattleValue.HPIncrease(999999);
        }
        private void PointPanelTest() {
            PointCapacityPanel panel = new PointCapacityPanel(bioview);
            panel.Margin = new Thickness(20, 20, 0, 0);
            screen.AddControl(panel);
            MainTimer.Tick += delegate { panel.Update(); };
        }
        private void QuickPanelTest() {
            QuickSlotPanel panel = new QuickSlotPanel(key);
            panel.Location = new Point(300, 600);
            screen.AddHControl(panel);
        }
        private void SkillPanelTest() {
            SkillPanel panel = new SkillPanel(skillManager);
            SubWindow win = new SubWindow(panel) { Location = new Point(720, 20) };
            win.SetTitle("技能欄");
            screen.AddHControl(win);
        }
        private void MessageFrameTest() {
            MessageFrame mf = new MessageFrame();
            screen.AddHControl(mf);
            ControlAligner.HAlignMiddle(screen.Size, mf);
            ControlAligner.VAlignBottom(screen.Size, mf);
            mf.MessageList.Add("HSHSHS!!");
            mf.MessageList.Add("貓子30cm，小兔兔50cm~~");
            mf.Next();
            key.AddEvent(Key.A, () => mf.Next());
        }
        private void SkillTest() {

            skillManager = new SkillManager(bioview);
            Skill skill = new Skill(1, "攻1", bioview, (ski, val) => val.ATK + 7) { Description = "很厲害的斬擊" };
            skill.CD = 1;
            skill.CostSp = 1;
            skill.EffectRegion = RegionMaker.Cross1();
            skillManager.Add(skill);

            Skill skill2 = new Skill(1, "爆裂", bioview, (ski, val) => val.ATK + 12) { Description = "猛烈的攻擊周圍敵人" };
            skill2.CD = 10;
            skill2.CostSp = 3;
            skill2.EffectRegion = RegionMaker.Square1();
            skillManager.Add(skill2);

        }
        private void StoreTest() {
            StoreManager manager = new StoreManager();
            Stuff g = new Stuff(2, "硬硬的頭盔");
            Equipment gun = new Equipment(g, new BattleValue(2, 0, 0, 0), EquipmentType.Head, null) {
                Description = "感覺髒髒，體驗超棒!", Price = 99, IsCountable = false
            };
            var money = new Stuff(1, "錢幣") { Description = "錢幣\n台幣10元" , IsCountable =true , Count = 1, Price = 10};
            Consumable c = new Consumable(99, "紅色藥水", bioview) { IsCountable = true, Count = 3, CD = 5, Price = 60 };
            c.UsedEvent += delegate(bool isok) {
                if (isok)
                    bioview.BattleValue.HPIncrease(10);
            };
            manager.Stuffs.Add(gun);
            manager.Stuffs.Add(money);
            manager.Stuffs.Add(c);
            StorePanel panel = new StorePanel(manager, bioview, stuffmanager);
            storewin = new SubWindow(panel);
            storewin.SetTitle("商店");
            screen.AddHControl(storewin);
            storewin.Hide();
            
        }
        #endregion
               
        private void ConsumableTest() {
            Consumable c = new Consumable(99, "紅色藥水",bioview) { IsCountable =true, Count = 3, CD = 5};
            c.UsedEvent += delegate(bool isok) {
                if(isok)
                    bioview.BattleValue.HPIncrease(10); 
            };
            stuffmanager.Add(c);
        }
        private void LevelUpTest() {
            bioview.MaxExp = 10;
            BattlerGrowthItem item = new BattlerGrowthItem();
            item.BattleValue = new BattleBaseValue(2, 0, 0, 0);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
            bioview.LevelItem.Add(item);
        }
    }

}
