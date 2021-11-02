using hoshi_lib.Imaging;
using hoshi_lib.View;
using System;
namespace hoshi_lib.Game.Card {

    public class BattleSite {

        static public int DeckCount = 20;
        static public int SiteCardCount = 5;

        public PlayerBattleOperate User { get; protected set; }
        public PlayerBattleOperate Hostile { get; protected set; }

        public int Round { get; protected set; }
        public bool UserRound { get; protected set; }
        public bool IsPutCard { get; protected set; }
        public bool IsAttack { get; protected set; }
        public Card SelectedSiteCard { get; protected set; }

        public BattleSite(Deck userDeck,Deck hostileDeck) {
            User = new PlayerBattleOperate(userDeck,this);
            Hostile = new PlayerBattleOperate(hostileDeck,this);
            initGameRule();
        }

        private void initGameRule() {
            Round = 1;
            UserRound = true;
            initFlag();
        }
        private void initFlag() {
            IsPutCard = false;
            IsAttack = false;
        }

        public void Start() {
            User.ShuffleDeck();
            Hostile.ShuffleDeck();
            IsPutCard = false;
            IsAttack = false;
            /*for (int i = 0; i < SiteCardCount; ++i) {
                User.DrewDeckToHand();
                Hostile.DrewDeckToHand();
            }*/
        }
        public void NextPlayer() {
            initFlag();
            UserRound = !UserRound;
            if (UserRound) {
                ++Round;
                User.DrawDeck();
            } else { 
                Hostile.DrawDeck();
            }
            
        }

        public bool AttackHostileSiteCard(int siteIndex) {
            PlayerBattleOperate attacker;
            PlayerBattleOperate attacked;
            if (UserRound) {
                attacker = User;
                attacked = Hostile;
            } else {
                attacker = Hostile;
                attacked = User;
            }
            if (attacker.SelectedSiteCard == null) return false;
            if (siteIndex < 0 || siteIndex >= 5) return false;
            if (attacked.SiteCard[siteIndex] == null) return false;
            if (attacker.SelectedSiteCard.ATK > attacked.SiteCard[siteIndex].ATK) {
                attacked.SiteToCemetery(siteIndex);
                return true;
            } 
            return false;
        }
        public Card GetUserHandCard(int index) {
            return User.HandCard[index];
        }
        public Card GetHostileSiteCard(int index) {
            return Hostile.HandCard[index];
        }
        public Card GetUserSiteCard(int index) {
            return User.SiteCard[index];
        }
        public Card GetSelectedUserSiteCard() {
            return User.SelectedSiteCard;
        }

        public void PutCard() {
            IsPutCard = true;
        }
        public void Attack() {
            IsAttack = true;
        }
        private bool IsWin() {
            return false;
        }

    }

}