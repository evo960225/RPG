using hoshi_lib.Game._2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hoshi_lib.Game.RPG {
     
    public class StoreManager {
        public delegate void StoreManagerSelectEvent(IStuff stuff);
        public delegate void StoreManagerBuyEvent(List<IStuff> stuffs);
        public event StoreManagerSelectEvent SelectedEvent {
            add { selectedEvent += value; }
            remove { selectedEvent -= value; }
        }
        public event StoreManagerSelectEvent UnselectedEvent {
            add { unselectedEvent += value; }
            remove { unselectedEvent -= value; }
        }
        public event StoreManagerBuyEvent BuyedEvent {
            add { buyedEvent += value; }
            remove { buyedEvent -= value; }
        }

        private StoreManagerSelectEvent selectedEvent;
        private StoreManagerSelectEvent unselectedEvent;
        private StoreManagerBuyEvent buyedEvent;

        public int Price { get; protected set; }
        public List<IStuff> Stuffs { get; set; }
        private List<IStuff> selectedStuffs;

        public StoreManager() {
            Stuffs = new List<IStuff>(50);
            selectedStuffs = new List<IStuff>(50);
        }
        public void Buy(IMoney money,StuffManager manager) {
            if(selectedStuffs.Count>0){
                if (Price > money.Money) {
                    MessageBox.Show("現金不足", "購買訊息");
                    return;
                }
                var res = MessageBox.Show("確定要購買?\n總額" + Price + "元", "購買訊息", MessageBoxButton.YesNo);
                if(res==MessageBoxResult.Yes){
                    money.Money -= Price;
                    selectedStuffs.ForEach((x) => manager.Add(x));
                    selectedStuffs.ForEach((x) => Stuffs.Remove(x));
                    Price = 0;
                    if (buyedEvent != null) buyedEvent(selectedStuffs);
                    selectedStuffs.Clear();
                }
            }
        }
        public void Select(IStuff stuff) {
            selectedStuffs.Add(stuff);
            Price += stuff.Price;
            if (selectedEvent != null) selectedEvent(stuff);
        }
        public void Unselect(IStuff stuff) {
            selectedStuffs.Remove(stuff);
            Price -= stuff.Price;
            if (unselectedEvent != null) unselectedEvent(stuff);
        }
    }
}
