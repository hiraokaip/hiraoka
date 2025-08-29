using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using ViveSR.anipal.Eye;

public class SelectionManager : MonoBehaviour
{
    private XRIDefaultInputActions controls;
    public int state;
    public GameObject sranipa;
    public GameObject yobi;
    public GameObject selected;
    public GameObject kinki;
    public List<GameObject> dendo;
    private float time;
    private float count;
    private int cant;
    public Material terashi;
    public Color activeColor = Color.cyan;
    public float intensity = 1f;
    public string tag;

    private void Awake()
    {

        // MyControls�̃C���X�^���X���쐬
        controls = new XRIDefaultInputActions();

        // ActionMaps[Player]�̒���[Jump]�Ƃ���Action�ɕR�Â��C�x���g���X�i�[��o�^
        controls.XRIRightInteraction.Select.performed += OnSelectPerformed;
        controls.XRIRightInteraction.Select.canceled += OnSelectCanceled;
        controls.XRIRightLocomotion.Jump.performed += OnJumpPerformed;
        controls.XRIRightInteraction.Activate.performed += OnActivatePerformed;
        state = 0;
        time = 0.0f;
        cant = 0;
    }
    private void OnEnable()
    {
        // Input�A�N�V������L����
        controls.Enable();
    }

    private void OnDisable()
    {
        // Input�A�N�V�����𖳌���
        controls.Disable();
    }

    void OnSelectPerformed(InputAction.CallbackContext context)
    {

        state = 1;
    }
    void OnSelectCanceled(InputAction.CallbackContext context)
    {

        state = 0;
    }
    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        selected.GetComponent<Renderer>().material.color = Color.gray;
        selected = null;
    }
    void OnActivatePerformed(InputAction.CallbackContext context)
    {
        selected.GetComponent<Renderer>().material.color = Color.gray;
        selected = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        yobi = sranipa.GetComponent<GazeCSVSRanipal>().Kouho;
        tag = yobi.gameObject.tag;
        if (state == 1 && cant == 0 && yobi != null)
        {
            if(tag != "yuka")
            {
                selected = yobi;
                dendo.Add(selected);
                time = 0.0f;
                cant = 1;
                switch (tag)
                {
                    case "Menu":
                        selected.GetComponent<Renderer>().material.color = Color.magenta;
                        break;
                    case "Untagged":
                        selected.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }
            }
        }
        if (time >= 1.0f)
        {
            cant = 0;
        }
        //selected.gameObject.SetActive(false);
    }
}
