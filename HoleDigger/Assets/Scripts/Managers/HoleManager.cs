using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Keeps track of the progress of the hole and the player
/// </summary>
public class HoleManager : MonoBehaviour {

    public delegate void DigEvent();
    public static event DigEvent OnDig;

    //Struct to hold data on the hole (Used to pass to other scripts)

    public double HoleDepth;
    public Text HoleDepthText;
    //Singleton
    private static HoleManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        Init();
    }

    public void Init()
    {
        //Lock Screenrotation
        Screen.orientation = ScreenOrientation.Portrait;
        UpdateUI();
    }

    // Update is called once per frame
    void Update() {

    }

    //Function to generate rewards and at what depth they'll be dug up

    //Function to dig hole
    public void DigHole(double _AmountDug)
    {
        HoleDepth += _AmountDug;
        UpdateUI();
        //set hole depth
        PlayerPrefs.SetFloat("Hole Depth", (float)HoleManager.GetInstance().GetHoleData());
        CheckNextTreasure();
        OnDig();
    }

    //Check the next treasure
    void CheckNextTreasure()
    {
        //Get reference
        Treasure _TreasureRef = TreasureManager.GetInstance().GetNextTreasure().GetComponent<Treasure>();
        //Check if the treasure has reached the surface
        if (_TreasureRef.GetDepthFound() <= HoleDepth)
        {
            _TreasureRef.OpenTreasure();
        }
    }

    //Update UI related to the hole
    void UpdateUI()
    {
        if(HoleDepthText.IsActive()) HoleDepthText.text = "Depth: " + HoleDepth.ToString("F2") + "m";
    }

    //Getter to get hole data
    public double GetHoleData()
    {
        return HoleDepth;
    }

    public void SetDepth(double _NewDepth) { HoleDepth = _NewDepth; }

    //Get Instance
    public static HoleManager GetInstance()
    {
        if(Instance == null)
        {
            if(GameObject.Find("HoleManager"))
            {
                return Instance = GameObject.Find("HoleManager").GetComponent<HoleManager>();
            }
            GameObject HoleMgt = new GameObject("HoleManager");
            HoleMgt.AddComponent<HoleManager>();
            HoleMgt.GetComponent<HoleManager>().Init();
        }
        return Instance;
    }
}
