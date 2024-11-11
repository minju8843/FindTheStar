using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QManager questManager;//����Ʈ �Ŵ����� ������ �����ϰ� ����Ʈ��ȣ�� �����´�
    public GameObject talkPanel;
    public Image portraitImg;//Image UI������ ���� ������ �����ϰ� �Ҵ��ϳ�.
    public Text talkText;//��ȭâ ������ ���� ��
    //public Text questText;//�޴� ��ư ���� ����Ʈ �˸� �޴� ������ �ϴ� ����
    public GameObject menuSet;//�޴� ��ư������ �������
    public GameObject scanObject;//�÷��̾ �����ߴ� ���� ������Ʈ
    public GameObject player;//���� ����޴� ������ �������
    public bool isAction;//��ȭâ�� ������� �� ������� Ȯ���� ���� ���� ����� ������ �߰�
    public int talkIndex;

    public GameObject TitleSet;//���� ȭ��

    public GameObject fadeInPanel;//���̵� �� �г�



    //public SceneTransition sceneTransition;//�� ��ȯ
    //public SceneTransition sceneTransition2;//�� ��ȯ
    //public string sceneToLoad;//�� �ҷ����� ��

    //public SceneDetails CurrentScene { get; private set; }//�� ��ȯ �� �Ǹ� �����
    //public SceneDetails PrevScene { get; private set; }//�� ��ȯ �� �Ǹ� �����

    //public static GameManager Instance { get; private set; }//�� ��ȯ �� �Ǹ� �����

    /*private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

    }*/

    //public GameObject fadeOutPanel;//���̵� �ƿ� �г�20220929

    void Start()
    {
        GameLoad();//���� �ε忡�� ���� �޴������� �������

        Debug.Log(questManager.CheckQuest());//�޴� ����� ������ ����� �ڵ�


        //�Ű������� ���� �Լ��� �����

        //�Ű������� ���� �Լ��� ȣ��Ǵ� ���� �����ε�(Overloading)�̶� �Ѵ�.

        //questText.text = questManager.CheckQuest();//����Ʈ �ؽ�Ʈ UI�� ������ �Ҵ��Ͽ� ����Ʈ �̸� ����
        //��� �޴������� ���� ����
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

        
    }


    void Update()
    {
        //SubMenu
        if (Input.GetButtonDown("Cancel"))//Esc��ư�� ������
        {
            //���� �ؿ� PC�� ���
            /*if (menuSet.activeSelf)//�޴��� ���� ������
                menuSet.SetActive(false);//�޴�â�� ���ּ���
            else
                menuSet.SetActive(true);//�ƴϸ� �޴�â�� ���ּ���*/

            SubMenuActive();//�̰� �׼� ��ư������ ���� ����(v�� �׸�.)
        }

        

        if (TitleSet.activeSelf)//Ÿ��Ʋ ���� ������
        {
            

            TitleSet.SetActive(true);//Ÿ��Ʋ�� ���ּ���


            //soundmanager.bgSound.Pause();

        }


        else
        {
            TitleSet.SetActive(false);//�ƴϸ� Ÿ��Ʋ�� ���ּ���
            //soundmanager.bgSound.Play();
            
        }
            


        //TitleSet.SetActive(true);//�ƴϸ� Ÿ��Ʋ�� �Ѽ���



    }

    public void SubMenuActive()//�̰� �׼� ��ư������ ���� ����(v�� �׸�.)
    {
        if (menuSet.activeSelf)//�޴��� ���� ������
            menuSet.SetActive(false);//�޴�â�� ���ּ���
        else
            menuSet.SetActive(true);//�ƴϸ� �޴�â�� ���ּ���
    }


    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;//��ĵ�ߴ� object�� ������ �ڿ�
        ObjData objData = scanObject.GetComponent<ObjData>();
        //��ĵ�� ������Ʈ�� ������ ���� ������Ʈ ������ ������ �;� ��
        Talk(objData.id, objData.isNpc);
        

        talkPanel.SetActive(isAction);
        //�׼� ���ο� ���� talkPanel�� ��Ÿ���� �����
        





        void Talk(int id, bool isNpc)
        {
            int questTalkIndex = questManager.GetQuestTalkIndex(id);//����Ʈ ��ȣ ������
            string talkData=talkManager.GetTalk(id+questTalkIndex, talkIndex);
            //����Ʈ ��ȣ+NPC Id=����Ʈ ��ȭ ������Id

            //id, talkIndex�� �ش��ϴ� ���ڿ��� �����µ� �װ� ����

            //���� ��ũ �����Ͱ� ���������(���� ��ȭ�� ������)
            //�� ��ȭ�� ���� ���ٰ� �˸�.
            if(talkData==null)
            {
                isAction = false;
                talkIndex = 0; //��ȭ�� ���� �� talkIndex�� 0���� �ʱ�ȭ

                //questText.text = questManager.CheckQuest(id);//�޴������� �������



                Debug.Log(questManager.CheckQuest(id));//����Ʈ �̸��� ��ȯ�ϵ��� �Լ� ����
                //�޴� �� �Ǹ� �̰� �ٽ� �츮��


                //��ȭ�� ���������� ����Ʈ �Ŵ����� ���� CheckQuest()�� �ҷ��´�
                //�׷��� ��簡 ������ questActionIndex++�� �ö󰡸鼭 ���� ����Ʈ�� �ҷ��´�.
                return;//void�Լ����� return�� ���� ���� �����̴�
            }


            //���࿡ Npc�� 
            if (isNpc)
            {
                talkText.text = talkData.Split(':')[0];

                portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
                //GetPortrait�� ���� Sprite�� �������� �� Sprite�� PortraitImg�� ����ִ´�

                portraitImg.color = new Color(1, 1, 1, 1);//NPC�϶��� �̹����� ���̵��� �ۼ�.(�� ������� �� ���Ŷ� �Ѵ� �� ����)
                //color�� �̹����� ����
            }
            else //Npc�� �ƴϸ�
            {
                talkText.text = talkData.Split(':')[0];
                //talkText.text = talkData;

                portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
                portraitImg.color = new Color(1, 1, 1, 1);//NPC�϶��� �̹����� ���̵��� �ۼ�.(�� ������� �� ���Ŷ� �Ѵ� �� ����)
                //color�� �̹����� ����
                //�� ���̰� �Ϸ��� (1, 1, 1, 0)���� �ؾ���

            }

            isAction = true;
            talkIndex++;//��ũ �ε����� �÷������.
                        //��ȭ�� ���� ������ �̾Ƴ��� ���� �ʿ���

            
        }

        
    }



    public void GameSave()//���� ����
    {
        Debug.Log("���� ����");
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        //PlayerPrefs.SetString("SceneName", sceneTransition.sceneToLoad);//�� ������
        //PlayerPrefs.SetString("SceneName", sceneTransition2.sceneToLoad);//�� ������

        //**����� ������ ���� �ҷ����� ���� ���� ����**//
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

        //**������� ������ ���� �ҷ����� ���� ���� ����**//


        PlayerPrefs.Save();//�������丮�� ���� ������ �͵��� �����

        menuSet.SetActive(false);//���� ��ư ������ �޴� ��ư �����
        

    }

    public void GameLoad()//���� �ҷ�����
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }

        Debug.Log("����ϱ�");
        //���� ���� �������� �� �����Ͱ� �����Ƿ� ����ó��
        if (!PlayerPrefs.HasKey("PlayerX"))//PlayerPrefs�� �� ���̶� ������ ���� ���ٸ�
            return;//�ε� ��ü�� ���� ��

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        //**����� ������ ���� �ҷ����� ���� ���� ����**//
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

        //**������� ������ ���� �ҷ����� ���� ���� ����**//
        





        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        //sceneTransition.sceneToLoad = sceneToLoad;//�� ������
        //sceneTransition2.sceneToLoad = sceneToLoad;//�� ������

        questManager.ControlObject();//���嶧���� �������

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }





    }

    

    public void GameExit()//���� ������ �޴�
    {
        Debug.Log("��");
        //ControlSet.SetActive(true);
        //Application.Quit();//���߿� ���� ������ �� �̰͸� ��
        //SceneManager.LoadScene("Main");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//����Ƽ �ֵ��� �ȿ��� ���߰� �Ѵ�
#else   
        Application.Quit();
#endif




    }

    public void OnClickQuit()
    {

        Debug.Log("��");
        //ControlSet.SetActive(true);
        //Application.Quit();//���߿� ���� ������ �� �̰͸� ��
        //SceneManager.LoadScene("Main");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//����Ƽ �ֵ��� �ȿ��� ���߰� �Ѵ�
#else   
        Application.Quit();
#endif

    }

    /*public void OnClickNewGame()
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }


        TitleSet.SetActive(false);//���� ��ư ������ �޴� ��ư �����
        Debug.Log("�� �����ƴ� ¥��");
        PlayerPrefs.DeleteAll();
        //StartCoroutine(WaitPlease());
        
        SceneManager.LoadScene("SampleScene");


    }*/

    public void OnClickNewGame()
    {

        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;

            Destroy(panel, 1);
        }


        TitleSet.SetActive(false);//���� ��ư ������ �޴� ��ư �����
        Debug.Log("�� �����ƴ� ¥��");
        PlayerPrefs.DeleteAll();
        //StartCoroutine(WaitPlease());

        SceneManager.LoadScene("Prologe");


    }

    public void OnClickGoMain()
    {
        
        TitleSet.SetActive(true);
        Debug.Log("���� �޴���");
        SceneManager.LoadScene("Main");

    }


    //���̵� �� �ڷ�ƾ ������ ���� ����
    /*IEnumerator WaitPlease()
    {
        yield return new WaitForSeconds(1.0f);
    }*/




    /* public void SetCurrentScene(SceneDetails currScene)//�� ��ȯ������ ���� ��. �� �Ǹ� �����
     {
         PrevScene = CurrentScene;
         CurrentScene = currScene;
     }*/



}


