using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [Header("ˆÚ“®‚µ‚½‚¢ƒV[ƒ“–¼‚ğ“ü—Í")] [SerializeField] string _sceneName;
    public void ChangeScene()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(_sceneName);
    }

    public void Audio()
    {
        StartCoroutine(Enumerator());

        IEnumerator Enumerator()
        {
            yield return new WaitForSeconds(1.0f);
            ChangeScene();
        }
    }
}