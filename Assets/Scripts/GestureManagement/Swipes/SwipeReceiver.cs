using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeReceiver : MonoBehaviour
{
    private CardData _cardData;

    void Start(){        
        GestureManager.Instance.OnSwipe += this.OnSwipe;
    }

    private void OnDisable() {
        GestureManager.Instance.OnSwipe -= this.OnSwipe;
    }
    
    public void OnSwipe(object sender, SwipeEventArgs args){
        Debug.Log("Hello");
        Debug.Log(args.Direction);



            if (args.Direction == ESwipeDirection.RIGHT)
            {             
                
                
                DockManager.Instance.tryDockWith();
                

            }
            else
            {
                Debug.Log("Swipe direction is not right");
            }
       
            // if(args.HitObject != null)
            //     return;

            // GameObject obj = GameObject.Instantiate(templateObject, this.transform);
            // obj.SetActive(true);

            // Vector3 spawnLoc = Vector3.zero;

            // Ray ray = Camera.main.ScreenPointToRay(args.Position);

            // spawnLoc += ray.GetPoint(10);

            // obj.transform.localPosition = spawnLoc;
        }
    }
