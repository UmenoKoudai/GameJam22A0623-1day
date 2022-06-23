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
    [SerializeField] GameObject _slashEff;
    [SerializeField] bool _isPlayer;

    public delegate IEnumerator Attack(bool b);
    public Attack _attack;

    public Coroutine _autoAction;

    void Start()
    {
        _autoAction = StartCoroutine(AutoAction());
    }

    void Update()
    {

    }

    public void Action()
    {
        StartCoroutine(_attack.Invoke(_isPlayer));
        _stand.SetActive(false);
        _attacked.SetActive(true);
        Vector3 pos = transform.position;
        int dir = _isPlayer == true ? 1 : -1;
        Instantiate(_slashEff, new Vector3(pos.x + (3.5f * dir), pos.y, pos.z), Quaternion.identity);;
    }

    // 指定された秒後に攻撃する
    IEnumerator AutoAction()
    {
        yield return new WaitForSecondsRealtime(_wait);
        Action();
    }
}
