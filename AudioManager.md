# AudioManager

## 介绍

实现对音频控件的统一管理

---

##结构

- AudioManager：总管理器
  - SourceManager：播放源管理器
  - ClipManager：音源管理器

---

##脚本

- ClipBase：用于存储每一个Clip
  - Attributes：
    - clip：存储音源
    - name：存储名字
  - Methods：
    - 构造函数



- ClipManager：实现对Clip的统一管理
  - Attributes：
    - clipNames：配置文件中读取的名字
    - clips：统一管理的clips
  - Methods：
    - ReadConfig：实现从配置文件中读取需要进行管理的Clip
    - LoadClips：根据上面读取的对Clip进行Load，并保存在ClipBase中
    - FindClipByName：返回一个ClipBase
    - 构造函数：进行初始化



- SourceManager：实现对AudioSource的统一管理
  - Attributes：
    - audioSourceCount：初始化时创建多少AudioSource
    - allSources：统一管理的AudioSources
    - obj：将所有的AudioScource挂载到该obj上
  - Methods：
    - Init：初始化，默认初始化三个
    - GetFreeAudioSource：返回一个空闲的AudioSource，如果此时三个都在用则再创建一个
    - ReleaseAudioSource：释放多余的AudioSource，使AudioSource尽可能回到三个
    - 构造函数：根据传入的参数进行初始化



- AudioManager：实现对AudioSource和Clips的统一管理
  - Attributes：
    - Instance：采用单例模式进行访问
    - sourceManager：SourceManager类
    - AudioManagerObject：选择挂载AudioSource挂载的物体
    - clipManager：ClipManager类
  - Methods：
    - Play：根据名字播放音乐
    - Stop：根据名字停止播放音乐
    - Start：初始化函数



- UsingAudioManager：一个使用AudioManager进行播放音乐的例子

