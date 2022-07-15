using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharaSelectText : MonoBehaviour
{
    [SerializeField] Text _underText;
    [SerializeField] Text _forPadText;
    [SerializeField] bool pcText = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            pcText = true;
        }
      �@ // else if (Input.)
        //_forPadText.text = "A D�����@���ŃL�����ύX�@�@�@SPACE�{�^�����o�b�N�X���b�V���Ō���/�L�����Z��";
    }

    void displayPCText()
    {
        _underText.DOColor(Color.clear, 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    void displayPadText()
    {

    }
}
