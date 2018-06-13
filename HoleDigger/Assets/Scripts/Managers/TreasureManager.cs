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

    public Vector2 ExtraGoldRange = Vector2.zero;
    public Vector2 ExtraDepthRange = Vector2.zero;

    public Vector3 TreasureScale = Vector3.one;
    public Sprite NormalChestSprite;

    public GameObject OpenVFX;
    public AudioClip OpenSFX;

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
        _NewTreasure.transform.localScale = TreasureScale;
        _NewTreasure.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        //Add Treasure Script
        _NewTreasure.AddComponent<Treasure>();
        _NewTreasure.GetComponent<Treasure>().Initialise(_DepthFound + (int)Random.Range(ExtraDepthRange.x, ExtraDepthRange.y), _Amount + (int)Random.Range(ExtraGoldRange.x, ExtraGoldRange.y));
        _NewTreasure.GetComponent<Treasure>().OpenSFX = OpenSFX;
        //Add Sprite Renderer
        _NewTreasure.AddComponent<SpriteRenderer>();
        _NewTreasure.GetComponent<SpriteRenderer>().sprite = NormalChestSprite;
        //Add Treasure Prefab
        _NewTreasure.GetComponent<Treasure>().SetOpenVFX(OpenVFX);
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
