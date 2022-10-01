using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;//卡堆

    public List<string> usedCardList;//弃牌堆


    public void Init()
    {
        cardList = new List<string>();

        usedCardList = new List<string>();

        List<string> tempList = new List<string>();//临时集合

        tempList.AddRange(RoleManager.Instance.cardList);//将玩家卡牌存储到临时集合

        while (tempList.Count>0)
        {
            //随机下标
            int tempIndex = Random.Range(0, tempList.Count);

            //添加到卡堆
            cardList.Add(tempList[tempIndex]);

            //临时集合删除
            tempList.RemoveAt(tempIndex);
        }

        Debug.Log(cardList.Count);
    }

    //是否有卡
    public bool HasCard()
    {
        return cardList.Count > 0;
    }

    //抽卡(逻辑和我们不同
    public string DrawCard()
    {
        string id = cardList[cardList.Count - 1];//牌库？
        cardList.RemoveAt(cardList.Count - 1);//将对应卡牌从牌库中移除
        return id;
    }


}
