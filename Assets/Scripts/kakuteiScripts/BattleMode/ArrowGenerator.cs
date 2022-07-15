using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1p�̋|�g���p�̖����R���|�[�l���g
/// </summary>
public class ArrowGenerator : MonoBehaviour
{
    GameObject _player1;
    Rigidbody2D _rb;

    /// <summary>Arrow�̃_���[�W</summary>
    [SerializeField] float _damage = 10;

    /// <summary>Arrow�̑��x</summary>
    [SerializeField] Vector2 _Velocity = new Vector2(10, 0);

    /// <summary> �����������̏Ռ�</summary>
    [SerializeField] int _impactPower = 1000;


    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _rb = GetComponent<Rigidbody2D>();

        if (_player1.transform.localScale.x == 1)
        {
            _rb.velocity = _Velocity;
        }
        else if(_player1.transform.localScale.x == -1)
        {
            //�������̎�������ς���
            transform.localScale = new Vector3(-1, 1, 1);
            _rb.velocity = -_Velocity;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ʊO�̈��̋����𒴂��������
        if (transform.position.x < -8 || transform.position.x > 2)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �v���C���[�Q�ɓ����������̃��\�b�h
    /// �_���[�W�ƃm�b�N�o�b�N��^����
    /// �����ɓ������������
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = transform.localScale.x;

        if (collision.gameObject.tag == "Player2")
        {
            //�_���[�W��^����
            collision.gameObject.GetComponent<Player2controller>().Ondamage(_damage);

            if (x > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * _impactPower);
            }
            else if (x < 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * _impactPower);
            }
            Destroy(gameObject);
        }
        

    }

}
