using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [Header("�X�e�[�^�X")]
    public float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        
    }

    //�U���A�j���[�V����������
    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("isAttack");
            Debug.Log("Attack");
        }
    }

    //�����蔻���on�ɂ���
    void AttackDamage()
    {
        
    }
}
