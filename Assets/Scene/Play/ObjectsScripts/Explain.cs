using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //クリックされたら
    public void OnClick()
    {
        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
