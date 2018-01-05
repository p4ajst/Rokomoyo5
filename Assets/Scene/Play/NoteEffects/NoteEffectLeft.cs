﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffectLeft : MonoBehaviour
{
    private float Cycle;
    private float move;
    private float tall;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
        Cycle = 0.1f;
        move = 0.02f;
        tall = 4.0f;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveEffectLeft()
    {
        transform.position = new Vector3(transform.position.x - move
  , 1.5f + (Mathf.Sin(Time.frameCount * Cycle) / tall), transform.position.z);
    }
    public void MoveEffectLeftAttract(Vector3 positions)
    {
        transform.position = new Vector3(positions.x - 6.0f + move,
            1.5f + (Mathf.Sin(Time.frameCount * Cycle) / tall), transform.position.z);
    }


    public void ResetEffect(Vector3 positions)
    {
        if (transform.position.x <=positions.x -6.0f)
        {
            transform.position = positions;
        }
    }

    public void ResetPos(Vector3 positions)
    {
        transform.position = positions;
    }
    public void ResetPosAttract(Vector3 positions)
    {
        if (transform.position.z == positions.z && transform.position.x == transform.position.x)
        {
            transform.position = new Vector3(positions.x-6.0f, positions.y, positions.z );
        }
    }
}

