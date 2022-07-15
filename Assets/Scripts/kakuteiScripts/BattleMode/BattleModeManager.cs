using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// �o�g���V�[�����Ǘ�����R���|�[�l���g
/// HP�Ǘ��i�Ή����j
/// ���ԊǗ��i�Ή����j
/// ��������Ɖ��o
/// </summary>
public class BattleModeManager : MonoBehaviour
{
    private static BattleModeManager instance = new BattleModeManager();

    public static BattleModeManager BMInstance { get => instance; }

    [Header("�A�C�e���o���p")]
    /// <summary>�A�C�e����������I�u�W�F�N�g</summary>
    [SerializeField] GameObject _itemGenerator;

    /// <summary>���A�C�e�������I�u�W�F�N�g���N�����邩</summary>
    [SerializeField] int _setActiveItemGenerator;

    [Header("���ԊǗ��p")]
    /// <summary>�o�ߎ��Ԃ�\������e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _timerText;

    /// <summary>�����̍ő厞��</summary>
    [SerializeField] float _totalTime;

    /// <summary>���݂̎���</summary>
    [SerializeField] int _nowSecond;

    /// <summary> _nowSecond�̃v���p�e�B</summary>
    public int Second { get => _nowSecond; set => _nowSecond = value; }

    [Header("�̗͊Ǘ��p")]
    float _player1Hp;
    float _player2Hp;

    [Header("���o�p")]
    [SerializeField] TextMeshProUGUI playerWinText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound1;

    /// <summary>���o��\������܂ł̎���</summary>
    [SerializeField] float _passedTime;

    /// <summary>�퓬�������Ă��邩�𔻒肷��</summary>
    public bool isPlaying = false;

    private void Awake()
    {
        isPlaying = true;
    }

    private void Update()
    {
        TimerCount();

        SetActiveItemGenerator();
    }
    /// <summary>
    /// �v���C���[�P�����񂾂�v���C���[�Q�𓮂��Ȃ������ď������o���s��
    /// </summary>
    public void Player1Die()
    {
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;
        StartCoroutine(P2Win());
    }

    /// <summary>
    /// �v���C���[�Q�����񂾂�v���C���[�P�𓮂��Ȃ������ď������o���s��
    /// </summary>
    public void Player2Die()
    {
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;
        StartCoroutine(P1Win());
    }

    /// <summary>�v���C���[�P�����������̉��o</summary>
    IEnumerator P1Win()
    {
        yield return new WaitForSeconds(_passedTime);
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            audioSource.PlayOneShot(sound1);
            isPlaying = false;
        }
        yield return new WaitForSeconds(_passedTime);
        GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
    }

    /// <summary>�v���C���[�Q�����������̉��o</summary>
    IEnumerator P2Win()
    {
        yield return new WaitForSeconds(_passedTime);
        if (isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            audioSource.PlayOneShot(sound1);
            isPlaying = false;
        }
        yield return new WaitForSeconds(_passedTime);
        GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
    }

    /// <summary>���Ԑ؂�ɂȂ������̔���</summary>
    public void Judge()
    {
        if (isPlaying == true)
        {
            _player1Hp = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().Hp;
            _player2Hp = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().Hp;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;
        }

        if (_player1Hp > _player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER1 WIN!";
            isPlaying = false;
            GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
        }
        else if (_player1Hp < _player2Hp && isPlaying == true)
        {
            playerWinText.text = "PLAYER2 WIN!";
            isPlaying = false;
            GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
        }
        else
        {
            if (isPlaying == true)
            {
                playerWinText.text = "DRAW GAME";
                isPlaying = false;
                GameObject.Find("Buttons").GetComponent<SelectButton2>().isPlaying = false;
            }
        }
    }

    /// <summary>
    /// ���Ԃ��Ǘ�����R���|�[�l���g
    /// </summary>
    void TimerCount()
    {
        //�v���C���Ȃ�
        if (isPlaying == true)
        {
            _totalTime -= Time.deltaTime;
            _nowSecond = (int)_totalTime;
            if (_nowSecond >= 0)
            {
                _timerText.text = _nowSecond.ToString();
            }
            //���Ԑ؂�ɂȂ����画��p�̃��\�b�h���Ăяo��
            else
            {
                Judge();
            }
        }
    }

    /// <summary>
    /// �A�C�e�������I�u�W�F�N�g���N�����郁�\�b�h
    /// </summary>
    void SetActiveItemGenerator()
    {
        if (_nowSecond == _setActiveItemGenerator)
        {
            _itemGenerator.SetActive(true);
        }
    }
}
