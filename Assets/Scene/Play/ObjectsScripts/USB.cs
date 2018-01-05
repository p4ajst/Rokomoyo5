using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USB : Gimmick {

    ////USBの関数を取る
    GameObject usbA;
    GameObject usbB;
    //USBの位置を取る
    GameObject usbA_pos;
    GameObject usbB_pos;

    //パーティクルエフェクト
    public GameObject warpParticle;        //パーティクル
    public GameObject warpParticleDown;        //パーティクル
    public Transform[] warpPoints;         // 地点
    bool effect;
    //多重に移動しないようにするフラグ
    bool flag = false;

    // Use this for initialization
    void Start () {
        base.Start();
        usbA = GameObject.Find("USB/USB");
        usbB = GameObject.Find("USB/USB (1)");
        usbA_pos = GameObject.Find("USB/USB");
        usbB_pos = GameObject.Find("USB/USB (1)");
        effect = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        base.Update();

        //USBAに行った場合
        if (usbA.GetComponent<USBA>().GetFlagA() && !flag)
        {
         
            //移動したことを示す
            flag = true;
            effect = true;
            if (effect == true)
            {
                Invoke("walpDownCoroutine2", 1.0f);
                walpUp(warpPoints[0]);
            }
            //プレイヤーを移動させる
            player.GetComponent<chara>().transform.position = new Vector3(usbB_pos.GetComponent<USBB>().transform.position.x, 0.6f, usbB_pos.GetComponent<USBB>().transform.position.z);
        }
        //USBBに行った場合
        if (usbB.GetComponent<USBB>().GetFlagB() && !flag)
        {
          
            //移動したことを示す
            flag = true;
            effect = true;
            if (effect == true)
            {
                Invoke("walpDownCoroutine1", 1.0f);
                walpUp(warpPoints[1]);
            }
            //プレイヤーを移動させる
            player.GetComponent<chara>().transform.position = new Vector3(usbA_pos.GetComponent<USBA>().transform.position.x, 0.6f, usbA_pos.GetComponent<USBA>().transform.position.z);
        }
      //  walpDownCoroutine1();
        //どちらも踏んでない状態になったら
        if (!usbA.GetComponent<USBA>().GetFlagA() && !usbB.GetComponent<USBB>().GetFlagB())
            //多重移動のフラグを消す
            flag = false;
            effect = false;
    }

    private void walpUp(Transform pos)
    {
        foreach (Transform explosionPos in pos)
        {
            GameObject warp = Instantiate(warpParticle,               // パーティクルオブジェクトの生成
                explosionPos.position, transform.rotation) as GameObject;
            Destroy(warp, 1f);                                             // 3秒後に消す
        }
    }
    private void walpdown(Transform pos)
    {
        
        foreach (Transform explosionPos in pos)
        {
            GameObject warp = Instantiate(warpParticleDown,               // パーティクルオブジェクトの生成
                explosionPos.position, transform.rotation) as GameObject;
            Destroy(warp, 1f);                                             // 3秒後に消す
        }
    }
    private void walpDownCoroutine1()
    {
        Transform pos;
        pos = warpPoints[0];
        foreach (Transform explosionPos in pos)
        {
            GameObject warp = Instantiate(warpParticleDown,               // パーティクルオブジェクトの生成
                explosionPos.position, transform.rotation) as GameObject;
            Destroy(warp, 1f);                                             // 3秒後に消す
        }
    }
    private void walpDownCoroutine2()
    {
        Transform pos;
        pos = warpPoints[1];
        
        foreach (Transform explosionPos in pos)
        {
            GameObject warp = Instantiate(warpParticleDown,               // パーティクルオブジェクトの生成
                explosionPos.position, transform.rotation) as GameObject;
            Destroy(warp, 1f);                                             // 3秒後に消す
        }
    }
}
