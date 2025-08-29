using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;


[InitializeOnLoad]//エディター起動時にコンストラクタが呼ばれるように
public static class RecorderIgniter
{

    //=================================================================================
    //初期化
    //=================================================================================

    /// <summary>
    /// コンストラクタ(InitializeOnLoad属性によりエディター起動時に呼び出される)
    /// </summary>
    static RecorderIgniter()
    {
        //playModeStateChangedイベントにメソッド登録
        EditorApplication.playModeStateChanged += OnChangedPlayMode;
    }

    //=================================================================================
    //プレイモードの変更
    //=================================================================================

    //プレイモードが変更された
    private static void OnChangedPlayMode(PlayModeStateChange state)
    {


        //エディタの再生開始時
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            StartRecording();
        }

    }

    //=================================================================================
    //録画開始
    //=================================================================================

    //録画開始
    private static void StartRecording()
    {
        //Recorderのウィンドウ取得
        var recorderWindow = (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
        if (recorderWindow == null)
        {
            Debug.LogWarning("RecorderWindowがないので自動再生出来ませんでした");
            return;
        }

        if (recorderWindow.IsRecording())
        {
            return;
        }
        Debug.Log("自動録画開始");
        recorderWindow.StartRecording();
    }

    //=================================================================================
    //ファイルの削除
    //=================================================================================



}