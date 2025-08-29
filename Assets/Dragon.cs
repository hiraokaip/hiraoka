using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private float time;
    private GameObject target;
    public float dx;
    public int junban;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("elder");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            dx = target.transform.position.x - this.transform.position.x;
            time = 1.0f;
        }
    }
}
