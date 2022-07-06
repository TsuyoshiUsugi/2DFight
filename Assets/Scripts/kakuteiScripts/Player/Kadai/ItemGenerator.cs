using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 30秒経過時にステージにアイテムを一つランダムで出現させるコンポーネント
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    /// <summary>出現させるアイテムのリスト</summary>
    [SerializeField] List<GameObject> ItemList = new List<GameObject>();

    void Update()
    {
        if (TimerScript.second == 30 && FindObjectOfType<ItemBase>() == null)
        {
            Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
        }
    }      
}
