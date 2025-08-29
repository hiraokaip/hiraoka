using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class Resetbox : MonoBehaviour
{
    public GameObject selctet;
    private XRIDefaultInputActions controls;
    // Start is called before the first frame update
    public Shotai shotai1;
    public Shotai shotai2;
    public Shotai shotai3;
    public Shotai shotai4;
    public Shotai shotai5;
    public Shotai shotai6;
    public Shotai shotai7;
    public Shotai shotai8;
    public Shotai shotai9;
    public Sagase sagase;
    public GameObject kanban;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    private void Awake()
    {
        controls = new XRIDefaultInputActions();
        // ActionMaps[Player]の中の[Jump]というActionに紐づくイベントリスナーを登録
        controls.XRILeftInteraction.Select.performed += OnSelectPerformed;
        //controls.XRILeftInteraction.Select.canceled += OnSelectCanceled;
    }
    private void OnEnable()
    {
        // Inputアクションを有効化
        controls.Enable();
    }

    private void OnDisable()
    {
        // Inputアクションを無効化
        controls.Disable();
    }
    void OnSelectPerformed(InputAction.CallbackContext context)
    {

        if (this.gameObject == selctet.GetComponent<SelectionManager>().selected)
        {
            sagase.Randoming();
            shotai1.Restarting();
            shotai2.Restarting();
            shotai3.Restarting();
            shotai4.Restarting();
            shotai5.Restarting();
            shotai6.Restarting();
            shotai7.Restarting();
            shotai8.Restarting();
            shotai9.Restarting();

        }
        

    }
    //void OnSelectCanceled(InputAction.CallbackContext context){    }
    void Start()
    {
        sagase = kanban.GetComponent<Sagase>();
        shotai1 = tile1.GetComponent<Shotai>();
        shotai2 = tile2.GetComponent<Shotai>();
        shotai3 = tile3.GetComponent<Shotai>();
        shotai4 = tile4.GetComponent<Shotai>();
        shotai5 = tile5.GetComponent<Shotai>();
        shotai6 = tile6.GetComponent<Shotai>();
        shotai7 = tile7.GetComponent<Shotai>();
        shotai8 = tile8.GetComponent<Shotai>();
        shotai9 = tile9.GetComponent<Shotai>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != selctet.GetComponent<SelectionManager>().selected)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }

    }
}
