using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Csv : MonoBehaviour
{
    private float time;
    private float count;
    private StreamWriter sw;
    public float[] results;
    public Fors script;
    // Start is called before the first frame update
    void Start()
    {
        sw = new StreamWriter("@Gekirin.csv", true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = {"time", "idai", "shihai", "raimei" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        int len = s1.Length - 1;
        results = new float[len];
        script = GetComponent<Fors>();
    }
    public void zahyo(string txt1, string txt2, string txt3, string txt4) 
    {
        string[] s1 = { txt1, txt2, txt3, txt4 };
        string s2 = string.Join (",", s1);
        sw.WriteLine (s2);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < results.Length; i++)
            {
                results[i] = script.dxs[i];
            }
            zahyo(time.ToString(), results[0].ToString(), results[1].ToString(), results[2].ToString());
        if (time >= 6.0f) { 
            sw.Close();
        
        }
    }
}
