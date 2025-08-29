using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveSR.anipal.Eye;

public class Indian : MonoBehaviour
{
    private TMPro.TMP_Text text;
    public GameObject Gaze;
    private float shotai;
    private int check;
    private GazeCSVSRanipal rani;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TMPro.TMP_Text>();
        rani = Gaze.GetComponent<GazeCSVSRanipal>();
    }

    // Update is called once per frame
    void Update()
    {
        shotai = rani.perc;
        check = Mathf.CeilToInt(shotai);
        text.SetText(check.ToString());
        if(check == 100)
        {
            text.color = Color.cyan;
        }
        else
        {
            text.color = Color.white;
        }
    }
}
