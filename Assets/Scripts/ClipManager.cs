using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ClipManager
{

    private string[] clipNames;//clip的名字
    private List<ClipBase> clips;//所有clip文件，采用clip类存储

    public ClipManager()
    {
        ReadConfig();
        LoadClips();
    }

    /// <summary>
    /// 读取配置文件
    /// </summary>
    public void ReadConfig()
    {
        var fileAddress = System.IO.Path.Combine(Application.streamingAssetsPath, "ClipsConfig.txt");
        FileInfo fileInfo = new FileInfo(fileAddress);
        // string s = "";
        if(fileInfo.Exists)
        {
            StreamReader r = new StreamReader(fileAddress);
            string tmpLine = r.ReadLine();
            //Debug.Log(tmpLine);
            if (int.TryParse(tmpLine,out int lineCount))
            {
                clipNames = new string[lineCount];
                //clipPaths = new
                for (int i = 0; i < lineCount; i++)
                {
                    tmpLine = r.ReadLine();
                    clipNames[i] = tmpLine.Split(' ')[0];//存名字，不包含拓展名
                }
            }
            else
            {
                return;
            }
        }
        //Debug.Log(clipNames[0]);
    }

    /// <summary>
    /// 按照配置文件加载Clips
    /// </summary>
    public void LoadClips()
    {
        clips = new List<ClipBase>();
        for (int i = 0; i < clipNames.Length; i++)
        {
            ClipBase tmpClip;
            AudioClip tmpAudioClip = Resources.Load<AudioClip>(clipNames[i]);
            tmpClip = new ClipBase(tmpAudioClip, clipNames[i]);//加载AudioClip时不需要拓展名
            clips.Add(tmpClip);
        }
        //Debug.Log(clips[0].name);
    }


    /// <summary>
    /// 根据名字找到Clip
    /// </summary>
    /// <param name="clipNameToBeFound">需要被播放的Clip名</param>
    /// <returns>返回对应ClipBase类</returns>
    public ClipBase FindClipByName(string clipNameToBeFound)
    {
        for (int i = 0; i < clips.Count; i++)
        {
            if(clips[i].name.Equals(clipNameToBeFound))
            {
                return clips[i];
            }
        }
        return null;
    }
}
