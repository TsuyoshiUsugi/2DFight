using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour
{
    [Tooltip("取得時の効果音")]
    [SerializeField] AudioClip _sound = default;
    GameObject _item;
    // Start is called before the first frame update
    void Start()
    {
        _item = this.gameObject;
        _item.transform.DOMove(new Vector3(-3.5f, -1f, 0) ,1);
        Debug.Log("aaa");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Get();

    //プレイヤーが当たったら効果を発動し消す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1"))
        {
          
            Get();
            AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
        
    }

    public void objMove()
    {
        
        //transform.DOMove(new Vector3(-3.5f, -1f, 0), 1);
        transform.DOPath(
            new Vector3[] { new Vector3(-3.5f, -1f, 0), new Vector3(-0.5f, -1f, 0), new Vector3(-6.18f, -1f, 0) },10f
            ).SetLoops(-1, LoopType.Yoyo);

    }
}
