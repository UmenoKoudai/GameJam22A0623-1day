using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    // ///////////////////////
    /* カウントするテキスト */
    // ///////////////////////

    Text text;
    // カウントがこれになったら隠す
    int _invisibleCount;
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        
    }

    // カウントの更新、
    public void SetCount(int count)
    {
        text.text = count.ToString();
    }
}
