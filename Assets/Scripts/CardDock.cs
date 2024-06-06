using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDock : MonoBehaviour
{
    [SerializeField] private List<CardData> _dockStack;
    [SerializeField] private CardData.CardSuit _dockSuit;

    public CardData TopCard {
        get { return _dockStack.Last(); }
    }
    public CardData.CardSuit DockSuit {
        get { return _dockSuit;}
    }
    
    private void Awake() {
        DockManager.Instance.RegisterDock(this);
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
