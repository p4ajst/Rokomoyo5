﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//即死トラップのスクリプト

public class Goal : Trap {

    GameObject key;
    GameObject keyChild;

    bool goalflag = false;
    static int x = 2;

	// Use this for initialization
	override protected void Start () {
        //基底クラスのStart関数
        base.Start();
        key = GameObject.Find("Key");
        keyChild = key.transform.Find("key").gameObject;
    }

    // Update is called once per frame
    override protected void Update()
    {
        //基底クラスのUpdate関数
        base.Update();

        //Debug.Log(StereoPlug.noteFripFlag);

        //トラップの上にいるなら
        if (base.OnFloor() )
        {
            //player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            //シーン遷移する
            //if (key.activeSelf == true)
            //if (key.active == false)
            //if (GameObject.Find("Key").transform.Find("Key").gameObject.activeSelf == false)
            if (keyChild.activeSelf == false)
            {
                microUSB.SetFlag(false);
                StereoPlug.SetStereoFlag(false);

                //ゴールした瞬間にリープでゴールへ動く
                float MoveTime = Time.deltaTime / 0.5f*2;
                float Length = Vector3.Distance(player.transform.position,new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z));
                float time = MoveTime / Length;
                player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z),time);

                //プレイヤーとゴールの位置が噛み合ったらシーン遷移
                if (player.transform.position == new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z))
                {
                    Stage.ChangeStage();
                    //player.transform.position = new Vector3(0.0f,0.0f,0.0f);
                }
            }
        }
        //いないなら
        else { }
    }
}
