using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    // public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public RectTransform content; // Content�� Transform
    private List<float> originalPositionsX = new List<float>(); // X ��ǥ�� ����
    private bool positionsSaved = false;

    public static Swipe_1_fin instance;




    void Start()
    {
        SetPositions();
        CenterOnStart();

        instance = this;
        Load();

        // 5�� �Ŀ� �ڽ� ������Ʈ���� X ��ġ�� ����
        // Invoke("SavePositions", 5f);

        // 1�� �ĺ��� 1�� �������� RestorePositions() ȣ��
        //InvokeRepeating("TriggerRestorePositions", 0f, 1f);
    }


    public void SavePositions()
    {
        originalPositionsX.Clear(); // ������ ����� X ��ġ �ʱ�ȭ

        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // X ��ǥ�� ����
                originalPositionsX.Add(rectTransform.anchoredPosition.x);
            }
        }

        positionsSaved = true; // ��ġ ���� �Ϸ� ǥ��
        //Debug.Log("�ڽ� ������Ʈ���� X ��ġ�� ����Ǿ����ϴ�.");
        //for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
        //{
            //Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
        //}
    }


    // LateUpdate()���� ���� �۾� ����
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // �ֱ������� ���� �۾��� ����
            RestorePositions();
        }
    }

    void RestorePositions()
    {
        if (positionsSaved)
        {
            // ����� X ��ġ�� �ǽð����� �ҷ��ͼ� ����
            for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
            {
                RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // ������ Y, Z ���� �״�� �ΰ� X ���� ����
                    Vector3 currentPos = rectTransform.anchoredPosition;
                    currentPos.x = originalPositionsX[i]; // ����� X ������ ����
                    rectTransform.anchoredPosition = currentPos;
                    //Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
                }
            }
        }
    }


    //����
    void Update()
    {
        if (runIt== true)
        {
            GecisiDuzenle();// -> �� ������ ������ �� �Ǵ� �ſ���

            // ��ġ ���� �� ���� �޼��� ȣ��
            SavePositions(); // ��ġ ����
            RestorePositions(); // ����� ��ġ ����

            // ���� �� runIt�� false�� �����Ͽ� �ߺ� ȣ�� ����
            runIt = false;
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                   // Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


    }


    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

       // Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        //Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }


    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� ���� 0���� �ʱ�ȭ
                                                           // ���⼭ �������� �ʱ�ȭ���ݴϴ�.
            scroll_pos = 0;
            btnNumber = 0; // ��ư ��ȣ�� 0���� �ʱ�ȭ
            Load(); // �⺻ ������ �ҷ��ɴϴ�. (�Ǵ� �� �κ��� �����Ͽ� ���� �� ���ο� ���·� �ʱ�ȭ)
        }

        if (File.Exists(path1))
        {
            File.Delete(path1);
            btnNumber = 0;
            previousBtnNumber = -1;
            Load();
        }
        else
        {
            return;
            //Debug.Log("�������� ���� �� ��");
        }

        // �����Ͱ� ���µ� �� GecisiDuzenle()�� ȣ���Ͽ� UI ���¸� ������Ʈ�մϴ�.
        GecisiDuzenle();
    }


    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            //Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            //Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            return;
            //������ �������� �ʴ� ���
            //Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);

    }

    public void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    public void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber]; // btnNumber�� 0���� ���µ� ���¿��� ����
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }


    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}


//���� ������. ������ ������
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

   // public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public RectTransform content; // Content�� Transform
    private List<float> originalPositionsX = new List<float>(); // X ��ǥ�� ����
    private bool positionsSaved = false;

    public static Swipe_1_fin instance;


    //�ʱ�ȭ �ڵ�
    public void InitializeValues()
    {
        btnNumber = 0;
        previousBtnNumber = -1;
    }

    void Start()
    {
        SetPositions();
        CenterOnStart();

        instance = null;
        // Load();

        // 5�� �Ŀ� �ڽ� ������Ʈ���� X ��ġ�� ����
       // Invoke("SavePositions", 5f);

        // 1�� �ĺ��� 1�� �������� RestorePositions() ȣ��
        //InvokeRepeating("TriggerRestorePositions", 0f, 1f);
    }


    public void SavePositions()
    {
        originalPositionsX.Clear(); // ������ ����� X ��ġ �ʱ�ȭ

        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // X ��ǥ�� ����
                originalPositionsX.Add(rectTransform.anchoredPosition.x);
            }
        }

        positionsSaved = true; // ��ġ ���� �Ϸ� ǥ��
        Debug.Log("�ڽ� ������Ʈ���� X ��ġ�� ����Ǿ����ϴ�.");
        for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
        {
            Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
        }
    }


    // LateUpdate()���� ���� �۾� ����
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // �ֱ������� ���� �۾��� ����
            RestorePositions();
        }
    }

    void RestorePositions()
    {
        if (positionsSaved)
        {
            // ����� X ��ġ�� �ǽð����� �ҷ��ͼ� ����
            for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
            {
                RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // ������ Y, Z ���� �״�� �ΰ� X ���� ����
                    Vector3 currentPos = rectTransform.anchoredPosition;
                    currentPos.x = originalPositionsX[i]; // ����� X ������ ����
                    rectTransform.anchoredPosition = currentPos;
                    Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
                }
            }
        }
    }


    //����
    void Update()
    {
        if (runIt)
        {
            GecisiDuzenle();

            // ��ġ ���� �� ���� �޼��� ȣ��
            SavePositions(); // ��ġ ����
            RestorePositions(); // ����� ��ġ ����

            // ���� �� runIt�� false�� �����Ͽ� �ߺ� ȣ�� ����
            runIt = false;
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();

       
    }


    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    public void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    public void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }

    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public static Swipe_1_fin instance;

    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;

    }





    void Update()
    {


        Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    //Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
        }
    }

    //���� 7�� 42��
    public void ArrangeObjectsWithSpacing(float spacing)
    {
        int childCount = imageContent.transform.childCount;
        if (childCount == 0) return;

        // �߽��� �������� ù ��° �ڽ��� ��� ��ġ
        float centerX = 0;
        RectTransform centerChild = imageContent.transform.GetChild(childCount / 2).GetComponent<RectTransform>();
        centerChild.anchoredPosition = new Vector2(centerX, centerChild.anchoredPosition.y);

        // ����� �������� ������ ������ �ڽ� ��ġ
        float currentXLeft = centerX - (centerChild.rect.width / 2) - spacing;
        float currentXRight = centerX + (centerChild.rect.width / 2) + spacing;

        for (int i = (childCount / 2) - 1; i >= 0; i--)
        {
            RectTransform leftChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXLeft -= (leftChild.rect.width / 2);
            leftChild.anchoredPosition = new Vector2(currentXLeft, leftChild.anchoredPosition.y);
            currentXLeft -= (leftChild.rect.width / 2) + spacing;
        }

        for (int i = (childCount / 2) + 1; i < childCount; i++)
        {
            RectTransform rightChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXRight += (rightChild.rect.width / 2);
            rightChild.anchoredPosition = new Vector2(currentXRight, rightChild.anchoredPosition.y);
            currentXRight += (rightChild.rect.width / 2) + spacing;
        }
    }

    //���� 3�� 49�� ������
    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }



    //3�� 50�� ���� �ڵ�
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // ��ũ�� ��ġ�� ���� ����� ��ư�� ����
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }

        // ��ġ�� �ٲ�� �ڽ� ������Ʈ���� ũ�� �ٽ� ����
        //ScaleObjects();

    }



    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }


    public void GecisiDuzenle()
    {
        // ��ũ�ѹ��� ���� ���� ���õ� ��ġ�� ����
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // ���õ� �ڽ� ������Ʈ�� ������ �߾ӿ� ��ġ
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }


    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}*/

//�⺻ ����
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public static Swipe_1_fin instance;

    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;

    }





    void Update()
    {


        Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    //Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
        }
    }

    //���� 7�� 42��
    public void ArrangeObjectsWithSpacing(float spacing)
    {
        int childCount = imageContent.transform.childCount;
        if (childCount == 0) return;

        // �߽��� �������� ù ��° �ڽ��� ��� ��ġ
        float centerX = 0;
        RectTransform centerChild = imageContent.transform.GetChild(childCount / 2).GetComponent<RectTransform>();
        centerChild.anchoredPosition = new Vector2(centerX, centerChild.anchoredPosition.y);

        // ����� �������� ������ ������ �ڽ� ��ġ
        float currentXLeft = centerX - (centerChild.rect.width / 2) - spacing;
        float currentXRight = centerX + (centerChild.rect.width / 2) + spacing;

        for (int i = (childCount / 2) - 1; i >= 0; i--)
        {
            RectTransform leftChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXLeft -= (leftChild.rect.width / 2);
            leftChild.anchoredPosition = new Vector2(currentXLeft, leftChild.anchoredPosition.y);
            currentXLeft -= (leftChild.rect.width / 2) + spacing;
        }

        for (int i = (childCount / 2) + 1; i < childCount; i++)
        {
            RectTransform rightChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();
            currentXRight += (rightChild.rect.width / 2);
            rightChild.anchoredPosition = new Vector2(currentXRight, rightChild.anchoredPosition.y);
            currentXRight += (rightChild.rect.width / 2) + spacing;
        }
    }

    //���� 3�� 49�� ������
    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }



    //3�� 50�� ���� �ڵ�
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // ��ũ�� ��ġ�� ���� ����� ��ư�� ����
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }

        // ��ġ�� �ٲ�� �ڽ� ������Ʈ���� ũ�� �ٽ� ����
        //ScaleObjects();

    }



    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }


    public void GecisiDuzenle()
    {
        // ��ũ�ѹ��� ���� ���� ���õ� ��ġ�� ����
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // ���õ� �ڽ� ������Ʈ�� ������ �߾ӿ� ��ġ
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }


    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public static Swipe_1_fin instance;

    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;

    }





    void FixedUpdate()
    {


        Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    //Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
        }
    }


    //���� 3�� 49�� ������
    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }



    //3�� 50�� ���� �ڵ�
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }



    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        //scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }


    public void CenterOnClosest()
    {
        // ��ũ�� ��ġ�� ���� ����� ��ư�� ����
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }

        // ��ġ�� �ٲ�� �ڽ� ������Ʈ���� ũ�� �ٽ� ����
        ScaleObjects();

    }



    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }


    public void GecisiDuzenle()
    {
        // ��ũ�ѹ��� ���� ���� ���õ� ��ġ�� ����
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // ���õ� �ڽ� ������Ʈ�� ������ �߾ӿ� ��ġ
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }


    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}*/





//��ġ�� �� ����Ǵµ� 0�� �ڽ� ������Ʈ�� �����ϰ� ������ ���� �߾� ��ġ�� �ȵ�

//11�� 16�� ���� 5�� 5�� ���� �ڵ�
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform

    public RectTransform content; // Content�� Transform
    private List<float> originalPositionsX = new List<float>(); // X ��ǥ�� ����
    private bool positionsSaved = false;



    void Start()
    {
        SetPositions();
        CenterOnStart();


        // Load();

        // 5�� �Ŀ� �ڽ� ������Ʈ���� X ��ġ�� ����
        Invoke("SavePositions", 5f);

        // 1�� �ĺ��� 1�� �������� RestorePositions() ȣ��
        InvokeRepeating("TriggerRestorePositions", 0f, 1f);
    }


    void SavePositions()
    {
        originalPositionsX.Clear(); // ������ ����� X ��ġ �ʱ�ȭ

        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // X ��ǥ�� ����
                originalPositionsX.Add(rectTransform.anchoredPosition.x);
            }
        }

        positionsSaved = true; // ��ġ ���� �Ϸ� ǥ��
        Debug.Log("�ڽ� ������Ʈ���� X ��ġ�� ����Ǿ����ϴ�.");
        for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
        {
            Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
        }
    }

    // InvokeRepeating()�� ���� Ʈ���ŵ� RestorePositions() �޼���
    void TriggerRestorePositions()
    {
        if (positionsSaved)
        {
            RestorePositions();
        }
    }

    // LateUpdate()���� ���� �۾� ����
    void LateUpdate()
    {
        if (positionsSaved)
        {
            // �ֱ������� ���� �۾��� ����
            RestorePositions();
        }
    }

    void RestorePositions()
    {
        if (positionsSaved)
        {
            // ����� X ��ġ�� �ǽð����� �ҷ��ͼ� ����
            for (int i = 0; i < content.childCount && i < originalPositionsX.Count; i++)
            {
                RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // ������ Y, Z ���� �״�� �ΰ� X ���� ����
                    Vector3 currentPos = rectTransform.anchoredPosition;
                    currentPos.x = originalPositionsX[i]; // ����� X ������ ����
                    rectTransform.anchoredPosition = currentPos;
                    Debug.Log("����� X ��ġ - �ڽ� " + i + ": " + originalPositionsX[i]);
                }
            }
        }
    }

   
    void Update()
    {


        //Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    Save();
                }
            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
        }
    }


    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);


        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    public void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }
    }

    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }

    public void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }

    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }



}*/

//24.11.16.���� 4�� 30�� ���� �ڵ�

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Swipe_1_fin_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_1_fin : MonoBehaviour
{
    public GameObject scrollbar, imageContent;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    public HorizontalLayoutGroup hor;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����
    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����


    //public RectTransform content; // ��ũ�� ������ ��� RectTransform


    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

    }





    void Update()
    {
      

        //Save();

        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
            SfxPlayed = false; // �������� �߿��� �Ҹ� ��� ����
        }
        else
        {
            CenterOnClosest();
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;

                // ����: ���� ��ư�� 0�� �ƴϾ��� ���� btnNumber�� 0�� ���� �Ҹ� ���
                if (!SfxPlayed && previousBtnNumber > 0)
                {
                    SFX_Manager.instance.SFX_Button();
                    SfxPlayed = true;
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();


        for (int i = 0; i < 2; i++)
        {
            Select_Album.instance.btn[i].interactable = (i == Select_Album.instance.swipe_1.btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
        }
    }



    //���� 3�� 49�� ������
    public void Save()
    {
        //������ ����
        Swipe_1_fin_Data data = new Swipe_1_fin_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_fin.json", jsonData);

        Debug.Log("�����ϴ� ���� �󸶾�!" + data.Scroll);

        //������ ����
        Swipe_1_fin_Data data1 = new Swipe_1_fin_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_1_num.json", jsonData1);

        Debug.Log("�����ϴ� ���ڰ� �󸶾�!" + data1.number);
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0;
            Load();
        }

        if (File.Exists(path))
        {
            File.Delete(path1);
            btnNumber = 0;
            Load();
        }

        else
        {
            Debug.Log("�������� ���� �� ��");
        }
    }



    //3�� 50�� ���� �ڵ�
    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_1_fin.json";
        string path1 = Application.persistentDataPath + "/Swipe_1_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data = JsonUtility.FromJson<Swipe_1_fin_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;

            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);

           
        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_1_fin_Data data1 = JsonUtility.FromJson<Swipe_1_fin_Data>(json1);

            btnNumber = data1.number;

            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);

        }

        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
    }


    public void SetPositions()
     {
         pos = new float[transform.childCount];
         float distance = 1f / (pos.Length - 1f);

         for (int i = 0; i < pos.Length; i++)
         {
             pos[i] = distance * i;
         }
     }



    public void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        //scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f);
    }

    
    public void CenterOnClosest()
    {
        // ��ũ�� ��ġ�� ���� ����� ��ư�� ����
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true;
                break;
            }
        }

        // ��ġ�� �ٲ�� �ڽ� ������Ʈ���� ũ�� �ٽ� ����
        //ScaleObjects();
    }



    private void ScaleObjects()
    {
        float distance = 1f / (pos.Length - 1f);
        int selectedIndex = -1;

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.49f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                    transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                }
            }
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.5f, 0.5f);


            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
            }
        }
    }
    

    public void GecisiDuzenle()
    {
        // ��ũ�ѹ��� ���� ���� ���õ� ��ġ�� ����
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

        // ���õ� �ڽ� ������Ʈ�� ������ �߾ӿ� ��ġ
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }


    public void ResetScrollBar()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� �ʱ�ȭ
    }

    public void ResetObjects()
    {
        for (int i = 0; i < imageContent.transform.childCount; i++)
        {
            Transform child = imageContent.transform.GetChild(i);
            child.localScale = new Vector2(0.4f, 0.4f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.5f, 0.5f); // ù ��° ������Ʈ Ȯ��
    }


    
}
*/


//�̰Ŵ� �� ���� ��

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;

    void Start()
    {
        // �ʱ�ȭ: 0��° �ڽ� ������Ʈ�� ȭ�� �߾ӿ� ��ġ�ϰ� ũ�⸦ Ű��
        CenterAndScaleObject(0, new Vector2(0.54f, 0.54f));
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level: " + i);

                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                    }
                }

                // ��ũ�ѹٰ� ���� ����� ������Ʈ ��ġ�� �ε巴�� �̵�
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 1f * Time.deltaTime);

                // ���õ� ������Ʈ�� RectTransform ��������
                RectTransform selectedChild = imageContent.transform.GetChild(i).GetComponent<RectTransform>();

                // ȭ�� �߾� ��ǥ ���
                Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

                // Screen ��ǥ�� UI ��ǥ�� ��ȯ
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    imageContent.GetComponent<RectTransform>(),
                    screenCenter,
                    null,
                    out Vector2 localPoint);

                // Content ��ġ�� ȭ�� �߾ӿ� ���ߵ��� ����
                selectedChild.anchoredPosition = localPoint;

                // �߾ӿ� ��ġ�ߴ��� üũ
                if (Vector2.Distance(selectedChild.anchoredPosition, localPoint) < 0.1f)
                {
                    Debug.Log("������Ʈ�� �߾ӿ� ��ġ�߽��ϴ�. ������Ʈ �̸�: " + selectedChild.name);
                }
            }
        }
    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);
            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            btn.transform.name = ".";
        }
    }

    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }
    }

    // �߾ӿ� ��ġ�ϴ� �޼��� (�ʱ�ȭ��)
    private void CenterAndScaleObject(int index, Vector2 scale)
    {
        RectTransform child = imageContent.transform.GetChild(index).GetComponent<RectTransform>();
        child.localScale = scale;

        // �߾� ��ġ ����
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageContent.GetComponent<RectTransform>(),
            screenCenter,
            null,
            out Vector2 localPoint);

        child.anchoredPosition = localPoint;
    }
}*/


//��������
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_1_fin : MonoBehaviour
{
   public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    //private float time;
    //private Button takeTheBtn;
    public int btnNumber;

    public HorizontalLayoutGroup hor;



    //private float distance; // distance�� ��� ������ �߰�

    void Start()
    {
        SetPositions();
        CenterOnStart();
    }

    

    void Update()
    {


        if (runIt)
        {
            GecisiDuzenle();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            runIt = false;
        }
        else
        {
            CenterOnClosest();
            if(!Input.GetMouseButton(0) || Input.touchCount == 0)
            {
                runIt = true;
            }
        }

        ScaleObjects();
    }

    private void SetPositions()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    private void CenterOnStart()
    {
        // ù ��° �ڽ��� ȭ�� �߾ӿ� ��ġ
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.54f, 0.54f);
    }



    private void CenterOnClosest()
    {
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                btnNumber = i;
                runIt = true; // runIt�� true�� �����Ͽ� �ε巴�� �߾����� �̵��ϵ��� ��
                break;
            }
        }
    }

    //�׽�Ʈ��(���� �س´� �̤�)
    private void ScaleObjects()
     {
         float distance = 1f / (pos.Length - 1f);
         int selectedIndex = -1;

         // ���õ� �ε��� ã��
         for (int i = 0; i < pos.Length; i++)
         {
             if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
             {
                 selectedIndex = i; // ���õ� �ε��� ����
                 break;
             }
         }

         // ���� ���õ� ������Ʈ�� Ȯ��� �������� Ȯ��
         if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.53f)
         {
             // �߽� ������Ʈ�� �̹� Ȯ��� ���¶�� ������ ������Ʈ�� ��� 0.4f�� ����
             for (int j = 0; j < pos.Length; j++)
             {
                 if (j != selectedIndex)
                 {
                     // ������ ������Ʈ�� 0.4f�� ��� ����
                     imageContent.transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                     transform.GetChild(j).localScale = new Vector2(0.4f, 0.4f);
                 }
             }
             return; // Lerp�� ������� �ʵ��� �ߴ�
         }

         // ���õ� ������Ʈ Ȯ�� �� ������ ������Ʈ ���
         for (int i = 0; i < pos.Length; i++)
         {
             if (i == selectedIndex)
             {
                 // ���� ���õ� ������Ʈ Ȯ��
                 transform.GetChild(i).localScale = new Vector2(0.54f, 0.54f);
                 imageContent.transform.GetChild(i).localScale = new Vector2(0.54f, 0.54f);
             }
             else
             {
                 // ������ ������Ʈ�� 0.4f�� ��� ����
                 imageContent.transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
                 transform.GetChild(i).localScale = new Vector2(0.4f, 0.4f);
             }
         }
     }

     private void GecisiDuzenle()
     {
         // ��ũ�ѹٰ� ���� ����� ������Ʈ ��ġ�� ��� �̵�
         scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];

         // ��ũ�ѹٰ� �����̴� ���� ȭ�� �߾����� ����
         RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();

         // ȭ�� �߾� ��ǥ ���
         Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

         // Screen ��ǥ�� UI ��ǥ�� ��ȯ
         RectTransformUtility.ScreenPointToLocalPointInRectangle(
             imageContent.GetComponent<RectTransform>(),
             screenCenter,
             null,
             out Vector2 localPoint);

         // Content ��ġ�� ȭ�� �߾ӿ� ���ߵ��� ����
         selectedChild.anchoredPosition = localPoint;

         runIt = false; // ������ �Ϸ�Ǹ� runIt�� false�� ����
     }*/

/*private void ScaleObjects()
{
 float distance = 1f / (pos.Length - 1f);
 for (int i = 0; i < pos.Length; i++)
 {
     if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
     {
         // ���� ���õ� ������Ʈ Ȯ��
         transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);
         imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(0.54f, 0.54f), 0.1f);

         // ������ ������Ʈ ���
         for (int j = 0; j < pos.Length; j++)
         {
             if (j != i)
             {
                 imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
                 transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.4f, 0.4f), 0.1f);
             }
         }
     }
 }


}


private void GecisiDuzenle()
{
// ��ũ�ѹٰ� ���� ����� ������Ʈ ��ġ�� �ε巴�� �̵�
scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);

// ��ũ�ѹٰ� �����̴� ���� ȭ�� �߾����� ����
RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();

// ȭ�� �߾� ��ǥ ���
Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

// Screen ��ǥ�� UI ��ǥ�� ��ȯ
RectTransformUtility.ScreenPointToLocalPointInRectangle(
    imageContent.GetComponent<RectTransform>(),
    screenCenter,
    null,
    out Vector2 localPoint);

// Content ��ġ�� ȭ�� �߾ӿ� ���ߵ��� ����
selectedChild.anchoredPosition = localPoint;

runIt = false; // ������ �Ϸ�Ǹ� runIt�� false�� ����
}*/


//�̰� ���� �Ⱦ���

/*public void WhichBtnClicked(Button btn)
{
    btn.transform.name = "clicked";
    for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
    {
        if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
        {
            btnNumber = i;
            takeTheBtn = btn;
            scroll_pos = (pos[btnNumber]);
            runIt = true; // ��ư Ŭ�� �� runIt�� true�� ����
        }
    }
}*/

//}