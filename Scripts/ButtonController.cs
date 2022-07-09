using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonController : MonoBehaviour
{
    //TextMeshProUGUI tm ;
    public Material defaultMaterial;
    public Material selectedMaterial;
    public Material hoverMaterial;

    private Renderer currentMaterial;
    public void Start(){
        //tm = GetComponent<TextMeshProUGUI>();
        currentMaterial = GetComponent<Renderer>();
        currentMaterial.material = defaultMaterial;
        Debug.Log("In Start of button controller");
    }
    public void OnPointerEnter()
    {
        Debug.Log("In OnPointer Enter in Button controller");
        currentMaterial.material = hoverMaterial;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        //tm.color = Color.white;
        Debug.Log("In Button controller Exit");
        currentMaterial.material = defaultMaterial;
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Debug.Log("In OnPointer Click in button controller");
        currentMaterial.material = selectedMaterial;
        //TeleportRandomly();
    }
}
