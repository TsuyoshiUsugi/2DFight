using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Item : MonoBehaviour
{
    [Tooltip("�擾���̌��ʉ�")]
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

    //�v���C���[��������������ʂ𔭓����A����
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
