using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("playerTime");
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //�ظ��ж���
            FightManager.Instance.CurPowerCount = 3;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            //�������Ѿ��ľ������³�ʼ��
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();

                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
            }


            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreatCardItem(4);//��4�ſ�
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();//���¿���λ��

            //���¿�����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
