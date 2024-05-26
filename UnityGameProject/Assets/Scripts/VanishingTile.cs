using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingTile : MonoBehaviour
{
    public int lines = 5;   // Ÿ���� �� ��
    public int order;   // ó���� Ÿ���� ��Ÿ���� ����� ����. �� ���� ���� ���� ��Ÿ��
    public float appearingDelay = 10f;  // Ÿ���� �����Ǵ� �ð�
    

    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;   // ���۽� Ÿ�� ���� Off
        this.GetComponent<Renderer>().enabled = false;      // ���۽� Ÿ�� ��� Off
        StartCoroutine(FirstAppearance());  // Initial �ڷ�ƾ ȣ��
    }

    private IEnumerator FirstAppearance()   // Ÿ���� ó�� ��Ÿ���� �ϴ� �ڷ�ƾ. order�� ���� ������� ��Ÿ��.
    {
        yield return new WaitForSeconds(order * appearingDelay);    // order�� ���� ���
        this.GetComponent<BoxCollider>().enabled = true;    // Ÿ�� ���� On
        this.GetComponent<Renderer>().enabled = true;       // Ÿ�� ��� On
        StartCoroutine(TileAppearance());   // �ݺ� �ڷ�ƾ ȣ��
    }

    private IEnumerator TileAppearance()    // Ÿ���� ��Ÿ��/����� �ݺ� �ڷ�ƾ. 
    {
        while (true)    
        {
            if (this.GetComponent<BoxCollider>().enabled)   // Ÿ���� ��Ÿ���ִ� ������ ���
            {
                yield return new WaitForSeconds(appearingDelay);    // appearingDelay��ŭ ��� �� �����.
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Renderer>().enabled = false;
            }
            else     // Ÿ���� ������ִ� ������ ���
            {
                yield return new WaitForSeconds((lines - 1) * appearingDelay);   
                this.GetComponent<BoxCollider>().enabled = true;    // (�� �� - 1) * appearingDelay��ŭ ��� �� ��Ÿ��.
                this.GetComponent<Renderer>().enabled = true;
            }
        }     
    }
}
