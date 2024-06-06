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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
