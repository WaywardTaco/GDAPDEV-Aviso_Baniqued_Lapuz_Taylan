using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLookManager : MonoBehaviour
{
    public static CardLookManager Instance;    

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else    
            Destroy(this);
    }
    
    public Material GetCardLook(CardData data){
        
    }
}
