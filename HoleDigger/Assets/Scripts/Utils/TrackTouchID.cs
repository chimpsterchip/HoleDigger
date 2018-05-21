using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTouchID : MonoBehaviour {

    public int ID;
    public Text DebugText;
	
	// Update is called once per frame
	void Update () {
        DebugText.text = transform.position.ToString();
        if (ID < Input.touches.Length)
        {
            Touch Trackee = Input.touches[ID];
            DebugText.text += "\n" + Trackee.position;
            switch (Trackee.phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Vector3 NewPos = Camera.main.ScreenToWorldPoint(Trackee.position);
                    NewPos.z = 0;
                    transform.position = NewPos;
                    
                    break;
                case TouchPhase.Ended:
                    transform.position = new Vector3(0, 0, -10);
                    break;
                default:
                    break;
            }
        }
	}
}
