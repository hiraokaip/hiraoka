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

        // MyControlsのインスタンスを作成
        controls = new XRIDefaultInputActions();

        // ActionMaps[Player]の中の[Jump]というActionに紐づくイベントリスナーを登録
        controls.XRIRightLocomotion.Jump.performed += OnJumpPerformed;
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

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        // Rigidbodyに上方向の力を加える
        Debug.Log("anb");
    }
}
