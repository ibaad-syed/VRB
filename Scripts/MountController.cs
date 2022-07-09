using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MountController : MonoBehaviour
{
    GamePadInput gp;
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public Material SelectedMaterial;
    public bool holdObject;
    private string movementDirection;
    private Renderer _myRenderer;
    private GameObject parent;
    public void Awake()
    {
        gp = new GamePadInput();
        holdObject = false;
        movementDirection = string.Empty;
        _myRenderer = GetComponent<Renderer>();
        parent = transform.parent.gameObject;
        // movement direct up
        gp.GamePlay.RotateUp.performed += ctx => movementDirection = "UP";
        gp.GamePlay.RotateUp.canceled += ctx => movementDirection = string.Empty;
        // movement direct down
        gp.GamePlay.RotateDown.performed += ctx => movementDirection = "DOWN";
        gp.GamePlay.RotateDown.canceled += ctx => movementDirection = string.Empty;
        // movement direct left
        gp.GamePlay.RotateLeft.performed += ctx => movementDirection = "LEFT";
        gp.GamePlay.RotateLeft.canceled += ctx => movementDirection = string.Empty;
        // movement direct right
        gp.GamePlay.RotateRight.performed += ctx => movementDirection = "RIGHT";
        gp.GamePlay.RotateRight.canceled += ctx => movementDirection = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(holdObject){
            Debug.Log("Movement Direction value : "+movementDirection);
            // move the parent object
            switch(movementDirection){
                case "LEFT":
                    Debug.Log("Left pressed");
                    break;
                case "RIGHT":
                    Debug.Log("Right pressed");
                    break;
                case "UP":
                    Debug.Log("Up pressed");
                    break;
                case "DOWN":
                    Debug.Log("Down pressed");
                    break;
            }
        }
    }
    public void OnPointerEnter()
    {
        _myRenderer.material = GazedAtMaterial;
        Debug.Log("In OnPointer Enter of MoutController");
    }

    public void OnPointerExit()
    {
        _myRenderer.material = InactiveMaterial;
        Debug.Log("In OnPointer Exit of MoutController");
    }
    public void OnPointerHold(bool value)
    {
        holdObject = value;
        Debug.Log("Hold Object Value : "+value);
        if(value){
            _myRenderer.material = SelectedMaterial;
        }
        else{
            _myRenderer.material = InactiveMaterial;
        }
        Debug.Log("In OnPointer Hold of MoutController");

    }
    public void OnPointerClick(){
        // handle on pointer click
    }
    void OnEnable(){
        gp.GamePlay.Enable();
    }
    void OnDisable(){
        gp.GamePlay.Disable();
    }
}
