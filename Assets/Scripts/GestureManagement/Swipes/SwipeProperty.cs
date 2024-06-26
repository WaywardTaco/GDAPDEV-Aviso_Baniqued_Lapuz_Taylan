using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SwipeProperty {
    [Tooltip ("Maximum Swipe Time")]
    [SerializeField]
    private float _time = 2.0f;
    public float Time {
        get { return this._time; }
        set { this._time = value; }
    }

    [Tooltip ("Minimum Swipe Distance")]
    [SerializeField]
    private float _minDistance = 0.7f;
    public float MinDistance {
        get { return this._minDistance; }
        set { this._minDistance = value; }
    }
}
