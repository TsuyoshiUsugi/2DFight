using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public static HeroManager instance;

    //�U���́A�̗́A�ړ��X�s�[�h���i�[����ϐ���p��
    int at = 20;
    public float hp = 200;
    public float moveSpeed;

    //�A�j���[�V�����̎擾
    Animator animator;

    //p�v���C���[�̃I�u�W�F�N�g�ƈʒu���i�[����ϐ���p��
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 HeroPosition;

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
        //�A�j���[�V�����̎擾
        animator = GetComponent<Animator>();

        //�v���C���[�I�u�W�F�N�g�̎擾�A�v���C���[�|�W�V�����̎擾
        playerObject = GameObject.FindWithTag("Player");
        PlayerPosition = playerObject.transform.position;
        HeroPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        GameObject.Find("GameManager").GetComponent<GameManage>().enemyCount++;

        //this.rb.AddForce(transform.right * (-moveSpeed))
    }

    void Update()
    {
        passedTime += Time.deltaTime;

        if (0.5 > PlayerPosition.x - HeroPosition.x && passedTime > attackInterval && hp != 0)
        {
            //InvokeRepeating("Attack", 2, 5);
            Attack();
            passedTime = 0;
        }
        else if (0.5 > HeroPosition.x - PlayerPosition.x && passedTime > attackInterval && hp != 0)
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
        HeroPosition = transform.position;

        if (PlayerPosition.x - 0.5f > HeroPosition.x && hp > 0)
        {
            x = 1;

            //this.rb.AddForce(transform.right * moveSpeed);
            rb.velocity = new Vector2(moveSpeed, 0f);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("speed", Mathf.Abs(x));



        }
        else if (PlayerPosition.x < HeroPosition.x - 0.5f && hp > 0)
        {
            x = 1;

            //this.rb.AddForce(transform.right * (-moveSpeed));
            rb.velocity = new Vector2(- 1 * moveSpeed, 0f);
            transform.localScale = new Vector3(-1, 1, 1);
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


