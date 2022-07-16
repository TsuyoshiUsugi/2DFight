using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成された弓の挙動のコンポーネント
/// </summary>
public class Arrow : MonoBehaviour
{
    [Header("参照")]
    GameObject _player1;
    Rigidbody2D _rb;

    /// <summary>Arrowのダメージ</summary>
    [SerializeField] float _damage = 10;

    /// <summary>Arrowの速度</summary>
    [SerializeField] Vector2 _Velocity = new Vector2(10, 0);

    /// <summary> 当たった時の衝撃</summary>
    [SerializeField] int _impactPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
