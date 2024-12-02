using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonDestroyOnLoad : MonoBehaviour
{
    public static DonDestroyOnLoad instance;

    public GameObject[] objectsToPersist;



    void Awake()
    {
        if (instance != null)
        {
            foreach (GameObject obj in objectsToPersist)
            {
                Destroy(obj);
                //Debug.Log($"{obj.name} will not be destroyed on load.");
            }
        }

        instance = this;

        foreach (GameObject obj in objectsToPersist)
        {
            DontDestroyOnLoad(obj);
            //Debug.Log($"{obj.name} will not be destroyed on load.");
        }
    }

    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/

    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene {scene.name} loaded.");
        // �� �ε� �� �߰����� �ʱ�ȭ ����
        //Rhythm_Fade.instance.Fade_Anim.SetTrigger("Go_Empty");
        //StartCoroutine(SetActive_False());

    }*/

    /*IEnumerator SetActive_False()
    {
        yield return new WaitForSecondsRealtime(1.4f);

        Rhythm_Fade.instance.Fade.SetActive(false);
        Debug.Log("�ٸ� ������ �̵��ؼ� ���̵� �ƿ��� ��");

        //StartCoroutine(Note_Reset());




    }*/
}
