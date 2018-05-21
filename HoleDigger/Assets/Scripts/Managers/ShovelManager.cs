using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShovelManager : MonoBehaviour {

    public double ShovelStrength = 1.0;
    public int ShovelState = 0; //0 = Idle; 1 = Dig; 2 = Shovel;
    private string ShovelTag = "Shovel";

    private Animator myAnim;

    public Text DebugText;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        Debug.Log(">>>><<<<SHOVEL_OPERATIONAL>>>><<<<");
    }
	
	// Update is called once per frame
	void Update () {
        if (DebugText) DebugText.text = "";
        CheckTouchInput();

    }

    private void CheckTouchInput()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D _HitInfo = Physics2D.Raycast(TouchPos, Vector2.zero);
                if (_HitInfo)
                {
                    if(DebugText) DebugText.text += "Raycast Hit ; ";
                    //If the GameObject is the shovel update the state of the shovel
                    if (_HitInfo.collider.CompareTag(ShovelTag))
                    {
                        UpdateState();
                    }
                }
                else
                {
                    if (DebugText) DebugText.text += "Raycat Not Hit ; ";
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D _HitInfo = Physics2D.Raycast(MousePos, Vector2.zero);
            if (_HitInfo)
            {
                if (DebugText) DebugText.text += "Raycast Hit ; ";
                //If the GameObject is the shovel update the state of the shovel
                if (_HitInfo.collider.CompareTag(ShovelTag))
                {
                    UpdateState();
                }
            }
            else
            {
                if (DebugText) DebugText.text += "Raycat Not Hit ; ";
            }
        }
    }

    private void UpdateState()
    {
        if (DebugText) DebugText.text += "Updating Shovel State ; ";
        switch (ShovelState)
        {
            case 0: //If in Idle State
                myAnim.SetTrigger("Dig");
                ShovelState++;
                break;
            case 1: //If in Dig State
                myAnim.SetTrigger("Shovel");
                ShovelState = 0;

                HoleManager.GetInstance().DigHole(ShovelStrength);
                break;
            default:
                break;
        }
    }
}
