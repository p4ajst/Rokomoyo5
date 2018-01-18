using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrl : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnGUI()
    {
        // "run"ボタンが押されたら
        if (GUI.Button(new Rect(20, 10, 80, 20), "Grass"))
        {
            Debug.Log("anime");
            anim.Play("Grass", 0);
        }

        //// "walk"ボタンが押されたら
        //if (GUI.Button(new Rect(20, 30, 80, 20), "walk"))
        //{
        //    anim.CrossFade("walk", 0);
        //}
    }
}
