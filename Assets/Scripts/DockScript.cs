using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DockScript : MonoBehaviour, ISwipeable
{
    [SerializeField] private CardData _cardData;


    public void OnSwipe(SwipeEventArgs args)
    {
        if (args.Direction == ESwipeDirection.RIGHT)
        {

        }
        else
        {
            Debug.Log("Swipe direction is not right");
        }
    }

    private GameObject GetHitObject(Vector2 screenPoint)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = screenPoint;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Count > 1)
        {
            return results[1].gameObject;
        }
        return null;
    }

    public void Dock(object sender, SwipeEventArgs args)
    {
        GameObject hitObject = GetHitObject(this.transform.position);

    }
}
