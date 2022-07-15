using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1pの弓使い用の矢を放つコンポーネント
/// </summary>
public class ArrowGenerator : MonoBehaviour
{
    GameObject _player1;
    Rigidbody2D _rb;

    /// <summary>Arrowのダメージ</summary>
    [SerializeField] float _damage = 10;

    /// <summary>Arrowの速度</summary>
    [SerializeField] Vector2 _Velocity = new Vector2(10, 0);

    /// <summary> 当たった時の衝撃</summary>
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
            //左向きの時向きを変える
            transform.localScale = new Vector3(-1, 1, 1);
            _rb.velocity = -_Velocity;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //画面外の一定の距離を超えたら消す
        if (transform.position.x < -8 || transform.position.x > 2)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// プレイヤー２に当たった時のメソッド
    /// ダメージとノックバックを与える
    /// 何かに当たったら消す
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = transform.localScale.x;

        if (collision.gameObject.tag == "Player2")
        {
            //ダメージを与える
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
