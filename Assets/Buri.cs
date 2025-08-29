using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buri : MonoBehaviour
{
    [SerializeField]
    IndPie _pie;

    // Start is called before the first frame update
    void Start()
    {
        float[] list = { 1, 3, 5 };
        _pie.SetPieChartAnimation(list);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
