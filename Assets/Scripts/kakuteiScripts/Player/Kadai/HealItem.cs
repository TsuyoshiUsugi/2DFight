using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当たったらHPが回復するアイテム
/// </summary>
public class HealItem : ItemBase
{
    /// <summary>回復の値</summary>
    [SerializeField] float HealPoint = 20;

    public override void Get()
    {
        if (Player.CompareTag("Player1"))
        {
            Player.GetComponent<Player1controller>().Hp += HealPoint;
        }
        else
        {
            Player.GetComponent<Player2controller>().Hp += HealPoint;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objMove();
    }
}
