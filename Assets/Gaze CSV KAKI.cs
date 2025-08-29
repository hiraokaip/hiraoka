using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using ViveSR.anipal.Eye;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class GazeCSVKAKI : MonoBehaviour
{
    private XRIDefaultInputActions controls;
    private float time;
    private float count;
    private StreamWriter sw;
    public float[] results;
    public GazeCSVSRanipal script;
    int tile;
    public string filename;
    // Start is called before the first frame update
    private void Awake()
    {

        // MyControlsのインスタンスを作成
        controls = new XRIDefaultInputActions();

        // ActionMaps[Player]の中の[Jump]というActionに紐づくイベントリスナーを登録
        controls.XRILeftInteraction.Activate.performed += OnActivatePerformed;
    }
    private void OnEnable()
    {
        // Inputアクションを有効化
        controls.Enable();
    }

    private void OnDisable()
    {
        // Inputアクションを無効化
        controls.Disable();
    }

    void OnActivatePerformed(InputAction.CallbackContext context)
    {
        sw.Close();
    }
    void Start()
    {
        DateTime thisday = DateTime.Now;
        filename = thisday.ToString($"{thisday:yyyyMMddHHmmss}");
        //sw = new StreamWriter($"@Recordings@\\{filename}.csv", true, Encoding.GetEncoding("Shift_JIS"));
        sw = new StreamWriter($"Recordings/{filename}.csv", true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "time", "GazeX", "GazeY", "GazeZ", "GazeOX", "GazeOY", "GazeOZ", "GazeLX", "GazeLY", "GazeLZ", "GazeRX", "GazeRY", "GazeRZ", "GazeOLX", "GazeOLY", "GazeOLZ", "GazeORX", "GazeORY", "GazeORZ", "PpLX", "PpLY", "PpRX", "PpRY", "FacePositionX", "FacePositionY", "FacePositionZ", "FaceForwardX", "FaceForwardY", "FaceForwardZ", "GazingTime", "Tile"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        int len = s1.Length - 1;
        results = new float[len];
        script = GetComponent<GazeCSVSRanipal>();
    }
    public void zahyo(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10, string txt11, string txt12, string txt13, string txt14, string txt15, string txt16, string txt17, string txt18, string txt19, string txt20, string txt21, string txt22, string txt23, string txt24, string txt25, string txt26, string txt27, string txt28, string txt29,string txt30, string txt31)
    {
        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10, txt11, txt12, txt13, txt14, txt15, txt16, txt17, txt18, txt19, txt20, txt21, txt22, txt23, txt24, txt25, txt26, txt27, txt28, txt29, txt30, txt31 };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < 3; i++)
        {
            results[i] = script.Gaze[i];
            results[i + 3] = script.GazeO[i];
            results[i + 6] = script.GazeL[i];
            results[i + 9] = script.GazeR[i];
            results[i + 12] = script.GazeOL[i];
            results[i + 15] = script.GazeOR[i];
            results[i + 22] = script.Kaoposi[i];
            results[i + 25] = script.Kaomuki[i];
        }
        for (int j = 0; j < 2; j++)
        {

            results[j + 18] = script.PupilL[j];
            results[j + 20] = script.PupilR[j];
        }
        switch (script.namae)
        {
            case "Tile1":
                tile = 1; break;
            case "Tile2":
                tile = 2; break;
            case "Tile3":
                tile = 3; break;
            case "Tile4":
                tile = 4; break;
            case "Tile5":
                tile = 5; break;
            case "Tile6":
                tile = 6; break;
            case "Tile7":
                tile = 7; break;
            case "Tile8":
                tile = 8; break;
            case "Tile9":
                tile = 9; break;
            default:
                tile = 0;
                break;
        }
        zahyo(time.ToString(), results[0].ToString(), results[1].ToString(), results[2].ToString(), results[3].ToString(), results[4].ToString(), results[5].ToString(), results[6].ToString(), results[7].ToString(), results[8].ToString(), results[9].ToString(), results[10].ToString(), results[11].ToString(), results[12].ToString(), results[13].ToString(), results[14].ToString(), results[15].ToString(), results[16].ToString(), results[17].ToString(), results[18].ToString(), results[19].ToString(), results[20].ToString(), results[21].ToString(), results[22].ToString(), results[23].ToString(), results[24].ToString(), results[25].ToString(), results[26].ToString(), results[27].ToString(), script.time.ToString(), tile.ToString());

    }
    private void OnDestroy()
    {
        sw.Close();
    }
}
