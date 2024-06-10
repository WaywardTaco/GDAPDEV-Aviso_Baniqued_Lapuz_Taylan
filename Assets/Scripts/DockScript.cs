using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DockScript : MonoBehaviour, ISwipeable
{
    public void OnSwipe(SwipeEventArgs args)
    {

        if (args.Direction == ESwipeDirection.RIGHT)
        {

            CardData cardData = GetComponent<CardData>();

            if (cardData != null)
            {

                CardDock dock = DockManager.Instance.tryDockCard(cardData);

                if (dock != null)
                {
                    DockManager.Instance.DockCard(cardData, dock);
                    Debug.Log("Card successfully docked.");

                }
                else
                {
                    Debug.Log("No suitable dock found for the card.");
                }
            }
            else
            {
                Debug.LogError("No CardData component found on the game object.");
            }
        }
    }
}
