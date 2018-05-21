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

    //Treasure Variables
    Queue<Treasure> TreasureQueue;
    Treasure NextTreasure;

    //Singleton
    private static HoleManager Instance = null;

	// Use this for initialization
	void Start () {
        Init();
	}

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateUI();
    }

    // Update is called once per frame
    void Update () {
		
	}

    //Function to generate rewards and at what depth they'll be dug up

    //Function to dig hole
    public void DigHole(double _AmountDug)
    {
        HoleDepth += _AmountDug;
        UpdateUI();
        OnDig();
    }

    //Generates a given amount of treasures
    void GenerateTreasures(int _Amount)
    {
        for(int i = 0; i < _Amount; ++i)
        {

        }
    }

    void UpdateTreasures()
    {
        if(TreasureQueue.Count <= 0)
        {
            GenerateTreasures(5);
        }
        else
        {
            NextTreasure = TreasureQueue.Dequeue();
        }
    }

    //Update UI related to the hole
    void UpdateUI()
    {
        HoleDepthText.text = "Depth: " + HoleDepth;
    }

    //Getter to get hole data
    public double GetHoleData()
    {
        return HoleDepth;
    }

    //Get Instance
    public static HoleManager GetInstance()
    {
        if(Instance == null)
        {
            GameObject HoleMgt = new GameObject("HoleManager");
            HoleMgt.AddComponent<HoleManager>();
            HoleMgt.GetComponent<HoleManager>().Init();
        }
        return Instance;
    }
}
