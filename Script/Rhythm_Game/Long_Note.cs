using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Long_Note : MonoBehaviour
{
    public Note_1105 note_1105;

    public Manager_0 manager;

    public static Long_Note instance;
    public Long_Col[] long_col;

   // public GameObject hit_5_1;


    public float beatTempo;//��Ʈ�� �󸶳� ���� ����������//Beat_Scroller���� ������
    public bool hasStarted;//���۵ƴ���

    public RectTransform rect; // ������Ʈ�� RectTransform
    public BoxCollider2D[] long_note_col;

    public bool canBePressed;

    public bool Button_0_Pressed = false;
    public bool Button_1_Pressed = false;
    public bool Button_2_Pressed = false;
    public bool Button_3_Pressed = false;
    public bool Button_4_Pressed = false;
    public bool Button_5_Pressed = false;

    public int no_hit_0 = 0;
    public int no_hit_1 = 0;
    public int no_hit_2 = 0;
    public int no_hit_3 = 0;
    public int no_hit_4 = 0;
    public int no_hit_5 = 0;

    //0����
    /*public int no_hit_0_0 = 0;
    public int no_hit_0_1 = 0;

    //1����
    public int no_hit_1_0 = 0;

    //2����
    public int no_hit_2_0 = 0;

    //3����
    public int no_hit_3_0 = 0;

    //4����
    //public bool long_note_4_0 = false;
    public int no_hit_4_0 = 0;
    public int no_hit_4_1 = 0;//5��° ������ 0��° �� ��Ʈ
    */

    //5����
    // public bool long_note_5_0 = false;//5��° ������ 0��° �� ��Ʈ
    //public int no_hit_5_0 = 0;//5��° ������ 0��° �� ��Ʈ
    //public int no_hit_5_1 = 0;

    //private bool isInputReleased = false;

    public List<GameObject> buttons; // ��ư���� �����ϴ� ����Ʈ
   // public bool[] buttonTouched = new bool[6];

    //public bool[] isButtonTouchedOnce = new bool[6]; // ��ġ�� �� ���̶� �̷�������� ����

    public void ResetTouch_Count_0()//Ƚ�� ���� 
    {
        no_hit_0 = 0;
    }

    public void ResetTouch_Count_1()
    {
        no_hit_1 = 0;
    }

    public void ResetTouch_Count_2()
    {
        no_hit_2 = 0;
    }

    public void ResetTouch_Count_3()
    {
        no_hit_3 = 0;
    }

    public void ResetTouch_Count_4()
    {
        no_hit_4 = 0;
    }

    public void ResetTouch_Count_5()
    {
        no_hit_5 = 0;
    }

   /* public void ResetTouchStatus_0()//��ġ ����
    {
        isButtonTouchedOnce[0] = false;
    }

    public void ResetTouchStatus_1()//��ġ ����
    {
        isButtonTouchedOnce[1] = false;
    }

    public void ResetTouchStatus_2()//��ġ ����
    {
        isButtonTouchedOnce[2] = false;
    }

    public void ResetTouchStatus_3()//��ġ ����
    {
        isButtonTouchedOnce[3] = false;
    }

    public void ResetTouchStatus_4()//��ġ ����
    {
        isButtonTouchedOnce[4] = false;
    }

    public void ResetTouchStatus_5()//��ġ ����
    {
        isButtonTouchedOnce[5] = false;
    }
   */
    void Start()
    {
        ResetTouch_Count_0();
        ResetTouch_Count_1();
        ResetTouch_Count_2();
        ResetTouch_Count_3();
        ResetTouch_Count_4();
        ResetTouch_Count_5();

        /*ResetTouchStatus_0();
        ResetTouchStatus_1();
        ResetTouchStatus_2();
        ResetTouchStatus_3();
        ResetTouchStatus_4();
        ResetTouchStatus_5();
       */
        instance = this;

        rect = GetComponent<RectTransform>();
        beatTempo = beatTempo / 2f;

    }


    public void Update()
    {
        //CheckTouchInput(); // ��ġ ���� ���� ������Ʈ
        //HandleOtherLogic(); // �ٸ� ���� ���� ó��

        if (Winter_Music.instance.Pause.activeSelf == true || Winter_Music.instance.keep_speed == false)
        {
            rect.anchoredPosition -= new Vector2(0f, 0.0f * Time.deltaTime);
            // Debug.Log("���� �ճ�Ʈ ��� �̽� �ƴ�");
        }

        if (Winter_Music.instance.Pause.activeSelf == false && Winter_Music.instance.keep_speed == true)
        {
            rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
            
        }



        //0-0
        if (gameObject.name == "Long_Note0_0")// && Manager_0.instance.Nor_Note_Log_rect[0].anchoredPosition.y < -18.0f)
        {

            if (canBePressed == true)
            {
                //(rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y >= -18.0f )
                //-> �Ϲ� ��Ʈ�� ����Ʈ�� �� ��Ʈ�� �ִ� ���̿� 
               /* if ((Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[1].activeSelf == true || Manager_0.instance.Nor_Note_Log[1].activeSelf == false ))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {
                        
                        Debug.Log("0-0 ������ �ֱ���");
                        no_hit_0 = 0;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[1].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[1].activeSelf == false && long_col[6].fin_col.enabled == true && long_note_col[1].enabled == true))
                {
                    //ó���� ���ε� �� ������ �� ���
                    //��ư�� �� ������ ���
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[1].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[1].rect.anchoredPosition.y < -18.0f && long_col[1].fin_col.enabled == true && long_note_col[1].enabled == true)
                {
                    //��ư�� �� ������ ���
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        //Long_Col.instance.fin_col.enabled = true;
                        long_col[1].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[1].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }



            }


        }

        //0-1
        if (gameObject.name == "Long_Note0_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[4].activeSelf == true || Manager_0.instance.Nor_Note_Log[4].activeSelf == false))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {

                        Debug.Log("0-1 ������ �ֱ���");
                        no_hit_0 = 0;
                        long_col[4].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[4].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[4].activeSelf == false && long_col[4].fin_col.enabled == true && long_note_col[4].enabled == true))
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[4].rect.anchoredPosition.y < -18.0f && long_col[4].fin_col.enabled == true && long_note_col[4].enabled == true)
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //0-2
        if (gameObject.name == "Long_Note0_2")
        {
            if (canBePressed == true)
            {
               /* if((Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[15].activeSelf == true || Manager_0.instance.Nor_Note_Log[15].activeSelf == false))
                {
                    if (Button_0_Pressed == true && no_hit_0 == 0)
                    {

                        Debug.Log("0-2 ������ �ֱ���");
                        no_hit_0 = 0;
                        long_col[15].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[15].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[15].activeSelf == false && long_col[15].fin_col.enabled == true && long_note_col[15].enabled == true))
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[15].rect.anchoredPosition.y < -18.0f && long_col[15].fin_col.enabled == true && long_note_col[15].enabled == true)
                {
                    if (Button_0_Pressed == false && no_hit_0 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("0-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_0 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }


        //1-0
        if (gameObject.name == "Long_Note1_0")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[6].activeSelf == true || Manager_0.instance.Nor_Note_Log[6].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-0 ������ �ֱ���");
                        no_hit_1 = 0;
                        long_col[6].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[6].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }
               */
                if ((Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[6].activeSelf == false && long_col[6].fin_col.enabled == true && long_note_col[6].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[6].rect.anchoredPosition.y < -18.0f && long_col[6].fin_col.enabled == true && long_note_col[6].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //1-1
        if (gameObject.name == "Long_Note1_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[8].activeSelf == true || Manager_0.instance.Nor_Note_Log[8].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-1 ������ �ֱ���");
                        no_hit_1 = 0;
                        long_col[8].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[8].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[8].activeSelf == false && long_col[8].fin_col.enabled == true && long_note_col[8].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[8].rect.anchoredPosition.y < -18.0f && long_col[8].fin_col.enabled == true && long_note_col[8].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }


        //1-2
        if (gameObject.name == "Long_Note1_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[10].activeSelf == true || Manager_0.instance.Nor_Note_Log[10].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-2 ������ �ֱ���");
                        no_hit_1 = 0;
                        long_col[10].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[10].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[10].activeSelf == false && long_col[10].fin_col.enabled == true && long_note_col[10].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[10].rect.anchoredPosition.y < -18.0f && long_col[10].fin_col.enabled == true && long_note_col[10].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //1-3
        if (gameObject.name == "Long_Note1_3")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[24].activeSelf == true || Manager_0.instance.Nor_Note_Log[24].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-3 ������ �ֱ���");
                        no_hit_1 = 0;
                        long_col[24].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[24].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }
                */
                if ((Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[24].activeSelf == false && long_col[24].fin_col.enabled == true && long_note_col[24].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-3�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[24].rect.anchoredPosition.y < -18.0f && long_col[24].fin_col.enabled == true && long_note_col[24].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-3�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //1-4
        if (gameObject.name == "Long_Note1_4")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[31].activeSelf == true || Manager_0.instance.Nor_Note_Log[31].activeSelf == false))
                {
                    if (Button_1_Pressed == true && no_hit_1 == 0)
                    {

                        Debug.Log("1-4 ������ �ֱ���");
                        no_hit_1 = 0;
                        long_col[31].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[31].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[31].activeSelf == false && long_col[31].fin_col.enabled == true && long_note_col[31].enabled == true))
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-4�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[31].rect.anchoredPosition.y < -18.0f && long_col[31].fin_col.enabled == true && long_note_col[31].enabled == true)
                {
                    if (Button_1_Pressed == false && no_hit_1 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("1-4�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_1 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-0
        if (gameObject.name == "Long_Note2_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[5].activeSelf == true || Manager_0.instance.Nor_Note_Log[5].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-0 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[5].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[5].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[5].activeSelf == false && long_col[5].fin_col.enabled == true && long_note_col[5].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[5].rect.anchoredPosition.y < -18.0f && long_col[5].fin_col.enabled == true && long_note_col[5].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-1
        if (gameObject.name == "Long_Note2_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[20].activeSelf == true || Manager_0.instance.Nor_Note_Log[20].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-1 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[20].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[20].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[20].activeSelf == false && long_col[20].fin_col.enabled == true && long_note_col[20].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[20].rect.anchoredPosition.y < -18.0f && long_col[20].fin_col.enabled == true && long_note_col[20].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-2
        if (gameObject.name == "Long_Note2_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[12].activeSelf == true || Manager_0.instance.Nor_Note_Log[12].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-2 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[12].activeSelf == false && long_col[12].fin_col.enabled == true && long_note_col[12].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[12].rect.anchoredPosition.y < -18.0f && long_col[12].fin_col.enabled == true && long_note_col[12].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-3
        if (gameObject.name == "Long_Note2_3")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[25].activeSelf == true || Manager_0.instance.Nor_Note_Log[25].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-3 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[25].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[25].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[25].activeSelf == false && long_col[25].fin_col.enabled == true && long_note_col[25].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-3�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[25].rect.anchoredPosition.y < -18.0f && long_col[25].fin_col.enabled == true && long_note_col[25].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-3�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-4
        if(gameObject.name == "Long_Note2_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[26].activeSelf == true || Manager_0.instance.Nor_Note_Log[26].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-4 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[26].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[26].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[26].activeSelf == false && long_col[26].fin_col.enabled == true && long_note_col[26].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-4�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[26].rect.anchoredPosition.y < -18.0f && long_col[26].fin_col.enabled == true && long_note_col[26].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-4�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-5
        if (gameObject.name == "Long_Note2_5")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[33].activeSelf == true || Manager_0.instance.Nor_Note_Log[33].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-5 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[33].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[33].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[33].activeSelf == false && long_col[33].fin_col.enabled == true && long_note_col[33].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-5�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[33].rect.anchoredPosition.y < -18.0f && long_col[33].fin_col.enabled == true && long_note_col[33].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-5�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //2-6
        if (gameObject.name == "Long_Note2_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[34].activeSelf == true || Manager_0.instance.Nor_Note_Log[34].activeSelf == false))
                {
                    if (Button_2_Pressed == true && no_hit_2 == 0)
                    {

                        Debug.Log("2-6 ������ �ֱ���");
                        no_hit_2 = 0;
                        long_col[34].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[34].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[34].activeSelf == false && long_col[34].fin_col.enabled == true && long_note_col[34].enabled == true))
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-6�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[34].rect.anchoredPosition.y < -18.0f && long_col[34].fin_col.enabled == true && long_note_col[34].enabled == true)
                {
                    if (Button_2_Pressed == false && no_hit_2 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("2-6�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_2 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-0
        if (gameObject.name == "Long_Note3_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[7].activeSelf == true || Manager_0.instance.Nor_Note_Log[7].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-0 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[7].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[7].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[7].activeSelf == false && long_col[7].fin_col.enabled == true && long_note_col[7].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[7].rect.anchoredPosition.y < -18.0f && long_col[7].fin_col.enabled == true && long_note_col[7].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-1
        if (gameObject.name == "Long_Note3_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[9].activeSelf == true || Manager_0.instance.Nor_Note_Log[9].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-1 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[9].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[9].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[9].activeSelf == false && long_col[9].fin_col.enabled == true && long_note_col[9].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[9].rect.anchoredPosition.y < -18.0f && long_col[9].fin_col.enabled == true && long_note_col[9].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-2
        if (gameObject.name == "Long_Note3_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[11].activeSelf == true || Manager_0.instance.Nor_Note_Log[11].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-2 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[11].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[11].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[11].activeSelf == false && long_col[11].fin_col.enabled == true && long_note_col[11].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[11].rect.anchoredPosition.y < -18.0f && long_col[11].fin_col.enabled == true && long_note_col[11].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-3
        if (gameObject.name == "Long_Note3_3")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[13].activeSelf == true || Manager_0.instance.Nor_Note_Log[13].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-3 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[13].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[13].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[13].activeSelf == false && long_col[13].fin_col.enabled == true && long_note_col[13].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-3�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[13].rect.anchoredPosition.y < -18.0f && long_col[13].fin_col.enabled == true && long_note_col[13].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-3�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-4
        if (gameObject.name == "Long_Note3_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[19].activeSelf == true || Manager_0.instance.Nor_Note_Log[19].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-4 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[19].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[19].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[19].activeSelf == false && long_col[19].fin_col.enabled == true && long_note_col[19].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-4�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[19].rect.anchoredPosition.y < -18.0f && long_col[19].fin_col.enabled == true && long_note_col[19].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-4�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-5
        if (gameObject.name == "Long_Note3_5")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[27].activeSelf == true || Manager_0.instance.Nor_Note_Log[27].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-5 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[27].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[27].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[27].activeSelf == false && long_col[27].fin_col.enabled == true && long_note_col[27].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-5�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[27].rect.anchoredPosition.y < -18.0f && long_col[27].fin_col.enabled == true && long_note_col[27].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-5�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //3-6
        if (gameObject.name == "Long_Note3_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[36].activeSelf == true || Manager_0.instance.Nor_Note_Log[36].activeSelf == false))
                {
                    if (Button_3_Pressed == true && no_hit_3 == 0)
                    {

                        Debug.Log("3-6 ������ �ֱ���");
                        no_hit_3 = 0;
                        long_col[36].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[36].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[36].activeSelf == false && long_col[36].fin_col.enabled == true && long_note_col[36].enabled == true))
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-6�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[36].rect.anchoredPosition.y < -18.0f && long_col[36].fin_col.enabled == true && long_note_col[36].enabled == true)
                {
                    if (Button_3_Pressed == false && no_hit_3 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("3-6�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_3 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-0
        if (gameObject.name == "Long_Note4_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[2].activeSelf == true || Manager_0.instance.Nor_Note_Log[2].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-0 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[2].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[2].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[2].activeSelf == false && long_col[2].fin_col.enabled == true && long_note_col[2].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[2].rect.anchoredPosition.y < -18.0f && long_col[2].fin_col.enabled == true && long_note_col[2].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-1
        if (gameObject.name == "Long_Note4_1")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[3].activeSelf == true || Manager_0.instance.Nor_Note_Log[3].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-1 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[3].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[3].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[3].activeSelf == false && long_col[3].fin_col.enabled == true && long_note_col[3].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[3].rect.anchoredPosition.y < -18.0f && long_col[3].fin_col.enabled == true && long_note_col[3].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-2
        if (gameObject.name == "Long_Note4_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[16].activeSelf == true || Manager_0.instance.Nor_Note_Log[16].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-2 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[16].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[16].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[16].activeSelf == false && long_col[16].fin_col.enabled == true && long_note_col[16].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[16].rect.anchoredPosition.y < -18.0f && long_col[16].fin_col.enabled == true && long_note_col[16].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-3
        if (gameObject.name == "Long_Note4_3")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[17].activeSelf == true || Manager_0.instance.Nor_Note_Log[17].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-3 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[17].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[17].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[17].activeSelf == false && long_col[17].fin_col.enabled == true && long_note_col[17].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-3�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[17].rect.anchoredPosition.y < -18.0f && long_col[17].fin_col.enabled == true && long_note_col[17].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-3�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-4
        if (gameObject.name == "Long_Note4_4")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[18].activeSelf == true || Manager_0.instance.Nor_Note_Log[18].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-4 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[18].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[18].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[18].activeSelf == false && long_col[18].fin_col.enabled == true && long_note_col[18].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-4�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[18].rect.anchoredPosition.y < -18.0f && long_col[18].fin_col.enabled == true && long_note_col[18].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-4�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-5
        if (gameObject.name == "Long_Note4_5")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[21].activeSelf == true || Manager_0.instance.Nor_Note_Log[21].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-5 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[21].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[21].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[21].activeSelf == false && long_col[21].fin_col.enabled == true && long_note_col[21].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-5�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[21].rect.anchoredPosition.y < -18.0f && long_col[21].fin_col.enabled == true && long_note_col[21].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-5�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-6
        if (gameObject.name == "Long_Note4_6")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[22].activeSelf == true || Manager_0.instance.Nor_Note_Log[22].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-6 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[22].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[22].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[22].activeSelf == false && long_col[22].fin_col.enabled == true && long_note_col[22].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-6�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[22].rect.anchoredPosition.y < -18.0f && long_col[22].fin_col.enabled == true && long_note_col[22].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-6�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-7
        if (gameObject.name == "Long_Note4_7")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[23].activeSelf == true || Manager_0.instance.Nor_Note_Log[23].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-7 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[23].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[23].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[23].activeSelf == false && long_col[23].fin_col.enabled == true && long_note_col[23].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-7�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[23].rect.anchoredPosition.y < -18.0f && long_col[23].fin_col.enabled == true && long_note_col[23].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-7�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-8
        if (gameObject.name == "Long_Note4_8")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[28].activeSelf == true || Manager_0.instance.Nor_Note_Log[28].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-8 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[28].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[28].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[28].activeSelf == false && long_col[28].fin_col.enabled == true && long_note_col[28].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-8�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[28].rect.anchoredPosition.y < -18.0f && long_col[28].fin_col.enabled == true && long_note_col[28].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-8�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-9
        if (gameObject.name == "Long_Note4_9")
        {
            if (canBePressed == true)
            {
               /* if ((Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[29].activeSelf == true || Manager_0.instance.Nor_Note_Log[29].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-9 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[29].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[29].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[29].activeSelf == false && long_col[29].fin_col.enabled == true && long_note_col[29].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-9�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[29].rect.anchoredPosition.y < -18.0f && long_col[29].fin_col.enabled == true && long_note_col[29].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-9�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-10
        if (gameObject.name == "Long_Note4_10")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[30].activeSelf == true || Manager_0.instance.Nor_Note_Log[30].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-10 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[30].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[30].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[30].activeSelf == false && long_col[30].fin_col.enabled == true && long_note_col[30].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-10�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[30].rect.anchoredPosition.y < -18.0f && long_col[30].fin_col.enabled == true && long_note_col[30].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-10�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-11
        if (gameObject.name == "Long_Note4_11")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[32].activeSelf == true || Manager_0.instance.Nor_Note_Log[32].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-11 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[32].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[32].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[32].activeSelf == false && long_col[32].fin_col.enabled == true && long_note_col[32].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-11�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[32].rect.anchoredPosition.y < -18.0f && long_col[32].fin_col.enabled == true && long_note_col[32].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-11�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-12
        if(gameObject.name == "Long_Note4_12")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[35].activeSelf == true || Manager_0.instance.Nor_Note_Log[35].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-12 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[35].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[35].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[35].activeSelf == false && long_col[35].fin_col.enabled == true && long_note_col[35].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-12�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[35].rect.anchoredPosition.y < -18.0f && long_col[35].fin_col.enabled == true && long_note_col[35].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-12�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //4-13
        if (gameObject.name == "Long_Note4_13")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[38].activeSelf == true || Manager_0.instance.Nor_Note_Log[38].activeSelf == false))
                {
                    if (Button_4_Pressed == true && no_hit_4 == 0)
                    {

                        Debug.Log("4-13 ������ �ֱ���");
                        no_hit_4 = 0;
                        long_col[38].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[38].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[38].activeSelf == false && long_col[38].fin_col.enabled == true && long_note_col[38].enabled == true))
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-13�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[38].rect.anchoredPosition.y < -18.0f && long_col[38].fin_col.enabled == true && long_note_col[38].enabled == true)
                {
                    if (Button_4_Pressed == false && no_hit_4 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("4-13�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_4 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //5-0
        if (gameObject.name == "Long_Note5_0")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[0].activeSelf == true || Manager_0.instance.Nor_Note_Log[0].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-0 ������ �ֱ���");
                        no_hit_5 = 0;
                        long_col[0].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[0].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[0].activeSelf == false && long_col[0].fin_col.enabled == true && long_note_col[0].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-0�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[0].rect.anchoredPosition.y < -18.0f && long_col[0].fin_col.enabled == true && long_note_col[0].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-0�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //5-1
        if (gameObject.name == "Long_Note5_1")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y == -18.0f)
                     && (Manager_0.instance.Nor_Note_Log[14].activeSelf == true || Manager_0.instance.Nor_Note_Log[14].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-1 ������ �ֱ���");
                        no_hit_5 = 0;
                        long_col[14].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[14].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[14].activeSelf == false && long_col[14].fin_col.enabled == true && long_note_col[14].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-1�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[14].rect.anchoredPosition.y < -18.0f && long_col[14].fin_col.enabled == true && long_note_col[14].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-1�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }

        //5-2
        if (gameObject.name == "Long_Note5_2")
        {
            if (canBePressed == true)
            {
                /*if ((Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y == -18.0f)
                    && (Manager_0.instance.Nor_Note_Log[37].activeSelf == true || Manager_0.instance.Nor_Note_Log[37].activeSelf == false))
                {
                    if (Button_5_Pressed == true && no_hit_5 == 0)
                    {

                        Debug.Log("5-2 ������ �ֱ���");
                        no_hit_5 = 0;
                        long_col[37].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[37].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }

                }*/

                if ((Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y <= -1.86404f && Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y >= -18.0f) &&
                    (Manager_0.instance.Nor_Note_Log[37].activeSelf == false && long_col[37].fin_col.enabled == true && long_note_col[37].enabled == true))
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-2�� ���̾��µ� �߰��� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

                if (Manager_0.instance.Note_1105_Log[37].rect.anchoredPosition.y < -18.0f && long_col[37].fin_col.enabled == true && long_note_col[37].enabled == true)
                {
                    if (Button_5_Pressed == false && no_hit_5 == 0)
                    {
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                        foreach (GameObject obj in objectsWithTag)
                        {
                            Destroy(obj);
                        }

                        Debug.Log("5-2�� ó������ �� ���� + �� ��Ʈ �̽� 1 �߰�");
                        no_hit_5 = 1;
                        Manager_0.instance.Long_Note_Miss++;
                        long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                        long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    }
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ʈ���� �� ��ȿȭgkrh 2d�� �Է��ϰ� ���⿡�� ���� �浹�� ����

        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = true;
            // Debug.Log("�� ��Ʈ ��� ��������");







            //0-1
            /*if (gameObject.name == "Long_Note0_1" && Button_0_Pressed == true)
            {
                if (no_hit_0 == 0 && buttonTouched[0] == true)
                {
                    no_hit_0 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[4].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[4].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_0 == 0 && buttonTouched[0] == false)
                {
                    no_hit_0 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_0 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_0 = 1;
                    long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("0-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note0_1" && Button_0_Pressed == false && no_hit_0 > 0)
            {
                no_hit_0 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note0_1" && buttonTouched[0] == false)
            {
                no_hit_0 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //0-2
            if (gameObject.name == "Long_Note0_2" && Button_0_Pressed == true)
            {
                if (no_hit_0 == 0 && buttonTouched[0] == true)
                {
                    no_hit_0 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[15].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[15].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");



                }

                if (no_hit_0 == 0 && buttonTouched[0] == false)
                {
                    no_hit_0 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_0 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_0 = 1;
                    long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("0-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note0_2" && Button_0_Pressed == false && no_hit_0 > 0)
            {
                no_hit_0 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note0_2" && buttonTouched[0] == false)
            {
                no_hit_0 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-0
            if (gameObject.name == "Long_Note1_0" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[6].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[6].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");



                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("1-0�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_0" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_0" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-1
            if (gameObject.name == "Long_Note1_1" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[8].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[8].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("1-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_1" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_1" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-2
            if (gameObject.name == "Long_Note1_2" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[10].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[10].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("1-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_2" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_2" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-3
            if (gameObject.name == "Long_Note1_3" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[24].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[24].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("1-3�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_3" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;




            }

            if (gameObject.name == "Long_Note1_3" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //1-4
            if (gameObject.name == "Long_Note1_4" && Button_1_Pressed == true)
            {
                if (no_hit_1 == 0 && buttonTouched[1] == true)
                {
                    no_hit_1 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[31].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[31].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

       

                }

                if (no_hit_1 == 0 && buttonTouched[1] == false)
                {
                    no_hit_1 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_1 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_1 = 1;
                    long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("1-4�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note1_4" && Button_1_Pressed == false && no_hit_1 > 0)
            {
                no_hit_1 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note1_4" && buttonTouched[1] == false)
            {
                no_hit_1 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-0
            if (gameObject.name == "Long_Note2_0" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[5].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[5].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-0�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_0" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_0" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-1
            if (gameObject.name == "Long_Note2_1" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[20].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[20].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_1" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_1" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-2
            if (gameObject.name == "Long_Note2_2" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_2" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_2" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-3
            if (gameObject.name == "Long_Note2_3" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[25].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[25].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-3�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_3" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_3" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-4
            if (gameObject.name == "Long_Note2_4" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[26].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[26].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");



                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-4�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_4" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_4" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-5
            if (gameObject.name == "Long_Note2_5" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[33].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[33].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");



                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-5�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_5" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note2_5" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //2-6
            if (gameObject.name == "Long_Note2_6" && Button_2_Pressed == true)
            {
                if (no_hit_2 == 0 && buttonTouched[2] == true)
                {
                    no_hit_2 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[34].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[34].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_2 == 0 && buttonTouched[2] == false)
                {
                    no_hit_2 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_2 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_2 = 1;
                    long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("2-6�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note2_6" && Button_2_Pressed == false && no_hit_2 > 0)
            {
                no_hit_2 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;

            }

            if (gameObject.name == "Long_Note2_6" && buttonTouched[2] == false)
            {
                no_hit_2 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-0
            if (gameObject.name == "Long_Note3_0" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[7].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[7].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-0�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_0" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_0" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-1
            if (gameObject.name == "Long_Note3_1" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[9].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[9].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");



                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_1" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }


                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_1" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-2
            if (gameObject.name == "Long_Note3_2" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[11].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[11].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_2" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_2" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-3
            if (gameObject.name == "Long_Note3_3" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[13].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[13].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-3�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_3" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;

            }

            if (gameObject.name == "Long_Note3_3" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-4
            if (gameObject.name == "Long_Note3_4" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[19].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[19].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-4�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_4" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_4" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-5
            if (gameObject.name == "Long_Note3_5" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[27].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[27].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-5�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_5" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_5" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //3-6
            if (gameObject.name == "Long_Note3_6" && Button_3_Pressed == true)
            {
                if (no_hit_3 == 0 && buttonTouched[3] == true)
                {
                    no_hit_3 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[36].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[36].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_3 == 0 && buttonTouched[3] == false)
                {
                    no_hit_3 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_3 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_3 = 1;
                    long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("3-6�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note3_6" && Button_3_Pressed == false && no_hit_3 > 0)
            {
                no_hit_3 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note3_6" && buttonTouched[3] == false)
            {
                no_hit_3 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //4-0
            if (gameObject.name == "Long_Note4_0" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[2].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[2].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-0�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_0" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;


            }

            if (gameObject.name == "Long_Note4_0" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("0-0�ճ�Ʈ �̽�");
                long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }

            //4-1
            if (gameObject.name == "Long_Note4_1" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[3].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[3].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                     // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_1" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_1" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            

            //4-2
            if (gameObject.name == "Long_Note4_2" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[16].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[16].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                     // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_2" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_2" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-3
            if (gameObject.name == "Long_Note4_3" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[17].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[17].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-3�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_3" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_3" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-4
            if (gameObject.name == "Long_Note4_4" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[18].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[18].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-4�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_4" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_4" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-5
            if (gameObject.name == "Long_Note4_5" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[21].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[21].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-5�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_5" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_2" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-6
            if (gameObject.name == "Long_Note4_6" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[22].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[22].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-6�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_6" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_6" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-7
            if (gameObject.name == "Long_Note4_7" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[23].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[23].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-7�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_7" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_7" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-8
            if (gameObject.name == "Long_Note4_8" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[28].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[28].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-8�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_8" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_8" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-9
            if (gameObject.name == "Long_Note4_9" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[29].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[29].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-9�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_9" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_9" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-10
            if (gameObject.name == "Long_Note4_10" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[30].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[30].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-10�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_10" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_10" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-11
            if (gameObject.name == "Long_Note4_11" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[32].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[32].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-11�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_11" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_11" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-12
            if (gameObject.name == "Long_Note4_12" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[35].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[35].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-12�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_12" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_12" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //4-13
            if (gameObject.name == "Long_Note4_13" && Button_4_Pressed == true)
            {
                if (no_hit_4 == 0 && buttonTouched[4] == true)
                {
                    no_hit_4 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[38].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[38].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                                                      // Debug.Log("5-0�ճ�Ʈ ����");
       

                }

                if (no_hit_4 == 0 && buttonTouched[4] == false)
                {
                    no_hit_4 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_4 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_4 = 1;
                    long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("4-13�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note4_13" && Button_4_Pressed == false && no_hit_4 > 0)
            {
                no_hit_4 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            if (gameObject.name == "Long_Note4_13" && buttonTouched[4] == false)
            {
                no_hit_4 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

            }

            //5-0
            if (gameObject.name == "Long_Note5_0" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[0].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[0].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                   // Debug.Log("5-0�ճ�Ʈ ����");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                   // Long_Col.instance.fin_col.enabled = false;
                    long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-0�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("5-0�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_0" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
               // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_0" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                //Debug.Log("5-0�ճ�Ʈ �̽�");
                long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }


            //5-1
            if (gameObject.name == "Long_Note5_1" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[14].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[14].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("5-1�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;

                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_1" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_1" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                Debug.Log("5-1�ճ�Ʈ �̽�");
                long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }


            //5-2
            if (gameObject.name == "Long_Note5_2" && Button_5_Pressed == true)
            {
                if (no_hit_5 == 0 && buttonTouched[5] == true)
                {
                    no_hit_5 = 0;
                    //Long_Col.instance.fin_col.enabled = true;
                    long_col[37].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[37].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ ����");

                }

                if (no_hit_5 == 0 && buttonTouched[5] == false)
                {
                    no_hit_5 = 1;
                    // Long_Col.instance.fin_col.enabled = false;
                    long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    //Debug.Log("5-1�ճ�Ʈ �̽���");
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }

                }

                if (no_hit_5 > 0)
                {

                    //Long_Col.instance.fin_col.enabled = false;
                    no_hit_5 = 1;
                    long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                    Debug.Log("5-2�ճ�Ʈ �̽� Long_Note_Miss");
                    Manager_0.instance.Long_Note_Miss++;
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }

            }

            if (gameObject.name == "Long_Note5_2" && Button_5_Pressed == false && no_hit_5 > 0)
            {
                no_hit_5 = 1;
                //Long_Col.instance.fin_col.enabled = false;
                long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                //Debug.Log("5-0�ճ�Ʈ �̽� ����");
                // Manager_0.instance.Long_Note_Miss++;
            }

            if (gameObject.name == "Long_Note5_2" && buttonTouched[5] == false)
            {
                no_hit_5 = 1;
                Debug.Log("5-2�ճ�Ʈ �̽�");
                long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                //Long_Col.instance.fin_col.enabled = false;
                //isButtonTouchedOnce[5] = true;//��ġ ���θ� true
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }
        }

        else
        {
            canBePressed = false; // �ٸ� �±׿� �浹 �� �ʱ�ȭ
        }*/
        }
    }

   
}
        
