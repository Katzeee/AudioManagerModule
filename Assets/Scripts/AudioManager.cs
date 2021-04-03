using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    SourceManager sourceManager;
    GameObject AudioManagerObject;


    ClipManager clipManager;


    /// <summary>
    /// 根据名字播放音乐
    /// </summary>
    /// <param name="nameToBePlayed">需要被播放的音乐名</param>
    public void Play(string nameToBePlayed)
    {
        AudioSource tmpSource = sourceManager.GetFreeAudioSource();
        ClipBase tmpClipBase = clipManager.FindClipByName(nameToBePlayed);

        tmpSource.clip = tmpClipBase.clip;
        tmpSource.Play();

    }

    /// <summary>
    /// 根据名字停止播放音乐
    /// </summary>
    /// <param name="nameToBeStopped">需要被停止播放的音乐名</param>
    public void Stop(string nameToBeStopped)
    {
        for (int i = 0; i < sourceManager.allSources.Count; i++)
        {
            if (sourceManager.allSources[i].isPlaying && sourceManager.allSources[i].clip.name.Equals(nameToBeStopped))
            {
                sourceManager.allSources[i].Stop();
                return;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManagerObject = new GameObject();
        AudioManagerObject.name = "AudioSourceManager";
        sourceManager = new SourceManager(AudioManagerObject);

        clipManager = new ClipManager();
    }

}
