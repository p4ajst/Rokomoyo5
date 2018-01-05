using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

/// <summary>
/// 画面をキャプチャーしTexture2Dを生成します。
/// </summary>
public class DisplayCapture : MonoBehaviour
{
    /// <summary>
    /// キャプチャーが完了したときに呼び出すハンドラー
    /// </summary>
    public Action ResultHandler = null;

    /// <summary>
    /// テクスチャー
    /// </summary>
    public Texture2D Texture = null;

    /// <summary>
    /// キャプチャー画像を保存済みかどうか
    /// </summary>
    bool saved_screen_capture = false;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        saved_screen_capture = false;
    }

    /// <summary>
    /// Raises the post render event.
    /// </summary>
    void Update()
    {
        if (saved_screen_capture != true)
        {
            // キャプチャー
            Take();

            // 通知
            if (ResultHandler != null)
            {
                ResultHandler();
            }

            // 破棄
            // Destroy(this);
        }
    }

    /// <summary>
    /// 画面をキャプチャーします
    /// </summary>
    protected void Take()
    {
        // Texture2D screenShot = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(screenShot.width, screenShot.height, 24);

        // Render from all!
        foreach (Camera cam in Camera.allCameras)
        {
            RenderTexture prev = cam.targetTexture;
            cam.targetTexture = rt;
            cam.Render();
            cam.targetTexture = prev;
        }

        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);

        //various other post processing here..

        screenShot.Apply();

        this.Texture = screenShot;
        saved_screen_capture = true;
    }
}
