using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject[] End_Panel;//���� ���� ȭ��
    public Image[] End_Panel_Image;//���� ���� ȭ���� UI

    private void Start()
    {
        End_Panel[0].SetActive(false);//������
        End_Panel[1].SetActive(false);//����
    }

    private void Update()
    {
        //������ ���� ����

        //EscŰ�� ���� �����ε�, ���� ������ ��Ȱ��ȭ�� ���¶��
        if (Input.GetButtonDown("Cancel") && Map.instance.map[0].activeSelf == false)
        {
            //������ �����Ͻðڽ��ϱ�? ����â ������, ����â ��Ȱ��
            End_Panel[0].SetActive(true);
            End_Panel[1].SetActive(false);

            //�ٵ�, ���� ���� â ������ ���� ȭ���� �ִ� �ٸ� â�� �����ٸ�
            if (Setting.instance.Game_Reset.activeSelf == true || Hint.instance.Go_Hint.activeSelf == true
                    || Hint_Array_Active() || Map.instance.How_Map.activeSelf == true
                    || Bag_Item.instance.How_To_Use.activeSelf == true || Person_Btn.instance.Hint.activeSelf == true
                    || Change_Music.instance.Question.activeSelf == true || Item_Hint.instance.Hint_Panel.activeSelf == true
                    || Item_Hint.instance.Show_Panel.activeSelf == true 
                    || Select_Album.instance.Quest1.activeSelf == true || Select_Album.instance.Quest2.activeSelf == true)
            //���� �����Ͻðڽ��ϱ�? ȭ���� �����ִ� ���¶��
            //Ȥ�� ��Ʈ�� ���ðڽ��ϱ�? ȭ���� �����ִ� ���¶��
            {

                End_Panel_Image[0].color = new Color(0, 0, 0, 0);//���� �����ϰ�
            }

            else//�׷��� �ʴٸ� ���� �� ����
            {

                End_Panel_Image[0].color = new Color(0, 0, 0, 200f / 255f);
            }
        }

        //EscŰ�� ���� �����ε�, ���� ������ Ȱ��ȭ�� ���¶��

        if (Input.GetButtonDown("Cancel") && Map.instance.map[0].activeSelf == true)
        {
            //������ �����Ͻðڽ��ϱ�? ����â ������, ����â ��Ȱ��
            End_Panel[0].SetActive(false);
            End_Panel[1].SetActive(true);

            //�ٵ�, ���� ���� â ������ ���� ȭ���� �ִ� �ٸ� â�� �����ٸ�
            if (Setting.instance.Game_Reset.activeSelf == true || Hint.instance.Go_Hint.activeSelf == true
                    || Hint_Array_Active() || Map.instance.How_Map.activeSelf == true
                    || Bag_Item.instance.How_To_Use.activeSelf == true|| Person_Btn.instance.Hint.activeSelf == true
                     || Change_Music.instance.Question.activeSelf == true || Item_Hint.instance.Hint_Panel.activeSelf == true
                     || Item_Hint.instance.Show_Panel.activeSelf == true
                     || Select_Album.instance.Quest1.activeSelf == true || Select_Album.instance.Quest2.activeSelf == true)
            //���� �����Ͻðڽ��ϱ�? ȭ���� �����ִ� ���¶��
            //Ȥ�� ��Ʈ�� ���ðڽ��ϱ�? ȭ���� �����ִ� ���¶��
            {
                End_Panel_Image[1].color = new Color(0, 0, 0, 0);//���� �����ϰ�
            }

            else//�׷��� �ʴٸ� ���� �� ����
            {

                End_Panel_Image[1].color = new Color(0, 0, 0, 200f / 255f);
            }
        }

    }


    bool Hint_Array_Active()//Hints�迭 �� �ϳ��� Ȱ��ȭ�Ǿ� �ִٸ�
    {
        foreach(GameObject hint in Hint.instance.Hints)
        {
            if(hint.activeSelf)
            {
                return true;//�ϳ��� Ȱ��ȭ�Ǿ� ������ true
            }
        }

        //������ ����� �Ŀ� �Ʒ� �ڵ� �����
        return false;//��� ��Ȱ��ȭ�Ǿ� ������ false
    }

    public void End_Game_Yes()
    {
        //���� ���� - ��
        //End_Panel[0].SetActive(false);
        //End_Panel[1].SetActive(false);

        End_Game();
    }

    public void End_Game_No()//
    {
        //���� ���� - �ƴϿ�
        End_Panel[0].SetActive(false);
        End_Panel[1].SetActive(false);
    }

    public void End_Game()
    {
#if UNITY_EDITOR//����Ƽ �������� ���
        UnityEditor.EditorApplication.isPlaying = false;
#else//���� ������ ���
        Application.Quit(); // ���ø����̼� ����
#endif
    }

}
