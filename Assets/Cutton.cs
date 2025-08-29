using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class Cutton : MonoBehaviour
{
    private XRIDefaultInputActions controls;

    private void Awake()
    {

        // MyControls�̃C���X�^���X���쐬
        controls = new XRIDefaultInputActions();

        // ActionMaps[Player]�̒���[Jump]�Ƃ���Action�ɕR�Â��C�x���g���X�i�[��o�^
        controls.XRIRightLocomotion.Jump.performed += OnJumpPerformed;
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

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        // Rigidbody�ɏ�����̗͂�������
        Debug.Log("anb");
    }
}
