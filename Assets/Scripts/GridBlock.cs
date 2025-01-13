using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlock : MonoBehaviour
{
    protected int blockPos;

    // Start is called before the first frame update
    void Start()
    {
        setRotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void setRotation()
    {
        switch (blockPos){
            case 0:
            Debug.Log("Position 1");
            break;
            case 1:
            break;
            default:
            break;
        }
    }
}
