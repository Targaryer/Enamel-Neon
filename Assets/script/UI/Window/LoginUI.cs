using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//��ʼ����
public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("bg/startBtn").onClick = onStartGameBtn;      
    }

    private void onStartGameBtn(GameObject obj,PointerEventData pData)
    {
        //�رտ�ʼ����
        Close();
    }
}
