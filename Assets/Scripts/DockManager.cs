using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    public static DockManager Instance;
    
    private List<CardDock> _cardDocks;
    
    void Awake()
    {
        if(Instance == null)
            Instance = this;
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

    public void RegisterDock(CardDock dock){
        this._cardDocks.Add(dock);
    }
}
