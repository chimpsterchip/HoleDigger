using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    public double DepthFound;

    public double GoldAmount;

    public Sprite TreasureSprite;

    public GameObject OpenVFX;
    public AudioClip OpenSFX;

    private SpriteRenderer Renderer;

	// Use this for initialization
	void Start () {
        Renderer = GetComponent<SpriteRenderer>();
    }

    public void Initialise(double _DepthFound, double _GoldAmount)
    {
        DepthFound = _DepthFound;
        GoldAmount = _GoldAmount;
    } 

    // Update is called once per frame
    void Update () {
		
	}

    public void OpenTreasure()
    {
        Debug.Log("Opening treasure " + gameObject.name);
        AudioSource.PlayClipAtPoint(OpenSFX, transform.position);
        if (OpenVFX) Instantiate(OpenVFX, transform.position, transform.rotation);
        ProgressionManager.GetInstance().AddGold(GoldAmount);
        Destroy(gameObject);
    }

    public double GetDepthFound() { return DepthFound; }
    public void SetDepthFound(double _Depth) { DepthFound = _Depth; }
    public double GetGoldAmount() { return GoldAmount; }
    public void SetGoldAmount(double _Gold) { GoldAmount = _Gold; }
    public Sprite GetTreasureSprite() { return TreasureSprite; }
    public void SetTreasureSprite(Sprite _NewSprite) { TreasureSprite = _NewSprite; }
    public void SetOpenVFX(GameObject _NewObject) { OpenVFX = _NewObject; }
    public void HideSprite() { Renderer.enabled = false; }
    public void ShowSprite() { Renderer.enabled = true; }
}
