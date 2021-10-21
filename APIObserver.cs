using System;
using UnityEngine;
using UniRx;

public class APIObserver : MonoBehaviour
{

    public const string URL_01 = "https://xxxxx.com/api/v1";
    public const string URL_02 = "https://xxxxx.com/api/v2";

    private void Start()
    {
        Action<bool, string> actionJson = JudegJsonVal;
        StartCoroutine(WebRequestUtil.ReceiveAPI(URL_01, actionJson));

        Action<bool, Texture> actionImage = JudegImageVal;
        StartCoroutine(WebRequestUtil.ReceiveImage(URL_02, actionImage));
    }

    // Jsonの受け取り
    private void JudegJsonVal(bool result, string json)
    {
        if (result)
        {
            // レスポンス受信成功
            // クラスに格納
            APIValue apiValue = null;
            if (json != null) apiValue = JsonUtility.FromJson<APIValue>(json);
        }
        else
        {
            // レスポンス受信失敗
            Debug.Log("エラー発生!");
        }
    }

    // 画像の受け取り
    // ※スプライトの動的生成は、メモリが開放されないので、手動でResources.UnloadUnusedAssets()を呼ぶと良い（あまり呼びすぎないように注意）
    private void JudegImageVal(bool result, Texture texture)
    {
        if (result)
        {
            // レスポンス受信成功
            // スプライトを作成
            sprite = Sprite.Create((Texture2D)texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(1.0f, 1.0f));
        }
        else
        {
            // レスポンス受信失敗
            Debug.Log("エラー発生!");
        }
    }
}
