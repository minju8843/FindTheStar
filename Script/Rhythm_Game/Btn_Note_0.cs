using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Btn_Note_0 : MonoBehaviour
{
    //public static Note_Btn_0 instance;
    //public BoxCollider2D col_0;

    // public RectTransform[] button;

    public GameObject[] Line_0_Note;
    public Note_1105[] Line_0;

    public Long_Col[] Long_fin_0;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_0;
    public RectTransform[] Long_Note_0_Rect;

    public GameObject[] Line_1_Note;
    public Note_1105[] Line_1;

    public Long_Col[] Long_fin_1;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_1;
    public RectTransform[] Long_Note_1_Rect;

    public GameObject[] Line_2_Note;
    public Note_1105[] Line_2;

    public Long_Col[] Long_fin_2;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_2;
    public RectTransform[] Long_Note_2_Rect;

    public GameObject[] Line_3_Note;
    public Note_1105[] Line_3;

    public Long_Col[] Long_fin_3;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_3;
    public RectTransform[] Long_Note_3_Rect;

    public GameObject[] Line_4_Note;
    public Note_1105[] Line_4;

    public Long_Col[] Long_fin_4;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_4;
    public RectTransform[] Long_Note_4_Rect;

    public GameObject[] Line_5_Note;
    public Note_1105[] Line_5;

    public Long_Col[] Long_fin_5;//�ճ�Ʈ ���κ�
    public Long_Note[] Long_Note_5;
    public RectTransform[] Long_Note_5_Rect;//�ճ�Ʈ ��� ��ġ -> 0823 ����Ʈ�� �� �������� ���� ������

    //public GameObject[] Long_fin_4_Long_Note;//�ճ�Ʈ ���
    

    //public GameObject[] Line_5_Long_Note;//�ճ�Ʈ ���
    




    

    //public Transform[] Long_Note_5_Tran;

    //public GameObject[] Long_fin_5_Long_Note;//�ճ�Ʈ ���


    public bool Line_0_Touch = false;
    public bool Line_1_Touch = false;
    public bool Line_2_Touch = false;
    public bool Line_3_Touch = false;
    public bool Line_4_Touch = false;
    public bool Line_5_Touch = false;

    public static Btn_Note_0 instance;



    //1108
    public GameObject btn0;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;



    void Start()
    {
        instance = this;
        Input.multiTouchEnabled = true;  // ��Ƽ��ġ Ȱ��ȭ

        //// �ʱ� ���� ����
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            buttonPressed[i] = false;
        }
    }

    private void Awake()
    {
        Input.multiTouchEnabled = true;  // ��Ƽ��ġ Ȱ��ȭ
    }

    public List<GameObject> buttons; // ���� ��ư�� ó���ϱ� ���� List<GameObject> ���


    private bool[] buttonPressed = new bool[6]; // 6���� ��ư (Btn_0 ~ Btn_5)



    // ��ư ��ġ ����
    public void OnButtonDown(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonPressed.Length)
        {
            buttonPressed[buttonIndex] = true;
            Debug.Log($"Button {buttonIndex} Down");
            HandleButtonPress(buttonIndex, true);
        }
    }

    // ��ư ��ġ ����
    public void OnButtonUp(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonPressed.Length)
        {
            buttonPressed[buttonIndex] = false;
            Debug.Log($"Button {buttonIndex} Up");
            HandleButtonPress(buttonIndex, false);
        }
    }

    // ��ư ���� ó�� (���� ������ ����)
    private void HandleButtonPress(int buttonIndex, bool isPressed)
    {
        switch (buttonIndex)
        {
            case 0:
                if (isPressed) Btn_0_Down();
                else Btn_0_Up();
                break;
            case 1:
                if (isPressed) Btn_1_Down();
                else Btn_1_Up();
                break;
            case 2:
                if (isPressed) Btn_2_Down();
                else Btn_2_Up();
                break;
            case 3:
                if (isPressed) Btn_3_Down();
                else Btn_3_Up();
                break;
            case 4:
                if (isPressed) Btn_4_Down();
                else Btn_4_Up();
                break;
            case 5:
                if (isPressed) Btn_5_Down();
                else Btn_5_Up();
                break;
        }
    }







    /*private bool isBtn0Pressed = false;
    private bool isBtn1Pressed = false;
    private bool isBtn2Pressed = false;
    private bool isBtn3Pressed = false;
    private bool isBtn4Pressed = false;
    private bool isBtn5Pressed = false;

    private bool[] buttonTouched = new bool[6];
    private bool[] buttonTouchStarted = new bool[6];
    */


    /* void Update()
     {
         if (Input.touchCount > 0) // ��ġ�� ���� ��
         {
             for (int i = 0; i < Input.touchCount; i++)
             {
                 Touch touch = Input.GetTouch(i);
                 Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                 // �� ��ư�� ���� ��ġ ���� �� ���� üũ
                 for (int j = 0; j < buttons.Count && j < 6; j++) // ��ư�� 6�� �̳��� ��쿡�� Ȯ��
                 {
                     if (IsTouchingButton(buttons[j], touchPosition))
                     {
                         if (touch.phase == TouchPhase.Began)
                         {
                             buttonTouchStarted[j] = true; // �ش� ��ư�� ���� ��ġ ���۵�
                             Debug.Log($"{j}��° ��ư ��ġ ���۵Ǿ����ϴ�.");
                         }
                         else if (touch.phase == TouchPhase.Ended)
                         {
                             buttonTouched[j] = true; // �ش� ��ư�� ���� ��ġ �����
                             Debug.Log($"{j}��° ��ư ��ġ ����Ǿ����ϴ�.");
                         }
                     }
                 }
             }
         }
     }

     // ��ġ�� �ش� ��ư�� ���ԵǴ��� Ȯ���ϴ� �޼���
     bool IsTouchingButton(GameObject button, Vector2 touchPosition)
     {
         Collider2D buttonCollider = button.GetComponent<Collider2D>();
         if (buttonCollider != null)
         {
             return buttonCollider.OverlapPoint(touchPosition);
         }
         return false;
     }

     // ��ư ��ġ ���� ���θ� ��ȯ�ϴ� �޼��� (���ϴ� ��ư ��ȣ�� ���¸� Ȯ��)
     public bool IsButtonTouchStarted(int buttonIndex)
     {
         if (buttonIndex >= 0 && buttonIndex < buttonTouchStarted.Length)
         {
             return buttonTouchStarted[buttonIndex];
         }
         return false;
     }

     // ��ư ��ġ ���� ���θ� ��ȯ�ϴ� �޼��� (���ϴ� ��ư ��ȣ�� ���¸� Ȯ��)
     public bool IsButtonTouched(int buttonIndex)
     {
         if (buttonIndex >= 0 && buttonIndex < buttonTouched.Length)
         {
             return buttonTouched[buttonIndex];
         }
         return false;
     }*/



    //�и� ��Ƽ ��ġ �� �Ǿ��� �� ������, �� �ȵ�
    /*void Update()
    {
        int i = 0;
        Debug.Log("���� ��ġ �: " + Input.touchCount); // ���� ��ġ ������ ����Ͽ� �����

        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                //Debug.Log("Touch began - FingerId: " + t.fingerId);

                // �� ��ư�� ���� ��ġ�� ���� ���� �ִ��� Ȯ��
                foreach (GameObject button in buttons)
                {
                    if (IsTouchInsideButton(button, t))
                    {
                        // ��ġ�� ��ư�� 0�� ��ư���� Ȯ��
                        if (button == buttons[0] && t.fingerId == 0)
                        {
                            isBtn0Pressed = true;
                            ExecuteButtonFunction(button, t.fingerId); // 0�� ��ư ���� ����
                        }
                        else if (button != buttons[0]) // 0�� ��ư�� �ƴ� �ٸ� ��ư�� ���
                        {
                            isBtn0Pressed = false;
                            ExecuteButtonFunction(button, t.fingerId); // �ٸ� ��ư ����
                        }


                    }
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
               // Debug.Log("Touch ended - FingerId: " + t.fingerId);
                isBtn0Pressed = false;  // ��ġ�� ����� �� 0�� ��ư ���� �ʱ�ȭ
            }

            i++;
        }
    }

    bool IsTouchInsideButton(GameObject button, Touch touch)
    {
        // ��ư�� RectTransform�� �����ͼ� ��ġ ��ġ�� ��
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        return buttonRect.rect.Contains(buttonRect.InverseTransformPoint(touch.position));
    }

    // ��ư�� ������ �� ȣ��Ǵ� �Լ�
    void ExecuteButtonFunction(GameObject button, int fingerId)
    {
        // ��ġ�� ��ư�� fingerId�� ���� �ٸ� ����� ����
        switch (fingerId)
        {
            case 0:
                break;

            case 1:
                Btn_1_Down();
                break;

            case 2:
                Btn_2_Down();
                break;

            case 3:
                Btn_3_Down();
                break;

            case 4:
                Btn_4_Down();
                break;

            case 5:
                Btn_5_Down();
                break;

        }
    }*/

    /*public List<GameObject> buttons;  // ��ư ��� (�� ��ư�� ���� GameObject)

    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                // ��ġ�� ���۵� ��ġ�� ��ư ���� ���� �ִ��� üũ
                CheckButtonPress(t);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("touch ended");
                // ��ġ�� ����Ǿ��� ���� ó�� (�ʿ� �� �߰� ��� �ۼ� ����)
            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("touch is moving");
                // ��ġ�� �̵� ���� ���� ó�� (�ʿ� �� �߰� ��� �ۼ� ����)
            }

            ++i;
        }
    }

    // ��ġ ��ġ�� UI ȭ�� ��ǥ�� ��ȯ
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return touchPosition;  // UI���� ����ϴ� ��ǥ�� Screen space �״�� ���
    }

    // ��ġ�� ��ư ���� ���� �ִ��� üũ�ϰ�, ��ư�� ����� ����
    void CheckButtonPress(Touch t)
    {
        Vector2 touchPosition = getTouchPosition(t.position);

        // �� ��ư�� ���ؼ� ��ġ ��ġ�� �ش� ��ư�� Collider2D ���� ���� �ִ��� Ȯ��
        foreach (var button in buttons)
        {
            Collider2D buttonCollider = button.GetComponent<Collider2D>();
            if (buttonCollider.OverlapPoint(touchPosition))
            {
                // ��ư�� ������ �� ������ ����� ȣ��
                ExecuteButtonFunction(button);
            }
        }
    }

    // ��ư�� ������ �� ������ ���
    void ExecuteButtonFunction(GameObject button)
    {
        // ��ư�� �´� ����� ���⿡ �ۼ�
        // ���÷� ��ư �̸��� ����ϴ� ���:
        Debug.Log(button.name + " pressed");
    }*/


    /*private void Update()
    {
        // ��ġ�� ���� ��쿡�� ó��
        if (Input.touchCount > 0)
        {
            // ��� ��ġ�� ���������� ó��
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // ��ġ ��ġ�� ���� ��ǥ�� ��ȯ
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // ��ġ�� ���¿� ���� ��ư ó��
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // ��ġ�� ���۵� ��, �� ��ư�� ������ ��ġ�� ���ԵǾ� �ִ��� Ȯ��
                        HandleTouchBegin(touchPosition);
                        break;



                    case TouchPhase.Ended:
                        // ��ġ�� ������ ��, ��ġ ���� ó��
                        HandleTouchEnd(touchPosition);
                        break;
                }
            }
        }
    }

    private void HandleTouchBegin(Vector2 touchPosition)
    {
        if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_0_Down();
        }

        if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_1_Down();
        }

        if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_2_Down();
        }

        if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_3_Down();
        }

        if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_4_Down();
        }

        if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_5_Down();
        }
    }

    private void HandleTouchEnd(Vector2 touchPosition)
    {
        if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_0_Up();
        }

        if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_1_Up();
        }

        if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_2_Up();
        }

        if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_3_Up();
        }

        if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_4_Up();
        }

        if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
        {
            Btn_5_Up();
        }
    }*/

    //1108
    /*private void Update()
     {
         for (int i = 0; i < Input.touchCount; i++)
         {
             Touch touch = Input.GetTouch(i);

             if (touch.phase == TouchPhase.Began)
             {
                 // ��ġ ��ġ�� ���� ��ǥ�� ��ȯ
                 Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                 // �� ��ư�� Collider�� �����ͼ� ��ġ ��ġ�� �ش� ��ư ���� �ȿ� �ִ��� Ȯ��
                 if (btn0.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_0_Down(); // Btn_4_Down ȣ��
                 }

                 if (btn1.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_1_Down(); // Btn_5_Down ȣ��
                 }

                 if (btn2.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_2_Down(); // Btn_5_Down ȣ��
                 }

                 if (btn3.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_3_Down(); // Btn_5_Down ȣ��
                 }

                 if (btn4.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_4_Down(); // Btn_5_Down ȣ��
                 }

                 if (btn5.GetComponent<Collider2D>().OverlapPoint(touchPosition))
                 {
                     Btn_5_Down(); // Btn_5_Down ȣ��
                 }
             }
         }
     }//1108
    */


    public void Btn_0_Down()
    {

        for (int i = 0; i < Line_0.Length; i++)
        {
            Line_0[i].Button_0_Pressed = true;
        }

        for (int i = 0; i < Long_Note_0.Length; i++)
        {

            Long_Note_0[i].Button_0_Pressed = true;

        }

        for (int i = 0; i < Long_fin_0.Length; i++)
        {

            Long_fin_0[i].Button_0_Pressed = true;

        }

        //Debug.Log("0 ����");

    }

    public void Btn_0_Up()
    {
      

        //����ũ ��Ȱ��ȭ
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_0_Note.Length; j++)
        {
            Line_0[j].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_Note_0.Length; i++)
        {

            Long_Note_0[i].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_fin_0.Length; i++)
        {

            

            Long_fin_0[i].Button_0_Pressed = false;


        }

        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag5 = GameObject.FindGameObjectsWithTag("Long_Note_Effect0");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag5)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }

        GameObject[] objectsWithTag6 = GameObject.FindGameObjectsWithTag("Note_Effect0");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag6)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        //Debug.Log("5�ø�");
    }



    public void Btn_1_Down()
    {

        for (int i = 0; i < Line_1.Length; i++)
        {
            Line_1[i].Button_1_Pressed = true;
        }

        for (int i = 0; i < Long_Note_1.Length; i++)
        {

            Long_Note_1[i].Button_1_Pressed = true;

        }

        for (int i = 0; i < Long_fin_1.Length; i++)
        {

            Long_fin_1[i].Button_1_Pressed = true;

        }

       // Debug.Log("1 ����");

    }

    public void Btn_1_Up()
    {
        //����ũ ��Ȱ��ȭ
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_1_Note.Length; j++)
        {
            Line_1[j].Button_1_Pressed = false;
        }

        for (int i = 0; i < Long_Note_1.Length; i++)
        {

            Long_Note_1[i].Button_1_Pressed = false;
        }

        for (int i = 0; i < Long_fin_1.Length; i++)
        {



            Long_fin_1[i].Button_1_Pressed = false;


        }

        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect1");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect1");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        //Debug.Log("5�ø�");
    }

    //2
    public void Btn_2_Down()
    {

        for (int i = 0; i < Line_2.Length; i++)
        {
            Line_2[i].Button_2_Pressed = true;
        }

        for (int i = 0; i < Long_Note_2.Length; i++)
        {

            Long_Note_2[i].Button_2_Pressed = true;

        }

        for (int i = 0; i < Long_fin_2.Length; i++)
        {

            Long_fin_2[i].Button_2_Pressed = true;

        }

        //Debug.Log("2 ����");

    }

    public void Btn_2_Up()
    {
 

        //����ũ ��Ȱ��ȭ
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_2_Note.Length; j++)
        {
            Line_2[j].Button_2_Pressed = false;
        }

        for (int i = 0; i < Long_Note_2.Length; i++)
        {

            Long_Note_2[i].Button_2_Pressed = false;
        }

        for (int i = 0; i < Long_fin_2.Length; i++)
        {

            Long_fin_2[i].Button_2_Pressed = false;


        }

        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect2");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }

        GameObject[] objectsWithTag3 = GameObject.FindGameObjectsWithTag("Note_Effect2");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag3)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        //Debug.Log("2�ø�");
    }

    //3
    public void Btn_3_Down()
    {

        for (int i = 0; i < Line_3.Length; i++)
        {
            Line_3[i].Button_3_Pressed = true;
        }

        for (int i = 0; i < Long_Note_3.Length; i++)
        {

            Long_Note_3[i].Button_3_Pressed = true;

        }

        for (int i = 0; i < Long_fin_3.Length; i++)
        {

            Long_fin_3[i].Button_3_Pressed = true;

        }

       // Debug.Log("3 ����");

    }

    public void Btn_3_Up()
    {
        //����ũ ��Ȱ��ȭ
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_3_Note.Length; j++)
        {
            Line_3[j].Button_0_Pressed = false;
        }

        for (int i = 0; i < Long_Note_3.Length; i++)
        {

            Long_Note_3[i].Button_3_Pressed = false;
        }

        for (int i = 0; i < Long_fin_3.Length; i++)
        {



            Long_fin_3[i].Button_3_Pressed = false;


        }

        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect3");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect3");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        //Debug.Log("5�ø�");
    }

    public void Btn_4_Down()
    {

        for (int i = 0; i < Line_4.Length; i++)
        {
            Line_4[i].Button_4_Pressed = true;
        }

        for (int i = 0; i < Long_Note_4.Length; i++)
        {

            Long_Note_4[i].Button_4_Pressed = true;

        }

        for (int i = 0; i < Long_fin_4.Length; i++)
        {

            Long_fin_4[i].Button_4_Pressed = true;

        }
        //Debug.Log("4����");
    }

    public void Btn_4_Up()
    {
        //����ũ ��Ȱ��ȭ
        //Manager_0..instance.Long_Line_Mask[4].enabled = false;

        for (int j = 0; j < Line_4_Note.Length; j++)
        {
            Line_4[j].Button_4_Pressed = false;
        }

        for (int i = 0; i < Long_Note_4.Length; i++)
        {

            Long_Note_4[i].Button_4_Pressed = false;
        }

        for (int i = 0; i < Long_fin_4.Length; i++)
        {

            //���� ����Ʈ�� �־�����
           /* GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

            foreach (GameObject obj in objectsWithTag)
            {
                //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
                Destroy(obj);
            }*/

            Long_fin_4[i].Button_4_Pressed = false;


        }

        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect4");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect4");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }
    }

    //5
    public void Btn_5_Down()
    {

        for (int i = 0; i < Line_5.Length; i++)
        {
            Line_5[i].Button_5_Pressed = true;
        }

        for (int i = 0; i < Long_Note_5.Length; i++)
        {

            Long_Note_5[i].Button_5_Pressed = true;

        }

        for (int i = 0; i < Long_fin_5.Length; i++)
        {

            Long_fin_5[i].Button_5_Pressed = true;

        }

        //Debug.Log("5 ����");

    }

    public void Btn_5_Up()
    {
        //����ũ ��Ȱ��ȭ
        //Manager_0.instance.Long_Line_Mask[5].enabled = false;

        for (int j = 0; j < Line_5_Note.Length; j++)
        {
            Line_5[j].Button_5_Pressed = false;
        }

        for (int i = 0; i < Long_Note_5.Length; i++)
        {

            Long_Note_5[i].Button_5_Pressed = false;
        }

        for (int i = 0; i < Long_fin_5.Length; i++)
        {

            //���� ����Ʈ�� �־�����
           /* GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

            foreach (GameObject obj in objectsWithTag)
            {
                //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
                Destroy(obj);
            }*/

            Long_fin_5[i].Button_5_Pressed = false;


        }
        //���� ����Ʈ�� �־�����
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Long_Note_Effect5");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }

        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("Note_Effect5");//Hierarchy������ ������Ʈ ã��

        foreach (GameObject obj in objectsWithTag1)
        {
            //Long_Note_Effect5�±׸� ���� ������Ʈ�� ������ �����Ѵ�.
            Destroy(obj);
        }


        //Debug.Log("5�ø�");
    }



}
