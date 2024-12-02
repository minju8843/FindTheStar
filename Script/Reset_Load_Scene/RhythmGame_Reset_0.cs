using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RhythmGame_Reset_0 : MonoBehaviour
{
    private bool initialized = false; // �ʱ�ȭ üũ ����

//���� 0�� ������� ���� �� ����

    void Start()
    {
        // ���� Ȱ��ȭ�� �� Ȯ��
        if (SceneManager.GetActiveScene().name == "Go_Rhythm" && !initialized)
        {
            InitializeGameSettings(); // �ʱ�ȭ �޼��� ����
            initialized = true; // �ߺ� ���� ����
            StartCoroutine(Go_Empty());
            StartCoroutine(Music_Go());
        }

       

        if (SceneManager.GetActiveScene().name == "Go_Rhythm")
        {
            // �ִϸ����� ���� �ʱ�ȭ
            Rhythm_Fade.instance.Fade_Anim.Rebind();

            // ���̵� �ƿ� ����
            Rhythm_Fade.instance.Fade.SetActive(true);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        }
    }

    void InitializeGameSettings()
    {
        Debug.Log("���� �ʱ�ȭ ����");

        

        Winter_Music.instance.Winter_Songs[0].SetActive(true);

        for (int k = 0; k < Winter_Music.instance.Pause_Black.Length; k++)
        {
            Winter_Music.instance.Pause_Black[k].SetActive(false);
        }
        Winter_Music.instance.Pause.SetActive(false);

        // ���� �ʱ�ȭ
        foreach (var m in Winter_Music.instance.manager)
        {
            m.currentScore = 0.0f;
            m.Good_Hits = 0;
            m.Perfect_Hits = 0;
            m.Miss_Hits = 0;
            m.Long_Note_Miss = 0;
            m.ScoreText.text = "0.00%"; // ���� ����
        }

        // �� ��Ʈ�� �ݶ��̴� Ȱ��ȭ
        for (int j = 0; j < Winter_Music.instance.Win_0_Long.Length; j++)
        {
            Winter_Music.instance.Win_0_Long[j].long_note_col[j].enabled = true;
            Winter_Music.instance.Win_0_Long_Fin[j].fin_col.enabled = true;
            ResetLongNotes(j);
        }

        // Winter_0_Note Ȱ��ȭ
        for (int i = 0; i < Winter_Music.instance.Winter_0_Note.Length; i++)
        {
            Winter_Music.instance.Winter_0_Note[i].SetActive(true);
        }

        // ��Ʈ �迭 �ʱ�ȭ
        InitializeNotes();
    }

    void ResetLongNotes(int j)
    {
        //Winter_Music.instance.Win_0_Long[j].ResetTouchStatus_0();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_0();
        //Winter_Music.instance.Win_0_Long[j].ResetTouchStatus_1();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_1();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_2();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_3();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_4();
        Winter_Music.instance.Win_0_Long[j].ResetTouch_Count_5();
    }

    void InitializeNotes()
    {
        var NoteArrays = new List<Note_1105[]>()
        {
            Winter_Music.instance.Win_0_Note,
            // Win_1_Note, etc.
        };

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

    public IEnumerator Go_Empty()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        //Rhythm_Fade.instance.Fade.SetActive(true);
        //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        Debug.Log("���̵� �ƿ� �Ƕ��");

        // �ʿ�� �߰� �۾� (���� ���� ��� ��Ȱ��ȭ ��)
    }

    public IEnumerator Music_Go()
    {
        yield return new WaitForSecondsRealtime(11.2f);//11.5���ٴ� �۰�
        Winter_Music.instance.Winter_Music_Obj[0].SetActive(true);
        Winter_Music.instance.Winter_Music_Audio[0].time = 0;//���� �ð� �ʱ�ȭ
                                                             //Winter_Music_Obj[0].SetActive(true);//���� 0��° ���� ������� ��Ȱ��
        Winter_Music.instance.Winter_Music_Audio[0].Play();

        //Note_1105.instance.YourClassName();//�ճ�Ʈ �̽� ��� �ʱ�ȭ
    }


}
