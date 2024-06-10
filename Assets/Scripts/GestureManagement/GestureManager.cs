using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GestureManager : MonoBehaviour
{
    [SerializeField] private TapProperty _tapProperty;
    [SerializeField] private SwipeProperty _swipeProperty;
    [SerializeField] private DragProperty _dragProperty;
    [SerializeField] public EventHandler<TapEventArgs> OnTap;
    [SerializeField] public EventHandler<SwipeEventArgs> OnSwipe;
    [SerializeField] public EventHandler<DragEventArgs> OnDrag ;
    public static GestureManager Instance;
    
    private Touch _trackedFinger;
    private float _gestureTime;
    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    // Start is called before the first frame update
    void Awake(){
        if(Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update(){
        if(Input.touchCount > 0){
            this._trackedFinger = Input.GetTouch(0);
            switch(this._trackedFinger.phase){
                case TouchPhase.Began:  
                    this._startPoint = this._trackedFinger.position;
                    this._gestureTime = 0.0f;
                    break;
                case TouchPhase.Ended:
                    this._endPoint = this._trackedFinger.position;
                    this.Reset();
                    DragObject = null;
                    this.CheckTap();
                    this.CheckSwipe();
                    break;
                default:
                    this._gestureTime += Time.deltaTime;
                    this.CheckDrag();
                    break;
            }
        }
    }

    private void Reset()
    {
        if(this.DragObject != null)
        {
            this.DragObject.transform.position = this._startPoint;
            GameObject hitObject = GetHitObject(this._endPoint);

            DragEventArgs args = new(this._trackedFinger, hitObject);
           
            IResettable target = this.DragObject.GetComponent<IResettable>();
            if (target != null)
                target.OnReset(args);
        }
        
    }

    private void CheckTap(){
        if(
            this._gestureTime <= this._tapProperty.Time &&
            Vector2.Distance(this._startPoint, this._endPoint) <=
                (Screen.dpi * this._tapProperty.MaxDistance)
        )
            this.FireTapEvent();
    }

    private void CheckSwipe(){
        if(
            this._gestureTime <= this._swipeProperty.Time &&
            Vector2.Distance(this._startPoint, this._endPoint) >=
                (Screen.dpi * this._swipeProperty.MinDistance)
        )
            this.FireSwipeEvent();
    }

    private void CheckDrag(){
        if(this._gestureTime >= this._dragProperty.Time)
            this.FireDragEvent();
    }

    private void FireTapEvent(){
        GameObject hitObject = this.GetHitObject(this._startPoint);
        TapEventArgs args = new (this._startPoint, hitObject);

        if(hitObject != null){
            ITappable target = hitObject.GetComponent<ITappable>();
            if(target != null)
                target.OnTap(args);
        } 
            
        if(this.OnTap != null)
            this.OnTap(this, args);
    }

    private void FireSwipeEvent(){
        GameObject hitObject = this.GetHitObject(this._startPoint);

        ESwipeDirection swipeDirection = 
            this.GetSwipeDirection(this._endPoint - this._startPoint);
        
        SwipeEventArgs args = new (swipeDirection, this._endPoint - this._startPoint, this._startPoint, hitObject);
        if(hitObject != null){
            ISwipeable target = hitObject.GetComponent<ISwipeable>();
            if(target != null)
                target.OnSwipe(args);
        }

        if(this.OnSwipe != null)
            this.OnSwipe(this, args);
    }

    GameObject DragObject = null;

    private void FireDragEvent(){
        GameObject hitObject = this.GetHitObject(this._trackedFinger.position);
        if (hitObject != null)
            this.DragObject = hitObject;

        DragEventArgs args = new (this._trackedFinger, this.DragObject);
        if(this.DragObject != null){
            IDraggable target = this.DragObject.GetComponent<IDraggable>();
            if(target != null)
                target.OnDrag(args);
        }

        if(this.OnDrag != null)
            this.OnDrag(this, args);
    }

    private GameObject GetHitObject(Vector2 screenPoint){
        GameObject hitObject = null;

        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            hitObject = hit.collider.gameObject;

        return hitObject;
    }

    private ESwipeDirection GetSwipeDirection(Vector2 rawDirection){
        if(Mathf.Abs(rawDirection.x) >= Mathf.Abs(rawDirection.y)){
            if(rawDirection.x >= 0)
                return ESwipeDirection.RIGHT;
            else
                return ESwipeDirection.LEFT;
        }
        else {
            if(rawDirection.y >= 0)
                return ESwipeDirection.UP;
            else
                return ESwipeDirection.DOWN;
            }
    }
}
