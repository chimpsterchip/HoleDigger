using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Runs the helper store to buy and levelup helpers
public class HelperManager : MonoBehaviour
{

    [Header("UI Settings")]
    public GameObject StoreRef;

    private Vector2 TouchBeginPos;
    private Vector2 TouchEndPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwipeDetection()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 TouchWorldPos = Camera.main.ScreenToWorldPoint(touch.rawPosition);
            TouchWorldPos.z = 0;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TouchBeginPos = touch.position;
                    break;
                case TouchPhase.Moved:

                    break;
                case TouchPhase.Ended:
                    TouchEndPos = touch.position;
                    if (TouchEndPos.x - TouchBeginPos.x < 0)
                    {
                        OpenStore();
                    }
					TouchBeginPos = Vector2.zero;
					TouchEndPos = Vector2.zero;
                    break;
                default:
                    break;
            }
        }
    }

    void OpenStore()
    {
        StoreRef.transform.position = new Vector3(0f, 0f, 0f);
    }

    void CloseStore()
    {
        StoreRef.transform.position = new Vector3(450f, 0f, 0f);
    }
}
