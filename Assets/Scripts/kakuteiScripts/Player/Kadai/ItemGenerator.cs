using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 30�b�o�ߎ��ɃX�e�[�W�ɃA�C�e����������_���ŏo��������R���|�[�l���g
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    /// <summary>�o��������A�C�e���̃��X�g</summary>
    [SerializeField] List<GameObject> ItemList = new List<GameObject>();

    void Update()
    {
        if (TimerScript.second == 30 && FindObjectOfType<ItemBase>() == null)
        {
            Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
        }
    }      
}
