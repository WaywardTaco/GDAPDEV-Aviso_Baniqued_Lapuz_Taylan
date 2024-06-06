using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData {
    public enum CardSuit {
        HEARTS, SPADES, DIAMONDS, CLUBS
    }

    private int _value;
    private CardSuit _suit;

    public int Value {
        get {return _value;}
    }
    public CardSuit Suit {
        get {return _suit;}
    }

    public bool isStackable(CardData stackTargetData){
        return 
            this._value == stackTargetData._value + 1 &&
            this.isSuitOppositeColor(stackTargetData.Suit);
    }

    public bool isDockableWith(CardData dockTargetData){
        return 
            (this._value == dockTargetData._value - 1 ||
                this._value == 1) &&
            this._suit == dockTargetData.Suit;
    }

    private bool isSuitOppositeColor(CardSuit comparisonSuit){
        return (
            ((this.Suit == CardSuit.HEARTS || this.Suit == CardSuit.DIAMONDS ) &&
                (comparisonSuit == CardSuit.CLUBS || comparisonSuit == CardSuit.SPADES)) ||
            ((this.Suit == CardSuit.CLUBS || this.Suit == CardSuit.SPADES ) &&
                (comparisonSuit == CardSuit.HEARTS || comparisonSuit == CardSuit.DIAMONDS))
        );
    }
}
