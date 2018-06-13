using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class ProgressionManager : MonoBehaviour {

    public delegate void GoldEvent();
    public static event GoldEvent OnGold;

    [Header("UI Settings")]
	public Text GoldDisplay;
	private double GoldAmount;

	private static ProgressionManager Instance;
	// Use this for initialization
	void Awake () {
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
    }

    private void Start()
    {
        LoadData();
        UpdateUI();
    }

    // Update is called once per frame
    void Update () {

	}

    void LoadData()
    {
        HoleManager.GetInstance().SetDepth(PlayerPrefs.GetFloat("Hole Depth"));
        GoldAmount = PlayerPrefs.GetFloat("Gold Collected");
        HelperManager.GetInstance().gameObject.GetComponent<HelperMiniShovel>().SetQuantity(PlayerPrefs.GetInt("MiniShovelQuantity"));
        HelperManager.GetInstance().gameObject.GetComponent<HelperMiniShovel>().SetQuantity(PlayerPrefs.GetInt("ReverseShovelQuantity"));
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        UpdateUI();
        TreasureManager.GetInstance().ClearTreasure();
        TreasureManager.GetInstance().GetNextTreasure();
    }

	void UpdateUI()
	{
        if (GoldDisplay)
        {
            GoldDisplay.gameObject.transform.DOShakeScale(0.3f);
            GoldDisplay.text = "Gold: " + GoldAmount.ToString("F2");
        }
	}

	public double GetGoldAmount(){return GoldAmount;}
	public void AddGold(double _NewGold)
    {
        GoldAmount += _NewGold;
        UpdateUI();
        if(OnGold != null) OnGold();
        //set gold
        PlayerPrefs.SetFloat("Gold Collected", (float)ProgressionManager.GetInstance().GetGoldAmount());
    }
	public void RemoveGold(double _GoldUsed)
    {
        GoldAmount -= _GoldUsed;
        UpdateUI();
        if (OnGold != null) OnGold();
    }

	public static ProgressionManager GetInstance()
	{
		if(Instance == null)
		{
			GameObject _NewInstance = new GameObject("ProgressionMananger");
			_NewInstance.AddComponent<ProgressionManager>();
			Instance = _NewInstance.GetComponent<ProgressionManager>();
			DontDestroyOnLoad(_NewInstance);
		}
		return Instance;
	}

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
