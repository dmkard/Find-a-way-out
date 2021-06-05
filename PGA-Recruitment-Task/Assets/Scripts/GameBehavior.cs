using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public Transform wall;
    public List<Transform> wallCells;
    public GameObject doorFrame;
    public GameObject chest;
    public GameObject keycard;

    private bool _isGameOnPause = false;
    private bool _doorOpened;
    private bool _chestOpened;
    private bool _keyPicked;

    private void Start()
    {
        StartGame();
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        _doorOpened = false;
        _chestOpened = false;
        _keyPicked = false;
        InitialiseWallCells();
        RandomlyPlaceDoor();
        RandomlyPlaceChestAndKey();
    }

    public void InitialiseWallCells()
    {
        wallCells.Clear();
        foreach(Transform clild in wall)
        {
            wallCells.Add(clild);
        }
    }
    public void RandomlyPlaceDoor()
    {
        int randomIndex = Random.Range(0, wallCells.Count);
        Transform wallCellInfo = wallCells[randomIndex].transform;
        Destroy(wallCells[randomIndex].gameObject);
        Instantiate(doorFrame, wallCellInfo.position, wallCellInfo.rotation);
    }
    public void RandomlyPlaceChestAndKey()
    {
        bool hasCollision = true;
        
        for(int attempt = 0; attempt < 10 && hasCollision; attempt++)
        {
            Debug.Log(attempt);
            float x = Random.Range(7.5f, 7.5f);
            float z = Random.Range(7.5f, 7.5f);
            Vector3 spawnPosition = new Vector3(x, 0, z);
            Collider[] colliders = Physics.OverlapBox(spawnPosition, new Vector3(0.4f, 0.4f, 0.4f), Quaternion.identity, LayerMask.GetMask("Props"));

            hasCollision = false;
            foreach (Collider col in colliders)
            {
                if(col)
                {
                    hasCollision = true;
                    break;
                }
            }

            if(!hasCollision)
            {
                Instantiate(chest, new Vector3(4.5f, 0 , 4.5f), Quaternion.identity);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastRay(bool isMouseClickAction = false)
    {
         
    }


    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        _isGameOnPause = true;
    }

    public void UnpauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        _isGameOnPause = false;
    }

    public bool IsGameOnPause()
    {
        return _isGameOnPause;
    }
}
