using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{

    public TextMeshProUGUI Credit_Text;
    public TextMeshProUGUI Reset_Text;

    //���� ����
    public GameObject Game_Reset;

    public static Setting instance;

    private void Start()
    {
        instance = this;
        Game_Reset.SetActive(false);
    }


    public void FixedUpdate()
    {
        /*if (Title_Fade.instance.Title_Canvas.activeSelf == true)//������
        {
            UI_Button.instance.Setting.SetActive(false);
        }*/
    }

    public void Go_Back()
    {
        Winter_Music.instance.Setting.SetActive(false);
        SFX_Manager.instance.SFX_Button();
    }

    public void Go_Reset()
    {
        Game_Reset.SetActive(true);
    }

    public void Reset_Btn_Y_N()//���� ��, �ƴϿ� �Ѵ�(�����ϴ� �� �ٸ� ��ũ��Ʈ�� ����)
    {
        Game_Reset.SetActive(false);
    }


    //ũ����
    public void Credit_Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        //200
        Credit_Text.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 255f / 255f);
    }

    public void Credit_PointerDown()//Ŭ��
    {
        //160
        Credit_Text.color = new Color(160f / 255f, 160f / 255f, 160f / 255f, 255f / 255f);
        //���� ��ư�� Ŭ���ߴٸ�
    }


    public void Credit_Pointer_Click()//Ŭ���ϰ� �� ��
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Creditt_Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Credit_Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        //255
        Credit_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    //�ʱ�ȭ ��ư
    public void Reset_Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        //200
        Reset_Text.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 255f / 255f);
    }

    public void Reset_PointerDown()//Ŭ��
    {
        //160
        Reset_Text.color = new Color(160f / 255f, 160f / 255f, 160f / 255f, 255f / 255f);
        //���� ��ư�� Ŭ���ߴٸ�
    }


    public void Reset_Pointer_Click()//Ŭ���ϰ� �� ��
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 25f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Reset_Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Reset_Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        //255
        Reset_Text.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }
}
