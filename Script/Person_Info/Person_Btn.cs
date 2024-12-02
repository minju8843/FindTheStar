using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person_Btn : MonoBehaviour
{
    public int Page_Count = 0;
    public GameObject[] Person_Page;//�ι� ���� ������
    public GameObject[] Arrow;//��, �� ��ư

    public GameObject Hint;//���� ���� �ִ� ? UI -> ���� ������ �ָ� 3%ȣ���� ����

    public GameObject[] Person_info;//�ι� ���� ���� ó���� ��Ȱ��ȭ �ؾ� �� ��

    public static Person_Btn instance;

    public void Start()
    {
        instance = this;

        Page_Count = 0;

        for(int i = 0; i< Person_info.Length; i++)
        {
            Person_info[i].SetActive(false);//�ι� ���� ���� ó������ ��Ȱ��
        }

        Arrow[0].SetActive(false);//���� ȭ��ǥ ��Ȱ��
    }

    private void FixedUpdate()
    {
        //���� ������ ī��Ʈ�� ���� �ش� ������ Ȱ��ȭ
        for(int i = 0; i< Person_info.Length; i++)
        {
            if (i == Page_Count)
            {
                Person_Page[i].SetActive(true);            
            }

            else
            {
                Person_Page[i].SetActive(false);
            }
        }
    }

    public void About_favorability()//ȣ���� ���� ? â ����
    {
        SFX_Manager.instance.SFX_Button();
        Hint.SetActive(true);
    }

    public void Closde_favorability()//ȣ���� ���� ? â �ݱ�
    {
        SFX_Manager.instance.SFX_Button();
        Hint.SetActive(false);
    }

    public void Back()
    {
        SFX_Manager.instance.SFX_Button();

        //�ڷΰ��� ��ư
        for (int i = 0; i < Person_info.Length; i++)
        {
            Person_info[i].SetActive(false);//�ι� ���� ���� ��Ȱ��
        }
    }

    public void Next_Arrow()
    {
        SFX_Manager.instance.SFX_Button();

        //������ ȭ��ǥ
        if (0 <= Page_Count && Page_Count < Person_Page.Length - 1)
        {
            Page_Count++;
            for (int i = 0; i < Person_Page.Length; i++)
            {
                Person_Page[i].SetActive(false);//�ι� ���� ������
            }

            Person_Page[Page_Count].SetActive(true);

            Arrow[0].SetActive(true);

            Name_Image.instance.Update_TextAndImagePosition();
        }


        //������ ���� ���������, ���� ��ư ���� ��, ȭ��ǥ �����
        if (Page_Count == Person_Page.Length-1)
        {
            Arrow[1].SetActive(false);// [0]�� ���� ȭ��ǥ, [1]�� ������ ȭ��ǥ
        }

    }

    public void Back_Arrow()
    {
        SFX_Manager.instance.SFX_Button();

        //���� ȭ��ǥ
        if (0 < Page_Count && Page_Count < Person_Page.Length)
        {
            Page_Count--;
            for (int i = 0; i < Person_Page.Length; i++)
            {
                Person_Page[i].SetActive(false);//�ι� ���� ������
            }

            Person_Page[Page_Count].SetActive(true);

            Arrow[1].SetActive(true);
            Name_Image.instance.Update_TextAndImagePosition();
        }


        //�� ù��° ���������, ���� ��ư ���� ��, ȭ��ǥ �����
        if (Page_Count == 0)
        {
            Arrow[0].SetActive(false);// [0]�� ���� ȭ��ǥ, [1]�� ������ ȭ��ǥ
        }
    }
}
