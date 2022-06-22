using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMove(new Vector3(5f, 0f, 0f), 3f).SetEase(Ease.InOutBounce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
