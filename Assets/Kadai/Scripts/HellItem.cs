using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当たったらHPが減るアイテム
/// </summary>
public class HellItem : ItemBase
{
    /// <summary>ダメージの値</summary>
    [SerializeField] float damagePoint = 20;

    public override void Get()
    {
        if (Player.CompareTag("Player1"))
        {
            Player.GetComponent<Player1controller>().Hp -= damagePoint;
        }
        else 
        {
            Player.GetComponent<Player2controller>().Hp -= damagePoint;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objMove();
    }
}
