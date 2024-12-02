using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class BGM_Data
{
    public float BGM_Volume;//���� ����
}

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager instance;

    public Slider BGM_Volume_Silder;
    public AudioSource[] BGM_Audio;//����� ���� ��
    public float Default_Volume = 0.5f;//���� ����
    public float Current_Volume;//���� ����

    private void Start()
    {
        instance = this;
        Load_BGM();//���� ������ ������ �ҷ�����
    }

    private void Update()
    {
        foreach (var audioSource in BGM_Audio)
        {
            audioSource.volume = BGM_Volume_Silder.value;//���� ���� �����̴� ���� ����
            Current_Volume = audioSource.volume;//���� ������ ȿ���� �������� ����

            Save_BGM();//�����ϱ�

            //Debug.Log(Application.persistentDataPath);
        }
    }

    private void Save_BGM()
    {
        //������ ����
        BGM_Data data = new BGM_Data();
        data.BGM_Volume = BGM_Volume_Silder.value;//���� ȿ���� ������ �����̴����� �����ͼ�
        //SFX_Volume�� �Ҵ�

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/BGM.json", jsonData);
        //Debug.Log("��� ���� ���� ����");
        //Debug.Log("���� ������:" + BGM_Volume_Silder.value);
    }

    private void Load_BGM()
    {
        string path = Application.persistentDataPath + "/BGM.json";
        //BGM.json�̶�� ������ �����ϴ��� Ȯ��

        if(File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json = File.ReadAllText(path);

            BGM_Data data = JsonUtility.FromJson<BGM_Data>(json);
            BGM_Volume_Silder.value = data.BGM_Volume;

            //Debug.Log("���� ������:" + BGM_Volume_Silder.value);
        }

        else
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            BGM_Volume_Silder.value = Default_Volume;

            // �� AudioSource�� �⺻ ������ �ʱ�ȭ
            foreach (var audioSource in BGM_Audio)
            {
                audioSource.volume = Default_Volume;
            }
        }

    }


    public void Reset_BGM_Settings()
    {

        string path = Application.persistentDataPath + "/BGM.json";

        if(File.Exists(path))
        {
            //������ ������ ���, �����
            File.Delete(path);

            //�ʱ�ȭ �� �����(���� ó�� �������)
            // �⺻ ������ �ʱ�ȭ
            BGM_Volume_Silder.value = Default_Volume;

            // �� AudioSource�� �⺻ ������ �ʱ�ȭ
            foreach (var audioSource in BGM_Audio)
            {
                audioSource.volume = Default_Volume;

                Current_Volume = audioSource.volume;
            }
        }

        else
        {
            return;
            //Debug.Log("������ ���� ������ ����");
        }

    }


    /*public void SFX_Button()//�׳� ��ư �Ҹ�
    {
        audio[0].volume = backVolumeSlider.value;

        audio[0].Play();
        Debug.Log(audio[0].volume);
    }*/
}
