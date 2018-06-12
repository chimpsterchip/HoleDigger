using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manages the background sprites as the hole gets dug.
/// Will get data about the hole from the hole manager to update the background accordingly
/// </summary>
public class BackgroundManager : MonoBehaviour
{

    public float ScreenHeight = 10f;
    [Tooltip("How many levels there should be in one screenheight.")]
    public float BackgroundDepthRatio = 0.1f;
    public float BackgroundZ = 5f;
    public float TreasureZ = 4f;

    public GameObject CurrentBackground;
    public GameObject NextBackground;
    public GameObject NextTreasure;

    private void OnEnable()
    {
        HoleManager.OnDig += UpdateBackground;
    }

    private void OnDisable()
    {
        HoleManager.OnDig -= UpdateBackground;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void Init()
    {
        CurrentBackground.transform.position = new Vector3(0f, 0f, BackgroundZ);
        NextBackground.transform.position = new Vector3(0f, ScreenHeight, BackgroundZ);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateTreasure()
    {
        if (!NextTreasure)//If the next treasure exists
        {
            NextTreasure = TreasureManager.GetInstance().GetNextTreasure();
        }
        //Calculate where to draw the treasure
        double Depth = HoleManager.GetInstance().GetHoleData() - NextTreasure.GetComponent<Treasure>().GetDepthFound();
        float modo = ScreenHeight / (BackgroundDepthRatio * 10);
        double TreasureDepth = Depth % modo;      
        //Change the position of the treasure if within range
        if (Mathf.Abs((float)Depth) < modo)
        {
            NextTreasure.transform.position = new Vector3(0f, (float)TreasureDepth, TreasureZ);
        }
    }

    void UpdateBackground()
    {
        //If the NextBackground has reached center screen get the new NextBackgound
        if (NextBackground.transform.position.y >= 0)
        {
            print("Swapping Backgrounds");
            GameObject temp = CurrentBackground;
            CurrentBackground = NextBackground;
            NextBackground = temp;
        }
        //Calculate the screen positions of the backgrounds
        float Depth = (float)HoleManager.GetInstance().GetHoleData();
        float modo = ScreenHeight / (BackgroundDepthRatio * 10);
        float CurrHeight = Depth % modo;
        float NextHeight = -10 + CurrHeight;
        //Change the background positions
        CurrentBackground.transform.position = new Vector3(0f, (float)CurrHeight, BackgroundZ);
        NextBackground.transform.position = new Vector3(0f, (float)NextHeight, BackgroundZ);
        //Update the treasure sprites
        UpdateTreasure();
    }
}
