using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    public GameObject[] clouds = new GameObject[3];
   

    public int cloudNumber;
    public float Interval = 6f;
    public float time;

    
    // Start is called before the first frame update
    static void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > Interval)
        {
            cloudNumber = Random.Range(1, 3);
            Instantiate(clouds[cloudNumber], new Vector3(10.32f, Random.Range(0, 4f)), Quaternion.identity);
            time = 0;
        }

      
    }
}
