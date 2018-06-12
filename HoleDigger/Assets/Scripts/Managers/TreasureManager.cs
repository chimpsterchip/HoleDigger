using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates Treasures
/// </summary>
public class TreasureManager : MonoBehaviour
{

    public enum TreasureType
    {
        Gold
    }


    public Sprite NormalChestSprite;

    private static TreasureManager Instance;
    private GameObject NextTreasure;

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetNextTreasure()
    {
        if(NextTreasure != null)
        {
            return NextTreasure;
        }
        return NextTreasure = CreateTreasure(TreasureType.Gold, 100, HoleManager.GetInstance().GetHoleData() + 10);
    }

    //Create and returns a treasure
    private GameObject CreateTreasure(TreasureType _Type, double _Amount, double _DepthFound)
    {
        GameObject _NewTreasure = new GameObject("Treasure");
        //Set Transform
        _NewTreasure.transform.position = new Vector3 (0f, 10f, 0f);
        //Add Treasure Script
        _NewTreasure.AddComponent<Treasure>();
        _NewTreasure.GetComponent<Treasure>().Initialise(_DepthFound, _Amount);
        //Add Sprite Renderer
        _NewTreasure.AddComponent<SpriteRenderer>();
        _NewTreasure.GetComponent<SpriteRenderer>().sprite = NormalChestSprite;
        return _NewTreasure;
    }

    public static TreasureManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject _NewInstance = new GameObject("TreasureManager");
            _NewInstance.AddComponent<TreasureManager>();
            Instance = _NewInstance.GetComponent<TreasureManager>();
        }
        return Instance;
    }
}
