using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {
        //��ʼ��ս����ֵ
        FightManager.Instance.Init();

        //����ս��bgm������ֻ��Ҫ����bgm�����־Ϳ���
        AudioManager.Instance.PlayBGM("");

        //��������
        EnemyManager.Instance.loadRes("");

        //��ʼ��ս������
        FightCardManager.Instance.Init();

        //��ʾս������
        UIManager.Instance.ShowUI<FightUI>("FightUI");

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        
    }
}
