using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChosei : MonoBehaviour
{
    public float Hiraki;
    public float Shindo;
    public float Hankei;
    public float Min;
    public float Max;
    public byte Tomei;
    public int AUTO;
    // Start is called before the first frame update
    void Start()
    {
        Transform Zz = this.transform;
        Zz.localPosition = new Vector3(0,0,Shindo);
        Vector3 Kame = Zz.parent.gameObject.transform.position;
        Hankei = Shindo * Mathf.Tan(Mathf.PI * Hiraki / 180);
        if (AUTO == 1)
        {
            int Ko = this.transform.childCount;
            for (int i = 0; i < Ko; i++)
            {
                GameObject Taisho = this.transform.GetChild(i).gameObject;

                //色
                MeshRenderer mesh = Taisho.GetComponent<MeshRenderer>();
                mesh.material.color = new Color32(255,255,255,Tomei);
                //開き
                Transform TaiTra = Taisho.transform;

                float PiPi = (Max - Min) / (Ko - 1);
                float kaku1 = Min + PiPi* i * Mathf.PI /180;

                Vector3 Mae = TaiTra.transform.localPosition;
                Mae.x = Hankei * Mathf.Sin(kaku1);
                Mae.y = Hankei * Mathf.Cos(kaku1);
                TaiTra.transform.localPosition = Mae;

                //カメラを向く
                Vector3 muki = Kame - TaiTra.position;
                TaiTra.forward = muki;
            }
        }
        else 
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                GameObject Taisho = this.transform.GetChild(i).gameObject;

                //色
                MeshRenderer mesh = Taisho.GetComponent<MeshRenderer>();
                mesh.material.color = new Color32(255, 255, 255, Tomei);
                //開き
                Transform TaiTra = Taisho.transform;

                float kaku1 = Taisho.GetComponent<MenuId>().Kaku1 * Mathf.PI / 180;
                Vector3 Mae = TaiTra.transform.localPosition;
                Mae.x = Hankei * Mathf.Sin(kaku1);
                Mae.y = Hankei * Mathf.Cos(kaku1);
                TaiTra.transform.localPosition = Mae;
                //カメラを向く
                Vector3 muki = Kame - TaiTra.position;
                TaiTra.forward = muki;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
