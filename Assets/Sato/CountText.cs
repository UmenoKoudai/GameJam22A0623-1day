using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void hoge()
    {
        SceneManager.load
    }
}
