using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextController : MonoBehaviour
{
    TextMeshProUGUI tm ;
    public void Start(){
        tm = GetComponent<TextMeshProUGUI>();
    }
    public void OnPointerEnter()
    {
        Debug.Log("In OnPointer Enter in text controller");
        tm.color = Color.blue;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        tm.color = Color.white;
        Debug.Log("In text controller");
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Debug.Log("In OnPointer Click in text controller");
        tm.color = Color.green;
        //TeleportRandomly();
    }
}
