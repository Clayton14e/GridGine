using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridHandler : MonoBehaviour
{
    private GameObject gridBlock;
    List<GameObject> gridBlocks;
    List<string> stringList;
    private int gridSize, gridLimit, gridMinimum, randomAttempts;
    private Vector3 blockSpawnPos;
    private bool isReady, isDone;
    public GameObject gridSizeInput;
    // Start is called before the first frame update
    void Awake(){
        gridBlock = Resources.Load("GridBlock") as GameObject;
        gridBlocks = new List<GameObject>();
        stringList = new List<string>();
    }
    void Start()
    {
        Debug.Log(gridSizeInput);
        randomAttempts = 0;
        isDone = false;
        isReady = false;
        gridLimit = 20;
        if(gridBlock == null){
            gridBlock = Resources.Load("GridBlock.prefab") as GameObject;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Control for CreateGrid
        if(isReady){
            for(int i = 0; i <= gridLimit; i++){
                GameObject block = GameObject.Instantiate(gridBlock, blockSpawnPos, transform.rotation, gameObject.transform);
                Debug.Log(i);
                gridBlocks.Add(block);
                DistributeBlocks(gridBlocks,i);
                if(i >= gridLimit){
                    isDone = true;
                    isReady = false;
                }
            }
        }
    }

    public void CreateGrid()
    {
        if(isReady == false && isDone == false){
            isReady = true;
        }else isReady=false;
    }
    public void Reset()
    {
        gridBlocks = new List<GameObject>();
        isDone = false;
    }
    public void ChangeSize()
    {
        Debug.Log(gridSizeInput.GetComponent<TMP_InputField>().text);
        stringList.Add(gridSizeInput.GetComponent<TMP_InputField>().text);
        int size = 0;
        int[] numArr = new int[stringList.Count];
        for(int i = 0; i < stringList.Count; i++){ 
            numArr[i]=int.Parse(string.Join("",stringList[i]));
            size = numArr[i];
        }
        Debug.Log(size);
        gridLimit = size;
    }
    private void DistributeBlocks(List<GameObject> blockList, int index)
    {
        // Default first block to center
        if(index == 0){
            blockList[index].transform.position = new Vector3(0,0,0);
        }
        if(index > 0){
            // Parent Selection Scope Allows Randomized Path Generation
            // Can remove parent from statement and add functionality for squared grid
            blockList[index].transform.parent.position += (randomPosition())/2;
        }
    }
    private Vector3 randomPosition(){
        int x, y;
        x = Random.Range(-1,2);
        y = Random.Range(-1,2);
        if(x == 0 && y == 0 && randomAttempts <= 3){
            randomAttempts++;
            x = Random.Range(-1,2);
            y = Random.Range(-1,2);
        }else if(x == 0 && y == 0 && randomAttempts >= 3){
            // Current Default Spawn to Left - This would ideally be a gridcheck to see where blocks are condensed
            x = 1;
        }
        // Add Control for forcing vertical and horizontal placement only (Exclude diagonals)
        // If x&y != 0 random 1-2 if1thenx0 if2theny0
        return new Vector3(x,y,0);
    }
}
