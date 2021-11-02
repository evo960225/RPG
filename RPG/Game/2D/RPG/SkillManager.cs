using System.Collections.Generic;
using System.Linq;

namespace hoshi_lib.Game._2D.RPG {
    public class SkillManager {
        public delegate void SkillManagerEvent(Skill add);

        public IEnumerable<Skill> Skills {
            get { return skills; }
        }
        public Skill this[int index] {
            get { return skills[index]; }
            protected set { skills[index] = value; }
        }
        public event SkillManagerEvent AddedEvent {
            add { addedEvent += value; }
            remove { addedEvent -= value; }
        }
        public event SkillManagerEvent RemovedEvent {
            add { removedEvent += value; }
            remove { removedEvent -= value; }
        }

        private SkillManagerEvent addedEvent;
        private SkillManagerEvent removedEvent;
        private List<Skill> skills = new List<Skill>(30);
        private Bio bio;

        public SkillManager(Bio bio) {
            this.bio = bio;
        }
        public void Use(int id) {
            var selected = skills.Where((x) => x.ID == id).ElementAt(0);
            selected.Used(bio);
        }
        public void Use(string name) {
            var selected = skills.Where((x) => x.Name == name).ElementAt(0);
            selected.Used(bio);
        }
        public void Add(Skill skill) {
            skills.Add(skill);
            if (addedEvent != null) addedEvent(skill);
        }
        public void Remove(Skill skill) {
            skills.Remove(skill);
            if (removedEvent != null) removedEvent(skill);
        }
    }
}
