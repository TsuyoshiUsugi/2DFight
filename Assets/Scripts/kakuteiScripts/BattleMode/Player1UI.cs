using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player1UI : MonoBehaviour
{
    private GameObject _player1Object;    //Player1�I�u�W�F�N�g
    private Player1controller _player1Script;    //Player1�X�N���v�g

    //Player1��HP���
    
    private float _player1Hp;    //Player1�̗̑�
    private float _gageRateHp;    //�̗͂ƃQ�[�W�̃T�C�Y�̔�
    public RectTransform _rtHp;

    //Player1��MP���

    private float _player1Mp;
    private float _gageRateMp;
    private RectTransform _rtMp;

    /// <summary>bar���ω�����̂ɂ����鎞��</summary>
    [SerializeField] float _changeBarInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Player1�̏���ǂݎ��
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
    /// DoTween���g����MP�Q�[�W��ω�������֐�
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
