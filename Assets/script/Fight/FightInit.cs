using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//卡牌战斗初始化
public class FightInit : FightUnit
{
    public override void Init()
    {
        //初始化战斗数值
        FightManager.Instance.Init();

        //播放战斗bgm，这里只需要输入bgm的名字就可以
        AudioManager.Instance.PlayBGM("");

        //敌人生成
        EnemyManager.Instance.loadRes("");

        //初始化战斗卡牌
        FightCardManager.Instance.Init();

        //显示战斗界面
        UIManager.Instance.ShowUI<FightUI>("FightUI");

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        
    }
}
