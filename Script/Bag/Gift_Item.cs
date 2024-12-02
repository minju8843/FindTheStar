using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;//LINQ�� ����ϱ� ���� �ʿ�

//1
[System.Serializable]
public class Item_1_Person//������ �̸��� ������ �����ϱ� ����
{
    public string itemName;//������ �̸� ����
    public int item_quantity;//������ ���� ����

    public Item_1_Person(string name, int quantity)//��ü�� ������ �� ȣ��Ǵ� �Լ�
    {//itemName�� item_quantity�� �ʱⰪ�� ������ �� ����.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_1_Person
{
    public List<Item_1_Person> items_1;

    public List_1_Person(List<Item_1_Person> items_1)
    {
        this.items_1 = items_1;
    }
}

//2
[System.Serializable]
public class Item_2_Person//������ �̸��� ������ �����ϱ� ����
{
    public string itemName;//������ �̸� ����
    public int item_quantity;//������ ���� ����

    public Item_2_Person(string name, int quantity)//��ü�� ������ �� ȣ��Ǵ� �Լ�
    {//itemName�� item_quantity�� �ʱⰪ�� ������ �� ����.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_2_Person
{
    public List<Item_2_Person> items_2;

    public List_2_Person(List<Item_2_Person> items_2)
    {
        this.items_2 = items_2;
    }
}

//3
[System.Serializable]
public class Item_3_Person//������ �̸��� ������ �����ϱ� ����
{
    public string itemName;//������ �̸� ����
    public int item_quantity;//������ ���� ����

    public Item_3_Person(string name, int quantity)//��ü�� ������ �� ȣ��Ǵ� �Լ�
    {//itemName�� item_quantity�� �ʱⰪ�� ������ �� ����.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_3_Person
{
    public List<Item_3_Person> items_3;

    public List_3_Person(List<Item_3_Person> items_3)
    {
        this.items_3 = items_3;
    }
}

//4
[System.Serializable]
public class Item_4_Person//������ �̸��� ������ �����ϱ� ����
{
    public string itemName;//������ �̸� ����
    public int item_quantity;//������ ���� ����

    public Item_4_Person(string name, int quantity)//��ü�� ������ �� ȣ��Ǵ� �Լ�
    {//itemName�� item_quantity�� �ʱⰪ�� ������ �� ����.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_4_Person
{
    public List<Item_4_Person> items_4;

    public List_4_Person(List<Item_4_Person> items_4)
    {
        this.items_4 = items_4;
    }
}

//5
[System.Serializable]
public class Item_5_Person//������ �̸��� ������ �����ϱ� ����
{
    public string itemName;//������ �̸� ����
    public int item_quantity;//������ ���� ����

    public Item_5_Person(string name, int quantity)//��ü�� ������ �� ȣ��Ǵ� �Լ�
    {//itemName�� item_quantity�� �ʱⰪ�� ������ �� ����.
        itemName = name;
        item_quantity = quantity;
    }
}

[System.Serializable]
public class List_5_Person
{
    public List<Item_5_Person> items_5;

    public List_5_Person(List<Item_5_Person> items_5)
    {
        this.items_5 = items_5;
    }
}

public class Gift_Item : MonoBehaviour
{
    public Bag_Item bag_item;

    public bool Person_1 = false;
    public bool Person_2 = false;
    public bool Person_3 = false;
    public bool Person_4 = false;
    public bool Person_5 = true;

    public TextMeshProUGUI Gift_Text;



    //������� �������� �־��� ��
    //Ư�� �������� ��� ȣ���Ǵ� �������� �������� ���, "����!"�� ����ϰ�
    //������ �׳� �������� �������� ���, "�� ������."
    //�Ⱦ��ϴ� �������� �޾��� ���, "��..." �� ����Ѵ�.

    //������� ���� �������� �����Ѵ�.

    //������ ���� ���� ��ųʸ�(������ �̸�-����)
    public Dictionary<string, int> Person_1_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_2_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_3_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_4_Item = new Dictionary<string, int>();
    public Dictionary<string, int> Person_5_Item = new Dictionary<string, int>();

    public void Gift()
    {
        SFX_Manager.instance.SFX_Button();

        if (Gift_Text.text == "�����ϱ�")
        {
            if (Person_1 == true)
            {
                // Gray �̹��� ������ �ִ� Item_Color �迭���� �ش� ������ ã��
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // �ش� �������� �̸� ��������
                        string itemName = item.itemName;

                        // �ش� �������� �����ϴ��� Ȯ���ϰ� ������ ������
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // ������ ���� 1 ����
                            bag_item.AddItem(itemName, -1);

                            // ������ ������ Gift_Save�� ����
                            Gift_1_Save(itemName, 1);

                            Debug.Log($"{itemName}��(��) 1��ŭ ���ҵǾ����ϴ�. ���� ����: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}�� ������ �����մϴ�.");
                        }

                        break; // ã������ �ݺ� ����
                    }
                }

                //������ ���� �� ������Ʈ
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //��ư ���� ��, �����ۺ��� �� �� �ִ����� ���� �� ���ϴ� �ɷ�
                    //Update�� �ڵ尡 ������ �̻��ؼ� �� ��ũ��Ʈ�� �ű�
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //2
            if (Person_2 == true)
            {
                // Gray �̹��� ������ �ִ� Item_Color �迭���� �ش� ������ ã��
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // �ش� �������� �̸� ��������
                        string itemName = item.itemName;

                        // �ش� �������� �����ϴ��� Ȯ���ϰ� ������ ������
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // ������ ���� 1 ����
                            bag_item.AddItem(itemName, -1);

                            // ������ ������ Gift_Save�� ����
                            Gift_2_Save(itemName, 1);

                            Debug.Log($"{itemName}��(��) 1��ŭ ���ҵǾ����ϴ�. ���� ����: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}�� ������ �����մϴ�.");
                        }

                        break; // ã������ �ݺ� ����
                    }
                }

                //������ ���� �� ������Ʈ
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //��ư ���� ��, �����ۺ��� �� �� �ִ����� ���� �� ���ϴ� �ɷ�
                    //Update�� �ڵ尡 ������ �̻��ؼ� �� ��ũ��Ʈ�� �ű�
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //3
            if (Person_3 == true)
            {
                // Gray �̹��� ������ �ִ� Item_Color �迭���� �ش� ������ ã��
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // �ش� �������� �̸� ��������
                        string itemName = item.itemName;

                        // �ش� �������� �����ϴ��� Ȯ���ϰ� ������ ������
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // ������ ���� 1 ����
                            bag_item.AddItem(itemName, -1);

                            // ������ ������ Gift_Save�� ����
                            Gift_3_Save(itemName, 1);

                            Debug.Log($"{itemName}��(��) 1��ŭ ���ҵǾ����ϴ�. ���� ����: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}�� ������ �����մϴ�.");
                        }

                        break; // ã������ �ݺ� ����
                    }
                }

                //������ ���� �� ������Ʈ
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //��ư ���� ��, �����ۺ��� �� �� �ִ����� ���� �� ���ϴ� �ɷ�
                    //Update�� �ڵ尡 ������ �̻��ؼ� �� ��ũ��Ʈ�� �ű�
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //4
            if (Person_4 == true)
            {
                // Gray �̹��� ������ �ִ� Item_Color �迭���� �ش� ������ ã��
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // �ش� �������� �̸� ��������
                        string itemName = item.itemName;

                        // �ش� �������� �����ϴ��� Ȯ���ϰ� ������ ������
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // ������ ���� 1 ����
                            bag_item.AddItem(itemName, -1);

                            // ������ ������ Gift_Save�� ����
                            Gift_4_Save(itemName, 1);

                            Debug.Log($"{itemName}��(��) 1��ŭ ���ҵǾ����ϴ�. ���� ����: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}�� ������ �����մϴ�.");
                        }

                        break; // ã������ �ݺ� ����
                    }
                }

                //������ ���� �� ������Ʈ
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //��ư ���� ��, �����ۺ��� �� �� �ִ����� ���� �� ���ϴ� �ɷ�
                    //Update�� �ڵ尡 ������ �̻��ؼ� �� ��ũ��Ʈ�� �ű�
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }

            //5
            if (Person_5 == true)
            {
                // Gray �̹��� ������ �ִ� Item_Color �迭���� �ش� ������ ã��
                foreach (var item in bag_item.item_color)
                {
                    if (item.Gray_Image.color.Equals(new Color32(253, 170, 170, 255)))
                    {
                        // �ش� �������� �̸� ��������
                        string itemName = item.itemName;

                        // �ش� �������� �����ϴ��� Ȯ���ϰ� ������ ������
                        int itemQuantity = bag_item.GetItemQuantity(itemName);

                        if (itemQuantity > 0)
                        {
                            // ������ ���� 1 ����
                            bag_item.AddItem(itemName, -1);

                            // ������ ������ Gift_Save�� ����
                            Gift_5_Save(itemName, 1);

                            Debug.Log($"{itemName}��(��) 1��ŭ ���ҵǾ����ϴ�. ���� ����: { bag_item.itemQuantities[itemName]}");
                            item.Item_Click();

                        }
                        else
                        {
                            Debug.Log($"{itemName}�� ������ �����մϴ�.");
                        }

                        break; // ã������ �ݺ� ����
                    }
                }

                //������ ���� �� ������Ʈ
                for (int i = 0; i < Bag_Item.instance.item_color.Length; i++)
                {
                    //��ư ���� ��, �����ۺ��� �� �� �ִ����� ���� �� ���ϴ� �ɷ�
                    //Update�� �ڵ尡 ������ �̻��ؼ� �� ��ũ��Ʈ�� �ű�
                    Bag_Item.instance.item_color[i].Color_Chage();
                }
            }
        }

        else
        {
            Debug.Log("������ �� ����� ������ ���� �����Դϴ�.");
        }

    }

    // Gift_Save: ���ҵ� �������� �����ϴ� �Լ�
    //1
    public void Gift_1_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person1_AddItem(newItemName, decreasedQuantity);
        Save_Person_1_Item();
        Debug.Log($"���ҵ� ������ 1�� ����� �޾���: {newItemName}, ����: {decreasedQuantity}");
        

        /*if(newItemName == "����")
        {
            Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
        }

        //
        else if(newItemName == "������")
        {
            Debug.Log("��...");
        }

        else
        {
            Debug.Log($"{newItemName}... �̰� ������ �ִ� �ž�? ����, �� ������!");
        }*/

       /* switch (newItemName)
        {
            //�����ϴ� �� ����
            case "����":
                Debug.Log($"��?! ����ħ {newItemName} �԰�;��µ�, ����! ����ũ�� �÷� ");
                if(decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "������":
                Debug.Log($"��, {newItemName}�ݾ�! ��¥ �޾Ƶ� ��? ��...! ��ŭ������ �޴��� �� ��...! ���־�!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "Ű��":
                Debug.Log($"�̰�... {newItemName}�ݾ�! ��ħ Ű���ֽ��� �԰� �;��µ�, ���ƸԾ�� �ڴ�. ����!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "��Ÿ�� ����":
                Debug.Log($"����... ���� {newItemName}�԰�;��ߴ� �� ��� �˰�! ���屹�� �־� �Ծ����!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "����":
                Debug.Log($"�̰�... ������ �ִ� �ž�? ��¥ �ܿ￡ ��{newItemName} ������ �� ��µ�, ���� ����!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "������":
                Debug.Log($"{newItemName}�ݾ�! �߾��߾�... �̰ɷ� ������ �ظ�����, �ƴϸ� �Ǹ�����... ��...! ���ְ� ������!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "����¡��":
                Debug.Log($"�̰� {newItemName}����...! �� �� �Ծ�� �;��µ�, �� ������!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "��ġ":
                Debug.Log($"{newItemName}�� ���������θ� �ôµ�, ���� ũ����...! ���� ���ְ� �� ������!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "���":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "������ũ":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "�����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "�ϵ���":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "������":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;
            case "�ұ�":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[0].value += 3;
                }
                break;

            //�Ⱦ��ϴ� ��
            case "���":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "������":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "������":
                Debug.Log($"�̰� ...{newItemName}? ����������...? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "�ٴ�":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "��Ƽ��ũ":
                Debug.Log($"�̰� ...{newItemName}? ��� �Ծ�� ����... �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "���":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "������":
                Debug.Log($"�̰� ...{newItemName}? �̰ɷ� �� �ظ���... ����� �Ȱ�... �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? ���־� ������ �ʴµ�... �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "ȣ�ھ�":
                Debug.Log($"�̰� ...{newItemName}? �� ������ �� ��� �Ծ�� �Ϸ���... �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "���α�":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;
            case "������":
                Debug.Log($"�̰�...{ newItemName}? ����...!�� ������.");
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
                break;

            //����, �Ȱ� ������� �ٸ� �������� ���� ��
            default:
                Debug.Log($"��... �̰� ������ �ִ� �ž�? {newItemName} �� ������!");
                break;
        }*/

       


    }

    //2 -> ������
    public void Gift_2_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person2_AddItem(newItemName, decreasedQuantity);
        Save_Person_2_Item();
        Debug.Log($"���ҵ� ������ 2�� ����� �޾���: {newItemName}, ����: {decreasedQuantity}");

        /*switch (newItemName)
        {
            //�����ϴ� �� ����
            case "���":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "���ڳ�":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "�ñ�ġ":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "ȣ��":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "��ĭ":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "ĳ����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "��ũ���� ġ��":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "�ĸ��޻� ġ��":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "�ٴҶ�":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "��������":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "�̽�Ʈ":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "�ް�":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;
            case "����":
                Debug.Log($"�ƴ�, �̰�...?! {newItemName}�ݾ�! ����!!");
                if (decreasedQuantity == 0)
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 7;
                }
                else
                {
                    Like_Slider.instance.Person_Like_Slider[1].value += 3;
                }
                break;

            //�Ⱦ��ϴ� ��
            case "Ŀ��Ʈ":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "�ڸ�":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "��ȭ��":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? ����...! �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "Ʈ����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "��ö�":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "��� ��ƿ��":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "ġ�ƽõ�":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "�ͻ��":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "����":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "�ӽ�Ÿ��":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;
            case "��ø":
                Debug.Log($"�̰� ...{newItemName}? �ϴ� �� ������.");
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
                break;

            //����, �Ȱ� ������� �ٸ� �������� ���� ��
            default:
                Debug.Log($"��... �̰� ������ �ִ� �ž�? {newItemName} �� ������!");
                break;
               
        }*/
    }

    //3
    public void Gift_3_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person3_AddItem(newItemName, decreasedQuantity);
        Save_Person_3_Item();
        Debug.Log($"���ҵ� ������ 3�� ����� �޾���: {newItemName}, ����: {decreasedQuantity}");
    }

    //4
    public void Gift_4_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person4_AddItem(newItemName, decreasedQuantity);
        Save_Person_4_Item();
        Debug.Log($"���ҵ� ������ 4�� ����� �޾���: {newItemName}, ����: {decreasedQuantity}");
    }

    //5
    public void Gift_5_Save(string itemName, int decreasedQuantity)
    {
        string newItemName = $"{itemName}";
        Person5_AddItem(newItemName, decreasedQuantity);
        Save_Person_5_Item();
        Debug.Log($"���ҵ� ������ 5�� ����� �޾���: {newItemName}, ����: {decreasedQuantity}");
    }


    /// ***************************************************************************************
    private void Person1_AddItem(string itemName, int quantity)
    {
        // Ű�� �������� ���� ��쿡�� �߰�
        if (!Person_1_Item.ContainsKey(itemName))
        {
            Person_1_Item.Add(itemName, quantity); // ���ο� Ű�� ���� �߰�

            if (itemName == "����" || itemName == "������" || itemName == "Ű��" || itemName == "��Ÿ�� ����" || itemName == "����"
                || itemName == "������" || itemName == "����¡��" || itemName == "��ġ" || itemName == "���" || itemName == "������ũ"
                || itemName == "�����" || itemName == "�ϵ���" || itemName == "������" || itemName == "����" || itemName == "�ұ�")
            {
                Like_Slider.instance.Person_Like_Slider[0].value += 7;
            }

            else if (itemName == "���" || itemName == "����" || itemName == "����" || itemName == "������" || itemName == "����"
                || itemName == "������" || itemName == "�ٴ�" || itemName == "��Ʈ��ũ" || itemName == "���" || itemName == "������"
                || itemName == "����" || itemName == "ȣ�ھ�" || itemName == "���α�" || itemName == "����" || itemName == "������")
            {
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
            }

            else
            {
                Debug.Log("ȣ���� ����");
            }

        }
        else
        {
            Person_1_Item[itemName] += quantity; // ���� Ű�� ���� ������Ʈ

            if (itemName == "����" || itemName == "������" || itemName == "Ű��" || itemName == "��Ÿ�� ����" || itemName == "����"
                || itemName == "������" || itemName == "����¡��" || itemName == "��ġ" || itemName == "���" || itemName == "������ũ"
                || itemName == "�����" || itemName == "�ϵ���" || itemName == "������" || itemName == "����" || itemName == "�ұ�")
            {
                Like_Slider.instance.Person_Like_Slider[0].value += 3;
            }

            else if (itemName == "���" || itemName == "����" || itemName == "����" || itemName == "������" || itemName == "����"
                || itemName == "������" || itemName == "�ٴ�" || itemName == "��Ʈ��ũ" || itemName == "���" || itemName == "������"
                || itemName == "����" || itemName == "ȣ�ھ�" || itemName == "���α�" || itemName == "����" || itemName == "������")
            {
                Like_Slider.instance.Person_Like_Slider[0].value -= 5;
            }

            else
            {

                return;
                //Debug.Log("ȣ���� ����");
            }

        }

       

    }

    private void Person2_AddItem(string itemName, int quantity)
    {
        // Ű�� �������� ���� ��쿡�� �߰�
        if (!Person_2_Item.ContainsKey(itemName))
        {
            Person_2_Item.Add(itemName, quantity); // ���ο� Ű�� ���� �߰�

            if (itemName == "���" || itemName == "���ڳ�" || itemName == "�ñ�ġ" || itemName == "ȣ��" || itemName == "��ĭ"
               || itemName == "�ɽ���" || itemName == "��ũ���� ġ��" || itemName == "�ĸ��޻� ġ��" || itemName == "����" || itemName == "�ٴҶ�"
               || itemName == "����" || itemName == "��������" || itemName == "�̽�Ʈ" || itemName == "�ް�" || itemName == "����")
            {
                Like_Slider.instance.Person_Like_Slider[1].value += 7;
            }

            else if (itemName == "Ŀ��Ʈ" || itemName == "�ڸ�" || itemName == "��ȭ��" || itemName == "����" || itemName == "����"
                || itemName == "Ʈ����" || itemName == "��ö�" || itemName == "����" || itemName == "��� ��ƿ��" || itemName == "ġ�ƽõ�"
                || itemName == "����" || itemName == "�ͻ��" || itemName == "����" || itemName == "�ӽ�Ÿ��" || itemName == "��ø")
            {
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
            }

            else
            {
                return;
               // Debug.Log("ȣ���� ����");
            }

        }
        else
        {
            Person_2_Item[itemName] += quantity; // ���� Ű�� ���� ������Ʈ

            if (itemName == "���" || itemName == "���ڳ�" || itemName == "�ñ�ġ" || itemName == "ȣ��" || itemName == "��ĭ"
               || itemName == "�ɽ���" || itemName == "��ũ���� ġ��" || itemName == "�ĸ��޻� ġ��" || itemName == "����" || itemName == "�ٴҶ�"
               || itemName == "����" || itemName == "��������" || itemName == "�̽�Ʈ" || itemName == "�ް�" || itemName == "����")
            {
                Like_Slider.instance.Person_Like_Slider[1].value += 3;
            }

            else if (itemName == "Ŀ��Ʈ" || itemName == "�ڸ�" || itemName == "��ȭ��" || itemName == "����" || itemName == "����"
                || itemName == "Ʈ����" || itemName == "��ö�" || itemName == "����" || itemName == "��� ��ƿ��" || itemName == "ġ�ƽõ�"
                || itemName == "����" || itemName == "�ͻ��" || itemName == "����" || itemName == "�ӽ�Ÿ��" || itemName == "��ø")
            {
                Like_Slider.instance.Person_Like_Slider[1].value -= 5;
            }

            else
            {
                return;
                //Debug.Log("ȣ���� ����");
            }
        }

    }

    private void Person3_AddItem(string itemName, int quantity)
    {
        // Ű�� �������� ���� ��쿡�� �߰�
        if (!Person_3_Item.ContainsKey(itemName))
        {
            Person_3_Item.Add(itemName, quantity); // ���ο� Ű�� ���� �߰�
        }
        else
        {
            Person_3_Item[itemName] += quantity; // ���� Ű�� ���� ������Ʈ
        }

    }

    private void Person4_AddItem(string itemName, int quantity)
    {
        // Ű�� �������� ���� ��쿡�� �߰�
        if (!Person_4_Item.ContainsKey(itemName))
        {
            Person_4_Item.Add(itemName, quantity); // ���ο� Ű�� ���� �߰�
        }
        else
        {
            Person_4_Item[itemName] += quantity; // ���� Ű�� ���� ������Ʈ
        }

    }

    private void Person5_AddItem(string itemName, int quantity)
    {
        // Ű�� �������� ���� ��쿡�� �߰�
        if (!Person_5_Item.ContainsKey(itemName))
        {
            Person_5_Item.Add(itemName, quantity); // ���ο� Ű�� ���� �߰�
        }
        else
        {
            Person_5_Item[itemName] += quantity; // ���� Ű�� ���� ������Ʈ
        }

    }

    //ĳ���ͺ��� ���� ������ ���� ����
    public void Save_Person_1_Item()
    {
        //������ ���� ����

        //��ųʸ��� ����Ʈ�� ��ȯ
        List<Item_1_Person> items_1 = Person_1_Item.Select(item_1 => new Item_1_Person(item_1.Key, item_1.Value)).ToList();

        string json_1 = JsonUtility.ToJson(new List_1_Person(items_1), true);
        string path_1 = Path.Combine(Application.persistentDataPath, "Person_1_Item.json");
        File.WriteAllText(path_1, json_1);

       // Debug.Log($"1�� ��� ������ ���� �����: {json_1}"); // ����� JSON �α� 

        Dictionary<string, int> itemIndexMap = new Dictionary<string, int>
    {     //������ �̸��� �׿� �����ϴ� �ε����� �����ϴ� ��ųʸ�


        { "����", 0 },
        { "������", 1 },
        { "Ű��", 2 },
        { "��Ÿ�� ����", 3 },
        { "����", 4 },
        { "������", 5 },
        { "����¡��", 6 },
        { "��ġ", 7 },
        { "���", 8 },
        { "������ũ", 9 },
        { "�����", 10 },
        { "�ϵ���", 11 },
        { "������", 12 },
        { "����", 13 },
        { "�ұ�", 14 },

        { "���", 15 },
        { "����", 16 },
        { "����", 17 },
        { "������", 18 },
        { "����", 19 },
        { "������", 20 },
        { "�ٴ�", 21 },
        { "��Ƽ��ũ", 22 },
        { "���", 23 },
        { "������", 24 },
        { "����", 25 },
        { "ȣ�ھ�", 26 },
        { "���α�", 27 },
        { "����", 28 },
        { "������", 29 }

    };

        foreach (var item in itemIndexMap)//��ųʸ��� �ݺ��ϸ鼭
        {
            string itemName = item.Key;  // ������ �̸�
            int index = item.Value;      // �ش� �������� �ε���

            // �ش� �������� �������� �ʰ� Ÿ������ 11 �̻��� ���
            if (!Person_1_Item.ContainsKey(itemName))// && Typing.instance.Sentences_0 > 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // �ڹ��� �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(false);  // ������ �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = true;   // ��ư Ȱ��ȭ
            }
            // �ش� �������� �������� �ʰ� Ÿ������ 10 ������ ���
            else if (!Person_1_Item.ContainsKey(itemName)) //&& Typing.instance.Sentences_0 <= 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // �ڹ��� �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(false);  // ������ �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = false;  // ��ư ��Ȱ��ȭ
            }
            // �ش� �������� �����ϴ� ���
            else if (Person_1_Item.ContainsKey(itemName))
            {
                Item_Hint.instance.Lock_Image[index].SetActive(false);  // �ڹ��� �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(true);   // ������ �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = false;  // ��ư ��Ȱ��ȭ
            }
        }



    }

    public void Save_Person_2_Item()
    {
        //2�� ���
        //������ ���� ����

        //��ųʸ��� ����Ʈ�� ��ȯ
        List<Item_2_Person> items_2 = Person_2_Item.Select(item_2 => new Item_2_Person(item_2.Key, item_2.Value)).ToList();

        string json_2 = JsonUtility.ToJson(new List_2_Person(items_2), true);
        string path_2 = Path.Combine(Application.persistentDataPath, "Person_2_Item.json");
        File.WriteAllText(path_2, json_2);

        //Debug.Log($"2�� ��� ������ ���� �����: {json_2}"); // ����� JSON �α� 

        Dictionary<string, int> itemIndexMap = new Dictionary<string, int>
    {     //������ �̸��� �׿� �����ϴ� �ε����� �����ϴ� ��ųʸ�


        { "���", 30 },
        { "���ڳ�", 31 },
        { "�ñ�ġ", 32 },
        { "ȣ��", 33 },
        { "��ĭ", 34 },
        { "ĳ����", 35 },
        { "��ũ���� ġ��", 36 },
        { "�ĸ��޻� ġ��", 37 },
        { "����", 38 },
        { "�ٴҶ�", 39 },
        { "����", 40 },
        { "��������", 41 },
        { "�̽�Ʈ", 42 },
        { "�ް�", 43 },
        { "����", 44 },

        { "Ŀ��Ʈ", 45 },
        { "�ڸ�", 46 },
        { "��ȭ��", 47 },
        { "����", 48 },
        { "����", 49 },
        { "Ʈ����", 50 },
        { "��ö�", 51 },
        { "����", 52 },
        { "��� ��ƿ��", 53 },
        { "ġ�ƽõ�", 54 },
        { "����", 55 },
        { "�ͻ��", 56 },
        { "����", 57 },
        { "�ӽ�Ÿ��", 58 },
        { "��ø", 59 }
        // ���⿡ �ٸ� �����۵鵵 �߰�
    };

        foreach (var item in itemIndexMap)//��ųʸ��� �ݺ��ϸ鼭
        {
            string itemName = item.Key;  // ������ �̸�
            int index = item.Value;      // �ش� �������� �ε���

            // �ش� �������� �������� �ʰ� Ÿ������ 11 �̻��� ���
            if (!Person_2_Item.ContainsKey(itemName)) //&& Typing.instance.Sentences_0 > 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // �ڹ��� �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(false);  // ������ �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = true;   // ��ư Ȱ��ȭ
            }
            // �ش� �������� �������� �ʰ� Ÿ������ 10 ������ ���
            else if (!Person_2_Item.ContainsKey(itemName)) // && Typing.instance.Sentences_0 <= 10)
            {
                Item_Hint.instance.Lock_Image[index].SetActive(true);   // �ڹ��� �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(false);  // ������ �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = false;  // ��ư ��Ȱ��ȭ
            }
            // �ش� �������� �����ϴ� ���
            else if (Person_2_Item.ContainsKey(itemName))
            {
                Item_Hint.instance.Lock_Image[index].SetActive(false);  // �ڹ��� �̹��� ��Ȱ��ȭ
                Item_Hint.instance.Item_Image[index].SetActive(true);   // ������ �̹��� Ȱ��ȭ
                Item_Hint.instance.Item_Button[index].enabled = false;  // ��ư ��Ȱ��ȭ
            }
        }
    }

    public void Save_Person_3_Item()
    {
        //3�� ���
        List<Item_3_Person> items_3 = Person_3_Item.Select(item_3 => new Item_3_Person(item_3.Key, item_3.Value)).ToList();

        string json_3 = JsonUtility.ToJson(new List_3_Person(items_3), true);
        string path_3 = Path.Combine(Application.persistentDataPath, "Person_3_Item.json");
        File.WriteAllText(path_3, json_3);

        //Debug.Log($"3�� ��� ������ ���� �����: {json_3}"); // ����� JSON �α�
    }

    public void Save_Person_4_Item()
    {
        //4�� ���
        List<Item_4_Person> items_4 = Person_4_Item.Select(item_4 => new Item_4_Person(item_4.Key, item_4.Value)).ToList();

        string json_4 = JsonUtility.ToJson(new List_4_Person(items_4), true);
        string path_4 = Path.Combine(Application.persistentDataPath, "Person_4_Item.json");
        File.WriteAllText(path_4, json_4);

        //Debug.Log($"4�� ��� ������ ���� �����: {json_4}"); // ����� JSON �α�
    }

    public void Save_Person_5_Item()
    { 
        //5�� ���
        List<Item_5_Person> items_5 = Person_5_Item.Select(item_5 => new Item_5_Person(item_5.Key, item_5.Value)).ToList();

        string json_5 = JsonUtility.ToJson(new List_5_Person(items_5), true);
        string path_5 = Path.Combine(Application.persistentDataPath, "Person_5_Item.json");
        File.WriteAllText(path_5, json_5);

        //Debug.Log($"5�� ��� ������ ���� �����: {json_5}"); // ����� JSON �α�
    }

    public void Load_Person_Item()
    {
        // ����� ������ ��� ����
        string path_1 = Path.Combine(Application.persistentDataPath, "Person_1_Item.json");
        string path_2 = Path.Combine(Application.persistentDataPath, "Person_2_Item.json");
        string path_3 = Path.Combine(Application.persistentDataPath, "Person_3_Item.json");
        string path_4 = Path.Combine(Application.persistentDataPath, "Person_4_Item.json");
        string path_5 = Path.Combine(Application.persistentDataPath, "Person_5_Item.json");

        // ������ �����ϴ��� Ȯ��
        if (File.Exists(path_1))
        {
            // ���� ������ �о��
            string json_1 = File.ReadAllText(path_1);

            List_1_Person itemList_1 = JsonUtility.FromJson<List_1_Person>(json_1);

            // ������ ������ ��ųʸ��� ����
            Person_1_Item = itemList_1.items_1.ToDictionary(item_1 => item_1.itemName, item_1 => item_1.item_quantity);

            // �ε�� ������ �α׿� ���
            //Debug.Log("1��° ����� ���� �ִ� ������ �ε��: " + json_1);
        }
        else if(!File.Exists(path_1))
        {
            // ������ �������� ���� ��� ��� �޽��� ���
            //Debug.LogWarning("1�� ����� ���� �������� ����.");

            // ��� ������ ������ 0���� ����
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item[item_1] = 0;
            }
        }

        //2
        if (File.Exists(path_2))
        {
            // ���� ������ �о��
            string json_2 = File.ReadAllText(path_2);

            List_2_Person itemList_2 = JsonUtility.FromJson<List_2_Person>(json_2);

            // ������ ������ ��ųʸ��� ����
            Person_2_Item = itemList_2.items_2.ToDictionary(item_2 => item_2.itemName, item_2 => item_2.item_quantity);

            // �ε�� ������ �α׿� ���
           // Debug.Log("2��° ����� ���� �ִ� ������ �ε��: " + json_2);
        }
        else if (!File.Exists(path_2))
        {
            // ������ �������� ���� ��� ��� �޽��� ���
            //Debug.LogWarning("2�� ����� ���� �������� ����.");

            // ��� ������ ������ 0���� ����
            foreach (var item_2 in Person_2_Item.Keys.ToList())
            {
                Person_2_Item[item_2] = 0;
            }
        }

        //3
        if (File.Exists(path_3))
        {
            // ���� ������ �о��
            string json_3 = File.ReadAllText(path_3);

            List_3_Person itemList_3 = JsonUtility.FromJson<List_3_Person>(json_3);

            // ������ ������ ��ųʸ��� ����
            Person_3_Item = itemList_3.items_3.ToDictionary(item_3 => item_3.itemName, item_3 => item_3.item_quantity);

            // �ε�� ������ �α׿� ���
            //Debug.Log("3��° ����� ���� �ִ� ������ �ε��: " + json_3);
        }
        else if (!File.Exists(path_3))
        {
            // ������ �������� ���� ��� ��� �޽��� ���
            //Debug.LogWarning("3�� ����� ���� �������� ����.");

            // ��� ������ ������ 0���� ����
            foreach (var item_3 in Person_3_Item.Keys.ToList())
            {
                Person_1_Item[item_3] = 0;
            }
        }

        //4
        if (File.Exists(path_4))
        {
            // ���� ������ �о��
            string json_4 = File.ReadAllText(path_4);

            List_4_Person itemList_4 = JsonUtility.FromJson<List_4_Person>(json_4);

            // ������ ������ ��ųʸ��� ����
            Person_4_Item = itemList_4.items_4.ToDictionary(item_4 => item_4.itemName, item_4 => item_4.item_quantity);

            // �ε�� ������ �α׿� ���
           // Debug.Log("4��° ����� ���� �ִ� ������ �ε��: " + json_4);
        }
        else if (!File.Exists(path_4))
        {
            // ������ �������� ���� ��� ��� �޽��� ���
           // Debug.LogWarning("4�� ����� ���� �������� ����.");

            // ��� ������ ������ 0���� ����
            foreach (var item_4 in Person_4_Item.Keys.ToList())
            {
                Person_4_Item[item_4] = 0;
            }
        }

        //5
        if (File.Exists(path_5))
        {
            // ���� ������ �о��
            string json_5 = File.ReadAllText(path_5);

            List_5_Person itemList_5 = JsonUtility.FromJson<List_5_Person>(json_5);

            // ������ ������ ��ųʸ��� ����
            Person_5_Item = itemList_5.items_5.ToDictionary(item_5 => item_5.itemName, item_5 => item_5.item_quantity);

            // �ε�� ������ �α׿� ���
            //Debug.Log("5��° ����� ���� �ִ� ������ �ε��: " + json_5);
        }
        else if (!File.Exists(path_5))
        {
            // ������ �������� ���� ��� ��� �޽��� ���
            //Debug.LogWarning("5�� ����� ���� �������� ����.");

            // ��� ������ ������ 0���� ����
            foreach (var item_5 in Person_5_Item.Keys.ToList())
            {
                Person_5_Item[item_5] = 0;
            }
        }
    }

    public void Reset_Person_Item()
    {
        string path_1 = Application.persistentDataPath + "/Person_1_Item.json";
        string path_2 = Application.persistentDataPath + "/Person_2_Item.json";
        string path_3 = Application.persistentDataPath + "/Person_3_Item.json";
        string path_4 = Application.persistentDataPath + "/Person_4_Item.json";
        string path_5 = Application.persistentDataPath + "/Person_5_Item.json";
        
        /*if (File.Exists(path_1))
        {//������ �����ϴ� ���

            File.Delete(path_1);

            //�ʱ�ȭ ���� ����
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item[item_1] = 0;
            }

        }
        else if (!File.Exists(path_1))
        {
            Debug.Log("��� 1�� ������ ������ ������ ����");
        }
        */
        if (File.Exists(path_1))
        {
            // ������ �����ϴ� ���, ���� ����
            File.Delete(path_1);

            // �ʱ�ȭ: ������ �̸��� ������ ��� ����
            foreach (var item_1 in Person_1_Item.Keys.ToList())
            {
                Person_1_Item.Remove(item_1); // ������ �̸��� �׿� �����ϴ� ���� ����
            }

            Debug.Log("��� 1���� ��� �����۰� ���� �ʱ�ȭ��");
        }
        else
        {
            Debug.Log("��� 1�� ������ ������ ������ ����");
        }

        //2
        if (File.Exists(path_2))
        {//������ �����ϴ� ���

            File.Delete(path_2);

            //�ʱ�ȭ ���� ����
            foreach (var item_2 in Person_2_Item.Keys.ToList())
            {
                Person_2_Item.Remove(item_2);//Person_2_Item[item_2] = 0;
            }

        }
        else if (!File.Exists(path_2))
        {
            Debug.Log("��� 2�� ������ ������ ������ ����");
        }

        //3
        if (File.Exists(path_3))
        {//������ �����ϴ� ���

            File.Delete(path_3);

            //�ʱ�ȭ ���� ����
            foreach (var item_3 in Person_3_Item.Keys.ToList())
            {
                Person_3_Item.Remove(item_3);//Person_3_Item[item_3] = 0;
            }

        }
        else if (!File.Exists(path_3))
        {
            Debug.Log("��� 3�� ������ ������ ������ ����");
        }

        //4
        if (File.Exists(path_4))
        {//������ �����ϴ� ���

            File.Delete(path_4);

            //�ʱ�ȭ ���� ����
            foreach (var item_4 in Person_4_Item.Keys.ToList())
            {
                Person_4_Item.Remove(item_4);//Person_4_Item[item_4] = 0;
            }

        }
        else if (!File.Exists(path_4))
        {
            Debug.Log("��� 4�� ������ ������ ������ ����");
        }

        //5
        if (File.Exists(path_5))
        {//������ �����ϴ� ���

            File.Delete(path_5);

            //�ʱ�ȭ ���� ����
            foreach (var item_5 in Person_5_Item.Keys.ToList())
            {
                Person_5_Item.Remove(item_5);//Person_5_Item[item_5] = 0;
            }

        }
        else if (!File.Exists(path_5))
        {
            Debug.Log("��� 5�� ������ ������ ������ ����");
        }

        Load_Person_Item();
        //Save_Person_1_Item();
        //Save_Person_2_Item();
        //Save_Person_3_Item();
        //Save_Person_4_Item();
        //Save_Person_5_Item();

        //�������� ��, ������ �̹��� ��� ��Ȱ��
        for (int i = 0; i < Item_Hint.instance.Item_Image.Length; i++)
        {
            Item_Hint.instance.Item_Image[i].SetActive(false);
        }

        //�ڹ��� �̹��� Ȱ��
        for (int i = 0; i < Item_Hint.instance.Lock_Image.Length; i++)
        {
            Item_Hint.instance.Lock_Image[i].SetActive(true);
        }

        //��ư ��Ȱ��
        for (int i = 0; i < Item_Hint.instance.Item_Button.Length; i++)
        {
            Item_Hint.instance.Item_Button[i].enabled = false;
        }
    }


    private void Start()
    {
        Load_Person_Item();
        /*Save_Person_1_Item();
        Save_Person_2_Item();
        Save_Person_3_Item();
        Save_Person_4_Item();
        Save_Person_5_Item();*/

    }

    private void FixedUpdate()
    {
        if(Person_1 == false && Person_2 == false & Person_3 == false
            & Person_4 == false & Person_5 == false)
        {
            //���� �ƹ��ϰ� ������ ���� ���¶��
            Gift_Text.text = "���� �Ұ�";//�ؽ�Ʈ �ٲٱ�
        }

        else
        {
            Gift_Text.text = "�����ϱ�";//�ؽ�Ʈ �ٲٱ�
        }

        Save_Person_1_Item();
        Save_Person_2_Item();
        Save_Person_3_Item();
        Save_Person_4_Item();
        Save_Person_5_Item();
    }
}
