using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;


[System.Serializable]

public class SFX_Data 
{
    public float SFX_Volume;//���� ����
}

public class SFX_Manager : MonoBehaviour
{
    public Slider SFX_Volume_Silder;
    public AudioSource[] SFX_Audio;//ȿ���� ���� ��
    public float Default_Volume = 0.5f;//���� ����
    public float Current_Volume;//���� ����

    public static SFX_Manager instance;

    private void Start()
    {
        instance = this;

        Load_SFX();//���� ������ ������ �ҷ�����
    }

    private void Update()
    {
        foreach(var audioSource in SFX_Audio)
        {
            audioSource.volume = SFX_Volume_Silder.value;//���� ���� �����̴� ���� ����
            Current_Volume = audioSource.volume;//���� ������ ȿ���� �������� ����

            Save_SFX();//�����ϱ�
            //Debug.Log(Application.persistentDataPath);
        }
    }

    private void Save_SFX()
    {
        //������ ����
        SFX_Data data = new SFX_Data();
        data.SFX_Volume = SFX_Volume_Silder.value;//���� ȿ���� ������ �����̴����� �����ͼ�
        //SFX_Volume�� �Ҵ�

        string jsonData = JsonUtility.ToJson(data);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/SFX.json", jsonData);
        //Debug.Log("��� ���� ���� ����");
        //Debug.Log("���� ������:" + SFX_Volume_Silder.value);
    }

    private void Load_SFX()
    {
        string path = Application.persistentDataPath + "/SFX.json";
        //SFX.json�̶�� ������ �����ϴ��� Ȯ��

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json = File.ReadAllText(path);

            SFX_Data data = JsonUtility.FromJson<SFX_Data>(json);
            SFX_Volume_Silder.value = data.SFX_Volume;

           // Debug.Log("���� ������:" + SFX_Volume_Silder.value);
        }

        else
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            SFX_Volume_Silder.value = Default_Volume;

            // �� AudioSource�� �⺻ ������ �ʱ�ȭ
            foreach (var audioSource in SFX_Audio)
            {
                audioSource.volume = Default_Volume;
            }
        }
    }


    public void Reset_SFX_Settings()
    {
        string path = Application.persistentDataPath + "/SFX.json";

        if (File.Exists(path))
        {
            //������ ������ ���, �����
            File.Delete(path);

            //�ʱ�ȭ �� �����(���� ó�� �������)
            // �⺻ ������ �ʱ�ȭ
            SFX_Volume_Silder.value = Default_Volume;

            // �� AudioSource�� �⺻ ������ �ʱ�ȭ
            foreach (var audioSource in SFX_Audio)
            {
                audioSource.volume = Default_Volume;

                Current_Volume = audioSource.volume;
            }
        }

        else
        {
            Debug.Log("������ ���� ������ ����");
        }
    }


    public void SFX_Button()//�׳� ��ư �Ҹ�
    {
        SFX_Audio[0].volume = SFX_Volume_Silder.value;

        SFX_Audio[0].Play();
    }

    public void SFX_Message_Alarm()//�޽��� �˸���
    {
        SFX_Audio[1].volume = SFX_Volume_Silder.value;

        SFX_Audio[1].Play();
    }

    public void SFX_Walk()//��������
    {
        SFX_Audio[2].volume = SFX_Volume_Silder.value;

        SFX_Audio[2].Play();
    }
}
