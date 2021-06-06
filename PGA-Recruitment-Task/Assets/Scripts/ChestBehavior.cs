using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    private Animation _animation;

    void Start()
    {
        this.gameObject.name = "Chest";
        _animation = gameObject.GetComponent<Animation>();
    }

    public void OpenChest()
    {
        _animation.Play("Crate_Open");
        gameObject.layer = 2;
    }
}
