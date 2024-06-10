using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {
    public enum CardSuit {
        HEARTS, SPADES, DIAMONDS, CLUBS
    }

    [Header("Card Information")]
    [SerializeField] private int _value;
    [SerializeField] private CardSuit _suit;
    [SerializeField] private bool _isRevealed = false;

    public int Value {
        get {return _value;}
    }
    public CardSuit Suit {
        get {return _suit;}
    }
    public bool IsRevealed {
        get {return _isRevealed;}
    }

    private void Start(){
        this.updateTexture();
    }

    public bool isStackable(CardData stackTargetData){
        return 
            this._value == stackTargetData._value + 1 &&
            this.isSuitOppositeColor(stackTargetData.Suit);
    }

    public bool isDockableWith(CardData dockTargetData){
        return 
            this._value == dockTargetData._value - 1 &&
            this._suit == dockTargetData.Suit;
    }

    public bool isDockableWith(CardSuit dockSuit){
        return 
            this._value == 1 &&
            this._suit == dockSuit;
    }

    private bool isSuitOppositeColor(CardSuit comparisonSuit){
        return (
            ((this.Suit == CardSuit.HEARTS || this.Suit == CardSuit.DIAMONDS ) &&
                (comparisonSuit == CardSuit.CLUBS || comparisonSuit == CardSuit.SPADES)) ||
            ((this.Suit == CardSuit.CLUBS || this.Suit == CardSuit.SPADES ) &&
                (comparisonSuit == CardSuit.HEARTS || comparisonSuit == CardSuit.DIAMONDS))
        );
    }

    private void updateTexture(){
        this.gameObject.GetComponent<Renderer>()?.material.SetTexture("_MainTex", CardLookManager.Instance.GetCardLook(this.Value, this.Suit, this.IsRevealed));
    }

    public void setData(int value, CardSuit suit){
        this._value = value;
        this._suit = suit;

        this.updateTexture();
    }

    public void Reveal(){
        if(!this._isRevealed)
            this._isRevealed = true;
        this.updateTexture();   
    }

    public void Hide(){
        if(this._isRevealed)
            this._isRevealed = false;
        
        this.updateTexture();
    }
}
