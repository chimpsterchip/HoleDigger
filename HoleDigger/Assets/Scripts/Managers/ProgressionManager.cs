using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour {

	[Header("UI Settings")]
	public Text GoldDisplay;
	private double GoldAmount;

	private static ProgressionManager Instance;
	// Use this for initialization
	void Start () {
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUI();
	}

	void UpdateUI()
	{
		GoldDisplay.text = "Gold: " + GoldAmount;
	}

	public double GetGoldAmount(){return GoldAmount;}
	public void AddGold(double _NewGold) {GoldAmount += _NewGold;}
	public void RemoveGold(double _GoldUsed){GoldAmount -= _GoldUsed;}

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
}
