using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMainCamera : MonoBehaviour
{
    public Camera mainCamera;
    private const float _maxDistance = 3;
    // Update is called once per frame
    void Update()
    {
        Vector3 mainCameraPosition = mainCamera.transform.forward * _maxDistance;
        mainCameraPosition.z += Mathf.Sign(mainCameraPosition.z);
        mainCameraPosition.y = 3f;
        transform.position = mainCameraPosition;
        Quaternion rotateTo = mainCamera.transform.rotation;
        rotateTo.z = 0;
        rotateTo.x = 0;
        transform.rotation = rotateTo;
    }
}
