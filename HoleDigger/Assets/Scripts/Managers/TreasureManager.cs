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

    //Create and returns a treasure
    public GameObject CreateTreasure(TreasureType _Type, double _Amount, double _DepthFound)
    {
        GameObject _NewTreasure = new GameObject();
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
