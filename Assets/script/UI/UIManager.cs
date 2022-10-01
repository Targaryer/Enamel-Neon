using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//DG插件
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTF;//画布位置组件

    private List<UIBase> uiList;//存储加载过的界面的列表

    private void Awake()
    {
        Instance = this;
        canvasTF = GameObject.Find("Canvas").transform;//寻找世界中的画布
        uiList = new List<UIBase>(); // 将列表初始化

    }

    public UIBase ShowUI<T>(string uiName) where T:UIBase
    {
        UIBase ui = Find(uiName);
        if (ui == null) 
        {
            //如果集合中没有 需要从Resources/UI中加载
            GameObject obj = Instantiate(Resources.Load("UI/" + uiName), canvasTF) as GameObject;
            //改名字
            obj.name = uiName;
            //添加需要的脚本
            ui = obj.AddComponent<T>();
            //添加到集合uiList
            uiList.Add(ui);

        }
        else
        {
            //将UI显示
            ui.Show();
        }

        return ui;
    }
    
    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
    }

    //关闭所有界面
    public void CloseAllUI()
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            Destroy(uiList[i].gameObject);

        }
        uiList.Clear();
    }

    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);//将ui销毁
        }
    }

    public UIBase Find(string uiName)//根据给定的界面名，从集合中将这个界面返回
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                return uiList[i];
            }     
        }
        return null;
    }

    public T GetUI<T> (string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;    
    }

    /// <summary>
    /// 创建敌人头部的行动图标
    /// </summary>
    /// <returns></returns>
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load(""),canvasTF) as GameObject;//加载UI文件夹中敌人行动图标的UI
        obj.transform.SetAsFirstSibling();//设置在父级的第一位，这样这个组件就可以通过GetUI得到
        return obj;
    }

    //创建敌人底部血量物体
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load(""), canvasTF) as GameObject;//加载UI文件夹中血量的UI
        obj.transform.SetAsFirstSibling();//设置在父级的第一位
        return obj;
    }

    //提示界面（回合切换等等
    public void ShowTip(string msg,Color color,System.Action callBack = null)
    {
        GameObject obj = Instantiate(Resources.Load(""), canvasTF) as GameObject;//加载UI文件夹中的提示UI
        Text text = obj.transform.Find("").GetComponent<Text>();
        text.color = color;
        text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1, 0.4f);//将回合切换UI藏在背景后面，当需要切换的时候，把他移到前面
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate () 
        {
            if (callBack != null)
            {
                callBack();
            }
        });

        MonoBehaviour.Destroy(obj, 2);//延迟2秒，销毁obj
    }
}
