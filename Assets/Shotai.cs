using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;


public class Shotai : MonoBehaviour
{
    private XRIDefaultInputActions controls;
    public GameObject selctet;
    public GameObject me;
    private TMPro.TMP_Text text;
    public GameObject kanban;
    public int rand;
    public int id;
    private int shotai;
    private int check;
    private Renderer a;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new XRIDefaultInputActions();
        // ActionMaps[Player]の中の[Jump]というActionに紐づくイベントリスナーを登録
        controls.XRILeftInteraction.Select.performed += OnSelectPerformed;
        controls.XRILeftInteraction.Select.canceled += OnSelectCanceled;
        text = this.gameObject.GetComponent<TMP_Text>();
        check = 0;

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
        rand = kanban.GetComponent<Sagase>().rnd;
        check = 1;

    }
    void OnSelectCanceled(InputAction.CallbackContext context)
    {

        check = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        a = this.GetComponent<Renderer>();
        Restarting();
    }

    // Update is called once per frame
    void Update()
    {
        //shotai = kanban.GetComponent<Sagase>().answers[id - 1];
        me = selctet.GetComponent<SelectionManager>().selected;
        if (me == this.transform.parent.gameObject)
        {
            if(shotai != 0)
            {
                text.SetText(shotai.ToString());
                a.enabled = true;
            }
            if (check == 1)
            {

                if (shotai == rand)
                {
                    text.SetText("O");
                    kanban.GetComponent<Sagase>().change = 1;
                }
                else
                {
                    text.SetText("X");
                }
            }
            else
            {
                text.SetText(shotai.ToString());
            }
        }
        else
        {
            this.transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }

        
    }
    public void Restarting()
    {
        a.enabled = false;
        shotai = kanban.GetComponent<Sagase>().answers[id - 1];
        if(shotai == 0)
        {
            this.transform.parent.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.transform.parent.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
