using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Collections;

public class uGUIresize : Trap
{
    public  GameObject rawImage;
    public ParticleSystem pe;
    public GameObject thunderParticle;        //パーティクル
    public Transform[] thunderPoints;         // 地点
    static float  height;
    static bool flag = false;
    // Use this for initialization
    void Start()
    {
        height = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが当たったらに条件式を変える
        //if (Input.GetKey("up"))
        if(base.OnFloor())
        {
            foreach (Transform explosionPos in thunderPoints)
            {
                GameObject thunder = Instantiate (thunderParticle,               // パーティクルオブジェクトの生成
                    explosionPos.position, transform.rotation) as GameObject;
                Destroy(thunder, 0.1f);                                             // 3秒後に消す
            }
        }

        //if (Input.GetKey("down"))
        //{
        //       height += 1;
        //}
        //if (height < 10)
        //{
        //    rawImage.transform.localScale = new Vector3(
        //    gameObject.transform.localScale.x - height,
        //    gameObject.transform.localScale.y - height,
        //    gameObject.transform.localScale.z - height);
        //}
       
    }
    public bool GetFlag()
    {
        return flag;
    }
    public void OnFlag()
    {
        flag = true;
    }
}