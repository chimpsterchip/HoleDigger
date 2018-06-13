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
        SwipeDetection();
    }

    void SwipeDetection()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 TouchWorldPos = Camera.main.ScreenToWorldPoint(touch.rawPosition);
            TouchWorldPos.z = 0;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TouchBeginPos = touch.position;
                    TouchEndPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    TouchEndPos = touch.position;
                    if (TouchBeginPos.x - TouchEndPos.x > 80)
                    {
                        OpenStore();
                    }
                    if (TouchBeginPos.x - TouchEndPos.x < -80)
                    {
                        CloseStore();
                    }
                    break;
                case TouchPhase.Ended:

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
