using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockScript : MonoBehaviour, ISwipeable
{

    public void OnSwipe(SwipeEventArgs args)
    {
        if (args.Direction == ESwipeDirection.RIGHT)
        {

            DockManager.Instance.tryDockWith(CardData dockTargetData);

        }
        else
        {
            Debug.Log("Swipe direction is not right");
        }
    }
}
