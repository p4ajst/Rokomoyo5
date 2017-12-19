﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// キャラクターの管理
/// </summary>
public class CharacterManager : Singleton<CharacterManager>
{

    /// <summary>
    /// 音マネージャーのインスタンス
    /// </summary>
    public SoundManager sound = null;

    /// <summary>
    /// 音符のインスタンス
    /// </summary>
    private Notes note = null;

    /// <summary>
    // ロボのインスタンス
    /// </summary>
    public chara roomba = null;
    GameObject player = null;

    //キャラクターのバッテリー
    public static float battery = 1.0f;
    GameObject explain;
    //GameObject menu;
    //Transform menu_button;

    public static float GetBattery()
    {
        return battery;
    }

    public static void SetBattery(float _battery)
    {
        battery = _battery;
    }

    /// <summary>
    /// 音符の設定
    /// </summary>
    /// <param name="notes">音符のインスタンス</param>
    public void SetNotes(Notes notes)
    {
        note = notes;
    }


    public void InitCharacter()
    {
        GameObject obj = null;
        // キャラクターを探す
        //player = GameObject.Find("Player");

        player = GameObject.Find("Player");

        // シーンからサウンドマネージャーを探す
        obj = GameObject.Find("SoundManager");
        // サウンドマネージャーのコンポーネントを取得
        sound = obj.GetComponent<SoundManager>();
        // キャラクターを探す
        player = GameObject.Find("Player");
        // キャラクターのコンポーネントを取得
        roomba = player.GetComponent<chara>();
    }

    /// <summary>
    /// キャラクターの移動
    /// </summary>
    public void MoveCharacter()
    {
        //Debug.Log("movecharacter動いてます");



        // 音が鳴っているか
        if (!sound.music.isPlaying)
        {
            roomba.MoveEnd();
            //Debug.Log("回ってる");
            return;
        }
       
       // 鳴っている音の場所がキャラクターの同一直線上にあるか
       if (roomba.transform.position.x == note.transform.position.x || roomba.transform.position.z == note.transform.position.z)
       {
           // 音の判別
           if (note.type == Notes.MusicType.ATTRACT)
           {
               roomba.AttactMove(note.transform.position);
           }
           if (note.type == Notes.MusicType.AWAY)
           {
               roomba.AwayMove(note.transform.position);
           }
       }
       else
       {
           roomba.MoveEnd();
           //Debug.Log("回ってる");
       }
    }

    // Use this for initialization
    void Start ()
    {
        // 自分のポインタはシングルトンでなかったら
        if (this != Instance)
        {
            // スクリプトの削除
            Destroy(this);
            // 関数を抜ける
            return;
        }
        InitCharacter();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveCharacter();

        //説明文があるかどうかを取得する
        explain = GameObject.Find("Explain");
        //メニューがあるかどうかを取得する
        //menu = GameObject.Find("Pause 1 1");
        //menu_button = menu.transform.Find("Retrun_Title_Button");
        //説明文がなかったら減らす
        if (explain == null && MenuButton.GetFlag()==false)
            battery -= 0.01f / 360.0f;

        if (battery >= 1.0f)
            battery = 1.0f;
        //Debug.Log(battery);
    }
}
