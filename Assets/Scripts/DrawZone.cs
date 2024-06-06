using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZone : MonoBehaviour, ITappable
{
    [SerializeField] private List<CardData> _registeredCards;
    private int _topCardIndex = 0;

    public void OnTap(TapEventArgs args){
        if(this._topCardIndex >= this._registeredCards.Count)
            this.ResetCards();
        else 
            this.MillCards(3);
    }

    private void ResetCards(){
        
    }

    private void MillCards(int count){
        for(int i = 0; i < count; i++){
            this.Mill(this._registeredCards[this._topCardIndex + i]);
        }

        this._topCardIndex += count;
        if(this._topCardIndex > this._registeredCards.Count){
            this._topCardIndex = this._registeredCards.Count;
        }
    }

    private void Mill(CardData card){
        // Logic of card movement
    }
}
