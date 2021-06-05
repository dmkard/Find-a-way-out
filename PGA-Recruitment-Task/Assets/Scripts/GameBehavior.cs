using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public Transform wall;
    public List<Transform> wallCells;

    private bool _isGameOnPause;
    private bool _doorOpened;
    private bool _chestOpened;
    private bool _keyPicked;

    // Start is called before the first frame update
    public void StartGame()
    {
        _doorOpened = false;
        _chestOpened = false;
        _keyPicked = false;
        InitialiseWallCells();
        RandomlyPlaceDoor();

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
