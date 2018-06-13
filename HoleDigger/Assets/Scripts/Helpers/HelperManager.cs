using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Runs the helper store to buy and levelup helpers
public class HelperManager : MonoBehaviour
{

    [Header("UI Settings")]
    public GameObject StoreRef;

    private Vector2 TouchBeginPos;
    private Vector2 TouchEndPos;

    private bool Open = false;

    private static HelperManager Instance;
    // Use this for initialization
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
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

    public void OpenStore()
    {
        StoreRef.transform.DOMove(new Vector3(Screen.width / 2 + Screen.width / 4, Screen.height / 2, 0f), 1f);
        Open = true;
    }

    public void CloseStore()
    {
        StoreRef.transform.DOMove(new Vector3(Screen.width + Screen.width / 4, Screen.height/2, 0f), 1f);
        Open = false;
    }

    public void ChangeConfig()
    {
        if (Open) CloseStore();
        else if (!Open) OpenStore();
    }

    public static HelperManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject _NewInstance = new GameObject("HelperManager");
            _NewInstance.AddComponent<HelperManager>();
            Instance = _NewInstance.GetComponent<HelperManager>();
        }
        return Instance;
    }
}
