using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Debug script to visually track all the touch inputs
/// </summary>
public class TouchTracker : MonoBehaviour {

    public GameObject TouchSprite;
    private GameObject[] Trackers;

	// Use this for initialization
	void Start () {
        Trackers = new GameObject[10];
    }
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches)
        {
            Vector3 TouchWorldPos = Camera.main.ScreenToWorldPoint(touch.rawPosition);
            TouchWorldPos.z = 0;
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    Trackers[touch.fingerId] = Instantiate(TouchSprite, TouchWorldPos, Quaternion.identity);
                    break;
                case TouchPhase.Moved:
                    Trackers[touch.fingerId].transform.position = TouchWorldPos;
                    break;
                case TouchPhase.Ended:
                    Destroy(Trackers[touch.fingerId]);
                    break;
                default:
                    break;
            }
        }
	}

}
