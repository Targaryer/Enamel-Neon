using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//开始界面
public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("bg/startBtn").onClick = onStartGameBtn;      
    }

    private void onStartGameBtn(GameObject obj,PointerEventData pData)
    {
        //关闭开始界面
        Close();
    }
}
