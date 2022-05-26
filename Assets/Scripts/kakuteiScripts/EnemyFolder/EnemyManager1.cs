using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager1 : MonoBehaviour
{
    public static EnemyManager1 instance;

    //�U���́A�̗́A�ړ��X�s�[�h���i�[����ϐ���p��
    int at = 20;
    public float hp = 200;
    public float moveSpeed;

    //�A�j���[�V�����̎擾
    Animator animator;

    //p�v���C���[�̃I�u�W�F�N�g�ƈʒu���i�[����ϐ���p��
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;

    //�����蔻����i�[����ϐ���p��
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask playerLayer;

    private float attackInterval = 1.5f;
    private float passedTime = -2f;

    Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerObject = GameObject.FindWithTag("Player");
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        GameObject.Find("GameManager").GetComponent<GameManage>().enemyCount++;

    }

    void Update()
    {
        passedTime += Time.deltaTime;

        if (0.5 > PlayerPosition.x - EnemyPosition.x && passedTime > attackInterval && hp != 0)
        {
            //InvokeRepeating("Attack", 2, 5);
            Attack();
            passedTime = 0;
        }
        else if (0.5 > EnemyPosition.x - PlayerPosition.x && passedTime > attackInterval && hp != 0)
        {
            //InvokeRepeating("Attack", 2, 5);
            Attack();
            passedTime = 0;
        }
    }

    void FixedUpdate()
    {


        //float hp = enemyScript.hp;
        //float hp = this.GameObject.GetComponent<EnemyManager>().hp;


        float x = 0;

        playerObject = GameObject.FindWithTag("Player");
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

        if (PlayerPosition.x - 0.5f > EnemyPosition.x && hp > 0)
        {
            x = 1;

            this.rb.AddForce(transform.right * moveSpeed);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("speed", Mathf.Abs(x));



        }
        else if (PlayerPosition.x < EnemyPosition.x - 0.5f && hp > 0)
        {
            x = 1;

            this.rb.AddForce(transform.right * (-moveSpeed));
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("speed", Mathf.Abs(x));
        }
        else
        {
            x = 0;
            animator.SetFloat("speed", Mathf.Abs(x));
        }


    }

    void Attack()
    {
        if (hp! >= 0)
        {

            animator.SetTrigger("isAttack");
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
            foreach (Collider2D hitplayer in hitPlayer)
            {
                Debug.Log(hitplayer.gameObject.name + "�ɍU��");
                hitplayer.GetComponent<PlayerManager>().OnDamage(at);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void OnDamage(float damage)
    {

        hp -= damage;
        animator.SetTrigger("IsHurt");

        if (hp == 0)
        {
            Die();
        }
    }

    void Die()
    {

        animator.SetTrigger("Die");
        if (hp! <= 0)
            GameObject.Find("GameManager").GetComponent<GameManage>().enemyCount--;

    }

}

