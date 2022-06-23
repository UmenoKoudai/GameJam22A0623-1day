using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ///////////////////////
    /* サウンドマネージャー */
    // ///////////////////////

    [Serializable]
    public class SoundData
    {
        public string key;
        public AudioClip audioClip;
        public float volume;
    }

    [SerializeField] SoundData[] _soundDatas;
    [SerializeField] float _distance;
    
    float _lastTime;
    AudioSource[] _audioSources = new AudioSource[3];
    Dictionary<string, SoundData> _soundDic = new Dictionary<string, SoundData>();

    void Awake()
    {
        for(int i = 0; i < _audioSources.Length; ++i)
            _audioSources[i] = gameObject.AddComponent<AudioSource>();

        foreach (SoundData sd in _soundDatas)
            _soundDic.Add(sd.key, sd);
    }

    AudioSource GetAudioSource()
    {
        for (int i = 0; i < _audioSources.Length; ++i)
            if (_audioSources[i].isPlaying == false) return _audioSources[i];
        return null;
    }

    public void Play(AudioClip clip, float volume)
    {
        AudioSource source = GetAudioSource();
        if(source == null)
        {
            Debug.LogWarning(clip.name + "は再生できませんでした。空きがないよ！");
            return;
        }
        source.volume = volume;
        source.clip = clip;
        source.Play();
    }

    public void Play(string key)
    {
        if (_soundDic.TryGetValue(key, out SoundData soundData))
        {
            if (Time.realtimeSinceStartup < _distance) return;
            _lastTime = Time.realtimeSinceStartup;
            Play(soundData.audioClip, soundData.volume);
        }
        else Debug.LogWarning("登録されていません" + key);
    }
}
