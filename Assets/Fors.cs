using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fors : MonoBehaviour
{
    public GameObject[] lisuto;
    public Dragon script;
    private int ide;
    private GameObject taisho;
    public GameObject[] menbas;
    public float[] dxs;
    private float re;
    private float time;
    private float count;
    public Csv csv;
    void Start()
    {
        menbas = GameObject.FindGameObjectsWithTag("Tokage");
        lisuto = new GameObject[menbas.Length];
        for (int manko = 0; manko < 3; manko++) {
            taisho = menbas[manko];
            script = taisho.GetComponent<Dragon>();
            ide = script.junban - 1;
            lisuto[ide] = taisho;
        }
        csv = this.GetComponent<Csv>();
        time = 0.0f;
        count = 0.0f;
    }

    // Update is called once per frame
void Update()
    {
        dxs = new float[lisuto.Length];
        for( int i = 0; i < lisuto.Length; i++)
        {
            taisho = lisuto[i];
            script = taisho.GetComponent<Dragon>();
            re = script.dx;
            dxs[i] = re;
        }
    }
    }

