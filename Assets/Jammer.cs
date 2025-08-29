using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jammer : MonoBehaviour
{
    public GameObject selctet;
    public GameObject hand;
    private Renderer a;
    private bool b;
    // Start is called before the first frame update
    void Start()
    {
        //a = this.GetComponent<Renderer>();
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.gameObject == selctet.GetComponent<SelectionManager>().selected)
        {
            //this.GetComponent<Renderer>().enabled = false;
            if(b == true)
            {
                b = false;
                this.GetComponent<Renderer>().enabled = b;
            }
            else
            {
                b = true;
                this.GetComponent<Renderer>().enabled = b;
            }
            
        }
        else
        {
            this.gameObject.transform.parent = null;
        }
    }
}
