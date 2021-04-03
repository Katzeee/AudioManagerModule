using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于存储每一个Clip
/// </summary>
public class ClipBase
{
    public AudioClip clip { get; private set; }
    public string name { get; private set; }

    public ClipBase(AudioClip tmpClip, string tmpName)
    {
        clip = tmpClip;
        name = tmpName;
    }

}
