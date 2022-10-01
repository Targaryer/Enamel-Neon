using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//游戏入口
public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化配置表
        GameConfigManager.Instance.Init();

        //初始化音频管理器
        AudioManager.Instance.Init();

        //初始化用户信息
        RoleManager.Instance.Init();

        //显示LoginUI 创建的脚本名字记得跟预制体物体的名字一致
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //播放BGM
        AudioManager.Instance.PlayBGM("");//在此填入初始BGM
    }

}
