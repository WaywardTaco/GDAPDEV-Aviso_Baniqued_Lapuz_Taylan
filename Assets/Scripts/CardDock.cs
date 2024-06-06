using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDock : MonoBehaviour
{
    private List<CardData> _dockStack;

    public CardData TopCard {
        get { return _dockStack.Last(); }
    }
    
    public void AddCard(CardData card){
        this._dockStack.Add(card);
    }

    public CardData RemoveTop(){
        CardData topCard = this._dockStack.Last();
        this._dockStack.Remove(topCard);
        
        return topCard;
    }
}
