using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    public DockManager Instance;
    
    private List<CardDock> _cardDocks;
    
    void OnAwake()
    {
        if(this.Instance == null)
            this.Instance = this;
        else 
            Destroy(this);
    }

    public CardDock tryDockCard(CardData targetDockCard){
        CardDock targetDock = null;

        foreach(CardDock dock in this._cardDocks){
            if(targetDockCard.isDockableWith(dock.TopCard) || (targetDockCard.isDockableWith(dock.DockSuit))){
                targetDock = dock;
                break;
            }
        }

        return targetDock;
    }
    

    
}
