using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator2 : MonoBehaviour
{

    GameObject _player2;
    Rigidbody2D _rb;

    /// <summary>Arrow�̃_���[�W</summary>
    [SerializeField] float damage = 10;

    /// <summary>Arrow�̉E�����̑��x</summary>
    [SerializeField] Vector2 rightVelocity = new Vector2(10, 0);

    /// <summary>Arrow�̍������̑��x</summary>
    [SerializeField] Vector2 leftVelocity = new Vector2(-10, 0);

    /// <summary>�E���瓖���������̏Ռ�</summary>
    [SerializeField] int rightImpactPower = 1000;

    /// <summary> �E���瓖���������̏Ռ�</summary>
    [SerializeField] int leftImpactPower = -1000;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player2 = GameObject.FindGameObjectWithTag("Player2");

        if (_player2.transform.localScale.x == -1)
        {
            //�������̎��A������ς���
            transform.localScale = new Vector3(-1, 1, 1);
            _rb.velocity = rightVelocity;
        }
        else if(_player2.transform.localScale.x == 1)
        {
            _rb.velocity = leftVelocity;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ʊO�ɏo��������
        if (transform.position.x < -8 || transform.position.x > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = transform.localScale.x;

        if (collision.gameObject.tag == "Player1")
        {
            collision.gameObject.GetComponent<Player1controller>().Ondamage(damage);
            Destroy(gameObject);
            if (x > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * rightImpactPower);
            }
            else if (x < 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * leftImpactPower);

            }
        }
        

    }

}
