using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player1UI : MonoBehaviour
{
    private GameObject _player1Object;    //Player1オブジェクト
    private Player1controller _player1Script;    //Player1スクリプト

    //Player1のHP情報
    
    private float _player1Hp;    //Player1の体力
    private float _gageRateHp;    //体力とゲージのサイズの比
    public RectTransform _rtHp;

    //Player1のMP情報

    private float _player1Mp;
    private float _gageRateMp;
    private RectTransform _rtMp;

    /// <summary>barが変化するのにかかる時間</summary>
    [SerializeField] float _changeBarInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Player1の情報を読み取る
        _player1Object = GameObject.FindGameObjectWithTag("Player1");
        _player1Script = _player1Object.GetComponent<Player1controller>();
        _rtHp = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        _rtMp = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        _player1Hp = _player1Script.Hp;
        _gageRateHp = _rtHp.sizeDelta.x / _player1Hp;

        _player1Mp = _player1Script.Mp;
        _gageRateMp = _rtMp.sizeDelta.x / _player1Mp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rtHp.sizeDelta.x <= 0)
        {
            GameObject.Find("BattleModeManager").GetComponent<BattleModeManager>().Player1Die();
        }
        ReadHp();
    }

    void ReadHp()
    {

        _player1Hp = _player1Object.GetComponent<Player1controller>().Hp;
        _rtHp.sizeDelta = new Vector2(_player1Hp * _gageRateHp, _rtHp.sizeDelta.y);
    }

    /// <summary>
    /// DoTweenを使ったMPゲージを変化させる関数
    /// </summary>
    /// <param name="mp"></param>
    public void ReadMp(float mp)
    {
        //rtMp.sizeDelta = new Vector2((mp * gageRateMp), rtMp.sizeDelta.y);
        DOTween.To(() => _player1Mp,
            x => _player1Mp = x,
            mp,
            1f)
            .OnUpdate(() => _rtMp.sizeDelta = new Vector2((_player1Mp * _gageRateMp), _rtMp.sizeDelta.y));
    }
}
