using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlimeMovement : MonoBehaviour
{

    [SerializeField] private float Range = 5;

    private Vector3 startPress;
    private Vector3 currentPosition;


    private void Awake()
    {
        var playerInputManager = new InputPlayerMaster();
        Debug.Log("Initialize InputManager");

        playerInputManager.Player.VelocityPress.performed += _ => Press();
        playerInputManager.Player.VelocityHold.performed += _ => Hold();
        playerInputManager.Player.VelocityRelease.performed += _ => Release();
    }

    private void Press()
    {
        Debug.Log("press");
    }

    private void Hold()
    {
        Debug.Log("hold");
    }

    private void Release()
    {
        Debug.Log("release");
    }
    
}
