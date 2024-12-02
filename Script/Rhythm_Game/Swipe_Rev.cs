using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Swipe_Rev_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_Rev : MonoBehaviour
{
    //public Swipe_Rev rev;

    public Swipe_1_fin swipe_1;

    public GameObject scrollbar, imageContent;
    public float Scroll_Value = 0.0f;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;


    public Button[] btn;//����������� ���� ��ư

    public GameObject[] Winter_BGM;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����

    public static Swipe_Rev instance;

    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����

    public RectTransform content; // Content�� Transform
    private List<float> originalPositionsX = new List<float>(); // X ��ǥ�� ����
    private bool positionsSaved = false;




    void Start()
    {
        SetPositions();
        CenterOnStart();

        Load();

        instance = this;
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

    void Update()
    {
        if (runIt == true)
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
                    Debug.Log("���� ��ư�� 0�� �ƴ� �� ��ư ȿ���� ����");
                    Save();
                }

            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ
        previousBtnNumber = btnNumber;
        ScaleObjects();

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = (i == btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
            Winter_BGM[i].SetActive(i == btnNumber); // �ѹ��� ������ ���� ���, �ƴϸ� ��Ȱ��ȭ
        }
    }

    void LateUpdate()
    {
        if (positionsSaved)
        {
            // �ֱ������� ���� �۾��� ����
            RestorePositions();
            positionsSaved = false;//�߰�
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

    /*public void Save()
    {
        //������ ����
        Swipe_Win_Data data = new Swipe_Win_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Win.json", jsonData);


        //������ ����
        Swipe_Win_Data data1 = new Swipe_Win_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_Win_num.json", jsonData1);
    }*/

    public void Save()
    {
        Swipe_Rev_Data data = new Swipe_Rev_Data
        {
            Scroll = scrollbar.GetComponent<Scrollbar>().value,
            number = btnNumber
        };

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev.json", jsonData);
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
        // scroll_pos = pos[0];
        //scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        // ù ��° �ڽ� ������Ʈ ũ�� ����
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
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
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
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
        // btnNumber�� �ùٸ� �������� Ȯ��
        if (btnNumber < 0 || btnNumber >= pos.Length)
        {
            Debug.LogError("btnNumber ���� �߸��Ǿ����ϴ�. �ùٸ� ������ �����Ͻʽÿ�.");
            return; // ��ȿ���� ���� ��� �Լ� ����
        }

        // btnNumber�� �ش��ϴ� ������ ��ũ�ѹ� ��ġ�� ������Ʈ
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber]; // btnNumber�� 0���� ���µ� ���¿��� ����
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageContent.GetComponent<RectTransform>(), screenCenter, null, out Vector2 localPoint);
        selectedChild.anchoredPosition = localPoint;

        runIt = false;
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

        // ���� ���� �� �ʱ�ȭ
        if (File.Exists(path))
        {
            File.Delete(path);
            scrollbar.GetComponent<Scrollbar>().value = 0; // ��ũ�ѹ� ���� 0���� �ʱ�ȭ
            scroll_pos = 0;
            btnNumber = 0; // ��ư ��ȣ�� 0���� �ʱ�ȭ
        }

        if (File.Exists(path1))
        {
            File.Delete(path1);
            btnNumber = 0;
            previousBtnNumber = -1;
        }

        // ���� ���� �� Load() �޼��� ȣ��
        Load();

        // Load()�� ���� �� UI ���� ����
        GecisiDuzenle();
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� Swipe_Win_Data ��ü�� ��ȯ
            Swipe_Rev_Data data = JsonUtility.FromJson<Swipe_Rev_Data>(json);

            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;
            Debug.Log("�ҷ����� ���� �󸶾�!" + scrollbar.GetComponent<Scrollbar>().value);
        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� Swipe_Win_Data ��ü�� ��ȯ
            Swipe_Rev_Data data1 = JsonUtility.FromJson<Swipe_Rev_Data>(json1);

            btnNumber = data1.number;
            Debug.Log("�ҷ����� ���ڰ� ����!" + btnNumber);
        }
        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
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
        firstChild.localScale = new Vector2(0.64f, 0.64f); // ù ��° ������Ʈ Ȯ��


    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Swipe_Rev_Data
{
    public float Scroll;
    public int number;
}

public class Swipe_Rev : MonoBehaviour
{

    public Swipe_Win win;

    public Swipe_1_fin swipe_1;

    public GameObject scrollbar, imageContent;
    //public float Scroll_Value = 0.0f;

    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber = 0;

    //public HorizontalLayoutGroup hor;

    public Button[] btn;//������� ������ ���� ��ư

    public GameObject[] Rev_BGM;

    public bool SfxPlayed = false; // ��ư ȿ���� ���� ����

    public static Swipe_Rev instance;

    public int previousBtnNumber = -1; // ���� ��ư ��ȣ�� ����

    public void Go_Back()
    {

        

        if (Select_Album.instance.Album[1].activeSelf == true)//���긮�� Ȱ��ȭ�� ������ ���
        {
            

            SFX_Manager.instance.SFX_Button();
            //swipe_1.hor.enabled = true;
            //���̵� �� �ƿ�
            Title_Fade.instance.Fade_Canvas.SetActive(true);
            Title_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

            

            

            StartCoroutine(Go_Game());
            IEnumerator Go_Game()
            {
                yield return new WaitForSeconds(1.4f);
                //�ٽ� �����ϴ� â����
                //swipe_1.hor.enabled = true;
                //win.hor.enabled = false;
                //hor.enabled = false;

                swipe_1.btnNumber = 1;
                //swipe_1.Scroll_Value = 0;
                swipe_1.previousBtnNumber = 1;
                swipe_1.scrollbar.GetComponent<Scrollbar>().value = 0.2f;



                StartCoroutine(SetActive_False()); 
                Select_Album.instance.select_Album.SetActive(true);//�ٹ� ���� Ȱ��
                                                                   //������ ������Ʈ ��Ȱ��
 

                Select_Album.instance.Select_Song_Btn.SetActive(false);//�ڷΰ��� ��Ȱ��
                UI_Button.instance.Piano_Btn.SetActive(true);//�ٹ� ���� �ڷΰ��� Ȱ��

                Title_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
                //StartCoroutine(SetActive_False());
                for (int i = 0; i < Select_Album.instance.Album.Length; i++)
                {
                    Select_Album.instance.Album[i].SetActive(false);
                }
                Select_Album.instance.BGM.SetActive(true);//�׸� ���� BGM Ȱ��ȭ

                
            }

            IEnumerator SetActive_False()
            {
                yield return new WaitForSeconds(1.4f);
                Title_Fade.instance.Fade_Canvas.SetActive(false);
            }

            
        }

        else
        {
            return;
        }

    }


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
                }
            }
        }

        // ���� ��ư ��ȣ�� ������Ʈ=
        previousBtnNumber = btnNumber;

        ScaleObjects();

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = (i == btnNumber); // btnNumber�� ������ Ȱ��ȭ, �ƴϸ� ��Ȱ��ȭ
            Rev_BGM[i].SetActive(i == btnNumber); // �ѹ��� ������ ���� ���, �ƴϸ� ��Ȱ��ȭ
        }
    }


    public void Save()
    {
        //������ ����
        Swipe_Rev_Data data = new Swipe_Rev_Data();
        data.Scroll = scrollbar.GetComponent<Scrollbar>().value;

        string jsonData = JsonUtility.ToJson(data);

        // JSON���ڿ��� ��ȯ
        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev.json", jsonData);


        //������ ����
        Swipe_Rev_Data data1 = new Swipe_Rev_Data();
        data1.number = btnNumber;

        string jsonData1 = JsonUtility.ToJson(data1);

        File.WriteAllText(Application.persistentDataPath + "/Swipe_Rev_num.json", jsonData1);

    }

    public void Reset()
    {

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "/Swipe_Rev_num.json";

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
            Debug.Log("������ ����");
        }
    }

    public void Load()
    {
        SetPositions();
        CenterOnStart();

        string path = Application.persistentDataPath + "/Swipe_Rev.json";
        string path1 = Application.persistentDataPath + "Swipe_Rev_num.json";

        if (File.Exists(path))
        {
            //������ �����ϴ� ��� ������ �о��
            string json = File.ReadAllText(path);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_Rev_Data data = JsonUtility.FromJson<Swipe_Rev_Data>(json);

            //��ȯ�� ��ü���� Sentences_0_Index���� �ҷ��ͼ� ���� Sentences_0�� ����
            scrollbar.GetComponent<Scrollbar>().value = data.Scroll;//���� ȿ���� ������ �����̴����� �����ͼ�

        }

        if (File.Exists(path1))
        {
            //������ �����ϴ� ��� ������ �о��
            string json1 = File.ReadAllText(path1);

            //JsonUtility.FromJson�� ���� GameData_Typing��ü�� ��ȯ�Ѵ�.
            Swipe_Rev_Data data1 = JsonUtility.FromJson<Swipe_Rev_Data>(json1);

            //��ȯ�� ��ü���� Sentences_0_Index���� �ҷ��ͼ� ���� Sentences_0�� ����
            btnNumber = data1.number;//���� ȿ���� ������ �����̴����� �����ͼ�


        }
        else
        {
            //������ �������� �ʴ� ���
            Debug.Log("����� �����Ͱ� �����ϴ�.");
        }
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
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
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
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
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
            child.localScale = new Vector2(0.64f, 0.64f); // �ʱ� ũ�� ����
        }
        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.4f, 0.4f); // ù ��° ������Ʈ Ȯ��
    }
}*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Rev : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    //private float time;
    //private Button takeTheBtn;
    public int btnNumber;

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
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
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
        firstChild.localScale = new Vector2(0.64f, 0.64f);
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
        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
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
                transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
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
    }

}*/



//��� ���� �ܿ� ��
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_Win : MonoBehaviour
{
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    public bool runIt = false;
    public int btnNumber;

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
            if (!Input.GetMouseButton(0) || Input.touchCount == 0)
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

        // ó������ ���̾ƿ� �׷��� ����� �ݿ��ǵ��� ������ ������Ʈ
        LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
    }

    private void CenterOnStart()
    {
        scroll_pos = pos[0];
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;

        Transform firstChild = imageContent.transform.GetChild(0);
        firstChild.localScale = new Vector2(0.64f, 0.64f);
    }

    private void CenterOnClosest()
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

        if (selectedIndex != -1 && imageContent.transform.GetChild(selectedIndex).localScale.x >= 0.63f)
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (j != selectedIndex)
                {
                    imageContent.transform.GetChild(j).localScale = new Vector2(0.45f, 0.45f);
                }
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
            return;
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == selectedIndex)
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.64f, 0.64f);
            }
            else
            {
                imageContent.transform.GetChild(i).localScale = new Vector2(0.45f, 0.45f);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(imageContent.GetComponent<RectTransform>());
    }

    private void GecisiDuzenle()
    {
        scrollbar.GetComponent<Scrollbar>().value = pos[btnNumber];
        RectTransform selectedChild = imageContent.transform.GetChild(btnNumber).GetComponent<RectTransform>();

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageContent.GetComponent<RectTransform>(),
            screenCenter,
            null,
            out Vector2 localPoint);

        selectedChild.anchoredPosition = localPoint;
        runIt = false;
    }
}*/

