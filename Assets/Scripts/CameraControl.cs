using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = Input.mouseScrollDelta.y;
        gameObject.GetComponent<Camera>().orthographicSize -= y;
    }
}
