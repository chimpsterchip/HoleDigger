using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public List<GameObject> EnableOnStart;
    public List<GameObject> DestroyOnStart;

    private void Start()
    {
        foreach (GameObject _Obj in EnableOnStart)
        {
            _Obj.SetActive(false);
        }
    }

    public void GameStart()
    {
        foreach(GameObject _Obj in EnableOnStart)
        {
            _Obj.SetActive(true);
        }
        for(int i = 0; i < DestroyOnStart.Count; ++i)
        {
            Destroy(DestroyOnStart[i], 0.1f);
        }
    }
}
