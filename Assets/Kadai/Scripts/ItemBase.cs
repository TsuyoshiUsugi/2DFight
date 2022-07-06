using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �X�e�[�W�ɏo������A�C�e���̋��ʃN���X
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour
{
    /// <summary>�擾���̌��ʉ�</summary>
    [Tooltip("�擾���̌��ʉ�")]
    [SerializeField] AudioClip _sound = default;

    /// <summary>�o�������A�C�e���̈ړ��n�_</summary>
    [Header("�ړ��n�_")]
    [SerializeField] Vector3[] route = { };

    public GameObject Player { get; set; }

    /// <summary>
    /// �A�C�e���̔������ʂ�����
    /// </summary>
    public abstract void Get();

    /// <summary>
    /// ���������v���C���[�Ɍ��ʂ𔭓�����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D _player)
    {
        Player = _player.gameObject;
        Get();
        AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// �t�B�[���h�̎w��̈ʒu���s��������
    /// </summary>
    public void objMove()
    {
        transform.DOPath(route,10f).SetLoops(-1, LoopType.Yoyo); ;
    }
    
}
