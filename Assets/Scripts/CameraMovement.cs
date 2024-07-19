using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Camera cam;

    //is set in start function as 20 percent of screen width
    public float mouseWeight;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (target == null)
            return;

        //follow the target
        Vector3 newPos = target.position;

        //make adjustments to camera position according to mouse position
        Vector3 mousePos = TransformScreenToNDC(Input.mousePosition);
        newPos = target.position + mousePos * mouseWeight;

        //set new position without changing z coordinate
        newPos.z = transform.position.z;
        transform.position = newPos;

    }
    //NDC - normalized device coordinates (in range [-1; 1])
    Vector3 TransformScreenToNDC(Vector3 screenCoordinates)
    {
        // Convert screen coordinates to viewport coordinates
        Vector3 viewportCoordinates = cam.ScreenToViewportPoint(new Vector3(screenCoordinates.x, screenCoordinates.y, 0));

        // Transform viewport coordinates to NDC coordinates
        Vector3 ndcCoordinates = new Vector3(viewportCoordinates.x * 2 - 1, viewportCoordinates.y * 2 - 1, viewportCoordinates.z);
        if (ndcCoordinates.x > 1)
            ndcCoordinates.x = 1;

        if (ndcCoordinates.x < -1)
            ndcCoordinates.x = -1;
        
        if (ndcCoordinates.y > 1)
            ndcCoordinates.y = 1;
        
        if (ndcCoordinates.y < -1)
            ndcCoordinates.y = -1;

        return ndcCoordinates;
    }
}
