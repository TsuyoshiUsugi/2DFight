using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] AudioClip _sound = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Items();

    private void OnTriggerEnter(Collider other)
    {
        if(_sound)
        {
            AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
        }
    }
}
