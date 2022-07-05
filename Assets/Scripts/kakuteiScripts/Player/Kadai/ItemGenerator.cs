using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] TimerScript time;
    [SerializeField] List<GameObject> ItemList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (time.second < 30)
        {
            Instantiate(ItemList[Random.Range(0, ItemList.Count)]);         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
