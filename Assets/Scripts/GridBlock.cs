using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlock : MonoBehaviour
{
    private int blockPos;
    private GameObject[] tiles;
    private List<SpawnableObjects> s_Scripts;
    // Start is called before the first frame update
    void Start()
    {
        //setRotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    // Set Public Function to set rotation from GridHandler after spawning
    public void setRotation(Vector3 pos)
    {
        if(pos.x == -1) blockPos=0;
        if(pos.x == 1) blockPos=1;
        if(pos.y == -1) blockPos=2;
        if(pos.y == 1) blockPos=3;
        switch (blockPos){
            // X -1
            case 0:  
            //Debug.Log("Position Left");
            gameObject.transform.Rotate(0,0, 90);
            break;
            // X 1
            case 1:
            //Debug.Log("Position Right");
            gameObject.transform.Rotate(0,0, 270);
            break;
            // Y -1
            case 2:
            //Debug.Log("Position Bottom");
            gameObject.transform.Rotate(0,0, 180);
            break;
            // Y 1
            case 3:
            //Debug.Log("Position Top");
            break;
            // CENTERED
            default:
            break;
        }
    }
}
