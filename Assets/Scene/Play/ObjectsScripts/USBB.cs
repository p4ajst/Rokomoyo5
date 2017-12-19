﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBB : Gimmick {

    //踏んでいるかのフラグ
    bool usedFlagB = false;

    // Use this for initialization
    override protected void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();

        //オブジェクトの上に行ったら
        if (base.OnFloor() == true && usedFlagB == false)
        {
            //フラグを立てる
            usedFlagB = true;
        }
        //その場にいなかったら
        else if (base.OnFloor() == false)
            //フラグを消す
            usedFlagB = false;
    }
    //フラグ確認用の関数
    public bool GetFlagB()
    {
        return usedFlagB;
    }
}
