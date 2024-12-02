using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Fade : MonoBehaviour
{
    public Button btn;

    public Typing typ;

    public GameObject Title_Canvas;
    public Animator picture_anim;
    public Animator Title_Text_Anim;
    public Animator Touch_Text_Anim;

    public GameObject Fade_Canvas;
    public Animator Fade_Anim;

    public GameObject Story_Canvas;

    public static Title_Fade instance;

    public void Start()
    {
        instance = this;

        //typ.Delete_Data();
        Story_Canvas.SetActive(false);//���丮 ���� ĵ���� �� ���̵���

        btn.enabled = true;
    }



    public void Go_Game()
    {

        if (picture_anim.GetCurrentAnimatorStateInfo(0).IsName("Show_Picture0"))
        {
            //���� �������� �ִϸ��̼� �̸��� Show_Picture0 ���
            //�� ���� �ִϸ��̼��� �� ������ �ʾҴٸ�
            picture_anim.SetTrigger("Show_P");

            Title_Text_Anim.SetTrigger("Continue");
            Touch_Text_Anim.SetTrigger("Two");
        }

        if(picture_anim.GetCurrentAnimatorStateInfo(0).IsName("Show_Picture1"))
        {
            //���������� �ִϸ��̼��� ������ ����Ǿ��ٸ�
            //���̵� ���� �� ���� ���� ���
            btn.enabled = false;

            Fade_Anim.SetTrigger("Go_Black");

            StartCoroutine(Go_Black());
            IEnumerator Go_Black()
            {
                yield return new WaitForSeconds(1.5f);
                Title_Canvas.SetActive(false);
            }


            //���⼭ ������ �ҷ��;� �ϳ�?
            StartCoroutine(Go_Game());
            IEnumerator Go_Game()
            {
                yield return new WaitForSeconds(2.25f);
                Fade_Anim.SetTrigger("Go_Empty");
                Story_Canvas.SetActive(true);//���丮 ���� ĵ���� ���̵���

                //���丮 �߿� ���̵� �� & �ƿ� ������� ��, �ҷ����� ���
                //Typing�ڵ忡�� ����ϸ� ��ȭâ�� ������ �ʴ� ���� �߻�

                if (Typing.instance.Sentences_0 == 34)
                {
                    Typing_Fade.instance.Sentences_0_34();
                    //Fade_Anim.SetTrigger("Go_Empty");
                    //StartCoroutine(SetActive_False());

                }

               

                else
                {
                    Debug.Log("����");
                }

                /*else if(Typing.instance.Sentences_0 != 33)
                {
                    Fade_Anim.SetTrigger("Go_Empty");
                    StartCoroutine(SetActive_False());
                }*/


                StartCoroutine(SetActive_False());
            }

            IEnumerator SetActive_False()
            {
                yield return new WaitForSeconds(1.35f);
                Fade_Canvas.SetActive(false);

                /*if (Typing.instance.Sentences_0 == 33)
                {
                    Typing_Fade.instance.Sentences_0_33();
                }*/

               
            }
        }
    }

    /*public void Go_Fade()
    {

    }*/
}
