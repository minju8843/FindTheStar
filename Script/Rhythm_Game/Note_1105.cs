using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Note_1105 : MonoBehaviour
{

    public Animator anim;//�߰�
    public int anim_count = 0;

    public float beatTempo;//��Ʈ�� �󸶳� ���� ����������//Beat_Scroller���� ������
    public bool hasStarted;//Beat_Scroller���� ������

    public bool canBePressed = false;//
   // public KeyCode keyToPress;//�� ȭ��ǥ�� ���� Ű�ڵ�

    public GameObject Effect_0, Effect_1, Effect_2, Effect_3, Effect_4, Effect_5;//��ư ������ �� ������ ����Ʈ

    public GameObject Long_Effect_0, Long_Effect_1, Long_Effect_2, Long_Effect_3, Long_Effect_4, Long_Effect_5;//�� ��Ʈ ������ �� ������ ����Ʈ

    //public GameObject Combo_Effect;

    public static Note_1105 instance;//���� ������ ���� ������ ����

    public RectTransform rect;

    //public Button[] btn;

    public Transform parentCanvasTransform;

    public bool Button_0_Pressed = false;
    public bool Button_1_Pressed = false;
    public bool Button_2_Pressed = false;
    public bool Button_3_Pressed = false;
    public bool Button_4_Pressed = false;
    public bool Button_5_Pressed = false;

    //public Long_Note long_note;

    //public bool[] Long_Note_Miss = new bool[39];//�ճ�Ʈ �̽����� �ƴ����� ���� bool

    /*public void YourClassName() //�ճ�Ʈ �̽� ���� ó���� ��� false�� ���·�
    {
        for (int i = 0; i < Long_Note_Miss.Length; i++)
        {
            Long_Note_Miss[i] = false; // ��� ���� false�� �ʱ�ȭ -> ��� �̽��� �ƴ� ����
        }
    }*/

    void Start()
    {
        beatTempo = beatTempo/2f;
        //������ ��Ʈ ������ ����ؾ� ��
        //60���� ��������
        //��ΰ� beatTempo�� beatTempo/60�� �Ͱ� ���ٰ� �� ���� 
        //�׷��� �̰� �ʴ� �󸶳� ���� �������� �ϴ��� �� �� �ִ�.
        //120���� �ʴ� 2������ ������ ���̶�� ���ϸ� ������ 60���� ���� ���̴�.
        //�׷��� �ʴ� �󸶳� ���� �����̴��� �� �� �ִ�.
        //->Update���� else�� �̵�

        instance = this;



    }

    public void Update()
    {


        /* if (hasStarted == true)
         {

             //���� �ּ� ���µ�, Winter_Music �� �ٸ� ������ ������
             if (rect.anchoredPosition.y > -18.58201)//-24.9f)//0.012f)//&& gameObject.name != "�� ��Ʈ �׽�Ʈ5_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0")//0.01222
             {
                 rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);

                 //Debug.Log("���� �̽� �ƴ�");

                 //������ �Ǿ����� ���� ���� �� �Ʒ����� ���� ���� ���
             }

             //Debug.Log(rect.anchoredPosition.y);

             //Debug.Log("Long_Note_5:"transform.position.y);

             //126.6246�� ��ư ������ �ٷ� ���� ��ġ

             //126.0489�� ������ ��ư�� ��¦ ����� �� -> ��
             //107.7897�� �Ʒ����� ��ư�� ��¦ ����� �� -> ��

             //117.4809 �� ���� ���

             //120.7801�� ������ ����Ʈ ��� ����
             //114.1941�� �Ʒ����� ����Ʈ ��� ����


             //106.272�� Ǫ���� ��ư ���� �ٷ� �ؿ�, 106.6422
         }*/

        if (rect.anchoredPosition.y > -18.58201)//-24.9f)//0.012f)//&& gameObject.name != "�� ��Ʈ �׽�Ʈ5_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0")//0.01222
        {
            if(Winter_Music.instance.Pause.activeSelf == true || Winter_Music.instance.keep_speed == false)
            {
                //���� â�� �����ִٸ�
                rect.anchoredPosition -= new Vector2(0f, 0 * Time.deltaTime);
                anim_count = 0;
            }

            if(Winter_Music.instance.Pause.activeSelf == false && Winter_Music.instance.keep_speed == true)
            {
                //���� â�� �����ִٸ�
                rect.anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
                anim_count = 0;
            }

            //Debug.Log("���� �̽� �ƴ�");

            //������ �Ǿ����� ���� ���� �� �Ʒ����� ���� ���� ���
        }


        //�Ϲ� ������Ʈ �����ϰ�
        if (rect.anchoredPosition.y <= -18.58201f && anim_count == 0 && Winter_Music.instance.keep_speed == true)//0.01222
        {

            StartCoroutine(Go_Empty());

            IEnumerator Go_Empty()
            {
                yield return new WaitForSeconds(0.07f);

                anim.SetTrigger("Empty");
                anim_count++;
                //Debug.Log("���������� �ִϸ��̼� ����");

                Button_0_Pressed = false;
                Button_1_Pressed = false;
                Button_2_Pressed = false;
                Button_3_Pressed = false;
                Button_4_Pressed = false;
                Button_5_Pressed = false;

                StartCoroutine(Go_Empty1());
            }

            IEnumerator Go_Empty1()
            {
                yield return new WaitForSeconds(0.35f);//�ִϸ��̼� �ӵ� + 0.05����
                { 
                
                    gameObject.SetActive(false);                               // gameObject.SetActive(false);
                    anim_count = 0;

                    
                }
                
            }

            //Debug.Log("transform.position.y :" + transform.position.y);


        }



        //Ű�� ������ 
        if (canBePressed)
        {



            //�� ��Ʈ 0-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ0_0" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 0-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[1].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[1].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 0-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[1].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[1].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

            }

            //0-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ0_1" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 0-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[4].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[4].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 0-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[4].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[4].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;
  
                }

            }

            //0-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ0_2" && Button_0_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 0-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[15].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[15].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 0-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[15].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[15].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Long_Effect_0.transform.rotation;

                }

            }

            //1-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ1_0" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 1-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }


                    Long_Note.instance.long_col[6].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[6].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 1-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[6].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[6].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ1_1" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 1-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[8].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[8].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 1-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[8].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[8].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ1_2" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 1-2��Ʈ�߼��̴�");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[10].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[10].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 1-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[10].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[10].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-3
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ1_3" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("�� ��Ʈ 1-3��Ʈ�߼��̴�");
                    gameObject.SetActive(false);


                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    Debug.Log("�� ��Ʈ 1-3��Ʈ�߼��̴�");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //1-4
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ1_4" && Button_1_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 1-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[31].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[31].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 1-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[31].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[31].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Long_Effect_1.transform.rotation;

                }

            }

            //2-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_0" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[5].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[5].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[5].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[5].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_1" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[20].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[20].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[20].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[20].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_2" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[12].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[12].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-3
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_3" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[25].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[25].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[25].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[25].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-4
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_4" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[26].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[26].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[26].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[26].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-5
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_5" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[33].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[33].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[33].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[33].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //2-6
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ2_6" && Button_2_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 2-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[34].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[34].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 2-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[34].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[34].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Long_Effect_2.transform.rotation;

                }

            }

            //3-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_0" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-0��Ʈ�߼��̴�");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[7].long_col[7].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[7].long_note_col[7].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[7].long_col[7].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[7].long_note_col[7].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_1" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 3-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[9].long_col[9].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[9].long_note_col[9].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[9].long_col[9].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[9].long_note_col[9].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_2" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-2��Ʈ�߼��̴�");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[11].long_col[11].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[11].long_note_col[11].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[11].long_col[11].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[11].long_note_col[11].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-3
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_3" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 3-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[13].long_col[13].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[13].long_note_col[13].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[13].long_col[13].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[13].long_note_col[13].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-4
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_4" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 3-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Manager_0.instance.long_note[19].long_col[19].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Manager_0.instance.long_note[19].long_note_col[19].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[19].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[19].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-5
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_5" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 3-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[27].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[27].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[27].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[27].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }

            //3-6
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ3_6" && Button_3_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 3-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[36].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[36].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 3-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[36].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[36].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Long_Effect_3.transform.rotation;

                }

            }



            //�� ��Ʈ 4-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_0" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                //-2.86404f
                //-17.58401

                /*if ((transform.position.y < 49.51384f && transform.position.y > 49.51339f) ||
                      (transform.position.y > 49.51233f && transform.position.y < 49.51286f))//�ճ�Ʈ ����
               */
                {
                    //49.51374 -> 49.51384
                    //Debug.Log("�� ��Ʈ 5-0��Ʈ�߼��̴�");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;

                    // UI_GameManager.instance.Good_Hit();
                    //UI_GameManager.instance.Good_Hits++;
                    Debug.Log("�� ��Ʈ 4-0��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                       // Debug.Log("4-0 ��");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        //Debug.Log("4-0 ��2");
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[2].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[2].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;


                    //Debug.Log("����Ʈ4 ���� Ȯ��-�ճ�Ʈ �� ��Ʈ");

                    //Long_Note.instance.long_note_5_0 = true;//�� ��Ʈ �ڿ� �ִ� ��� ģ�� ����(��Ʈ �ɰ���)

                    //����ũ Ȱ��ȭ -> �ֳ��ϸ� ���������ϱ� ��Ʈ�� �� �κ��� �Ⱥ����� ��
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {

                    // Debug.Log("�� ��Ʈ ġ�� ����");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;
                    // Debug.Log("�� ��Ʈ 5-0 ����Ʈ ��Ʈ�߼��̴�");
                    Debug.Log("�� ��Ʈ 4-0��Ʈ�߼��̴�");
                    //��� ��Ȱ�� 0823
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);

                        //Debug.Log("4-0 ����Ʈ");
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                        //Debug.Log("4-0 ����Ʈ2");
                    }

                    Long_Note.instance.long_col[2].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[2].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��
                    //Debug.Log("����Ʈ4 ���� Ȯ��-�ճ�Ʈ ����Ʈ ��Ʈ");
                    // Debug.Log("���� ������Ʈ�� �̸��� '�� �����'�Դϴ�.");
                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;
                    //Debug.Log("����Ʈ5 ���� Ȯ��-�ճ�Ʈ ����Ʈ ��Ʈ");

                    //Long_Note.instance.long_note_5_0 = true;//�� ��Ʈ �ڿ� �ִ� ��� ģ�� ����(��Ʈ �ɰ���)

                    //����ũ Ȱ��ȭ -> �ֳ��ϸ� ���������ϱ� ��Ʈ�� �� �κ��� �Ⱥ����� ��
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;
                }
                //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);

            }

            

            //4-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_1" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[3].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[3].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[3].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[3].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_2" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[16].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[16].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[16].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[16].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-3
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_3" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[17].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[17].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-3��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[17].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[17].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-4
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_4" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[18].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[18].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-4��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[18].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[18].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-5
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_5" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[21].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[21].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-5��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[21].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[21].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-6
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_6" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[22].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[22].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-6��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[22].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[22].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-7
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_7" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-7��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[23].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[23].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-7��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[23].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[23].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-8
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_8" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-8��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[28].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[28].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-8��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[28].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[28].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-9
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_9" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-9��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[29].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[29].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-9��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[29].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[29].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-10
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_10" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-10��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[30].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[30].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-10��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[30].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[30].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-11
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_11" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-11��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[32].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[32].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-11��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[32].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[32].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-12
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_12" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {

                    gameObject.SetActive(false);

                    Debug.Log("�� ��Ʈ 4-12��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[35].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[35].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 4-12��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[35].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[35].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }

            //4-13
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ4_13" && Button_4_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("�� ��Ʈ 4-13��Ʈ�߼��̴�");
                    gameObject.SetActive(false);


                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[38].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[38].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    Debug.Log("�� ��Ʈ 4-13��Ʈ�߼��̴�");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[38].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[38].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Long_Effect_4.transform.rotation;

                }

            }


            //�ճ�Ʈ 5-0
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ5_0" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                //-2.86404f
                //-17.58401

                /*if ((transform.position.y < 49.51384f && transform.position.y > 49.51339f) ||
                      (transform.position.y > 49.51233f && transform.position.y < 49.51286f))//�ճ�Ʈ ����
               */
                {
                    //49.51374 -> 49.51384
                    Debug.Log("�� ��Ʈ 5-0��Ʈ�߼��̴�");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;

                    // UI_GameManager.instance.Good_Hit();
                    //UI_GameManager.instance.Good_Hits++;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[0].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[0].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
                    //Debug.Log("����Ʈ5 ���� Ȯ��-�ճ�Ʈ �� ��Ʈ");

                    //Long_Note.instance.long_note_5_0 = true;//�� ��Ʈ �ڿ� �ִ� ��� ģ�� ����(��Ʈ �ɰ���)

                    //����ũ Ȱ��ȭ -> �ֳ��ϸ� ���������ϱ� ��Ʈ�� �� �κ��� �Ⱥ����� ��
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {

                    // Debug.Log("�� ��Ʈ ġ�� ����");
                    gameObject.SetActive(false);
                    //Button_1_Pressed = false;
                     Debug.Log("�� ��Ʈ 5-0 ����Ʈ ��Ʈ�߼��̴�");

                    //��� ��Ȱ�� 0823
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[0].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[0].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    // Debug.Log("���� ������Ʈ�� �̸��� '�� �����'�Դϴ�.");
                    //Instantiate(Long_Effect_5, new Vector3(487.0f, 63.0f, 0f), Long_Effect_5.transform.rotation);


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
                    //Debug.Log("����Ʈ5 ���� Ȯ��-�ճ�Ʈ ����Ʈ ��Ʈ");

                    //Long_Note.instance.long_note_5_0 = true;//�� ��Ʈ �ڿ� �ִ� ��� ģ�� ����(��Ʈ �ɰ���)

                    //����ũ Ȱ��ȭ -> �ֳ��ϸ� ���������ϱ� ��Ʈ�� �� �κ��� �Ⱥ����� ��
                    //Manager_0.instance.Long_Line_Mask[5].enabled = true;
                }
                //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);

            }

            //5-1
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ5_1" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("�� ��Ʈ 5-1��Ʈ�߼��̴�");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[14].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[14].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
  

                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 5-1��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[14].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[14].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;
   
                }


            }

            //5-2
            if (gameObject.name == "�� ��Ʈ �׽�Ʈ5_2" && Button_5_Pressed == true)
            {
                if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                  (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f))
                {
                    Debug.Log("�� ��Ʈ 5-2��Ʈ�߼��̴�");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[37].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[37].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��


                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;


                }

                if ((transform.position.y <= -7.446072f && transform.position.y >= -15.325f))
                {
                    gameObject.SetActive(false);
                    Debug.Log("�� ��Ʈ 5-2��Ʈ�߼��̴�");
                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    else if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    Long_Note.instance.long_col[37].fin_col.enabled = true;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                    Long_Note.instance.long_note_col[37].enabled = true; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� Ȱ��

                    GameObject newEffect = Instantiate(Long_Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Long_Effect_5.transform.rotation;

                }


            }

            //������� �Ϲ� ��Ʈ
            if ((rect.anchoredPosition.y <= -1.86404f && rect.anchoredPosition.y > -7.446072f) ||
                 (rect.anchoredPosition.y >= -18.0f && rect.anchoredPosition.y < -15.325f)
                && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_7"

                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_3" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_8" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_9"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_10" && gameObject.name != "�� ��Ʈ �׽�Ʈ1_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_11" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_12"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ3_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_13")
       
            {
                

                if (Button_0_Pressed == true
                    )

                {
                    Debug.Log("0 ��Ʈ �� ��Ʈ");

                    gameObject.SetActive(false);
                    Button_0_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Effect_0.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                if (Button_1_Pressed == true
                    )

                /*&& gameObject.name != "�� ��Ʈ �׽�Ʈ5_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"*/
                {
                    Debug.Log("1 ��Ʈ �� ��Ʈ");
                    gameObject.SetActive(false);
                    Button_1_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Effect_1.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }


                if (Button_2_Pressed == true
                    )
                {
                    Debug.Log("2 ��Ʈ �� ��Ʈ");
                    gameObject.SetActive(false);
                    Button_2_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Effect_2.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                /*if (Button_3_Pressed == true)
                {

                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_3, new Vector3(11.58f, 2.784f, -0.062f), Effect_3.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[3].enabled = false;
                }*/

                if (Button_3_Pressed == true
                    )

                /*&& gameObject.name != "�� ��Ʈ �׽�Ʈ5_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"*/
                {
                    Debug.Log("3 ��Ʈ �� ��Ʈ");
                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

                if (Button_4_Pressed == true)
                {
                    Debug.Log("4 ��Ʈ �� ��Ʈ");
                    gameObject.SetActive(false);
                    Button_4_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_4, new Vector3(15.414f, 2.773f, -0.079f), Effect_4.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Effect_4.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    // Manager_0.instance.Long_Line_Mask[4].enabled = false;
                }

                if (Button_5_Pressed == true
                    )

                    /*&& gameObject.name != "�� ��Ʈ �׽�Ʈ5_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0"
                    && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"*/
                {
                    Debug.Log("5 ��Ʈ �� ��Ʈ");
                    gameObject.SetActive(false);
                    Button_5_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(true);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Good_Hit();
                        Manager_0.instance.Good_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Effect_5.transform.rotation;


                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }

            }

            /*
             *((transform.position.y > 139.0783f && transform.position.y <= 146.7998f) ||
                 (transform.position.y >= 82.94745f && transform.position.y < 89.55161f))*/

            //����Ʈ ��Ʈ
            if (rect.anchoredPosition.y <= -7.446072f && rect.anchoredPosition.y >= -15.325f
               && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_7"

                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_3" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_8" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_9"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_10" && gameObject.name != "�� ��Ʈ �׽�Ʈ1_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_11" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_12"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ3_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_13") //(transform.position.y <= 29.90797f && transform.position.y <= 44.29614f)
            {

                //0821 - ���� �� ��ǥrect.anchoredPosition.y < 0.01387f && rect.anchoredPosition.y > 0.01307201f
                /*((transform.position.y < -3.297036f && transform.position.y > -3.477036f) ||
                 (transform.position.y > -4.34f && transform.position.y < -4.127036f))
                 */

                //���� ��ǥ
                //(transform.position.y < -3.467036 && transform.position.y > -3.637036)

                //-4.24 ~ -4.18
                //-4.46 ~ -4.39

                //-4.2 ~ -4.38


                //�޺� ����Ʈ
                //Instantiate(Combo_Effect, new Vector3(8.626f, 0.817f, 0.0f), Combo_Effect.transform.rotation);

                /* Debug.Log("�Ϻ��ϰ� ����");
                 gameObject.SetActive(false);
                 UI_GameManager.instance.Perfect_Hit();

                 UI_GameManager.instance.Perfect_Hits++;*/


                //PC��ư
                if (Button_0_Pressed == true)
                {
                    Debug.Log("0 ��Ʈ ����Ʈ ��Ʈ");
                    gameObject.SetActive(false);

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }


                    // 'A' Ű�� ������ �� ������ �ڵ�
                    //Instantiate(Effect_0, new Vector3(0f, -0.031f, 0.02f), Effect_0.transform.rotation);
                    //Instantiate(Effect_0, new Vector3(-508f, 63.0f, 0f), Effect_0.transform.rotation);//-0.031 //1.0
                    GameObject newEffect = Instantiate(Effect_0, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-508f, 63f);
                    rectTransform.localRotation = Effect_0.transform.rotation;

                    Button_0_Pressed = false;

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[0].enabled = false;
                }

                //�����


                if (Button_1_Pressed == true)
                {
                    Debug.Log("1 ��Ʈ ����Ʈ ��Ʈ");
                    gameObject.SetActive(false);
                    Button_1_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_1, new Vector3(3.81f, 2.8f, -0.03f), Effect_1.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_1, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-311f, 63f);
                    rectTransform.localRotation = Effect_1.transform.rotation;

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[1].enabled = false;
                }

                if (Button_2_Pressed == true)
                {
                    gameObject.SetActive(false);
                    Button_2_Pressed = false;

                    Debug.Log("2 ��Ʈ ����Ʈ ��Ʈ");

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_2, new Vector3(7.723f, 2.801f, -0.045f), Effect_2.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_2, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(-114.5f, 63f);
                    rectTransform.localRotation = Effect_2.transform.rotation;

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[2].enabled = false;
                    // Destroy(gameObject);
                }

                if (Button_3_Pressed == true)
                {
                    Debug.Log("3 ��Ʈ ����Ʈ ��Ʈ");
                    gameObject.SetActive(false);
                    Button_3_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //Instantiate(Effect_3, new Vector3(11.58f, 2.784f, -0.062f), Effect_3.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_3, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(89.7f, 63f);
                    rectTransform.localRotation = Effect_3.transform.rotation;

                    //Destroy(gameObject);

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[3].enabled = false;
                }

                if (Button_4_Pressed == true)
                {
                    Debug.Log("4 ��Ʈ ����Ʈ ��Ʈ");
                    gameObject.SetActive(false);
                    Button_4_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //UI_GameManager.instance.Perfect_Hit();
                    //UI_GameManager.instance.Perfect_Hits++;

                    //Instantiate(Effect_4, new Vector3(15.414f, 2.773f, -0.079f), Effect_4.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_4, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(280.8f, 63f);
                    rectTransform.localRotation = Effect_4.transform.rotation;


                    //Destroy(gameObject);

                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[4].enabled = false;

                }

                if (Button_5_Pressed == true)
                {
                    Debug.Log("5 ��Ʈ ����Ʈ ��Ʈ");
                    gameObject.SetActive(false);
                    Button_5_Pressed = false;

                    if (Manager_0.instance.Combo_Count >= 1)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;

                        Manager_0.instance.Perfect_Combo_Effect.SetActive(true);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }

                    if (Manager_0.instance.Combo_Count == 0)
                    {
                        Manager_0.instance.Perfect_Hit();
                        Manager_0.instance.Perfect_Hits++;
                        Manager_0.instance.Perfect_Combo_Effect.SetActive(false);
                        Manager_0.instance.Normal_Combo_Effect.SetActive(false);
                    }
                    //UI_GameManager.instance.Perfect_Hit();
                    //UI_GameManager.instance.Perfect_Hits++;


                    //Instantiate(Effect_5, new Vector3(19.271f, 2.762f, -0.096f), Effect_5.transform.rotation);
                    GameObject newEffect = Instantiate(Effect_5, parentCanvasTransform);
                    RectTransform rectTransform = newEffect.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(487f, 63f);
                    rectTransform.localRotation = Effect_5.transform.rotation;



                    //����ũ ��Ȱ��ȭ -> �ֳ��ϸ� ���� ��Ʈ�� �ճ�Ʈ�� ���� �����ϱ�
                    //Manager_0.instance.Long_Line_Mask[5].enabled = false;
                }


            }

        }

    }


    //��Ʈ�� ��ư ������ ���� ��,
    //�ٽ� ��ȯ�� �� Ȯ��

    //Ʈ���� ������ ������ Ȯ���ϰ� �׷��ٸ� �� �� �ִٰ� ���ϴ� ��

    //���� ��ư�� ������ �ش� ��ư�� ���ð��� ��������.
    //ȭ��ǥ�� �����ϰ� �׷��� ������ �� �̻� ���� �� ����.

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ʈ���� �� ��ȿȭgkrh 2d�� �Է��ϰ� ���⿡�� ���� �浹�� ����

        if (other.tag == "Finish")//(other.tag == "Note")
        {
            //�ٸ� �±װ� ������ activator��� �� ��° �±׿� �� �� �±׸� ����
            //�̰� �ٷ� ��ư�� �� ��

            canBePressed = true;
            //Activator�±��� ��� ���ο� bool�� �����Ͽ� 
            //canBePressed�� true�� ���ٰ��ϰ�
            //�Է��� �� ���� �� �ִ��� Ȯ��
            //
            //Debug.Log("��������");


        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")//(other.tag == "Note")
        {
            canBePressed = false;
            //OnTriggerExit2D�� ������ false�� ����

            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ0_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[1].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[1].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[1].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[1].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

            }

            //0-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ0_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[4].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[4].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[4].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[4].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //0-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ0_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 0-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[15].no_hit_0 == 1)
                {
                    Debug.Log("Note_1105 0-2 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[15].no_hit_0 = 1;
                    Debug.Log("Note_1105 0-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[15].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[15].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //1-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ1_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[6].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[6].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[6].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[6].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //1-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ1_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[8].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[8].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[8].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[8].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //1-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ1_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[10].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-2 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[10].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[10].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[10].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //1-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ1_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 1-3 �̽� ��Ʈ �߰�");


                if (Manager_0.instance.long_note[24].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-3 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[24].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-3�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[24].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[24].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //1-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ1_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 1-4 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[31].no_hit_1 == 1)
                {
                    Debug.Log("Note_1105 1-4 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[31].no_hit_1 = 1;
                    Debug.Log("Note_1105 1-4�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[31].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[31].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[5].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[5].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[5].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[5].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 2-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[20].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[20].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[20].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[20].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[12].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-2 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[12].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[12].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[12].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-3 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[25].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-3 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[25].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-3�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[25].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[25].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-4 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[26].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-4 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[26].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-4�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[26].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[26].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-5 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[33].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-5 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[33].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-5�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[33].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[33].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //2-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ2_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 2-6 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[34].no_hit_2 == 1)
                {
                    Debug.Log("Note_1105 2-6 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[34].no_hit_2 = 1;
                    Debug.Log("Note_1105 2-6�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[34].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[34].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[7].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[7].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[7].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[7].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[9].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[9].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[9].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[9].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[11].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-2 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[11].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[11].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[11].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-3 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[13].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-3 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[13].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-3�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[13].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[13].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-4 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[19].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-4 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[19].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-4�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[19].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[19].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-5 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[27].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-5 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[27].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-5�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[27].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[27].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //3-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ3_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 3-6 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[36].no_hit_3 == 1)
                {
                    Debug.Log("Note_1105 3-6 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[36].no_hit_3 = 1;
                    Debug.Log("Note_1105 3-6�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[36].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[36].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 4-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[2].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[2].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[2].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[2].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;

                Debug.Log("Note_1105 4-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[3].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[3].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[3].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[3].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_2")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[16].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-2�̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[16].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[16].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[16].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-3
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_3")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-3 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[17].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-3 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[17].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-3�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[17].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[17].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-4
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_4")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-4 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[18].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-4 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[18].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-4�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[18].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[18].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-5
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_5")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-5 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[21].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-5 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[21].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-5�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[21].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[21].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-6
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_6")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-6 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[22].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-6 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[22].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-6�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[22].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[22].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-7
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_7")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-7 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[23].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-7 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[23].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-7�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[23].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[23].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-8
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_8")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-8 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[28].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-8 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[28].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-8�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[28].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[28].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-9
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_9")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-8 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[29].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-9 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[29].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-9�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[29].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[29].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-10
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_10")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-10 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[30].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-10 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[30].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-10�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[30].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[30].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-11
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_11")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-11 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[32].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-11 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[32].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-11�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[32].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[32].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-12
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_12")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-12 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[35].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-12 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[35].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-12�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[35].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[35].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }

            //4-13
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ4_13")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 4-13 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[38].no_hit_4 == 1)
                {
                    Debug.Log("Note_1105 4-13 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[38].no_hit_4 = 1;
                    Debug.Log("Note_1105 4-13�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[38].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[38].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
            }
            //5-0
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ5_0")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-0 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[0].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-0 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[0].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-0�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[0].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[0].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

            }

            //5-1
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ5_1")//-4.431 //-4.44  
            {
                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-1 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[14].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-1 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[14].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-1�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                /* Manager_0.instance.Note_Missed();
                 Manager_0.instance.Miss_Hits++;

                 Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                 Long_Note.instance.no_hit_5++;

                 Long_Note.instance.long_col[14].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                 Long_Note.instance.long_note_col[14].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��
                */
                //Debug.Log("5-1�ճ�Ʈ �̽� �߰�");

            }

            //5-2
            if (rect.anchoredPosition.y <= -18.58201f && gameObject.name == "�� ��Ʈ �׽�Ʈ5_2")//-4.431 //-4.44  
            {

                Manager_0.instance.Note_Missed();
                Manager_0.instance.Miss_Hits++;
                Debug.Log("Note_1105 5-2 �̽� ��Ʈ �߰�");

                if (Manager_0.instance.long_note[37].no_hit_5 == 1)
                {
                    Debug.Log("Note_1105 5-2 �̹� �ճ�Ʈ �̽� ����");
                }
                else
                {
                    Manager_0.instance.Long_Note_Miss++;//�� ��Ʈ ��� �κ� ������ ��ħ
                    Manager_0.instance.long_note[37].no_hit_5 = 1;
                    Debug.Log("Note_1105 5-2�ճ�Ʈ �̽� �߰�");
                }

                Long_Note.instance.long_col[37].fin_col.enabled = false;//�� ��Ʈ ������ �κ��� �ݶ��̴���
                Long_Note.instance.long_note_col[37].enabled = false; //�ճ�Ʈ �߰� �κ��� �ݶ��̴� ��Ȱ��

            }

            if (rect.anchoredPosition.y <= -18.58201f
                && gameObject.name != "�� ��Ʈ �׽�Ʈ5_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_0" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_0"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ0_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_1"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_2" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_1" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_7"

                && gameObject.name != "�� ��Ʈ �׽�Ʈ1_3" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_3"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_4" && gameObject.name != "�� ��Ʈ �׽�Ʈ3_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_8" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_9"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_10" && gameObject.name != "�� ��Ʈ �׽�Ʈ1_4"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_11" && gameObject.name != "�� ��Ʈ �׽�Ʈ2_5"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ2_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ4_12"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ3_6" && gameObject.name != "�� ��Ʈ �׽�Ʈ5_2"
                && gameObject.name != "�� ��Ʈ �׽�Ʈ4_13")//-4.431 //-4.44  
            {//0821-���� �� -4.34
                Manager_0.instance.Note_Missed();
                //���� �Ŵ�����, ���ƴٰ� ����
                //Debug.Log("���� �Ŵ�����, ���ƴٰ� ����");
                Manager_0.instance.Miss_Hits++;
                Debug.Log("*******�Ϲ� ��Ʈ �̽��߼��̴�");


            }



        }

    }

}
