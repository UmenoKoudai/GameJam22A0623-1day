using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // ///////////////////////
    /* 役者のコントローラー */
    // ///////////////////////

    // 0になってから攻撃するまでのウェイト
    [SerializeField] float _wait;
    [SerializeField] GameObject _stand;
    [SerializeField] GameObject _attacked;
    [SerializeField] bool _isPlayer;

    public delegate void Attack(bool b);
    public Attack _attack;

    void Start()
    {
        StartCoroutine(AutoAction());
    }

    void Update()
    {

    }

    public void Action()
    {
        _attack.Invoke(_isPlayer);
        _stand.SetActive(false);
        _attacked.SetActive(true);
    }

    // 指定された秒後に攻撃する
    IEnumerator AutoAction()
    {
        yield return new WaitForSecondsRealtime(_wait);
        Action();
    }
}
