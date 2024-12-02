using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//���� ����
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class Slider_Data
{
    public float Person_1_Like;//���긮 ȣ����
    public float Person_2_Like;//��Ƽ ȣ����
    public float Person_3_Like;//���� ȣ����
    public float Person_4_Like;//�� ȣ����
    public float Person_5_Like;//ȥ ȣ����
}


public class Like_Slider : MonoBehaviour
{

    //ȣ���� ����
    public Slider[] Person_Like_Slider;//ȣ���� �����̴�
    public float Default_Like = 0f;//�⺻ ȣ����

    public TextMeshProUGUI Person_1_text;
    public TextMeshProUGUI Person_2_text;
    public TextMeshProUGUI Person_3_text;
    public TextMeshProUGUI Person_4_text;
    public TextMeshProUGUI Person_5_text;

    public float Current_Person_1;//���1 ȣ����
    public float Current_Person_2;//���2 ȣ����
    public float Current_Person_3;//���3 ȣ����
    public float Current_Person_4;//���4 ȣ����
    public float Current_Person_5;//���5 ȣ����

    public static Like_Slider instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Load_Like();//ȣ���� �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        Save_Like();
    }

    private void Load_Like()
    {
        //ȣ���� �ҷ�����
        string path_1 = Application.persistentDataPath + "/Person_1_Like.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Like.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Like.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Like.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Like.json";


        if (File.Exists(path_1))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json_1 = File.ReadAllText(path_1);

            Slider_Data data_1 = JsonUtility.FromJson<Slider_Data>(json_1);
            Person_Like_Slider[0].value = data_1.Person_1_Like;

            //Debug.Log("���� 1�� ȣ������:" + Person_Like_Slider[0].value);
            Person_1_text.text = "ȣ���� " + Person_Like_Slider[0].value.ToString() + "%";
        }

        else if(!File.Exists(path_1))
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            Person_Like_Slider[0].value = 0;
        }

        //2��
        if (File.Exists(path_2))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json_2 = File.ReadAllText(path_2);

            Slider_Data data_2 = JsonUtility.FromJson<Slider_Data>(json_2);
            Person_Like_Slider[1].value = data_2.Person_2_Like;

            //Debug.Log("���� 2�� ȣ������:" + Person_Like_Slider[1].value);
            Person_2_text.text = "ȣ���� " + Person_Like_Slider[1].value.ToString() + "%";
        }

        else if (!File.Exists(path_2))
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            Person_Like_Slider[1].value = 0;
        }

        //3��
        if (File.Exists(path_3))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json_3 = File.ReadAllText(path_3);

            Slider_Data data_3 = JsonUtility.FromJson<Slider_Data>(json_3);
            Person_Like_Slider[2].value = data_3.Person_3_Like;

            //Debug.Log("���� 3�� ȣ������:" + Person_Like_Slider[2].value);
            Person_3_text.text = "ȣ���� " + Person_Like_Slider[2].value.ToString() + "%";
        }

        else if (!File.Exists(path_3))
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            Person_Like_Slider[2].value = 0;
        }

        //4��
        if (File.Exists(path_4))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json_4 = File.ReadAllText(path_4);

            Slider_Data data_4 = JsonUtility.FromJson<Slider_Data>(json_4);
            Person_Like_Slider[3].value = data_4.Person_4_Like;

            //Debug.Log("���� 4�� ȣ������:" + Person_Like_Slider[3].value);
            Person_4_text.text = "ȣ���� " + Person_Like_Slider[3].value.ToString() + "%";
        }

        else if (!File.Exists(path_4))
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            Person_Like_Slider[3].value = 0;
        }

        //5��
        if (File.Exists(path_5))
        {
            //������ �����ϴ� ��� ������ �о�´�
            string json_5 = File.ReadAllText(path_5);

            Slider_Data data_5 = JsonUtility.FromJson<Slider_Data>(json_5);
            Person_Like_Slider[4].value = data_5.Person_5_Like;

            //Debug.Log("���� 5�� ȣ������:" + Person_Like_Slider[4].value);
            Person_5_text.text = "ȣ���� " + Person_Like_Slider[4].value.ToString() + "%";
        }

        else if (!File.Exists(path_5))
        {
            // ����� ���� ���� ��� �ʱ�ȭ
            Person_Like_Slider[4].value = 0;
        }
    }

    private void Save_Like()
    {
        //ȣ���� �����ϱ�
        Slider_Data data_1 = new Slider_Data();
        data_1.Person_1_Like = Person_Like_Slider[0].value;//���� ȿ���� ������ �����̴����� �����ͼ�

        string jsonData_1 = JsonUtility.ToJson(data_1);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Person_1_Like.json", jsonData_1);
       /// Debug.Log("���� 1�� ȣ������:" + Person_Like_Slider[0].value+"%");

        Person_1_text.text = "ȣ���� " + Person_Like_Slider[0].value.ToString()+"%";

       //ȣ����2
        Slider_Data data_2 = new Slider_Data();
        data_2.Person_2_Like = Person_Like_Slider[1].value;//���� ȿ���� ������ �����̴����� �����ͼ�

        string jsonData_2 = JsonUtility.ToJson(data_2);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Person_2_Like.json", jsonData_2);
        //Debug.Log("���� 2�� ȣ������:" + Person_Like_Slider[1].value + "%");
        
        Person_2_text.text = "ȣ���� " + Person_Like_Slider[1].value.ToString() + "%";

        //ȣ����3
        Slider_Data data_3 = new Slider_Data();
        data_3.Person_3_Like = Person_Like_Slider[2].value;//���� ȿ���� ������ �����̴����� �����ͼ�

        string jsonData_3 = JsonUtility.ToJson(data_3);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Person_3_Like.json", jsonData_3);
        //Debug.Log("���� 3�� ȣ������:" + Person_Like_Slider[2].value + "%");

        Person_3_text.text = "ȣ���� " + Person_Like_Slider[2].value.ToString() + "%";


        //ȣ����4
        Slider_Data data_4 = new Slider_Data();
        data_4.Person_4_Like = Person_Like_Slider[3].value;//���� ȿ���� ������ �����̴����� �����ͼ�

        string jsonData_4 = JsonUtility.ToJson(data_4);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Person_4_Like.json", jsonData_4);
        //Debug.Log("���� 4�� ȣ������:" + Person_Like_Slider[3].value + "%");

        Person_4_text.text = "ȣ���� " + Person_Like_Slider[3].value.ToString() + "%";

        //ȣ����5
        Slider_Data data_5 = new Slider_Data();
        data_5.Person_5_Like = Person_Like_Slider[4].value;//���� ȿ���� ������ �����̴����� �����ͼ�

        string jsonData_5 = JsonUtility.ToJson(data_1);

        //JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Person_5_Like.json", jsonData_5);
        //Debug.Log("���� 5�� ȣ������:" + Person_Like_Slider[4].value + "%");

        Person_5_text.text = "ȣ���� " + Person_Like_Slider[4].value.ToString() + "%";
    }

    public void Reset_Likes()
    {
        string path_1 = Application.persistentDataPath + "/Person_1_Like.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Like.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Like.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Like.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Like.json";


        if (File.Exists(path_1))
        {
            File.Delete(path_1);

            Person_Like_Slider[0].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_2))
        {
            File.Delete(path_2);

            Person_Like_Slider[1].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_3))
        {
            File.Delete(path_3);

            Person_Like_Slider[2].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_4))
        {
            File.Delete(path_4);

            Person_Like_Slider[3].value = Default_Like;
            Load_Like();
        }

        if (File.Exists(path_5))
        {
            File.Delete(path_5);

            Person_Like_Slider[4].value = Default_Like;
            Load_Like();
        }

        else
        {
            Debug.Log("������ Ÿ���� ������ ����");
        }
    }
}
