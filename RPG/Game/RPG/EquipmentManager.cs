using hoshi_lib.Game._2D;
using hoshi_lib.Game.TestView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public class EquipmentManager {
        public delegate void EquipmentManagerEvent(Equipment add);

        public IEnumerable<KeyValuePair<EquipmentType, Equipment>> Accouterments { 
            get { return accouterments; } 
        }
        public event EquipmentManagerEvent EquipedEvent {
            add { equipedEvent += value; }
            remove { equipedEvent -= value; }
        }
        public event EquipmentManagerEvent ChangedEvent {
            add { changedEvent += value; }
            remove { changedEvent -= value; }
        }
        public event EquipmentManagerEvent RemovedEvent {
            add { removedEvent += value; }
            remove { removedEvent -= value; }
        }

        private EquipmentManagerEvent equipedEvent;
        private EquipmentManagerEvent changedEvent;
        private EquipmentManagerEvent removedEvent;
        private Dictionary<EquipmentType, Equipment> accouterments;
        private Bio bio;
        private BattleValue controlValue;
        

        public EquipmentManager(Bio bio) {
            this.bio = bio;
            this.controlValue = bio.BattleValue;
            accouterments = new Dictionary<EquipmentType, Equipment>();
        }

        public bool Equip(Equipment accouterment) {
            if (accouterments.Keys.Where((x)=>x==accouterment.Type).Count()!=0) return false;
            accouterments.Add(accouterment.Type, accouterment);
            UpdatePlus();
            if (equipedEvent != null) equipedEvent(accouterment);
            return true;
        }
        public Equipment Change(Equipment accouterment) {
            Equipment tmp;
            accouterments.TryGetValue(accouterment.Type, out tmp);
            accouterments[accouterment.Type] = accouterment;
            UpdatePlus();
            if (changedEvent != null) changedEvent(accouterment);
            return tmp;
        }
        public bool Remove(Equipment accouterment) {
            if (!accouterments.Remove(accouterment.Type)) {
                return false;
            }
            UpdatePlus();
            if (removedEvent != null) removedEvent(accouterment);
            return true;
        }
        private void UpdatePlus() {
            BattleValue sum = new BattleValue();
            foreach (var it in accouterments.Values) {
                sum += it.BattleValues;
                if (it.PlusFunc!=null)
                    sum += it.PlusFunc(controlValue);
            }
            controlValue.SetPlus(sum);
            Log.Write(controlValue.ToString());
        }
    }
}
