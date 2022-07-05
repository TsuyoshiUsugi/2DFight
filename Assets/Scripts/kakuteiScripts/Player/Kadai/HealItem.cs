using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    public override void Get()
    {
        
        float hp = FindObjectOfType<Player1controller>()._hp;
        hp += 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
