using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    private Animation _animation;

    // Start is called before the first frame update
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
