using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Manager_0 : MonoBehaviour
{
    public GameObject[] Nor_Note_Log;//Note_1105�ε� �ճ�Ʈ ��
    public Note_1105[] Note_1105_Log;//Note_1105�ε� �ճ�Ʈ�� ���� �ִ� ��ũ��Ʈ


    public GameObject Result_Panel;//��� â ������Ʈ

    public GameObject Perfect_Combo_Effect;//�޺� ����Ʈ

    public GameObject Normal_Combo_Effect;//��� �޺� ����Ʈ

    public Animator Charming_anim;//���� �ִϸ��̼�
    public GameObject Charming_obj;//���� �۾�

    public TextMeshProUGUI Total_Charming_Text; //�� ���� �ؽ�Ʈ
    public int Total_Charming_Count; //������ �� �� ��° ���Դ���

    public TextMeshProUGUI Total_ScoreText;//�� ����

    public TextMeshProUGUI ScoreText;
    // public TextMeshProUGUI multiText;//�� ��° �õ�����

    public Animator Combo_anim;//�޺� �ִϸ��̼�
    public GameObject Combo_obj;
    public TextMeshProUGUI Combo_Text; //�� ��° �޺����� �ؽ�Ʈ
    public int Combo_Count;//�� ��° �޺�����



    public AudioSource Music_0;//����
    public bool StartPlaying;//���� ��� ȣ��

    public Note_1105[] theBS;//��Ʈ ��ũ�ѷ� ����(Note_Object)
    public Long_Note[] long_note;//Long Lote������Ʈ 
    public Long_Col[] long_note_fin;//Long Lote ���κ� ������Ʈ

    public static Manager_0 instance;//���� ������ ���� ������ ����
    //�ν��Ͻ� ȣ��


    //public int currentMultipiler;//�¼� ����. 
    //public int multiplierTracker;//�¼� ������. �¼� ������� 0���� ������
    //public int[] multiplierThresholds;//�¼� �Ӱ谪 ȣ��


    public float currentScore;//���� ����
    //public float scorePerNote=0.10f;//��Ʈ�� ����

    public float scorePerGoodNote = 2.67208f;//�� ��Ʈ�� ����
    public float scorePerPerfectNote = 5f;//����Ʈ ���� ����




    public float Total_Notes;//���� �ϰ� ���� �� ���� �� ��Ʈ�� ������ ���
    public int Good_Hits;//�� ����
    public int Perfect_Hits;//�Ϻ��ϰ� ����
    public int Miss_Hits;//�� ������
    public int Long_Note_Miss;//�ճ�Ʈ ��� �κ� ������ ��ħ


    public Note_1105[] Line_0;
    public Note_1105[] Line_1;
    public Note_1105[] Line_2;
    public Note_1105[] Line_3;
    public Note_1105[] Line_4;
    public Note_1105[] Line_5;

    private bool hasShownResult = false;

    /*public Button button_0;//��ư ���� Ȯ��
    public Button button_1;//��ư ���� Ȯ��
    public Button button_2;//��ư ���� Ȯ��
    public Button button_3;//��ư ���� Ȯ��
    public Button button_4;//��ư ���� Ȯ��
    public Button button_5;//��ư ���� Ȯ��
    */
    //public TextMeshProUGUI Charming_Total_Text; //Charming�� �� �� ������ �����ִ� �ؽ�Ʈ
    //public int Charming_Total;//Charming�� �� �� �� ���Դ���

    //public Mask[] Long_Line_Mask;//�� ��Ʈ�� ���� �� ������ ���� �� ����� ����ũ

    private void Start()
    {
        //Application.targetFrameRate = 300;//�����Ÿ��� ���� �ذ��ϱ� ���� �ڵ�

       // Winter_Music.instance.Keep_Speed();
        //StartCoroutine(Music_Go());
    

    /*IEnumerator Music_Go()
    {
        yield return new WaitForSeconds(11f);//5�ʺ��ٴ� ũ��
            Winter_Music.instance.Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Music.instance.Winter_Music_Obj[0].SetActive(true);//���� 0��° ���� ������� ��Ȱ��
            Winter_Music.instance.Winter_Music_Audio[0].Play();
    }*/

    /*for (int i = 0; i < Long_Line_Mask.Length; i++)
    {
        //����ũ ��Ȱ��ȭ
        Long_Line_Mask[i].enabled = false;
    }*/


    //Total_Notes = FindObjectsOfType<UI_Note_Object>().Length;//Total_Note�� ������ �ϴ� ������ ��ü�� ã�� �Ͱ� ����.
    //��� ��ü�� ã�� �ͱ� ������ objects
    Result_Panel.SetActive(false);//���� ���â ��Ȱ��


        Total_Charming_Count = 0;//���� ���� ���� ����

        instance = this;
        Combo_obj.SetActive(false);
        Charming_obj.SetActive(false);

        //�̷��� �ϸ� �̰� private(����)���� ���� �� ���� �����ڴ�
        //�ϳ��� ���� ��

        //�� ��� ������ �ϳ��� ���� �� �ִٴ� ��

        ScoreText.text = "0.00%";//ó���� 0%�� ����
        // currentMultipiler = 1;//���� �¼��� ������ 1�� �����Ǿ� �ִ��� Ȯ��

        currentScore = 0;

        //Note_Object��ũ��Ʈ�� �����ϰ� �� �� �� ���� �ִ��� ����ϸ�
        //�� ��Ʈ�� ������ �ϴ� ������ ��ü�� ã�� �Ͱ� ���ٰ� �� �� �ִ�.

        //��� ��ü�� ã�� ����
        //�츮�� ã�� ���� ����Ʈ���� ������ ��ü�� ã�ƾ� ��
        //�� �������� �ִ±��̸� ���غ���.
        //�� ���̸� ���ϸ� ���̴� ��鿡 �ִ� ��ü�� ���� ����Ѵ�.
        //total_Notes = FindObjectOfType<Note_Object>().Length;

    }


    private void Update()
    {
        //������ʹ� ���� ������ ����
        Total_Charming_Count = Good_Hits + Perfect_Hits;//�� �� �� �ƴ���


    
        //���� ���ϰ� �ϱ� ���� �ӽ÷� ���� �ڵ�
        /*if (Input.anyKeyDown)
        {
            Winter_Music.instance.Keep_Speed();
            Winter_Music.instance.Winter_Music_Audio[0].Play();
        }*/

       // Winter_Music.instance.Keep_Speed();

        //���� ��� ���� ������ �� ����
        //����� �����ϸ� �⺻������ false���� ��.
        /* if (StartPlaying == false)
         {
             //����� �������� �ʾҴٸ�,
             //����ڰ� �ƹ� ��ư�̳� �������� Ȯ���ϱ⸦ ��ٸ��� �����Ƿ� 
             //�Է��� �������ϰ� Ű�� ������ ��� 

             //�̰� ������ �ƴ�
             if (Input.anyKeyDown)
             {


                 StartCoroutine(Go_Empty());

                 IEnumerator Go_Empty()
                 {
                     yield return new WaitForSeconds(2.0f);

                     //���� �ּ� ���µ�, Winter_Music �� �ٸ� ������ ������
                     for (int i = 0; i < theBS.Length; i++)
                     {
                         theBS[i].hasStarted = true;
                     }

                     for (int i = 0; i < long_note.Length; i++)
                     {
                         long_note[i].hasStarted = true;
                     }

                     for (int i = 0; i < long_note_fin.Length; i++)
                     {
                         long_note_fin[i].hasStarted = true;
                     }

                     StartPlaying = true;
                     //��� ������ true�� 

                     Music_0.Play();
                     //��ư�� ���� �� ��� ���� ������ �׾�


                 }


             }
         }*/

        //if (StartPlaying == true)
        //{
            //������� �޺� ����Ʈ ����
            // Ư�� �̸��� ���� ������Ʈ���� ��� ã��
            //GameObject[] objects = GameObject.FindGameObjectsWithTag("Combo_Effect");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����

            //0�� ���� �� ��Ʈ
            GameObject[] objects0 = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");

            if (objects0.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList0 = new List<GameObject>(objects0);

                // ������Ʈ���� ������ ������� ����
                objectList0.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList0.Count - 1; i++)
                {
                    Destroy(objectList0[i]);
                }
            }

            //1�� ���� �� ��Ʈ
            GameObject[] objects1 = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");

            if (objects1.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList1 = new List<GameObject>(objects1);

                // ������Ʈ���� ������ ������� ����
                objectList1.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList1.Count - 1; i++)
                {
                    Destroy(objectList1[i]);
                }
            }

            //2�� ���� �� ��Ʈ
            GameObject[] objects2 = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");

            if (objects2.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList2 = new List<GameObject>(objects2);

                // ������Ʈ���� ������ ������� ����
                objectList2.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList2.Count - 1; i++)
                {
                    Destroy(objectList2[i]);
                }
            }

            //3�� ���� �� ��Ʈ
            GameObject[] objects3 = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");

            if (objects3.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList3 = new List<GameObject>(objects3);

                // ������Ʈ���� ������ ������� ����
                objectList3.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList3.Count - 1; i++)
                {
                    Destroy(objectList3[i]);
                }
            }


            //4�� ���� �� ��Ʈ
            GameObject[] objects4 = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");

            if (objects4.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList4 = new List<GameObject>(objects4);

                // ������Ʈ���� ������ ������� ����
                objectList4.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList4.Count - 1; i++)
                {
                    Destroy(objectList4[i]);
                }
            }

            //5�� ���� �� ��Ʈ
            GameObject[] objects5 = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");

            if (objects5.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList5 = new List<GameObject>(objects5);

                // ������Ʈ���� ������ ������� ����
                objectList5.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList5.Count - 1; i++)
                {
                    Destroy(objectList5[i]);
                }
                // Debug.Log("�޺� ����Ʈ �ϳ����� �� ������.");
            }



            //���� �Ʒ��� ������ ��
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Combo_Effect");

            if (objects.Length >= 2)
            {
                // �迭�� ����Ʈ�� ��ȯ
                List<GameObject> objectList = new List<GameObject>(objects);

                // ������Ʈ���� ������ ������� ����
                objectList.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));

                // ������ ������Ʈ(���� ���߿� ������)�� �����ϰ� ������ ����
                for (int i = 0; i < objectList.Count - 1; i++)
                {
                    Destroy(objectList[i]);
                }
                // Debug.Log("�޺� ����Ʈ �ϳ����� �� ������.");
            }

            if (objects.Length == 1)
            {
                // Debug.Log("����Ʈ0 �ϳ���.");
            }


            //������� ��Ʈ ������ �� ������ ����Ʈ ����
            // Ư�� �̸��� ���� ������Ʈ���� ��� ã��
            GameObject[] Note_Effect_0 = GameObject.FindGameObjectsWithTag("Note_Effect0");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_0.Length >= 2)
            {
                // ù ��° ������Ʈ�� ����
                for (int i = 1; i < Note_Effect_0.Length; i++)
                {
                    Destroy(Note_Effect_0[i]);
                }
                // Debug.Log("�� �ϳ����� �� ������.");
            }

            if (Note_Effect_0.Length == 1)
            {
                // Debug.Log("����Ʈ0 �ϳ���.");
            }

            GameObject[] Note_Effect_1 = GameObject.FindGameObjectsWithTag("Note_Effect1");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_1.Length == 2)
            {
                // ù ��° ������Ʈ�� ����
                Destroy(Note_Effect_1[0]);
                // Debug.Log("����Ʈ1 2������ �� �ϳ� ������.");
            }

            if (Note_Effect_1.Length == 1)
            {
                // Debug.Log("����Ʈ1 �ϳ���.");
            }

            GameObject[] Note_Effect_2 = GameObject.FindGameObjectsWithTag("Note_Effect2");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_2.Length == 2)
            {
                // ù ��° ������Ʈ�� ����
                Destroy(Note_Effect_2[0]);
                // Debug.Log("����Ʈ2 2������ �� �ϳ� ������.");
            }

            if (objects.Length == 1)
            {
                // Debug.Log("����Ʈ2 �ϳ���.");
            }

            GameObject[] Note_Effect_3 = GameObject.FindGameObjectsWithTag("Note_Effect3");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_3.Length == 2)
            {
                // ù ��° ������Ʈ�� ����
                Destroy(Note_Effect_3[0]);
                //Debug.Log("����Ʈ3 2������ �� �ϳ� ������.");
            }

            if (Note_Effect_3.Length == 1)
            {
                // Debug.Log("����Ʈ3 �ϳ���.");
            }

            GameObject[] Note_Effect_4 = GameObject.FindGameObjectsWithTag("Note_Effect4");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_4.Length == 2)
            {
                // ù ��° ������Ʈ�� ����
                Destroy(Note_Effect_4[0]);
                //Debug.Log("����Ʈ4 2������ �� �ϳ� ������.");
            }

            if (Note_Effect_4.Length == 1)
            {
                //Debug.Log("����Ʈ4 �ϳ���.");
            }

            GameObject[] Note_Effect_5 = GameObject.FindGameObjectsWithTag("Note_Effect5");

            // �ش� ������Ʈ�� 2�� �̻� ���� ��, �ϳ��� ����
            if (Note_Effect_5.Length == 2)
            {
                // ù ��° ������Ʈ�� ����
                Destroy(Note_Effect_5[0]);
                // Debug.Log("����Ʈ5 2������ �� �ϳ� ������.");
            }

            if (Note_Effect_5.Length == 1)
            {
                // Debug.Log("����Ʈ5 �ϳ���.");
            }


        //}



        //������ ����Ǳ� �����߱� ������ ��� ���� ������ �ƴ��� Ȯ���� �� �ְ�
        //������ �� �̻� ������� �ʴ´ٸ�, �̴� �뷡�� �������� Ʋ�����ٴ� �ǹ�
        //ȭ���� Ȱ��ȭ�Ѵ�.
        //������ ������� �ʰ� ��� ������ ��� ȭ���� ���� �������� Ȱ��ȭ�� ���, �̸� �߰��� ��
        //������������ ��� ȭ���� Ȱ��ȭ�Ǿ��ִ��� ���ϰ� �ʹ�.
        //if (!Music_0.isPlaying && Good_Hits + Miss_Hits + Long_Note_Miss == 373)
        //{
        //  StartPlaying = false;//�뷡�� ������ ��� ��Ʈ�� �� ������ StartPlaying�� false��
        //�̰� ������ ���â�� �� ����
        //}

        //������ ����Ǳ� �����߱� ������ ��� ���� ������ �ƴ��� Ȯ���� �� �ְ�
        //������ �� �̻� ������� �ʴ´ٸ�, �̴� �뷡�� �������� Ʋ�����ٴ� �ǹ�
        //ȭ���� Ȱ��ȭ�Ѵ�.
        //������ ������� �ʰ� ��� ������ ��� ȭ���� ���� �������� Ȱ��ȭ�� ���, �̸� �߰��� ��
        //������������ ��� ȭ���� Ȱ��ȭ�Ǿ��ִ��� ���ϰ� �ʹ�.
        /*if (!Music_0.isPlaying && Result_Panel.activeSelf == false && Good_Hits + Perfect_Hits + Miss_Hits + Long_Note_Miss == 373)
        {
            Show_Result();
        }*/
        if (!Music_0.isPlaying && Result_Panel.activeSelf == false && Good_Hits + Perfect_Hits + Miss_Hits + Long_Note_Miss == 373 &&!hasShownResult)
        {
            Show_Result();
            hasShownResult = true; // ������ ����Ǿ����� ���
        }


        //-> ������ ��Ʈ�� �ݶ��̴��� �������� �� �� �Ŀ� ��� ȭ���� �����ƺ��� 
    }

    public void Show_Result()
    {
        // ��� ������
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Show_Re());
    }

    IEnumerator Show_Re()
    {
        yield return new WaitForSeconds(1.4f);
        Result_Panel.SetActive(true);

        // ���� ���
        Total_ScoreText.text = currentScore.ToString("F2") + "%";

        StartCoroutine(Show_Re1());
    }

    IEnumerator Show_Re1()
    {
        yield return new WaitForSeconds(0.0f);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        BGM_Manager.instance.BGM_Audio[28].Play();
    }

    /*public void Show_Result()
    {
        //��� ������
        //��� â�� ��������

        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Show_Re());
        

        IEnumerator Show_Re()
        {
            yield return new WaitForSeconds(1.4f);
            Result_Panel.SetActive(true);

            //���ݱ����� ������ �����ְ�
            Total_ScoreText.text = currentScore.ToString("F2") + "%";

            //�� �� �� ������ �Ǿ����� ��������
            //Total_Charming_Text.text = "Charming: " + Total_Charming_Count.ToString();
            StartCoroutine(Show_Re1());
        }

        IEnumerator Show_Re1()
        {
            yield return new WaitForSeconds(1.4f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            BGM_Manager.instance.BGM_Audio[28].Play();
        }

    }*/

    public void Note_Hit()
    {


        Combo_Count++;//multiplierTracker


        //��������!
        // multiplierThresholds�� [0]�� �ִ� ���ڸ�ŭ ��Ʈ�ϸ� 
        //������ 2��� �ö�
        //�� ����3��, 4��... �̷��� �Ǵ� ��?


        /* if (currentMultipiler -1 < multiplierThresholds.Length)
         {
             //���� �¼� -1�� �¼� �Ӱ谪 ���̺��� ������ 


             multiplierTracker++;
             //Basie�� �¼� �����⿡ 1�� �߰�
             //�� multiplierTracker++
             //����, �¼� �����Ⱑ �Ӱ谪 �� �ϳ��� ����ߴ��� Ȯ��

             /*if (multiplierThresholds[currentMultipiler - 1] <= multiplierTracker)
             {
                 //�¼� �Ӱ谪 �迭���� ������ �Ӱ谪���� Ȯ���ϰ� ���� ��ġ��
                 //���� �¼����� 1�� �� ������ Ȯ���ϴ� ��
                 //���� ��ġ 0���� ���캸�� �̸� Ȯ���ϰ� üũ��.
                 //�̰��� ���� �¼� �����Ⱑ �����̵� �׺��� �۰ų� ������
                 //�¼� �����Ⱑ 4��� ���� �ȴٸ� ���� �����Ⱑ Ʈ���� �� ������
                 //�� �� �ƹ� �ϵ� �Ͼ�� ���� ��

                 multiplierTracker = 0;
                 //�� �̻������� �����Ⱑ 4�� �����ϸ�
                 //�� �������� ������ ��.
                 //���� �����⸦ �ٽ� 0���� �����Ͽ� 0�� �ǰ�
                 currentMultipiler++;
                 //���� �¼��� 1�� �߰��ϹǷ�
                 //���� �¼�++�ϳ��� �߰��ȴ�.
                 //�̻��� ���� �߻����� �ʵ��� ���⼭ Ȯ���� �ʿ�
                 //
             }

             //���� �¼��� �� ���ٸ� �ȳ��̶�� ���ϴ� ��
             //�� �츮�� ���� �� �ִ� �ִ밪�� Ʈ���̹Ƿ� �¼��� 1�� ���� Ʈ����.
             //long�� �Ӱ谪 ���̺��� ������ ����?? ���̴� Ʈ���̹Ƿ� 
             //�� �������� �츮�� �¼� Ʈ���� Ȯ���� �� Ʈ������ ���� �ʴٰ� ���� ��
             //���� �� ��쿡�� �� �۾�
             /* multiplierTracker++;
              * if (multiplierThresholds[currentMultipiler - 1] <= multiplierTracker)
             {
                  multiplierTracker = 0;
             }*/
        //�� �������� �ʴ´�.
        //�� �̻� �¼��� ���� ���� ������ �̻��� ���� �Ͼ�� ���� ��
        //�迭 �ε��� ������ �߻����� ���� ���̹Ƿ� 
        //�̸� ���ο� �ΰ� �¼��� ������Ʈ�ϰ� ������ ��� ���� �Ϻ��ϰ� �۵���
        //}


        // multiText.text = currentMultipiler.ToString(); //�ϴ� �޺� ���� �߰��� ���� �ʴ� �ɷ� 
        //�¼��� ���� �� �̹� ������ ���� �ؽ�Ʈ�� ���� ���̴�.




        //��ǥ�� ���� �� �¼��� 1�� ���ϱ� �����ؾ� �Ѵٰ� ���ϰ� �� ����� �¼� �����⸦ ���

        //������ �¼��� ����(??)
        //currentScore += scorePerNote * currentMultipiler;


        //����
        // currentScore += scorePerNote;

        //���� �޺� ī��Ʈ�� 2���� ũ�ٸ�
        //�޺� �ؽ�ũ�� Ȱ��ȭ�ǰ�, ���ÿ� �ִϸ��̼ǵ� Ȱ��ȭ�ϴ� �ɷ�
        if (Combo_Count > 1)//1
        {
            Combo_obj.SetActive(true);
            Charming_obj.SetActive(true);

            Charming_anim.SetTrigger("Empty");
            Combo_anim.SetTrigger("Up");

            //Perfect_Combo_Effect.SetActive(true);


        }

        if (Combo_Count < 1)//2
        {
            Combo_obj.SetActive(false);
            Charming_obj.SetActive(false);

            Perfect_Combo_Effect.SetActive(false);
            Normal_Combo_Effect.SetActive(false);
        }
        ScoreText.text = currentScore.ToString("F2") + "%";//�Ҽ��� �� �ڸ� ������ ���


        //Debug.Log(currentMultipiler);
    }


    /*public void Normal_Hit()
    {
        Debug.Log("Good note:" + good_Hits);

        currentScore += scorePerNote * currentMultipiler;//��ǥ�� ������ �߰��Ͽ� �ϳ��� ��Ȯ�� ������
        Note_Hit();
        //���� ������ ���ϱ�

        //��Ʈ �� �ϳ��� ���� ������ ��Ʈ �߰�
        //good_Hits++;
    }*/

    public void Good_Hit()
    {

        //Debug.Log("Good note:" + good_Hits);

        currentScore += scorePerGoodNote; //* currentMultipiler;

        //��ü ���ھ� ���

        Note_Hit();
        Combo_Text.text = Combo_Count.ToString();//�޺� �ؽ�Ʈ ��� //multiplierTracker

        for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            //Debug.Log("����0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            // Debug.Log("����1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            // Debug.Log("����2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            // Debug.Log("����3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            //Debug.Log("����4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("����5");
        }

        //��Ʈ �� �ϳ��� ���� ������ ��Ʈ �߰�
        //good_Hits++;

    }

    public void Perfect_Hit()
    {
        //Debug.Log("Perfect note:" + perfect_Hits);

        currentScore += scorePerPerfectNote; //* currentMultipiler;
                                             //��ü ���ھ� ���

        Note_Hit();
        Combo_Text.text = Combo_Count.ToString();//�޺� �ؽ�Ʈ ���

        for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            // Debug.Log("����0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            //Debug.Log("����1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            //Debug.Log("����2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            //Debug.Log("����3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            //Debug.Log("����4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("����5");
        }

        //��Ʈ �� �ϳ��� ���� ������ ��Ʈ �߰�
        //perfect_Hits++;
    }

    public void Note_Missed()
    {
        //Debug.Log("���ƾ�?");


        //currentMultipiler = 1;
        Combo_Count = 0;//�¼� ������� 0  //multiplierTracker
        //��ģ ��� �¼��� �缳��
        //��, �޺� �����ٰ� �̽� ������ �ٽ� �޺��� �����·� �����ٴ� ����

        // multiText.text = currentMultipiler.ToString();//���� ���ʽ��� ���ֵ���
        //�¼� �׽�Ʈ ������Ʈ(�޺� �� ������Ʈ��� �����ϱ�)

        //�̽� ���� ������ �̽� �߰�
        //miss_Hits++;

        Combo_Text.text = Combo_Count.ToString();//�޺� �ؽ�Ʈ ���  //multiplierTracker

        Combo_obj.SetActive(false);//�޺� ������Ʈ ��Ȱ��
        Charming_obj.SetActive(false);//���� ������Ʈ ��Ȱ��

        //Effect_Object.instance.Destroy_obj();


        /*for (int j = 0; j < Line_0.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
            //Debug.Log("����0");
        }

        for (int j = 0; j < Line_1.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
            //Debug.Log("����1");
        }

        //2
        for (int j = 0; j < Line_2.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
            // Debug.Log("����2");
        }

        for (int j = 0; j < Line_3.Length; j++)
        {
            Line_3[j].Button_3_Pressed = false;
            // Debug.Log("����3");
        }

        //4
        for (int j = 0; j < Line_4.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
            // Debug.Log("����4");
        }

        for (int j = 0; j < Line_5.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
            //Debug.Log("����5");
        }*/
    }


    
}
