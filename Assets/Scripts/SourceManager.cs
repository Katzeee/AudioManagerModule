using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager
{
    /// <summary>
    /// 初始化时创建多少Source
    /// </summary>
    int audioSourceCount;
    /// <summary>
    /// 保存所有AudioSource
    /// </summary>
    public List<AudioSource> allSources { get; private set; }
    /// <summary>
    /// 将所有的AudioScource挂载到该obj上
    /// </summary>
    GameObject obj;

    /// <summary>
    /// 构造函数，默认创建三个AudioSource
    /// </summary>
    /// <param name="gameObject">将AudioSource挂载到哪个GameObject上</param>
    public SourceManager(GameObject gameObject)
    {
        audioSourceCount = 3;
        obj = gameObject;
        Init();
    }
    /// <summary>
    /// 初始化，创建audioSourceCount个AudioSource
    /// </summary>
    private void Init()
    {
        allSources = new List<AudioSource>(audioSourceCount);
        for (int i = 0; i < audioSourceCount; i++)
        {
            AudioSource tmpAuodioSource;
            tmpAuodioSource = obj.AddComponent<AudioSource>();
            allSources.Add(tmpAuodioSource);
        }
    }

    /// <summary>
    /// 获取一个AudioSource
    /// </summary>
    /// <returns>返回一个空闲的AudioSource</returns>
    public AudioSource GetFreeAudioSource()
    {
        for (int i = 0; i < allSources.Count; i++) 
        {
            if (!allSources[i].isPlaying)
            {
                //Debug.Log("返回成功");
                return allSources[i];
            }
        }
        AudioSource tmpAuodioSource;
        tmpAuodioSource = obj.AddComponent<AudioSource>();
        allSources.Add(tmpAuodioSource);
        return tmpAuodioSource;
    }

    /// <summary>
    /// 当AudioSource多于三个的时候释放多余的
    /// </summary>
    public void ReleaseAudioSource()
    {
        List<AudioSource> toBeReleased = new List<AudioSource>();
        for (int i = 2; i < allSources.Count; i++)
        {
            if (!allSources[i].isPlaying)
            {
                toBeReleased.Add(allSources[i]);
            }
        }
        foreach(AudioSource tmp in toBeReleased)
        {
            if(!tmp.isPlaying)
            {
                allSources.Remove(tmp);
                GameObject.Destroy(tmp);
            }
        }
        toBeReleased.Clear();
        toBeReleased = null;//防止有未被清空的，释放空间
    }

}
