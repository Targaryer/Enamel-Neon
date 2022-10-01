using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;//����

    public List<string> usedCardList;//���ƶ�


    public void Init()
    {
        cardList = new List<string>();

        usedCardList = new List<string>();

        List<string> tempList = new List<string>();//��ʱ����

        tempList.AddRange(RoleManager.Instance.cardList);//����ҿ��ƴ洢����ʱ����

        while (tempList.Count>0)
        {
            //����±�
            int tempIndex = Random.Range(0, tempList.Count);

            //��ӵ�����
            cardList.Add(tempList[tempIndex]);

            //��ʱ����ɾ��
            tempList.RemoveAt(tempIndex);
        }

        Debug.Log(cardList.Count);
    }

    //�Ƿ��п�
    public bool HasCard()
    {
        return cardList.Count > 0;
    }

    //�鿨(�߼������ǲ�ͬ
    public string DrawCard()
    {
        string id = cardList[cardList.Count - 1];//�ƿ⣿
        cardList.RemoveAt(cardList.Count - 1);//����Ӧ���ƴ��ƿ����Ƴ�
        return id;
    }


}
