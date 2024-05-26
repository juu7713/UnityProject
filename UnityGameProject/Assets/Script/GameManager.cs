using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public GameObject gameclearText; // 게임클리어 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; //생존 시간 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public Text lifeText; // life 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private float endTime; // 제한 시간
    private bool isGameover; // 게임 오버 상태
    private bool isGameclear; // 게임 클리어 상태


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
                surviveTime += Time.deltaTime;           // 시간 갱신
                timeText.text = "Time: " + (int)surviveTime; // 텍스트로 표시
            }

            // 게임 클리어 상태
            else
            {
                //재시작
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }

        // 게임 오버 상태
        else
        {
            //재시작
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

        float bestTime = PlayerPrefs.GetFloat("BestTime"); // BestTime으로 저장된 이전 기록 가져오기

        // 최고 기록 갱신
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void TimeController()
    {

    }
}
