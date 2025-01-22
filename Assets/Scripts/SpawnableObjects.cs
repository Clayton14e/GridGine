using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObjects : MonoBehaviour
{
    public List<GameObject> spawnList;
    // Start is called before the first frame update
    void Start()
    {
        spawnList.Add(Resources.Load("") as GameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSpawnables(){
        foreach(GameObject spawnable in spawnList){
            Debug.Log(spawnable.name);
        }
    }
}
