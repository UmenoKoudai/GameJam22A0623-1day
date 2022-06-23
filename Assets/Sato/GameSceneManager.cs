using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // /////////////////////////////////
    /* ゲーム本編のシーンマネージャー */
    // /////////////////////////////////

    [SerializeField] GameSceneUI _gameSceneUI;
    [SerializeField] Actor _player;
    [SerializeField] Actor _enemy;
    [SerializeField] GameObject _attackButton;
    [SerializeField] CountText _countText;
    // 攻撃が可能になるまでのカウント
    [SerializeField] int _count;
    // サウンドマネージャー
    SoundManager soundManager;

    void Awake()
    {
        soundManager = GetComponent<SoundManager>();
    }

    void Start()
    {
        soundManager.Play("SE_てろれろーん");
        _player._attack = Attack;
        _enemy._attack = Attack;
        _countText.SetCount(_count);
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(_gameSceneUI.ActivePenaltyPanel());
        }
    }

    // ゲーム開始からカウントを始める
    IEnumerator Timer()
    {
        for (int i = _count - 1; i >= 0; i--)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            _countText.SetCount(i);
        }
        _attackButton.SetActive(true);
        _enemy.enabled = true;
    }

    // 攻撃
    public IEnumerator Attack(bool isPlayer)
    {
        soundManager.Play("SE_斬撃");
        _player.StopCoroutine(_player._autoAction);
        _enemy.StopCoroutine(_enemy._autoAction);
        _attackButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        _gameSceneUI.ActiveResultItem(isPlayer);
        Debug.Log("攻撃しました");
    }
}
