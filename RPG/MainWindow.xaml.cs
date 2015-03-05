﻿using hoshi_lib;
using hoshi_lib.Input;
using hoshi_lib.Data;
using hoshi_lib.Game;
using hoshi_lib.Game.TestView;
using hoshi_lib.Game.Texture2D;
using hoshi_lib.View;
using System;
using System.Windows.Media;
using Windows = System.Windows;

namespace RPG {

    public partial class MainWindow : Windows.Window {

        WindowController window;
        TitleScreen titleScreen;
        CreateRoleSimple roleSimp;
        GameStage gameStage;
        public MainWindow() {
            InitializeComponent();
            window = new WindowController(this);
            titleScreen = new TitleScreen(window);
            CreateView();
            SetViewEvent();
        }

        private void CreateView(){
            titleScreen.CreateButtons(3, "Start Game", "Select Role", "Quit");
            Array.ForEach<HButton>(titleScreen.Buttons, x => x.InitBrush(Brushes.DarkSalmon));
            Array.ForEach<HButton>(titleScreen.Buttons, x => x.EnterBrush = Brushes.LightSalmon);
            titleScreen.SetStandardSytle();
        }
        private void SetViewEvent() {
            titleScreen.Buttons[0].AddClickEvent(delegate { titleScreen.AddControl(roleSimp); });
            titleScreen.Buttons[1].AddClickEvent(delegate { gameStage = new GameStage(window); });
            titleScreen.Buttons[2].AddClickEvent(delegate { this.Close(); });

            roleSimp = new CreateRoleSimple();
            roleSimp.butCreate.MouseDown += delegate { gameStage = new GameStage(window); };
        }

    }

    public class GameStage {
        Screen gameScreen;
        WindowController win;
        
        private Map map;
        private MapData mapData;
        private MapView mapView;
        private MapTextureManager mapTexture;

        private BattleBio protagonist;
        private BattleBioValues protagonistValue;
        private BioView protagonistView;
        private BattleBio monster;
        private BattleBioValues monsterValue;
        private BioView monsterView;
        private Camera camera;
        private BioDataController bioC = new BioDataController();
        private PointCapacityControl pcc = new PointCapacityControl();

        public GameStage(WindowController win) {
            this.win = win;
            MakeMap();
            PutRoleInMap();
            SetKeyEvent();
            SetCamera();
            PutMonster();
            AddPointControl();
        }
        public void MakeMap() {

            gameScreen = new Screen(win, "Map");
            win.AutoSize = Windows.SizeToContent.WidthAndHeight;
            gameScreen.Size = new Size(1100, 600);
            win.UpdataLayout();


            mapData = new MapData("../../Map/map1.txt");
            mapTexture = new MapTextureManager(new MapDataController(), "../../Image/");
            mapView = new MapView(mapTexture, new Size(50, 50));
            map = new Map(mapData, mapView);
            gameScreen.AddHControlCollection(map.View);
        }
        private void PutRoleInMap() {
            protagonistValue = bioC.LoadRole(1);
            protagonistView = new BioView("../../Image/", new Size(50, 50), 3);
            protagonist = new BattleBio(protagonistValue, protagonistView);
            
            map.RegisterBattleBio(protagonist);
        }
        public void SetKeyEvent() {
            KeyDelegate keyD = new KeyDelegate(win);
            keyD.AddEvent(Key.Left, () => protagonist.MoveLeft());
            keyD.AddEvent(Key.Up, () => protagonist.MoveUp());
            keyD.AddEvent(Key.Down, () => protagonist.MoveDown());
            keyD.AddEvent(Key.Right, () => protagonist.MoveRight());
            keyD.AddEvent(Key.A, () => protagonistValue.Attack(map, ScaleFunc, DamageFunc));
        }
        private void SetCamera() {
            camera = new Camera(gameScreen.Size, mapView);
            camera.Observe(protagonist);
        }
        private void PutMonster() {
            monsterValue = bioC.LoadRole(2);
            monsterView = new BioView("../../Image/", new Size(50, 50), 3);
            monster = new AIBio(monsterValue, monsterView);
            map.RegisterBattleBio(monster);
        }
        public int DamageFunc(IBattler atkBio, IBattler defBio) {
            return atkBio.Atk - defBio.Def;
        }
        public bool ScaleFunc(IBattler atkBio, IBattler defBio) {
            var aLoc = atkBio.MatrixLocation;
            var dLoc = defBio.MatrixLocation;

            return Math.Abs((aLoc.X - dLoc.X) + (aLoc.Y - dLoc.Y)) == 1;
        }
        public void AddPointControl() {
            pcc.HP = protagonistValue.Hp.Point;
            pcc.SP = protagonistValue.Sp.Point;
            pcc.MaxHP = protagonistValue.Hp.Max;
            pcc.MaxSP = protagonistValue.Sp.Max;
            pcc.Name = protagonistValue.Name;
            pcc.Lv = protagonistValue.Level;
            gameScreen.AddHControl(new HControl(pcc) { Location = new Location(10, 5) });
        }
    }
}
