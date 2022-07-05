using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellItem : ItemBase
{
    public override void Get()
    {
        float hp = FindObjectOfType<Player1controller>()._hp -= 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        objMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
