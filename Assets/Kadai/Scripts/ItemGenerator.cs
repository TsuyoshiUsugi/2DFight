using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�W�ɃA�C�e����������_���ŏo��������R���|�[�l���g
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    /// <summary>�o��������A�C�e���̃��X�g</summary>
    [SerializeField] List<GameObject> ItemList = new List<GameObject>();
    private void Start()
    {
        Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
    }
}

