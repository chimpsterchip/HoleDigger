using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manages the background sprites as the hole gets dug.
/// Will get data about the hole from the hole manager to update the background accordingly
/// </summary>
public class BackgroundManager : MonoBehaviour {

    public float ScreenHeight = 10f;
    public float BackgroundDepthRatio = 0.1f;
    public float BackgroundZ = 5f;

    public GameObject CurrentBackground;
    public GameObject NextBackground;

    private void OnEnable()
    {
        HoleManager.OnDig += UpdateBackground;
    }

    private void OnDisable()
    {
        HoleManager.OnDig -= UpdateBackground;
    }

    // Use this for initialization
    void Start () {
		
	}

    public void Init()
    {
        CurrentBackground.transform.position = new Vector3(0f,0f,BackgroundZ);
        NextBackground.transform.position = new Vector3(0f, ScreenHeight, BackgroundZ);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateTreasureObject()
    {
        double Depth = HoleManager.GetInstance().GetHoleData();
        float modo = ScreenHeight / (BackgroundDepthRatio * 10);
        double CurrHeight = Depth % modo;
    }

    void UpdateBackground()
    {
        if(NextBackground.transform.position.y >= -1)
        {
            GameObject temp = CurrentBackground;
            CurrentBackground = NextBackground;
            NextBackground = temp;
        }
        double Depth = HoleManager.GetInstance().GetHoleData();
        float modo = ScreenHeight / (BackgroundDepthRatio * 10);
        double CurrHeight = Depth % modo;
        double NextHeight = -10 + CurrHeight;

        CurrentBackground.transform.position = new Vector3(0f, (float)CurrHeight, BackgroundZ);
        NextBackground.transform.position = new Vector3(0f, (float)NextHeight, BackgroundZ);       
    }
}
