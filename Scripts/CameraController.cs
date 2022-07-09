using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class CameraController : MonoBehaviour
{
    GamePadInput gp;
    public GameObject textGO;
    public GameObject pointer;
    float selectPressend = 0f;
    private const float _maxDistance = 7f;
    private GameObject _gazedAtObject = null;
    private LineRenderer lineRenderer;
    void Awake(){
        gp = new GamePadInput();
        // Handling button click functionality functionality
        gp.GamePlay.SelectButton.performed += ctx => selectPressend = 1f;
        gp.GamePlay.SelectButton.canceled += ctx => selectPressend  = 0f;
        // Handling holding button functionality
        gp.GamePlay.HoldButton.performed += ctx => {
            if(_gazedAtObject && _gazedAtObject.name.Equals("TV Mount")){
                _gazedAtObject.SendMessage("OnPointerHold",true);
            }
        };
        gp.GamePlay.HoldButton.canceled += ctx => {
            if(_gazedAtObject && _gazedAtObject.name.Equals("TV Mount")){
                _gazedAtObject.SendMessage("OnPointerHold",false);
            }
        };
        // Pointer functinaity
        lineRenderer = pointer.GetComponent<LineRenderer>();
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.forward * _maxDistance;

        Debug.DrawRay(transform.position,forward,Color.red);
        
        lineRenderer.SetPositions(new Vector3[2]{new Vector3(0,-0.1f,0),forward});
        if (Physics.Raycast(transform.position, forward, out hit, _maxDistance))
        {
            //lineRenderer.SetPositions(new Vector3[2]{new Vector3(0,-0.1f,0),hit.point});
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                
                Debug.Log(hit.transform.gameObject.name);
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
                
            }
            
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }
        if (Google.XR.Cardboard.Api.IsTriggerPressed || selectPressend==1f)
        {
            Debug.Log("Button is pressed");
            
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
        else{
            textGO.GetComponent<TextMeshProUGUI>().text = "Object is not selected";
        }
    }
    void OnEnable(){
        gp.GamePlay.Enable();
    }
    void OnDisable(){
        gp.GamePlay.Disable();
    }
    
   
}
