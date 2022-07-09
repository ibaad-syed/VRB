using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenGridControl : MonoBehaviour
{
    GamePadInput gp;
    float movementSpeed = 30f;
    float lr,rr,ru,rd;
    void Awake(){
        gp = new GamePadInput();
        gp.GamePlay.RotateLeft.performed += ctx => lr = ctx.ReadValue<float>();
        gp.GamePlay.RotateRight.performed += ctx => rr = ctx.ReadValue<float>();
        gp.GamePlay.RotateUp.performed += ctx => ru = ctx.ReadValue<float>();
        gp.GamePlay.RotateDown.performed += ctx => rd = ctx.ReadValue<float>();
        gp.GamePlay.RotateLeft.canceled += ctx => lr  = 0f;
        gp.GamePlay.RotateRight.canceled += ctx => rr  = 0f;
        gp.GamePlay.RotateUp.canceled += ctx => ru  = 0f;
        gp.GamePlay.RotateDown.canceled += ctx => rd  = 0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(lr!=0){
            Vector3 m = new Vector3(0,-lr*movementSpeed,0) * Time.deltaTime;
            transform.Rotate(m,Space.World);  
        }
        else if(rr!=0){
            Vector3 m = new Vector3(0,rr*movementSpeed,0) * Time.deltaTime;
            transform.Rotate(m,Space.World);  
        }
    }

    void OnEnable(){
        gp.GamePlay.Enable();
    }
    void OnDisable(){
        gp.GamePlay.Disable();
    }
}
