using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FightUI : UIBase
{
    private Text cardCountText;//卡牌数量
    private Text noCardCountText;//弃牌堆数量
    private Text powerText;
    private Text hpText;
    private Image hpImage;
    private Text defText;
    private List<CardItem> cardItemList; //存储卡牌物体的集合
    private void Awake()
    {
        cardItemList = new List<CardItem>();

        //这里应该读取UI元素的text和img
        cardCountText = transform.Find("").GetComponent<Text>();
        noCardCountText = transform.Find("").GetComponent<Text>();
        powerText = transform.Find("").GetComponent<Text>();
        hpText = transform.Find("").GetComponent<Text>();
        hpImage = transform.Find("").GetComponent<Image>();
        defText = transform.Find("").GetComponent<Text>();

        //获取回合切换按钮
        transform.Find("turnBtn").GetComponent<Button>().onClick.AddListener(onChangeTurnBtn);
    }

    //玩家回合结束，切换到敌人回合
    private void onChangeTurnBtn()
    {
        //只有玩家才能切换
        if (FightManager.Instance.fightUnit is FightPlayerTurn)
        {
            FightManager.Instance.ChangeType(FightType.Enemy);
        }
    }

    private void Start()
    {
        UpdateHP();
        UpdatePower();
        UpdateDef();
        UpdateCardCount();
        UpdateUsedCardCount();
    }

    public void UpdateHP()
    {
        hpText.text = FightManager.Instance.CurHP + "/" + FightManager.Instance.MaxHP;
        hpImage.fillAmount = (float)FightManager.Instance.CurHP / (float)FightManager.Instance.MaxHP;
    }

    public void UpdatePower()
    {
        //我们好像没有法力值这个东西
        powerText.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }

    public void UpdateDef()
    {
        defText.text = FightManager.Instance.DefCount.ToString();
    }

    public void UpdateCardCount()
    {
        cardCountText.text = FightCardManager.Instance.cardList.Count.ToString();
    }

    public void UpdateUsedCardCount()
    {
        noCardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }

    //创建卡牌物体
    public void CreatCardItem(int count)
    {
        if (count > FightCardManager.Instance.cardList.Count)
        {
            count = FightCardManager.Instance.cardList.Count;
        }
        for (int i = 0; i < count ; i++)
        {
            //Id	Name	Script	Type	Des	BgIcon	Icon	Expend	Arg0	Effects
            //唯一的标识（不能重复）	名称	卡牌添加的脚本	卡牌类型的Id	描述	卡牌的背景图资源路径	图标资源的路径	消耗的费用	属性值	特效
            //1000	普通攻击	AttackCardItem	10001	对单个敌人进行{0}点的伤害	Icon/BlueCard	Icon/sword_03e	1	3	Effects/GreenBloodExplosion

            GameObject obj = Instantiate(Resources.Load(""), transform) as GameObject;//加载卡牌UI
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);
            //var Item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.GetCardById(cardId);
            CardItem Item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            Item.Init(data);
            cardItemList.Add(Item);
        }
    }

    //更新卡牌位置（好像用不到？
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);
        for (int i = 0; i < cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }

    //删除卡牌物体
    public void RemoveCard(CardItem item)
    {
        AudioManager.Instance.PlayEffect("");//删除音效（文件夹路径

        item.enabled = false;//禁用卡牌逻辑

        //添加到弃牌集合
        FightCardManager.Instance.usedCardList.Add(item.data["Id"]);

        //更新使用后的卡牌数量
        noCardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();

        //从集合中删除
        cardItemList.Remove(item);

        //刷新卡牌位置
        UpdateCardItemPos();

        //卡牌移到弃牌堆效果
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject,1);


    }

    //清空所有卡牌
    public void RemoveAllCards()
    {
        for (int i = cardItemList.Count-1; i >= 0; i--)
        {
            RemoveCard(cardItemList[i]);
        }
    }
}
