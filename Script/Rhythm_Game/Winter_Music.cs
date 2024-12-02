using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Winter_Music : MonoBehaviour
{
    public int song_select, story;

    public GameObject[] Winter_Songs;

   // public GameObject[] Main_False;//��Ȱ���ؾ� �� ��

    public GameObject[] Pause_Black;//���� ���� â
    public GameObject Pause;//���� ���빰�� ��Ƴ��� ��

    public GameObject[] Winter_Music_Obj;//���Ǹ�-������Ʈ
    public AudioSource[] Winter_Music_Audio;//���Ǹ�-AudioSource

    //���� ������ �� �� �ִ� �������� Ȯ��
    //�̰Ŵ� Ÿ���ο� ���� �ٲ�� ������ ���� ����/�ε� �ʿ����
    public bool Music_Open_1 = false;
    public bool Music_Open_2 = false;
    public bool Music_Open_3 = false;
    public bool Music_Open_4 = false;

    public float Pause_Time_0 = 0;//�Ͻ� ������ ����
    public float Pause_Time_1 = 0;//�Ͻ� ������ ����
    public float Pause_Time_2 = 0;//�Ͻ� ������ ����
    public float Pause_Time_3 = 0;//�Ͻ� ������ ����
    public float Pause_Time_4 = 0;//�Ͻ� ������ ����

    public Button[] Winter_Pause_5;//���� ��ư 5��(��� �� ��, ��ư�� ������ �ʵ���)

    public GameObject[] Winter_0_Note;//���� 0��° ��Ʈ ��ư(������ �� ������ �ʵ���)
    public GameObject[] Winter_1_Note;//���� 1��° ��Ʈ ��ư(������ �� ������ �ʵ���)
    public GameObject[] Winter_2_Note;//���� 2��° ��Ʈ ��ư(������ �� ������ �ʵ���)
    public GameObject[] Winter_3_Note;//���� 3��° ��Ʈ ��ư(������ �� ������ �ʵ���)
    public GameObject[] Winter_4_Note;//���� 4��° ��Ʈ ��ư(������ �� ������ �ʵ���)

    //���� �� ������ �� ����� ��ũ��Ʈ(Long_Note, Long_Col, Note_1105)
    //0
    public Long_Note[] Win_0_Long;//�� ��Ʈ
    public Long_Col[] Win_0_Long_Fin;//�� ��Ʈ ���κ�
    public Note_1105[] Win_0_Note;//�׳� ��Ʈ

    //1
    public Long_Note[] Win_1_Long;//�� ��Ʈ
    public Long_Col[] Win_1_Long_Fin;//�� ��Ʈ ���κ�
    public Note_1105[] Win_1_Note;//�׳� ��Ʈ

    //2
    public Long_Note[] Win_2_Long;//�� ��Ʈ
    public Long_Col[] Win_2_Long_Fin;//�� ��Ʈ ���κ�
    public Note_1105[] Win_2_Note;//�׳� ��Ʈ

    //3
    public Long_Note[] Win_3_Long;//�� ��Ʈ
    public Long_Col[] Win_3_Long_Fin;//�� ��Ʈ ���κ�
    public Note_1105[] Win_3_Note;//�׳� ��Ʈ

    //4
    public Long_Note[] Win_4_Long;//�� ��Ʈ
    public Long_Col[] Win_4_Long_Fin;//�� ��Ʈ ���κ�
    public Note_1105[] Win_4_Note;//�׳� ��Ʈ


    public TextMeshProUGUI Pause_Text;//���� �ؽ�Ʈ (0~5���� ���� ����)


    //��ư 5���� ���� bool
    public bool Continue = false;
    public bool Reset = false;
    public bool Story = false;
    public bool Songs = false;
    public bool Tempo = false;

    public static Winter_Music instance;


    public int Restart_Count = 0;

    public bool keep_speed = false;

    //public GameObject winter_song;//���� ���� ����â

    public GameObject song_select_btn;//���� ����â ��ư ����
    public GameObject select_Album;//�ٹ� ���ö�
    public Select_Album select_album;

    public GameObject Piano, Piano_Btn, Setting, HeadPhone, album_bgm, Title;//

    //public Swipe_Rev rev;
    //public Swipe_Win win;
    //public Swipe_1_fin swipe_1;

    //public Select_Album select_album;//�ٹ� ���ö� ���� ��ũ��Ʈ

    public Manager_0[] manager;


    public void Start()
    {
        Input.multiTouchEnabled = true;  // ��Ƽ��ġ Ȱ��ȭ
        Rhythm_Fade.instance.Fade.SetActive(false);//������� ���̵� ���� ��Ȱ��
        Application.targetFrameRate = 60;

        Pause_Text.text = "PAUSE";
        instance = this;

        //�� �̵��� �� Ȥ�� �����ұ��
        song_select = 0;
        story = 0;
    }

    private void Awake()
    {
        Input.multiTouchEnabled = true;  // ��Ƽ��ġ Ȱ��ȭ

        Pause_Text.text = "PAUSE";
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �ִٸ� ���� ��ü�� ����
        }
    }


    public void Update()
    {


        for (int i = 0; i < Pause_Black.Length; i++)
        {

            //���� â�� �����ִ� ���
            if (Pause.activeSelf == true  && Pause_Text.text == "PAUSE")
            {//Pause.activeSelf == true && UI_Button.instance.Main_False[3].activeSelf == false && Pause_Text.text == "PAUSE"
                if (Input.GetButtonDown("Cancel"))
                {
                    //�ڷΰ��� ��ư�� �����ٸ�

                    //�Ʒ� ����ϱ� ��ư ������ ���� ����� ���ƾ� �Ѵ�.
                    //�� ���Ŀ� ��� ����
                    Continue_true();

                }

                else if (!Input.GetButtonDown("Cancel"))
                {
                    //���� â�� �������� ��


                    //����ϱ� ��ư�� ������ ���
                    //-> Ready�� �ٲٰ� ���� �ӵ����
                    if (Continue == true)
                    {
                        //��� ��ư
                        //���� 5�� ��ư ��� ������ �ʵ���
                        Continue_true();
                        //Touch_Count = 0;

                    }

                    //�ٽ��ϱ� ��ư�� ������ ���
                    //->���̵� �� & �ƿ� �ϰ� ����
                    else if (Reset == true)
                    {
                        ReStart_True();//���� ���빰 �� ����
                                       // Touch_Count = 0;
                    }

                    //���丮 ��ư�� ������ ���
                    //-> ���̵� �� & �ƿ� �ϰ� ���� + ���丮�� �̵�
                    else if (Story == true)
                    {
                        Story_True();
                        //Touch_Count = 0;
                    }

                    //���Ǽ��� ��ư�� ������ ���
                    // -> ���̵� �� & �ƿ��ϰ� ���� + ���� �������� �̵�
                    else if (Songs == true)
                    {
                        Select_Song_True();
                        //Touch_Count = 0;
                    }

                    //���� ���� ��ư�� ������ ���
                    //-> �ӵ� ������ ä�� â �̵�
                    else if (Tempo == true)
                    {
                        Tempo_True();
                    }

                    else
                    {
                        //Debug.Log("���� â���� ��ư ���� �� ������.");
                        Stop_Speed();
                        Pause_Time_0 = Winter_Music_Audio[0].time;
                        Winter_Music_Audio[0].Pause();
                    }
                }
            }

            //���� â�� �����ִ� ���
            if (Pause.activeSelf == false && Pause_Text.text == "PAUSE")
            {//Pause.activeSelf == false && UI_Button.instance.Main_False[3].activeSelf == false && Pause_Text.text == "PAUSE"
                //Pause_Text.text = "PAUSE";

                if (Input.GetButtonDown("Cancel"))
                {
                    //����â ����, �ӵ� 0
                    for (int k = 0; k < Pause_Black.Length; k++)
                    {
                        Pause_Black[k].SetActive(true);//���� ������ ���̵���
                    }

                    //���� ��ư ��� Ȱ��ȭ
                    for (int j = 0; j < Winter_Pause_5.Length; j++)
                    {
                        Winter_Pause_5[j].enabled = true;
                    }

                    //��Ʈ ��ư ������Ʈ ��Ȱ��
                    for (int k = 0; k < Winter_0_Note.Length; k++)
                    {
                        Winter_0_Note[k].SetActive(false);//��ư ��������
                                                          //Winter_1_Note[k].SetActive(false);//��ư ��������
                                                          //Winter_2_Note[k].SetActive(false);//��ư ��������
                                                          //Winter_3_Note[k].SetActive(false);//��ư ��������
                                                          //Winter_4_Note[k].SetActive(false);//��ư ��������
                    }

                    Pause.SetActive(true);//���� ���빰�� ���̵���
                    Stop_Speed();
                    Pause_Time_0 = Winter_Music_Audio[0].time;
                    Winter_Music_Audio[0].Pause();

                }

                else if (!Input.GetButtonDown("Cancel") && Pause_Text.text == "PAUSE")
                {
                    //���� â�� �����ִµ�, �ڷΰ��� ��ư�� ������ �ʾ��� ���
                    //��� ���, �ӵ� �������
                    Keep_Speed();

                }
            }


        }
    }

    public void Keep_Speed()
    {
        keep_speed = true;

    }

    public void Stop_Speed()
    {
        keep_speed = false;

    }


    public void Go_Continue()
    {
        Continue = true;
        
    }

    public void Continue_true()
    {
        Continue = false;
        SFX_Manager.instance.SFX_Button();

        //���� ��ư�� ��Ȱ��
        for (int j = 0; j < Winter_Pause_5.Length; j++)
        {
            Winter_Pause_5[j].enabled = false;
        }

        Pause_Text.text = "READY";


        StartCoroutine(No_Pause());
        IEnumerator No_Pause()
        {
            //���� â ���ֱ�
            yield return new WaitForSecondsRealtime(1.0f);
            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���


            StartCoroutine(Go_Game());
        }



        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.0f);

            for (int i = 0; i < Winter_Music_Obj.Length; i++)
            {
                if (Winter_Music_Obj[i].activeSelf == true)//���� Ȱ��ȭ��(������̴�)������Ʈ�� ���� ���
                {
                    //Pause_Text.text = "PAUSE";
                    //��Ʈ ��ư ��������
                    for (int k = 0; k < Winter_0_Note.Length; k++)
                    {
                        Winter_0_Note[k].SetActive(true);//��ư ��������
                                                         //Winter_1_Note[k].SetActive(true);//��ư ��������
                                                         //Winter_2_Note[k].SetActive(true);//��ư ��������
                                                         //Winter_3_Note[k].SetActive(true);//��ư ��������
                                                         //Winter_4_Note[k].SetActive(true);//��ư ��������
                    }

                    //Winter_Music_Audio[i].time = Pause_Time_0;
                    //Winter_Music_Audio[i].Play();
                    Winter_Music_Audio[0].time = Pause_Time_0;
                    Winter_Music_Audio[0].UnPause();


                    Debug.Log("����� �� �ٽ� ���");

                    //�׳� ��Ʈ, �� ��Ʈ, �� ��Ʈ ���κ� ���
                    Keep_Speed();


                    //Continue = false;




                }
            }

           StartCoroutine(Go_Game2());

        }

        IEnumerator Go_Game2()
        {
            yield return new WaitForSeconds(0.2f);
            Pause_Text.text = "PAUSE";
        }

    }

    public void Go_ReStart()
    {
        //�ٽ� ���� ��ư
        Reset = true;
        //����� ��Ʈ���� ��ġ�� �ҷ��;� ��.
        //�ϴ� ���߿�.



    }

    public void ReStart_True()
    {

        //���� ���� �ð� �ʱ�ȭ
        SFX_Manager.instance.SFX_Button();

        //���� ���ö��� �ִ� ������ �̵�
        Rhythm_Fade.instance.Fade.SetActive(true);

        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                          //�ٽ� ���� ��ư

            //SceneManager.LoadScene("Go_Rhythm");//�� �̵�
            Win_Note_Pos.instance.Load_AllPositions();

            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Songs[0].SetActive(true);//���� 0��° ���� ������� Ȱ��

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���

            // Select_Album.instance.winter_song.SetActive(false);//���� ���� ���� ��Ȱ��
            //Select_Album.instance.song_select_btn.SetActive(false);//���� ���� ��ư�� ��Ȱ��

            //���� �߰�
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(false);
            }*/

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���

            //UI_Button.instance.Piano_Btn.SetActive(false);

            /* manager[0].currentScore = 0.0f;
             manager[0].Good_Hits = 0;
             manager[0].Perfect_Hits = 0;
             manager[0].Miss_Hits = 0;
             manager[0].Long_Note_Miss = 0;
            */


            foreach (var m in manager)
            {
                m.currentScore = 0.0f;
                m.Good_Hits = 0;
                m.Perfect_Hits = 0;
                m.Miss_Hits = 0;
                m.Long_Note_Miss = 0;

                m.ScoreText.text = "0.00%";//���� ����
                m.currentScore = 0;
            }



            //�� ��Ʈ�� �� ��Ʈ ���κп� �ִ� �ݶ��̴� Ȱ��ȭ
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;

                //����
                //Win_0_Long[j].ResetTouchStatus_0();
                Win_0_Long[j].ResetTouch_Count_0();

                //Win_0_Long[j].ResetTouchStatus_1();
                Win_0_Long[j].ResetTouch_Count_1();

                //Win_0_Long[j].ResetTouchStatus_2();
                Win_0_Long[j].ResetTouch_Count_2();

               // Win_0_Long[j].ResetTouchStatus_3();
                Win_0_Long[j].ResetTouch_Count_3();

               // Win_0_Long[j].ResetTouchStatus_4();
                Win_0_Long[j].ResetTouch_Count_4();

              //  Win_0_Long[j].ResetTouchStatus_5();
                Win_0_Long[j].ResetTouch_Count_5();
                //Win_0_Long[j].ResetTouchStatus();

                Debug.Log("���̵� �ƿ� �Ƕ��2");
            }


            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);//��ư ��������
                                                 //Winter_1_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_2_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_3_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_4_Note[k].SetActive(true);//��ư ��������
            }


            var NoteArrays = new List<Note_1105[]>()
                        {
    Win_0_Note,
    //Win_1_Note,
    //Win_2_Note,
    //Win_3_Note,
    //Win_4_Note
};
            // ��� �迭�� rect.anchoredPosition�� ����
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }

            StartCoroutine(Go_Empty());

            //�������� ���� ��쿡 
            StartCoroutine(Music_Go());

        }



        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5�ʺ��ٴ� ũ��
            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Music_Obj[0].SetActive(true);//���� 0��° ���� ������� ��Ȱ��
            Winter_Music_Audio[0].Play();
        }

        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            Debug.Log("���̵� �ƿ� �Ƕ��5");

            //Keep_Speed();

            StartCoroutine(SetActive_False());
        }



        IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);

            Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("���̵� �ƿ� �Ƕ��");

            //StartCoroutine(Note_Reset());




        }
    }



    public void Go_Select_Song()
    {
        Songs = true;
    }

    public void Select_Song_True()
    {
        song_select = 1;
        SFX_Manager.instance.SFX_Button();

        //���� ���� ��ư
        Songs = false;

        //���� ���� ������Ʈ ��Ȱ��
        Pause_Text.text = "PAUSE";

        //���� ���� �ð� �ʱ�ȭ


        //���� ���ö��� �ִ� ������ �̵�
        //Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Go_Game());
        StartCoroutine(Go_Game2());

        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(1.0f);//2.25
            //SceneManager.LoadScene("Title_0930");//�� �̵�
            //SceneManager.LoadScene("Title_0930");//�� �̵�
            PlayerPrefs.SetString("NextScene", "Title_0930"); // �̵��� ���� PlayerPrefs�� ����
            PlayerPrefs.Save();

            Winter_Music_Obj[0].SetActive(false);

            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Songs[0].SetActive(false);//���� 0��° ���� ������� ��Ȱ��

            for (int k = 0; k < Pause_Black.Length; k++)
            {
               Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���

            /*select_album.select_Album.SetActive(false);
            select_album.Album[0].SetActive(true);
            Winter_Music.instance.select_album.Select_Song_Btn.SetActive(true);

            //Select_Album.instance.swipe_1.hor.enabled = false;//�ٹ����� �� ��

            //�������� �� ����
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();

            // ���� ��ư ��ȣ�� ���� Album Ȱ��ȭ �� ��Ȱ��ȭ
            for (int i = 0; i < Select_Album.instance.Album.Length; i++)
            {
                Select_Album.instance.Album[i].SetActive(i == Swipe_1_fin.instance.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ

            }*/
            //SceneManager.LoadScene("Loading_Scene"); // �ε� ������ �̵�

            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(true);//���� ��Ȱ���Ѱ� �� Ȱ��ȭ
            }*/

        }

        IEnumerator Go_Game2()
        {
            yield return new WaitForSeconds(1.4f);//2.25
            SceneManager.LoadScene("Loading_Scene");
        }
            /*Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Songs[0].SetActive(false);//���� 0��° ���� ������� ��Ȱ��

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���




            select_album.select_Album.SetActive(false);
            select_album.Album[0].SetActive(true);

            //Select_Album.instance.swipe_1.hor.enabled = false;//�ٹ����� �� ��

            //�������� �� ����
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();

            // ���� ��ư ��ȣ�� ���� Album Ȱ��ȭ �� ��Ȱ��ȭ
            for (int i = 0; i < Select_Album.instance.Album.Length; i++)
            {
                Select_Album.instance.Album[i].SetActive(i == Swipe_1_fin.instance.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ

            }

            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            StartCoroutine(SetActive_False());

            // ��Ÿ ��ư ��Ȱ��ȭ
            Select_Album.instance.Select_Song_Btn.SetActive(true);
            //UI_Button.instance.Piano_Btn.SetActive(false);
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(1.4f);
            Rhythm_Fade.instance.Fade.SetActive(false);


            Pause_Text.text = "PAUSE";
        }*/

        }

    public void Go_Tempo()
    {
        //���� ���� ��ư
        Tempo = true;
    }

    public void Tempo_True()
    {
        //���� ���� ��ư
        Tempo = false;
    }


    public void Go_Story()
    {
        //���丮 ��ư
        Story = true;
    }

    public void Story_True()
    {
        story = 1;
        SFX_Manager.instance.SFX_Button();

        Story = false;

        //���� ���� ������Ʈ ��Ȱ��
        Pause_Text.text = "PAUSE";

        //���� ���� �ð� �ʱ�ȭ


        //���� ���ö��� �ִ� ������ �̵�
       // Title_Fade.instance.Fade_Canvas.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");



        StartCoroutine(Go_Game());



        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(1.0f);//2.25
            PlayerPrefs.SetString("NextScene", "Title_0930"); // �̵��� ���� PlayerPrefs�� ����
            PlayerPrefs.Save();
            SceneManager.LoadScene("Loading_Scene");


            // ���� ��ư�� ��Ȱ��
            for (int j = 0; j < Winter_Pause_5.Length; j++)
            {
                Winter_Pause_5[j].enabled = false;
            }

            Pause_Text.text = "PAUSE";

            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Songs[0].SetActive(false);//���� 0��° ���� ������� ��Ȱ��

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���

            //�������� �� ����
            //Select_Album.instance.win.Reset();
            //Select_Album.instance.rev.Reset();
            //Swipe_1_fin.instance.Reset();
            //�������� �� ����
            Swipe_Win.instance.Reset();
            Swipe_Rev.instance.Reset();
            Swipe_1_fin.instance.Reset();


            //���丮 ��ư
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(true);//��Ȱ��ȭ �ߴ��� �� Ȱ��ȭ
            }*/

            //UI_Button.instance.Piano.SetActive(false);
            //Select_Album.instance.select_Album.SetActive(true);

            song_select_btn.SetActive(true);
            select_Album.SetActive(true);

            // ��Ÿ ��ư ��Ȱ��ȭ
            //Select_Album.instance.Select_Song_Btn.SetActive(false);
            //UI_Button.instance.Piano_Btn.SetActive(false);

            //���� ���ǵ� ���� ������Ʈ ���� ��Ȱ��ȭ
            for (int i = 0; i < Winter_Songs.Length; i++)
            {
                Winter_Songs[i].SetActive(false);
            }

            //���� ����Ǵ� ���� ������Ʈ ���� ��Ȱ��ȭ
            for (int i = 0; i < Winter_Music_Obj.Length; i++)
            {
                Winter_Music_Obj[i].SetActive(false);
            }

            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(1.4f);
            //Title_Fade.instance.Fade_Canvas.SetActive(false);


            Pause_Text.text = "PAUSE";
        }
    }

    public void Go_W_Music_0()
    {
        song_select = 0;
        story = 0;

        SFX_Manager.instance.SFX_Button();
        /*PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // �̵��� ���� PlayerPrefs�� ����
        PlayerPrefs.Save();
        SceneManager.LoadScene("Loading_Scene");*/
        //Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        // 1.4�� �Ŀ� �ε� ������ �̵��ϴ� �ڷ�ƾ ����
        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            // 1.4�� ��� �� �ε� ������ �̵�
            yield return new WaitForSecondsRealtime(1.0f);

            //Select_Album.instance.Select_Song_Btn.SetActive(false);
            //Select_Album.instance.Album[0].SetActive(false);
            song_select_btn.SetActive(false);
            select_Album.SetActive(false);

            // PlayerPrefs�� "NextScene" �� ����
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // �̵��� ���� PlayerPrefs�� ����
            PlayerPrefs.Save();
            SceneManager.LoadScene("Loading_Scene");

            
        }

        
    }

    /*public void Go_W_Music_03()
    {
        // ���� ���� �ð� �ʱ�ȭ

        // ���� ���ö��� �ִ� ������ �̵�
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        // 1.4�� �Ŀ� �ε� ������ �̵��ϴ� �ڷ�ƾ ����
        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            // 1.4�� ��� �� �ε� ������ �̵�
            yield return new WaitForSecondsRealtime(1.4f);
            Select_Album.instance.Piano.SetActive(false);
            Select_Album.instance.Piano_Btn.SetActive(false);

            Select_Album.instance.select_Album.SetActive(false);
            Select_Album.instance.Select_Song_Btn.SetActive(false);

            Select_Album.instance.Album[0].SetActive(false);
            Select_Album.instance.Album[1].SetActive(false);



            // PlayerPrefs�� "NextScene" �� ����
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // �̵��� ���� PlayerPrefs�� ����
            PlayerPrefs.Save();
            //SceneManager.LoadScene("Loading_Scene");
            // ���̵� �ƿ� �� �ε� ������ �̵�
             StartCoroutine(LoadSceneWithFade());

            // ���� ���� �ʱ�ȭ �ڵ� (�ε� ������ �����)
            InitializeGameSettings();

            // ���̵� �ƿ� �� ����� �߰� �۾�
            StartCoroutine(Go_Empty());
            StartCoroutine(Music_Go());
        }

        // �ε� ���� ���̵� �� �ε��ϴ� �ڷ�ƾ
        IEnumerator LoadSceneWithFade()
        {
            // ���̵� �ִϸ��̼��� ���� ������ ���
            yield return new WaitForSecondsRealtime(1f); // ���̵� �Ϸ� ��� (�ִϸ��̼� ���̿� ���߱�)

            // �ε� ������ �̵�
            SceneManager.LoadScene("Loading_Scene");
        }

        // ���� ���� �ʱ�ȭ �ڵ� (�ε� ������ ����)
        void InitializeGameSettings()
        {
            Winter_Songs[0].SetActive(true);

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);
            }
            Pause.SetActive(false);

            // ���� �ʱ�ȭ
            foreach (var m in manager)
            {
                m.currentScore = 0.0f;
                m.Good_Hits = 0;
                m.Perfect_Hits = 0;
                m.Miss_Hits = 0;
                m.Long_Note_Miss = 0;
                m.ScoreText.text = "0.00%"; // ���� ����
            }

            // �� ��Ʈ�� �ݶ��̴� Ȱ��ȭ
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;
                // ����
                ResetLongNotes(j);
            }

            // Winter_0_Note Ȱ��ȭ
            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);
            }

            // ��Ʈ �迭 �ʱ�ȭ
            InitializeNotes();
        }

        void ResetLongNotes(int j)
        {
            // �� ��Ʈ ���� ����
            //Win_0_Long[j].ResetTouchStatus_0();
            Win_0_Long[j].ResetTouch_Count_0();
            //Win_0_Long[j].ResetTouchStatus_1();
            Win_0_Long[j].ResetTouch_Count_1();
            Win_0_Long[j].ResetTouch_Count_2();
            Win_0_Long[j].ResetTouch_Count_3();
            Win_0_Long[j].ResetTouch_Count_4();
            Win_0_Long[j].ResetTouch_Count_5();
            // ��� �߰�...
        }

        void InitializeNotes()
        {
            var NoteArrays = new List<Note_1105[]>()
        {
            Win_0_Note,
            // Win_1_Note, etc.
        };

            // ��� �迭�� rect.anchoredPosition�� ����
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }
        }

        // ���̵� �ƿ� �� ����� �߰� �۾�
        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            //Rhythm_Fade.instance.Fade.SetActive(true);
            //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            Debug.Log("���̵� �ƿ� �Ƕ��");

            // �ʿ�� �߰� �۾� (���� ���� ��� ��Ȱ��ȭ ��)
            StartCoroutine(SetActive_False());
        }

        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5�ʺ��ٴ� ũ��
            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
                                           //Winter_Music_Obj[0].SetActive(true);//���� 0��° ���� ������� ��Ȱ��
            Winter_Music_Audio[0].Play();
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);
            Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("���̵� �ƿ� �Ϸ�");

            // �߰� �۾�
        }
    }


    */


    //�Ʒ����ʹ� ���� ���� �ڵ� ����
    //hopeful Piano�� �����Ϸ� ���� ��ư
    public void Go_W_Music_1()
    {

        //���� ���� �ð� �ʱ�ȭ


        //���� ���ö��� �ִ� ������ �̵�
        Rhythm_Fade.instance.Fade.SetActive(true);
        
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");


        StartCoroutine(Go_Game());

        IEnumerator Go_Game()
        {
            yield return new WaitForSecondsRealtime(1.4f);//1.4
                                                          //�ٽ� ���� ��ư

            // SceneManager.LoadScene("Go_Rhythm");//�� �̵�
            PlayerPrefs.SetString("NextScene", "Go_Rhythm"); // �̵��� ���� PlayerPrefs�� ����
            PlayerPrefs.Save();
            SceneManager.LoadScene("LoadingScene"); // �ε� ������ �̵�

            //Load_Control.LoadScene("Go_Rhythm");
            Win_Note_Pos.instance.Load_AllPositions();
            

            //Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            Winter_Songs[0].SetActive(true);//���� 0��° ���� ������� Ȱ��

            for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���

           // Select_Album.instance.winter_song.SetActive(false);//���� ���� ���� ��Ȱ��
            //Select_Album.instance.song_select_btn.SetActive(false);//���� ���� ��ư�� ��Ȱ��

            //���� �߰�
            /*for (int i = 0; i < UI_Button.instance.Main_False.Length; i++)
            {
                UI_Button.instance.Main_False[i].SetActive(false);
            }*/

            /*for (int k = 0; k < Pause_Black.Length; k++)
            {
                Pause_Black[k].SetActive(false);//���� ������ ������ �ʵ���
            }
            Pause.SetActive(false);//���� ���빰�� ������ �ʵ���
            */
            //UI_Button.instance.Piano_Btn.SetActive(false);

            /* manager[0].currentScore = 0.0f;
             manager[0].Good_Hits = 0;
             manager[0].Perfect_Hits = 0;
             manager[0].Miss_Hits = 0;
             manager[0].Long_Note_Miss = 0;
            */

            
                foreach (var m in manager)
                {
                    m.currentScore = 0.0f;
                    m.Good_Hits = 0;
                    m.Perfect_Hits = 0;
                    m.Miss_Hits = 0;
                    m.Long_Note_Miss = 0;

                    m.ScoreText.text = "0.00%";//���� ����
                    m.currentScore = 0;
                }
            


            //�� ��Ʈ�� �� ��Ʈ ���κп� �ִ� �ݶ��̴� Ȱ��ȭ
            for (int j = 0; j < Win_0_Long.Length; j++)
            {
                Win_0_Long[j].long_note_col[j].enabled = true;
                Win_0_Long_Fin[j].fin_col.enabled = true;

                //����
                //Win_0_Long[j].ResetTouchStatus_0();
                Win_0_Long[j].ResetTouch_Count_0();

                //Win_0_Long[j].ResetTouchStatus_1();
                Win_0_Long[j].ResetTouch_Count_1();

                //Win_0_Long[j].ResetTouchStatus_2();
                Win_0_Long[j].ResetTouch_Count_2();

                //Win_0_Long[j].ResetTouchStatus_3();
                Win_0_Long[j].ResetTouch_Count_3();

                //Win_0_Long[j].ResetTouchStatus_4();
                Win_0_Long[j].ResetTouch_Count_4();

                //Win_0_Long[j].ResetTouchStatus_5();
                Win_0_Long[j].ResetTouch_Count_5();
                //Win_0_Long[j].ResetTouchStatus();

                Debug.Log("���̵� �ƿ� �Ƕ��2");
            }


            for (int i = 0; i < Winter_0_Note.Length; i++)
            {
                Winter_0_Note[i].SetActive(true);//��ư ��������
                                                 //Winter_1_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_2_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_3_Note[k].SetActive(true);//��ư ��������
                                                 //Winter_4_Note[k].SetActive(true);//��ư ��������
            }


            var NoteArrays = new List<Note_1105[]>()
                        {
    Win_0_Note,
    //Win_1_Note,
    //Win_2_Note,
    //Win_3_Note,
    //Win_4_Note
};
            // ��� �迭�� rect.anchoredPosition�� ����
            foreach (var array in NoteArrays)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    array[k].anim.SetTrigger("None");
                    array[k].gameObject.SetActive(true);
                    array[k].anim_count = 0;
                }
            }

            StartCoroutine(Go_Empty());

            //�������� ���� ��쿡 
            StartCoroutine(Music_Go());

        }

        

        IEnumerator Music_Go()
        {
            yield return new WaitForSecondsRealtime(11f);//5�ʺ��ٴ� ũ��
            Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
            //Winter_Music_Obj[0].SetActive(true);//���� 0��° ���� ������� ��Ȱ��
            Winter_Music_Audio[0].Play();
        }

        IEnumerator Go_Empty()
        {
            yield return new WaitForSecondsRealtime(0.7f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            Debug.Log("���̵� �ƿ� �Ƕ��5");

            //Keep_Speed();

            //StartCoroutine(SetActive_False());
        }



        /*IEnumerator SetActive_False()
        {
            yield return new WaitForSecondsRealtime(1.4f);

            //Rhythm_Fade.instance.Fade.SetActive(false);
            Debug.Log("���̵� �ƿ� �Ƕ��");

            //StartCoroutine(Note_Reset());




        }*/
    }

 
    }
