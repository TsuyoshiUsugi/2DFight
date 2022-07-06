using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ステージに出現するアイテムの共通クラス
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour
{
    /// <summary>取得時の効果音</summary>
    [Tooltip("取得時の効果音")]
    [SerializeField] AudioClip _sound = default;

    /// <summary>出現したアイテムの移動地点</summary>
    [Header("移動地点")]
    [SerializeField] Vector3[] route = { };

    public GameObject Player { get; set; }

    /// <summary>
    /// アイテムの発動効果を実装
    /// </summary>
    public abstract void Get();

    /// <summary>
    /// あたったプレイヤーに効果を発動する
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
    /// フィールドの指定の位置を行き来する
    /// </summary>
    public void objMove()
    {
        transform.DOPath(route,10f).SetLoops(-1, LoopType.Yoyo); ;
    }
    
}
