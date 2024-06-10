using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLookManager : MonoBehaviour
{
    public static CardLookManager Instance;    

    [SerializeField] private List<Texture2D> _textureBank;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else    
            Destroy(this);
    }
    
    public Texture2D GetCardLook(int value, CardData.CardSuit suit, bool isRevealed){
        if(!isRevealed || value < 1 || value > 13)
            return this._textureBank[0];

        int targetIndex = value;
        switch(suit){
            case CardData.CardSuit.CLUBS:
                break;
            case CardData.CardSuit.DIAMONDS:
                targetIndex += 13;
                break;
            case CardData.CardSuit.HEARTS:
                targetIndex += 26;
                break;
            case CardData.CardSuit.SPADES:
                targetIndex += 39;
                break;
            default:
                return this._textureBank[0];
        }

        return this._textureBank[targetIndex];
    }
}
