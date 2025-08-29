using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sagase : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TMP_Text text;
    public int rnd;
    public List<int> answers;
    public int change;
    void Awake()
    {
        Randoming();
    }
    public void Randoming()
    {
        change = 0;
        rnd = Random.Range(1, 7);
        switch (rnd)
        {
            case 1:

                break;
        }
        text = this.gameObject.GetComponent<TMP_Text>();
        text.SetText("Search {0}", rnd);
        answers = new List<int>() { 1, 2, 3, 4, 5, 6, 0, 0, 0 };
        for (var i = answers.Count - 1; i >= 0; --i)
        {
            var j = Random.Range(0, i + 1);
            var tmp = answers[i];
            answers[i] = answers[j];
            answers[j] = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(change == 1) { text.SetText("Choose ResetBox"); }
    }
}
