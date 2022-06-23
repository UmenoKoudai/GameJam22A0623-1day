using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] GameObject _winLogo;
    [SerializeField] GameObject _loseLogo;
    [SerializeField] GameObject _resultItem;
    [SerializeField] GameObject _PenaltyPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator ActivePenaltyPanel()
    {
        yield return null;
        _PenaltyPanel.SetActive(true);
    }

    public void ActiveResultItem(bool isPlayer)
    {
        GameObject logo = isPlayer == true ? _winLogo : _loseLogo;
        logo.SetActive(true);
        _resultItem.SetActive(true);
    }
}
