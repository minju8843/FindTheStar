using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_Tip : MonoBehaviour
{
    public TextMeshProUGUI Tip_text;
    public string[] Tip_Collection;
    public float changeInterval = 2.0f; // �ؽ�Ʈ ���� ���� (�� ����)
    //public string targetSceneName = "Loading_Scene";

    private Coroutine changeTextCoroutine;

    private void Start()
    {
        // ���� �� �̸��� targetSceneName�� ������ ��쿡�� ����
        //if (SceneManager.GetActiveScene().name == targetSceneName)
        //{
            if (Tip_Collection.Length > 0)
            {
                changeTextCoroutine = StartCoroutine(ChangeTextRoutine());
            }
        //}
    }

    private IEnumerator ChangeTextRoutine()
    {
        while (true)
        {
            // �ؽ�Ʈ ��Ͽ��� ������ ����
            string randomText = Tip_Collection[Random.Range(0, Tip_Collection.Length)];
            Tip_text.text = randomText;

            // ���� ���� ���
            yield return new WaitForSeconds(changeInterval);
        }
    }

    private void OnDisable()
    {
        // �ڷ�ƾ ���� (���� ����ǰų� ������Ʈ�� ��Ȱ��ȭ�� ��)
        if (changeTextCoroutine != null)
        {
            StopCoroutine(changeTextCoroutine);
        }
    }
}
