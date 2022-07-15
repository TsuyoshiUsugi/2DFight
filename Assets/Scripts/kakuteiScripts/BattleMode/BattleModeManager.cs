using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// バトルシーンを管理するコンポーネント
/// HP管理（対応中）
/// 時間管理（対応中）
/// 勝利判定と演出
/// </summary>
public class BattleModeManager : MonoBehaviour
{
    private static BattleModeManager instance = new BattleModeManager();

    public static BattleModeManager BMInstance { get => instance; }

    [Header("アイテム出現用")]
    /// <summary>アイテム生成するオブジェクト</summary>
    [SerializeField] GameObject _itemGenerator;

    /// <summary>いつアイテム生成オブジェクトを起動するか</summary>
    [SerializeField] int _setActiveItemGenerator;

    [Header("時間管理用")]
    /// <summary>経過時間を表示するテキスト</summary>
    [SerializeField] TextMeshProUGUI _timerText;

    /// <summary>試合の最大時間</summary>
    [SerializeField] float _totalTime;

    /// <summary>現在の時間</summary>
    [SerializeField] int _nowSecond;

    /// <summary> _nowSecondのプロパティ</summary>
    public int Second { get => _nowSecond; set => _nowSecond = value; }

    [Header("体力管理用")]
    float _player1Hp;
    float _player2Hp;

    [Header("演出用")]
    [SerializeField] TextMeshProUGUI playerWinText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip sound1;

    /// <summary>演出を表示するまでの時間</summary>
    [SerializeField] float _passedTime;

    /// <summary>戦闘が続いているかを判定する</summary>
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
    /// プレイヤー１が死んだらプレイヤー２を動けなくさせて勝利演出を行う
    /// </summary>
    public void Player1Die()
    {
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2controller>().isPlaying = false;
        StartCoroutine(P2Win());
    }

    /// <summary>
    /// プレイヤー２が死んだらプレイヤー１を動けなくさせて勝利演出を行う
    /// </summary>
    public void Player2Die()
    {
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1controller>().isPlaying = false;
        StartCoroutine(P1Win());
    }

    /// <summary>プレイヤー１が勝った時の演出</summary>
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

    /// <summary>プレイヤー２が勝った時の演出</summary>
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

    /// <summary>時間切れになった時の判定</summary>
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
    /// 時間を管理するコンポーネント
    /// </summary>
    void TimerCount()
    {
        //プレイ中なら
        if (isPlaying == true)
        {
            _totalTime -= Time.deltaTime;
            _nowSecond = (int)_totalTime;
            if (_nowSecond >= 0)
            {
                _timerText.text = _nowSecond.ToString();
            }
            //時間切れになったら判定用のメソッドを呼び出す
            else
            {
                Judge();
            }
        }
    }

    /// <summary>
    /// アイテム生成オブジェクトを起動するメソッド
    /// </summary>
    void SetActiveItemGenerator()
    {
        if (_nowSecond == _setActiveItemGenerator)
        {
            _itemGenerator.SetActive(true);
        }
    }
}
