using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������ꂽ�|�̋����̃R���|�[�l���g
/// </summary>
public class Arrow : MonoBehaviour
{
    [Header("�Q��")]
    GameObject _player1;
    Rigidbody2D _rb;

    /// <summary>Arrow�̃_���[�W</summary>
    [SerializeField] float _damage = 10;

    /// <summary>Arrow�̑��x</summary>
    [SerializeField] Vector2 _Velocity = new Vector2(10, 0);

    /// <summary> �����������̏Ռ�</summary>
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
