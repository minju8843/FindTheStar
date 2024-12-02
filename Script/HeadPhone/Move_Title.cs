using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Move_Title : MonoBehaviour
{
    public TextMeshProUGUI firstTextPrefab; // ù ��° �ؽ�Ʈ ������
    public TextMeshProUGUI secondTextPrefab; // �� ��° �ؽ�Ʈ ������
    public RectTransform maskArea; // RectMask2D ������ ������ ����ũ ����
    private float speed = 50f; // �ؽ�Ʈ�� �����̴� �ӵ�
    public int spaceBetweenTexts = 10; // �ؽ�Ʈ ������ ���� (���� ����)

    public RectTransform firstText;
    public RectTransform secondText;
    private float firstTextWidth;
    private float secondTextWidth;
    private float spacing; // ������ ���� �Ÿ��� ��ȯ�� ��

    public void Start()
    {
        // ù ��° �ؽ�Ʈ ����
        firstText = Instantiate(firstTextPrefab, maskArea).GetComponent<RectTransform>();
        //������Ʈ�� maskArea�ȿ� �����Ѵ�
        //firstTextPrefab�̶�� �������� �����ؼ� ���ο� �ν��Ͻ� ����
        //firstTextPrefab�� ������ ��, maskArea��� RectTransform�� �θ�� ����
        //->���� ����ũ�� �̹���

        //.GetComponent<RectTransform>();
        // -> ���� ������ firstTextPrefab�� RectTransform�� ������


        firstText.anchoredPosition = new Vector2(0, 0);
        //ó������ 0,0 ��ġ�� ��ġ�Ѵ�

        // �� ��° �ؽ�Ʈ ����
        secondText = Instantiate(secondTextPrefab, maskArea).GetComponent<RectTransform>();
        secondText.anchoredPosition = new Vector2(0, 0);

        // ���� ������ �ؽ�Ʈ�� ��Ʈ ũ�� �������� ����
        spacing = spaceBetweenTexts * firstTextPrefab.fontSize;
        //���� ���� ��Ʈ ũ�⸦ ���ؼ� ���� ���� ���

        // �� �ؽ�Ʈ�� �ʺ� ���
        firstTextWidth = firstText.rect.width;
        secondTextWidth = secondText.rect.width;

        // �� ��° �ؽ�Ʈ�� ù ��° �ؽ�Ʈ �ڿ� ��ġ
        secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        
        //Set_Text();
    }

    public void Set_Text()
    {
        // ù ��° �ؽ�Ʈ ����
        //firstText = Instantiate(firstTextPrefab, maskArea).GetComponent<RectTransform>();
        //������Ʈ�� maskArea�ȿ� �����Ѵ�
        //firstTextPrefab�̶�� �������� �����ؼ� ���ο� �ν��Ͻ� ����
        //firstTextPrefab�� ������ ��, maskArea��� RectTransform�� �θ�� ����
        //->���� ����ũ�� �̹���

        //.GetComponent<RectTransform>();
        // -> ���� ������ firstTextPrefab�� RectTransform�� ������


        firstText.anchoredPosition = new Vector2(0, 0);
        //ó������ 0,0 ��ġ�� ��ġ�Ѵ�

        // �� ��° �ؽ�Ʈ ����
        //secondText = Instantiate(secondTextPrefab, maskArea).GetComponent<RectTransform>();
        secondText.anchoredPosition = new Vector2(0, 0);

        // ���� ������ �ؽ�Ʈ�� ��Ʈ ũ�� �������� ����
        spacing = spaceBetweenTexts * firstTextPrefab.fontSize;
        //���� ���� ��Ʈ ũ�⸦ ���ؼ� ���� ���� ���

        // �� �ؽ�Ʈ�� �ʺ� ���
        firstTextWidth = firstText.rect.width;
        secondTextWidth = secondText.rect.width;

        // �� ��° �ؽ�Ʈ�� ù ��° �ؽ�Ʈ �ڿ� ��ġ
        secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);

        //Move_Update();
    }

    /*public void Move_Update()
    {
        // ù ��°�� �� ��° �ؽ�Ʈ ��� �������� �̵�
        firstText.anchoredPosition += Vector2.left * speed * Time.deltaTime;
        secondText.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // ù ��° �ؽ�Ʈ�� ����ũ ������ ����� ��ġ�� �缳��
        if (firstText.anchoredPosition.x <= -firstTextWidth - spacing)
        {//firstText.anchoredPosition.x -> ���� X���� ��ġ
            //firstTextWidth�� �ؽ�Ʈ�� �ʺ�

            //-firstTextWidth - spacing->�ؽ�Ʈ�� ȭ�� ���� ���� �Ѿ �̵��� �Ÿ�
            //ù ��° �ؽ�Ʈ�� X��ġ�� �������� ���������

            firstText.anchoredPosition = new Vector2(secondText.anchoredPosition.x + secondTextWidth + spacing, 0);
            //ȭ���� ����ٸ� ���ο� ��ġ ����
            //secondText.anchoredPosition.x -> �� ��° �ؽ�Ʈ�� ���� X��ġ
            //�� ��° �ؽ�Ʈ�� ���� X��ġ�� �� ��° �ؽ�Ʈ�� �ʺ�� ������ ���Ͽ� ù ��° �ؽ�Ʈ�� �� ��° �ؽ�Ʈ�� �����ʿ� ��ġ�ǵ���
        }

        // �� ��° �ؽ�Ʈ�� ����ũ ������ ����� ��ġ�� �缳��
        if (secondText.anchoredPosition.x <= -secondTextWidth - spacing)
        {
            secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        }
    }*/

    void Update()
    {
        // ù ��°�� �� ��° �ؽ�Ʈ ��� �������� �̵�
        firstText.anchoredPosition += Vector2.left * speed * Time.deltaTime;
        secondText.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // ù ��° �ؽ�Ʈ�� ����ũ ������ ����� ��ġ�� �缳��
        if (firstText.anchoredPosition.x <= -firstTextWidth - spacing)
        {//firstText.anchoredPosition.x -> ���� X���� ��ġ
            //firstTextWidth�� �ؽ�Ʈ�� �ʺ�

            //-firstTextWidth - spacing->�ؽ�Ʈ�� ȭ�� ���� ���� �Ѿ �̵��� �Ÿ�
            //ù ��° �ؽ�Ʈ�� X��ġ�� �������� ���������

            firstText.anchoredPosition = new Vector2(secondText.anchoredPosition.x + secondTextWidth + spacing, 0);
            //ȭ���� ����ٸ� ���ο� ��ġ ����
            //secondText.anchoredPosition.x -> �� ��° �ؽ�Ʈ�� ���� X��ġ
            //�� ��° �ؽ�Ʈ�� ���� X��ġ�� �� ��° �ؽ�Ʈ�� �ʺ�� ������ ���Ͽ� ù ��° �ؽ�Ʈ�� �� ��° �ؽ�Ʈ�� �����ʿ� ��ġ�ǵ���
        }

        // �� ��° �ؽ�Ʈ�� ����ũ ������ ����� ��ġ�� �缳��
        if (secondText.anchoredPosition.x <= -secondTextWidth - spacing)
        {
            secondText.anchoredPosition = new Vector2(firstText.anchoredPosition.x + firstTextWidth + spacing, 0);
        }
    }
}
