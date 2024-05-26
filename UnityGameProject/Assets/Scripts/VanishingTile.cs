using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingTile : MonoBehaviour
{
    public int lines = 5;   // 타일의 행 수
    public int order;   // 처음에 타일이 나타나는 상대적 순서. 수 작을 수록 일찍 나타남
    public float appearingDelay = 10f;  // 타일이 유지되는 시간
    

    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;   // 시작시 타일 접촉 Off
        this.GetComponent<Renderer>().enabled = false;      // 시작시 타일 모습 Off
        StartCoroutine(FirstAppearance());  // Initial 코루틴 호출
    }

    private IEnumerator FirstAppearance()   // 타일이 처음 나타나게 하는 코루틴. order에 따라 순서대로 나타남.
    {
        yield return new WaitForSeconds(order * appearingDelay);    // order에 따라 대기
        this.GetComponent<BoxCollider>().enabled = true;    // 타일 접촉 On
        this.GetComponent<Renderer>().enabled = true;       // 타일 모습 On
        StartCoroutine(TileAppearance());   // 반복 코루틴 호출
    }

    private IEnumerator TileAppearance()    // 타일의 나타남/사라짐 반복 코루틴. 
    {
        while (true)    
        {
            if (this.GetComponent<BoxCollider>().enabled)   // 타일이 나타나있는 상태일 경우
            {
                yield return new WaitForSeconds(appearingDelay);    // appearingDelay만큼 대기 후 사라짐.
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Renderer>().enabled = false;
            }
            else     // 타일이 사라져있는 상태일 경우
            {
                yield return new WaitForSeconds((lines - 1) * appearingDelay);   
                this.GetComponent<BoxCollider>().enabled = true;    // (행 수 - 1) * appearingDelay만큼 대기 후 나타남.
                this.GetComponent<Renderer>().enabled = true;
            }
        }     
    }
}
