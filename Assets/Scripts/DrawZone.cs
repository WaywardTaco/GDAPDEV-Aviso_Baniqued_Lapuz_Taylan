using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawZone : MonoBehaviour, ITappable
{
    
    public void OnTap(TapEventArgs args){
        this.MillCards(3);
    }

    private void MillCards(int count){
        // for(int )
    }
}
