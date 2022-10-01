using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��Ϸ���
public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ʼ�����ñ�
        GameConfigManager.Instance.Init();

        //��ʼ����Ƶ������
        AudioManager.Instance.Init();

        //��ʼ���û���Ϣ
        RoleManager.Instance.Init();

        //��ʾLoginUI �����Ľű����ּǵø�Ԥ�������������һ��
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //����BGM
        AudioManager.Instance.PlayBGM("");//�ڴ������ʼBGM
    }

}
