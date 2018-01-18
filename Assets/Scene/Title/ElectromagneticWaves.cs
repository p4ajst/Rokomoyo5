using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectromagneticWaves : MonoBehaviour
{

    public  GameObject thunderParticle;        //パーティクル
    public Transform[] thunderPoints;         // 地点

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (GUI.Button(new Rect(20, 10, 80, 20), "Grass"))
        //{
        //    foreach (Transform explosionPos in thunderPoints)
        //    {
        //        GameObject thunder = Instantiate(thunderParticle,               // パーティクルオブジェクトの生成
        //            explosionPos.position, transform.rotation) as GameObject;
        //        Destroy(thunder, 3f);                                             // 3秒後に消す
        //    }
        //}
    }
    //static void Electrowaves()
    //{
    //    foreach (Transform explosionPos in thunderPoints)
    //    {
    //        GameObject thunder = Instantiate(thunderParticle,               // パーティクルオブジェクトの生成
    //            explosionPos.position, transform.rotation) as GameObject;
    //        Destroy(thunder, 3f);                                             // 3秒後に消す
    //    }
    //}
}
