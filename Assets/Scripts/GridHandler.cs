using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridHandler : MonoBehaviour
{
    private float loadTime;
    public GameObject debugText;
    private GameObject gridBlock;
    List<GameObject> gridBlocks;
    List<string> stringList;
    List<Vector3> positionList;
    private int gridSize, gridLimit, gridMinimum, randomAttempts;
    private Vector3 blockSpawnPos;
    private bool isReady, isDone;
    public GameObject gridSizeInput;
    // Start is called before the first frame update
    void Awake(){
        gridBlock = Resources.Load("GridBlock") as GameObject;
        gridBlocks = new List<GameObject>();
        stringList = new List<string>();
        positionList = new List<Vector3>();
    }
    void Start()
    { 
        loadTime=0;
        //Debug.Log(gridSizeInput);
        randomAttempts = 0;
        isDone = false;
        isReady = false;
        gridLimit = 0;
        if(gridBlock == null){
            gridBlock = Resources.Load("GridBlock.prefab") as GameObject;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Control for CreateGrid
        if(isReady){
            loadTime += Time.deltaTime;
            for(int i = 0; i <= gridLimit; i++){
                GameObject block = GameObject.Instantiate(gridBlock, blockSpawnPos, transform.rotation, gameObject.transform);
                Debug.Log(i);
                gridBlocks.Add(block);
                DistributeBlocks(gridBlocks,i);
                if(i >= gridLimit){
                    //Debug.Log("Load Time:" + loadTime +"s");
                    //debugText.GetComponent<Text>().text = positionList[i].ToString();
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
        stringList.Clear();
        gridBlocks.Clear();
        gridLimit = 0;
        //gridBlocks = new List<GameObject>();
        isDone = false;
        gridSizeInput.GetComponent<TMP_InputField>().text= "";
    }
    public void ChangeSize()
    {
       //Debug.Log(gridSizeInput.GetComponent<TMP_InputField>().text);
        stringList.Add(gridSizeInput.GetComponent<TMP_InputField>().text);
        int size = 0;
        int[] numArr = new int[stringList.Count];
        for(int i = 0; i < stringList.Count; i++){ 
            numArr[i]=int.Parse(string.Join("",stringList[i]));
            size = numArr[i];
        }
        //Debug.Log(size);
        gridLimit = size;
    }
    private void DistributeBlocks(List<GameObject> blockList, int index)
    {
        // Default first block to center
        if(index == 0){
            blockList[index].transform.position = new Vector3(0,0,0);
            positionList.Add(blockList[index].transform.parent.position);
            
        }
        if(index > 0){
            // Set random block position as modifier for Grid Handler
            Vector3 blockPos = randomPosition();
            // Loop through block list and compare block positions to v3 list positions
            for(int i = 0; i < index; i++){
                foreach(Vector3 v3 in positionList){
                    // If would be overlapping - Do something
                    if(blockList[index].transform.parent.position + blockPos == v3){
                        bool isOverlap = true;
                        // Reset Position to prevent overlap
                        Debug.Log("Overlap Occurred - Repositioning");         
                        do{
                            blockPos = randomPosition();
                            if(blockList[index].transform.parent.position + blockPos != v3){
                                isOverlap = false;
                            }
                            }while(isOverlap);
                    } else if(blockList[index].transform.parent.position + blockPos != v3){
                        // If position not taken move handler
                        Debug.Log("No Overlap - Tile Placed");
                    } 
                }
             }
            // Setting sta after loop for each block
            blockList[index].transform.parent.position += (blockPos);
            blockList[index].GetComponent<GridBlock>().setRotation(blockPos);
            positionList.Add(blockList[index].transform.parent.position); 
              
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
        if(x != 0 && y != 0){
            int shuffle = Random.Range(1,3);
            if(shuffle == 1){
                x = 0;
            } else if(shuffle == 2){
                y=0;
            }
        }
        
        return new Vector3(x,y,0);
    }
}
