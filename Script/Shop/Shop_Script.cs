using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Shop_Script : MonoBehaviour
{
    public static Shop_Script instance;

    public TextMeshProUGUI Buy_Image;
    public TextMeshProUGUI Reset_Image;

    public GameObject[] Menu;//���� �޴� ������

    public int Menu_Count = 0;//���� �� ��° �޴�����
    public TextMeshProUGUI Menu_Count_Text;//�� ��° �޴����� �˷��ִ� �ؽ�Ʈ

    public Image Right_Arrow;
    public Image Left_Arrow;

    public GameObject Shop_Panel;//���� �ǳ�




    public void Start()
    {

        instance = this;

        if(Menu_Count == 0)//ī��Ʈ�� 0�̸� 0��° �޴����� ��������
        {
            for(int i = 1; i< Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[0].SetActive(true);
            Menu_Count_Text.text = "1/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

    }

    //������ ȭ��ǥ ��ư
    public void Right_Button_1()
    {
        SFX_Manager.instance.SFX_Button();

        if (Menu_Count == 0)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[1].SetActive(true);
            Menu_Count_Text.text = "2/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if(Menu_Count == 1)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[2].SetActive(true);
            Menu_Count_Text.text = "3/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 2)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[3].SetActive(true);
            Menu_Count_Text.text = "4/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 3)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[4].SetActive(true);
            Menu_Count_Text.text = "5/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 4)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[5].SetActive(true);
            Menu_Count_Text.text = "6/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 5)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[6].SetActive(true);
            Menu_Count_Text.text = "7/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 6)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[7].SetActive(true);
            Menu_Count_Text.text = "8/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 7)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[8].SetActive(true);
            Menu_Count_Text.text = "9/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 8)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[9].SetActive(true);
            Menu_Count_Text.text = "10/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 9)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[10].SetActive(true);
            Menu_Count_Text.text = "11/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 10)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[11].SetActive(true);
            Menu_Count_Text.text = "12/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 11)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[12].SetActive(true);
            Menu_Count_Text.text = "13/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 12)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[13].SetActive(true);
            Menu_Count_Text.text = "14/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 13)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[14].SetActive(true);
            Menu_Count_Text.text = "15/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 14)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[15].SetActive(true);
            Menu_Count_Text.text = "16/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 15)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[16].SetActive(true);
            Menu_Count_Text.text = "17/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 16)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[17].SetActive(true);
            Menu_Count_Text.text = "18/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 17)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[18].SetActive(true);
            Menu_Count_Text.text = "19/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 18)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[19].SetActive(true);
            Menu_Count_Text.text = "20/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 19)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[20].SetActive(true);
            Menu_Count_Text.text = "21/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 20)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[21].SetActive(true);
            Menu_Count_Text.text = "22/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 21)
        {
            Menu_Count++;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[22].SetActive(true);
            Menu_Count_Text.text = "23/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 22)
        {
            Menu_Count = 0;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[0].SetActive(true);
            Menu_Count_Text.text = "1/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }
    }

    //���� ȭ��ǥ ��ư
    public void Left_Button_0()
    {

        SFX_Manager.instance.SFX_Button();

        if (Menu_Count == 0)
        {
            Menu_Count = 22;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[22].SetActive(true);
            Menu_Count_Text.text = "23/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 1)
        {
            Menu_Count = 0;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[0].SetActive(true);
            Menu_Count_Text.text = "1/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 2)
        {
            Menu_Count = 1;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[1].SetActive(true);
            Menu_Count_Text.text = "2/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 3)
        {
            Menu_Count = 2;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[2].SetActive(true);
            Menu_Count_Text.text = "3/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 4)
        {
            Menu_Count = 3;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[3].SetActive(true);
            Menu_Count_Text.text = "4/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 5)
        {
            Menu_Count = 4;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[4].SetActive(true);
            Menu_Count_Text.text = "5/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 6)
        {
            Menu_Count = 5;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[5].SetActive(true);
            Menu_Count_Text.text = "6/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 7)
        {
            Menu_Count = 6;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[6].SetActive(true);
            Menu_Count_Text.text = "7/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 8)
        {
            Menu_Count = 7;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[7].SetActive(true);
            Menu_Count_Text.text = "8/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 9)
        {
            Menu_Count = 8;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[8].SetActive(true);
            Menu_Count_Text.text = "9/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 10)
        {
            Menu_Count = 9;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[9].SetActive(true);
            Menu_Count_Text.text = "10/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 11)
        {
            Menu_Count = 10;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[10].SetActive(true);
            Menu_Count_Text.text = "11/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 12)
        {
            Menu_Count = 11;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[11].SetActive(true);
            Menu_Count_Text.text = "12/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 13)
        {
            Menu_Count = 12;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[12].SetActive(true);
            Menu_Count_Text.text = "13/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 14)
        {
            Menu_Count = 13;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[13].SetActive(true);
            Menu_Count_Text.text = "14/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 15)
        {
            Menu_Count = 14;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[14].SetActive(true);
            Menu_Count_Text.text = "15/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 16)
        {
            Menu_Count = 15;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[15].SetActive(true);
            Menu_Count_Text.text = "16/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 17)
        {
            Menu_Count = 16;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[16].SetActive(true);
            Menu_Count_Text.text = "17/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 18)
        {
            Menu_Count = 17;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[17].SetActive(true);
            Menu_Count_Text.text = "18/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 19)
        {
            Menu_Count = 18;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[18].SetActive(true);
            Menu_Count_Text.text = "19/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 20)
        {
            Menu_Count = 19;


            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[19].SetActive(true);
            Menu_Count_Text.text = "20/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 21)
        {
            Menu_Count = 20;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[20].SetActive(true);
            Menu_Count_Text.text = "21/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }

        else if (Menu_Count == 22)
        {
            Menu_Count = 21;

            for (int i = 0; i < Menu.Length; i++)
            {
                Menu[i].SetActive(false);
            }

            Menu[21].SetActive(true);
            Menu_Count_Text.text = "22/23";//���� �Ʒ� �ؽ�Ʈ �̷��� �ٲٱ�
        }
    }

    //���� ��ư
    public void Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        Buy_Image.color = new Color(210f / 255f, 190f / 255f, 157f / 255f, 255f / 255f);
    }

    public void PointerDown()//Ŭ��
    {
        Buy_Image.color = new Color(190f / 255f, 165f / 255f, 126f / 255f, 255f / 255f);
        //���� ��ư�� Ŭ���ߴٸ�

    }

    public void Pointer_Click()//Ŭ���ϰ� �� ��
    {
        Buy_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    public void Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        Buy_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    public void Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        Buy_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    //�ʱ�ȭ ��ư
    public void Cancel_Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        Reset_Image.color = new Color(210f / 255f, 190f / 255f, 157f / 255f, 255f / 255f);
    }

    public void Cancel_PointerDown()//Ŭ��
    {
        Reset_Image.color = new Color(190f / 255f, 165f / 255f, 126f / 255f, 255f / 255f);
        //���� ��ư�� Ŭ���ߴٸ�
    }


    public void Cancel_Pointer_Click()//Ŭ���ϰ� �� ��
    {
        //238, 224, 201
        Reset_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    public void Cancel_Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        Reset_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    public void Cancel_Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        Reset_Image.color = new Color(238f / 255f, 224f / 255f, 201f / 255f, 255f / 255f);
    }

    //������ ȭ��ǥ
    public void Right_Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        Right_Arrow.color = new Color(193f / 255f, 193f / 255f, 193f / 255f, 255f / 255f);
    }

    public void Right_PointerDown()//Ŭ��
    {
        Right_Arrow.color = new Color(144f / 255f, 144f / 255f, 144f / 255f, 255f / 255f);
    }

    public void Right_Pointer_Click()//Ŭ���ϰ� �� ��
    {
        Right_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Right_Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        Right_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Right_Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        Right_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    //���� ȭ��ǥ
    public void Left_Pointer_Enter()//��ư ���� ���콺 �÷��� ��
    {
        Left_Arrow.color = new Color(193f / 255f, 193f / 255f, 193f / 255f, 255f / 255f);
    }

    public void Left_PointerDown()//Ŭ��
    {
        Left_Arrow.color = new Color(144f / 255f, 144f / 255f, 144f / 255f, 255f / 255f);
    }

    public void Left_Pointer_Click()//Ŭ���ϰ� �� ��
    {
        Left_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Left_Pointer_Up()//���콺 ���ȴٰ� �÷��� ��
    {
        Left_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void Left_Pointer_Exit()//���콺�� ��ư���� ����� ��
    {
        Left_Arrow.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }
}

