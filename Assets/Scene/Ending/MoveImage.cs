using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{

    Vector3 pos;
    float y = 0;
    int timer = 0;

    // シーン変更
    SceneChanger sceneChanger = null;

    // Use this for initialization
    void Start()
    {
        pos = gameObject.transform.position;
        y = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        if (y >= -5)
        {
            y -= 0.02f;
            gameObject.transform.position = new Vector3(pos.x, pos.y + y, pos.z);
        }
        else
        {
            timer++;
            if(timer>=180)
            {
                timer = 0;
                //タイトルに行く

            }
        }
    }
}
