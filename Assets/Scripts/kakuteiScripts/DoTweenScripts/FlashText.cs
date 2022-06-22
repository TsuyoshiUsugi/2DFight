using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FlashText : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        //text = this.gameObject.GetComponent<Text>();
        text.DOColor(Color.clear, 2f).SetEase(Ease.OutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
