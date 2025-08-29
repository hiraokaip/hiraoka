using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Daial : MonoBehaviour
{
    private XRIDefaultInputActions controls;
    public GameObject selctet;
    private GameObject me;
    private int num;
    private float time;
    private int cant;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new XRIDefaultInputActions();

        // ActionMaps[Player]の中の[Jump]というActionに紐づくイベントリスナーを登録
        controls.XRILeftInteraction.Select.performed += OnSelectPerformed;
        num = 0;
        cant = 0;
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

        if (me == transform.parent.gameObject && cant == 0)
        {
            num += 1;
            if (num == 3)
            {
                num = 0;
            }
            time = 0.0f;
            cant = 1;
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        me = selctet.GetComponent<SelectionManager>().selected;
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            cant = 0;
        }
        if (num == 0)
        {
            this.transform.eulerAngles = new Vector3 (0, 0, 120);
        }
        if (num == 1)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 240);
        }
        if (num == 2)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
