using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用户信息管理类（用户拥有的卡牌等
public class RoleManager : MonoBehaviour
{
    public static RoleManager Instance = new RoleManager();


    public List<string> cardList;//存储拥有的卡牌ID
    public void Init()
    {
        cardList = new List<string>();

        cardList.Add("");//相当于手牌列表
    }
}
