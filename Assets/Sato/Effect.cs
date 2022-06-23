using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] float _lifeTime;

    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        
    }
}
