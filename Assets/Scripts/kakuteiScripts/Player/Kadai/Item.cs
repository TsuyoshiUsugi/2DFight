using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Item : MonoBehaviour
{
    [Tooltip("取得時の効果音")]
    [SerializeField] AudioClip _sound = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Get();

    //プレイヤーが当たったら効果を発動し、消す
    private void OnTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("")
        {
            if (_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }
        
    }
}
