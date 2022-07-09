using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrowController : MonoBehaviour
{
    public Material defaultMaterial;
    //public Material selectedMaterial;
    public GameObject screenGrid;
    public float rotationSpeed = 50f;
    public Material hoverMaterial;
    private Renderer currentMaterial;
    private bool pointerHoveredOnButton = false;
    public void Start(){
        currentMaterial = GetComponent<Renderer>();
        currentMaterial.material = defaultMaterial;
        Debug.Log("In Start of Left Arrow controller");
    }
    public void OnPointerEnter()
    {
        Debug.Log("In OnPointer Enter in Left Arrow controller");
        currentMaterial.material = hoverMaterial;
        pointerHoveredOnButton = true; 
        
        
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        //tm.color = Color.white;
        Debug.Log("In OnExit in Left Arrow controller");
        currentMaterial.material = defaultMaterial;
        pointerHoveredOnButton = false;
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Debug.Log("In OnPointer Click in Left Arrow controller");
        //currentMaterial.material = selectedMaterial;
    }
    void Update(){
        if(pointerHoveredOnButton){
            Vector3 rotationVector = new Vector3(0,-rotationSpeed,0) * Time.deltaTime;
            screenGrid.transform.Rotate(rotationVector,Space.World);
        }
    }
}
