using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microUSB : Gimmick {

    //踏んでいるか確認のフラグ
    static bool flag = false;

    public GameObject thunderParticle;        //パーティクル
    public Transform[] thunderPoints;         // 地点

    // Use this for initialization
    override protected void Start () {
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        base.Update();

        //踏んでいたら
        if (base.OnFloor())
        {
            if (flag == false)
            {
                Debug.Log("anime");
                foreach (Transform explosionPos in thunderPoints)
                {
                    GameObject thunder = Instantiate(thunderParticle,               // パーティクルオブジェクトの生成
                        explosionPos.position, transform.rotation) as GameObject;
                    Destroy(thunder, 0.15f);                                             // 3秒後に消す
                }
            }
            //フラグを立てる
            flag = true;
        }
	}

    //フラグ確認用
    public bool GetFlag()
    {

        return flag;
    }
    static public void SetFlag(bool _flag)
    {

        flag = _flag;
    }
}
