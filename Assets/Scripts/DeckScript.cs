using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour, ITappable
{
    [SerializeField] private List<GameObject> _deck;
    [SerializeField] private int _currentTop = 0;
    [SerializeField] private Transform _deckZone;
    [SerializeField] private Transform _drawCardZone;

    private void Start(){
        this._deck.Clear();

        int childCount = this.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++){
            this._deck.Add(this.gameObject.transform.GetChild(i).gameObject);
        }

        this.ResetDeck();
    }

    public void OnTap(TapEventArgs args){
        if(this._currentTop >= this._deck.Count){
            this.ResetDeck();
            this._currentTop = 0;
            return;
        }

        GameObject card = this._deck[this._currentTop];

        card.SetActive(true);
        Vector3 targetPos = new Vector3(this._drawCardZone.position.x, 0.14f + (this._currentTop * 0.001f), this._drawCardZone.position.z);
        card.transform.position = targetPos;

        this._currentTop++;
    }

    private void ResetDeck(){
        foreach(GameObject obj in this._deck)
            obj.SetActive(false);
    }
}
