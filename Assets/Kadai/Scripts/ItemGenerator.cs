using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージにアイテムを一つランダムで出現させるコンポーネント
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    /// <summary>出現させるアイテムのリスト</summary>
    [SerializeField] List<GameObject> ItemList = new List<GameObject>();
    private void Start()
    {
        Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
    }
}

