using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class DuttonEvent : UnityEvent<bool> { }
public class Dutton : MonoBehaviour
{
    public XRInputButtonReader m_JumpInput = new XRInputButtonReader("Jump");
    public bool mx;
    public XRInputButtonReader jumpInput
    {
        get => m_JumpInput;
        set => XRInputReaderUtility.SetInputProperty(ref m_JumpInput, value, this);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mx = jumpInput;
    }
}
