using hoshi_lib.Imaging;
using hoshi_lib.View;
using System;

namespace hoshi_lib.Game.Card {
    public class PlayerBattleOperate {

        private BattleSite site;
        public Deck Deck;
        public Deck HandCard;
        public Deck Cemetery;
        public Card[] SiteCard;
        public Card SelectedSiteCard { get; protected set; }

        public PlayerBattleOperate(Deck deck, BattleSite site) {
            Deck = deck;
            this.site = site;
            HandCard = new Deck(BattleSite.DeckCount);
            Cemetery = new Deck(BattleSite.DeckCount);
            SiteCard = new Card[BattleSite.SiteCardCount];
        }
        public void SetDeck(Deck deck) {
            //if (deck.Count != DeckCount) return;
            Deck = deck;
        }
        public void ShuffleDeck() {
            Deck.Shuffle();
        }

        public int? DrewDeckToHand() {
            var card = DrawDeck();
            if (card == null) return null;
            HandCard.Add(card);
            return HandCard.Count - 1;
        }
        public int? PutCardToSite(int handIndex) {
            if (site.IsPutCard) return null;
            var card = DrawHandCard(handIndex);
            if (card == null) return null;
            int? siteIndex = PutSite(card);
            if (siteIndex == null) return null;
            site.PutCard();
            return siteIndex;
        }
        public bool SelectSiteCard(int index) {
            if (SelectedSiteCard != null) {
                if (SelectedSiteCard == SiteCard[index]) {
                    SelectedSiteCard = null;
                    return false;
                } else {
                    SelectedSiteCard = SiteCard[index];
                }
            } else {
                SelectedSiteCard = SiteCard[index];
            }
            return true;
        }
        public void SiteToCemetery(int siteIndex) {
            Cemetery.Add(SiteCard[siteIndex]);
            SiteCard[siteIndex] = null;
        }
        public bool AttackHostileSiteCard(int siteIndex) {
            if (site.IsAttack) return false;
            if (!site.AttackHostileSiteCard(siteIndex)) return false;
            SelectedSiteCard = null;
            return true;
        }
        public void EndRound() {
            site.NextPlayer();
        }

        public Card DrawDeck() {
            return Deck.Draw();
        }
        public Card DrawHandCard(int index) {
            return HandCard.Draw(index);
        }
        public int? PutSite(Card card) {
            if (findSpaceInSite() == null) return null;
            int index = (int)findSpaceInSite();
            if (SiteCard[index] != null) return null;
            SiteCard[index] = card;
            return index;
        }
        public int? findSpaceInSite() {
            for (int i = 0; i < BattleSite.SiteCardCount; ++i) {
                if (SiteCard[i] == null) return i;
            }
            return null;
        }

    }
}
