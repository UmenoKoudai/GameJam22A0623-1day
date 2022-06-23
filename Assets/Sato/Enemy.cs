using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // /////////////////////////
    /* 敵さんのコントローラー */
    // /////////////////////////

    // 0になってから攻撃するまでのウェイト
    [SerializeField] float _wait;

    public delegate void Attack(bool b);
    public Attack _attack;

    void Start()
    {
        StartCoroutine(Action());
    }

    void Update()
    {
        
    }

    // 指定された秒後に攻撃する
    IEnumerator Action()
    {
        yield return new WaitForSecondsRealtime(_wait);
        _attack.Invoke(false);
    }
}
