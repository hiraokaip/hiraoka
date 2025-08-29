using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engumi : MonoBehaviour
{
    public GameObject selctet;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject == selctet.GetComponent<SelectionManager>().selected)
        {
            this.gameObject.transform.parent = hand.transform;
        }
        else
        {
            this.gameObject.transform.parent = null;
        }
    }
}
