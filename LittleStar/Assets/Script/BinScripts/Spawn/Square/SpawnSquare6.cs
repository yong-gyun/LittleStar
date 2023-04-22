using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare6 : MonoBehaviour
{
    [Header("�簢�� ���� ���� ���� ���� ����")]

    public GameObject squareObject_Horizontal;         //���� ������Ʈ
    public GameObject squareObject_Vertical;           //���� ������Ʈ
    public float maxDelay;                             //�������� �ִ밪
    public int max_Count;                              //ī��Ʈ���� �ִ�ġ�� �����ֱ����� ����

    private float Delay;                               //������Ʈ ���� ������
    private int random_X;                              //X ��ǥ���� �������� ��ȯ ���� ��ġ
    private int random_Y;                              //Y ��ǥ�� �������� ��ȯ ���� ��ġ
    private int Count;                                 //���� ī��Ʈ�� �Ǹ� ���̵� ȿ���� ������ 
    private void Start()
    {
        Delay = maxDelay;
        random_X = Random.Range(-4, 5);             //���� ��ǥ�� �������� ������
        random_Y = Random.Range(-4, 5);             //���� ��ǥ�� �������� ������

        //������Ʈ ���� (- ��ǥ�� + ��ǥ, ����, ���� �ϳ��� ��ȯ)
        Instantiate(squareObject_Horizontal, new Vector2(10, Mathf.Round(random_Y)), Quaternion.identity);
        Instantiate(squareObject_Vertical, new Vector2(Mathf.Round(random_X), 10), Quaternion.identity);

    }
    private void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)           
        {
            random_X = Random.Range(-4, 5);             //���� ��ǥ�� �������� ������
            random_Y = Random.Range(-4, 5);             //���� ��ǥ�� �������� ������

            //������Ʈ ���� (- ��ǥ�� + ��ǥ, ����, ���� �ϳ��� ��ȯ)
            Instantiate(squareObject_Horizontal, new Vector2(10, Mathf.Round(random_Y)), Quaternion.identity);      
            Instantiate(squareObject_Vertical, new Vector2(Mathf.Round(random_X), 10), Quaternion.identity);
            Delay = maxDelay;
            Count++;
        }
        
        if(Count == max_Count)
        {
            Fade.i.OnFade(0.1f);
            Count = 0;
        }
    }
}
