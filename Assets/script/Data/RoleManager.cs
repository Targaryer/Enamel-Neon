using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�û���Ϣ�����ࣨ�û�ӵ�еĿ��Ƶ�
public class RoleManager : MonoBehaviour
{
    public static RoleManager Instance = new RoleManager();


    public List<string> cardList;//�洢ӵ�еĿ���ID
    public void Init()
    {
        cardList = new List<string>();

        cardList.Add("");//�൱�������б�
    }
}
