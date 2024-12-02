using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Name_Image : MonoBehaviour
{
    public TextMeshProUGUI[] tmpText;  // TMP �ؽ�Ʈ ������Ʈ
    public RectTransform[] tmpText_Rect;  // TMP �ؽ�Ʈ RectTransform
    public RectTransform[] image;      // �̹��� RectTransform
    private float offsetX = 35f;      // ���� ������ �̹��������� ���� �Ÿ� (10px ������ ����)

    public static Name_Image instance;

    void Start()
    {
       
        instance = this;
    }

    public void Update_TextAndImagePosition()
    {
        for(int i = 0; i<tmpText.Length; i++)
        {
            // �ؽ�Ʈ�� Preferred Width ��������
            tmpText[i].ForceMeshUpdate();  // �ؽ�Ʈ ����
            float textWidth = tmpText[i].preferredWidth;

            // TMP �ؽ�Ʈ�� RectTransform ũ�� ����
            RectTransform textRectTransform = tmpText_Rect[i];
            textRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textWidth);

            // �ؽ�Ʈ �߾� ��ġ ���
            float centerX = textWidth / 2f;

            // �̹��� ��ġ�� �ؽ�Ʈ �߾ӿ��� offsetX��ŭ �̵�
            image[i].anchoredPosition = new Vector2(centerX + offsetX, image[i].anchoredPosition.y); // Y�� ���� �̹����� ��ġ�� ����
        }

    }

}

