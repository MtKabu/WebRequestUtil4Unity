using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestUtil
{
    public static IEnumerator ReceiveAPI(string strUrl, Action<bool, string> action)
    {
        //1.UnityWebRequestを生成
        UnityWebRequest request = UnityWebRequest.Get(strUrl);

        // DownkoadHandlerとheaderの設定
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 5;

        //2.SendWebRequestを実行し、送受信開始
        yield return request.SendWebRequest();

        //3.結果の受け取り
        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                Debug.Log("リクエスト成功");
                //受信したテキスト(json)を変換
                action.Invoke(true, request.downloadHandler.text);
                break;
            case UnityWebRequest.Result.InProgress:
                Debug.Log("リクエスト中");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("サーバとの通信に失敗。タイムアウトや、リクエストが接続できなかった、セキュリティで保護されたチャネルを確立できなかったなど。");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("サーバがエラー応答を返した。サーバとの通信には成功したが、接続プロトコルで定義されているエラーを受け取った。");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("データの処理中にエラーが発生。リクエストはサーバとの通信に成功したが、受信したデータの処理中にエラーが発生。データが破損しているか、正しい形式ではないなど。");
                action.Invoke(false, null);
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public static IEnumerator ReceiveImage(string strUrl, Action<bool, Texture> action)
    {
        //1.UnityWebRequestを生成
        UnityWebRequest request = UnityWebRequest.Get(strUrl);

        // DownkoadHandlerの設定
        request.downloadHandler = (DownloadHandlerTexture)new DownloadHandlerTexture();
        request.timeout = 5;

        //2.SendWebRequestを実行し、送受信開始
        yield return request.SendWebRequest();

        //3.結果の受け取り
        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                Debug.Log("リクエスト成功");
                //受信したテキスト(json)を変換
                action.Invoke(true, ((DownloadHandlerTexture)request.downloadHandler).texture);
                break;
            case UnityWebRequest.Result.InProgress:
                Debug.Log("リクエスト中");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("サーバとの通信に失敗。タイムアウトや、リクエストが接続できなかった、セキュリティで保護されたチャネルを確立できなかったなど。");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("サーバがエラー応答を返した。サーバとの通信には成功したが、接続プロトコルで定義されているエラーを受け取った。");
                action.Invoke(false, null);
                break;
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("データの処理中にエラーが発生。リクエストはサーバとの通信に成功したが、受信したデータの処理中にエラーが発生。データが破損しているか、正しい形式ではないなど。");
                action.Invoke(false, null);
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}
