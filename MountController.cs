using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountController : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public Material SelectedMaterial;
    private Renderer _myRenderer;
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter()
    {
        Debug.Log("In OnPointer Enter of MoutController");
    }

    public void OnPointerExit()
    {
        Debug.Log("In OnPointer Exit of MoutController");
    }
    public void OnPointerHold()
    {
        Debug.Log("In OnPointer Hold of MoutController");

    }
}
