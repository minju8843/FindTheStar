using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Color : MonoBehaviour
{
    public string itemName;//������ �̸�
    public TextMeshProUGUI Name_Text;//������ �̸� ��Ÿ�� �ؽ�Ʈ

    public Bag_Item bag_item;//������ �������� ��ũ��Ʈ
    public TextMeshProUGUI quantityText;//���� ��Ÿ�� �ؽ�Ʈ
    public Image itemImage;//���� �ٲ� ������ �̹���
    
    public Image Gray_Image;//���� �ٲ� ȸ�� �̹���
    public GameObject Big_Item_Image;//������ â�� ���� ������ �̹���

    public static Item_Color Touch_btn;//���� ���� ��ư ->
    //���� ��ư�� �������� ���� ���ϰų� ������ �̹����� ���̰�
    //�ٸ� ��ư�� ���� ������ ���ƿ��� ������ �̹����� ������ �ʰ� �ȴ�.


    public void Update()
    {
        //������ ������ �����´�
        /*int itemQuantity = bag_item.GetItemQuantity(itemName);
        

        //quantityText.text = "����: " + itemQuantity + "��";

        //���� ������ 0�� ���, ������ ȸ������ �� ����
        if (itemQuantity == 0)
        {
            itemImage.color = new Color32(106, 106, 106, 143);
            
        }

        //�׷��� �ʴٸ� ���� ������
        if (itemQuantity > 0)
        {
            itemImage.color = Color.white;
        }*/


    }

    public void Color_Chage()//���� ���� ���� ������ �� ����
    {
        //������ ������ �����´�
        int itemQuantity = bag_item.GetItemQuantity(itemName);


        //quantityText.text = "����: " + itemQuantity + "��";

        //���� ������ 0�� ���, ������ ȸ������ �� ����
        if (itemQuantity == 0)
        {
            itemImage.color = new Color32(106, 106, 106, 143);

        }

        //�׷��� �ʴٸ� ���� ������
        if (itemQuantity > 0)
        {
            itemImage.color = Color.white;
        }
    }


    public void Item_Click()
    {
        SFX_Manager.instance.SFX_Button();

        //��ư ��������
        //������ �̸� ���̱�
        Name_Text.text = itemName;


        //ȸ�� �̹��� �� ����
        Gray_Image.color = new Color32(253, 170, 170, 255);

        //������ �̹��� ��Ÿ������
        Big_Item_Image.SetActive(true);

        //������ ������ �����´�
        int itemQuantity = bag_item.GetItemQuantity(itemName);
        quantityText.text = "����: " + itemQuantity + "��";

        
        //������ ���õ� ���� ������
        //������ ��ġ�� ��ư�� ������ ������� ���� + ���� ������ �̹��� ��Ȱ��ȭ
        if(Touch_btn != null && Touch_btn != this)
        {
            Touch_btn.Gray_Image.color = Color.white;
            Touch_btn.Big_Item_Image.SetActive(false);
        }

        //���� ��ư�� Ȱ��ȭ ���·� ����!
        Touch_btn = this;
        
    }
}
