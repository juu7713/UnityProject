using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public GameObject gameclearText; // ����Ŭ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; //���� �ð� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text lifeText; // life ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private float endTime; // ���� �ð�
    private bool isGameover; // ���� ���� ����
    private bool isGameclear; // ���� Ŭ���� ����


    void Start()
    {
        surviveTime = 0;
        endTime = 60;
        isGameover = false;
        isGameclear = false;
    }


    void Update()
    {
        if (!isGameover)
        {
            if (!isGameclear)
            {
                surviveTime += Time.deltaTime;           // �ð� ����
                timeText.text = "Time: " + (int)surviveTime; // �ؽ�Ʈ�� ǥ��
            }

            // ���� Ŭ���� ����
            else
            {
                //�����
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }

        // ���� ���� ����
        else
        {
            //�����
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        isGameover = true;
        gameoverText.SetActive(true);


    }

    public void GameClear()
    {
        isGameclear = true;
        gameclearText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime"); // BestTime���� ����� ���� ��� ��������

        // �ְ� ��� ����
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void TimeController()
    {

    }
}
