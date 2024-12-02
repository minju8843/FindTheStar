using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    //public GameObject[] Main_False;//��Ȱ���ؾ� �� ��

    public Button[] btn;

    public GameObject Show_Three_Btn;//��ư 3�� ���ִ� ��
    //public Animator Menu_anim;//�޴� ��ư�� ������ ��, ��/�Ʒ��� ������ �ִϸ��̼�
    public int Menu_Touch_Count = 0;//�޴� ��ư�� �� �� �������� -> ���� �����ϸ� ���µ�

    //public GameObject HeadPhone;//���� �ٲٱ� ���빰
    //public GameObject Setting;//���� ���빰

    public static UI_Button instance;

    public Map map;
    public GameObject Bag; //Piano, Piano_Btn;//, Piano_Content;

    //public Swipe_1_fin swipe_1;

    //public GameObject album_bgm;

    private void Start()
    {
        Show_Three_Btn.SetActive(false);

        Winter_Music.instance.HeadPhone.SetActive(false);
        Winter_Music.instance.Setting.SetActive(false);//����

        Bag.SetActive(false);//����

        instance = this;
    }

    public void Go_Setting()
    {
        //���������� �̵�
        SFX_Manager.instance.SFX_Button();
        Winter_Music.instance.Setting.SetActive(true);
    }

    public void Will_Go_Hint()
    {
        //��Ʈ�� ���ðڽ��ϱ�? ȭ��
        SFX_Manager.instance.SFX_Button();
        Hint.instance.Go_Hint.SetActive(true);
    }

    public void Will_Sleep()
    {
        //���� �� ������? ��, ���� �������� �� �������� ���� ��ư
    }

    public void Go_Map()
    {
        SFX_Manager.instance.SFX_Button();

        //���������� �̵�
        map.map[0].SetActive(true);
        map.map[1].SetActive(true);

        for (int i = 0; i < map.Nine_Image.Length; i++)
        {
            map.Nine_Image[i].SetActive(false);//���� �ƹ��͵� ���õ��� ���� �ɷ�
        }

    }

    public void Go_HeadPhone()
    {
        SFX_Manager.instance.SFX_Button();
        //����� ���� �ٲٴ� â�� �����ֱ�
        Winter_Music.instance.HeadPhone.SetActive(true);
    }

    public void Touch_Menu()
    {
        SFX_Manager.instance.SFX_Button();
        //�޴� ��ư�� ������ ��
        Menu_Touch_Count++;//Ƚ�� �߰�

        if(Menu_Touch_Count % 2 == 0)
        {
            //���࿡ Ƚ���� ¦�����
            //Menu_anim.SetTrigger("Up");
            //���� �ø���

            Show_Three_Btn.SetActive(false);
        }

        else if(Menu_Touch_Count % 2 == 1)
        {
            //���࿡ Ƚ���� Ȧ�����
            //Menu_anim.SetTrigger("Down");
            //�Ʒ��� ��������

            Show_Three_Btn.SetActive(true);
        }
    }

    public void Reset_Btn_Count()
    {
        Menu_Touch_Count = 0;
        Show_Three_Btn.SetActive(false);
    }

    public void Go_Bag()
    {
        SFX_Manager.instance.SFX_Button();
        //��������� �̵�, ������ ������ ���� ���� �� �ʱ�ȭ
        Bag.SetActive(true);

       /* Bag_Item.instance.Current_Page = 0;//ó���� 0������
        for (int i = 1; i < Bag_Item.instance.Category.Length; i++)
        {
            Bag_Item.instance.Category[i].SetActive(false);
        }
        Bag_Item.instance.Category[0].SetActive(true);
        */
        //0�������� ���� 0������ �����ϰ� ������ ������ ��Ȱ��



        for (int i = 0; i < Bag_Item.instance.Select_Item.Length; i++)//������ �̹��� ������ �� ��Ȱ��
        {
            Bag_Item.instance.Select_Item[i].SetActive(false);
        }

        for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)//���õȰ� �� �ʱ�ȭ
        {
            Bag_Item.instance.item_color[i].Gray_Image.color = new Color32(255, 255, 255, 255);
        }

        //Bag_Item.instance.Category_Name.text = "����";
        Bag_Item.instance.Item_Count.text = "����: ?��";
        Bag_Item.instance.Item_Name.text = "???";

        for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
        {
            //�����ۺ��� �� �� �ִ����� ���� �� ���ϴ� ��
            Bag_Item.instance.item_color[i].Color_Chage();
        }
    }

    public void Go_Ch()
    {
        SFX_Manager.instance.SFX_Button();
        //ĳ���� ���������� �̵�
        for (int i = 0; i < Person_Btn.instance.Person_info.Length; i++)
        {
            Person_Btn.instance.Person_info[i].SetActive(true);//�ι� ���� ���� ��� Ȱ��
        }

        Name_Image.instance.Update_TextAndImagePosition();//�̸��� ���� ���� ��ġ �̵�
    }

    public void Go_Play_Piano()
    {
        SFX_Manager.instance.SFX_Button();
        //���̵� �� & �ƿ�
        Rhythm_Fade.instance.Fade.SetActive(true);
        Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Black");

        StartCoroutine(Go_Game());
        IEnumerator Go_Game()
        {
            yield return new WaitForSeconds(0.9f);
            //�ǾƳ� ���ֶ����� �̵�
            Winter_Music.instance.Piano.SetActive(true);
            Winter_Music.instance.Piano_Btn.SetActive(true);
            //swipe_1.Reset();

            
            //swipe_1.previousBtnNumber = -1;
            //swipe_1.btnNumber = 0;
            //swipe_1.scrollbar.GetComponent<Scrollbar>().value = 0.0f;

            //swipe_1.GecisiDuzenle();

            // Piano_Content.SetActive(true);
            //Select_Album.instance.select_Album.SetActive(true);


            StartCoroutine(SetActive_Middle());
            //Title_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
            //StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_Middle()
        {
            yield return new WaitForSeconds(0.5f);
            Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");

            //swipe_1.Load();
            //Debug.Log("���� �ǳ�?" + swipe_1.btnNumber);

            Change_Music.instance.Music_Col_Parent.SetActive(false);//�Ϲ� ��� ���� ��Ȱ��
            //Select_Album.instance.BGM.SetActive(true);
            Winter_Music.instance.album_bgm.SetActive(true);

            StartCoroutine(SetActive_False());
        }

        IEnumerator SetActive_False()
        {
            yield return new WaitForSeconds(0.9f);//1.4
           // Title_Fade.instance.Fade_Canvas.SetActive(false);
            //Debug.Log("���̵� ����");
        }

       
    }
    
}
