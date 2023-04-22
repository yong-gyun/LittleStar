using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare5 : MonoBehaviour
{
    [Header("�簢�� ���� 2�� ����")]

    public GameObject squareObject;
    public float maxDelay;              //������Ʈ ���� �������� �ִ밪
    public float position_X;            //x ��ǥ��

    private float Delay;                //������Ʈ�� ���� ������ 

    private void Start()
    {
        Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);
        Instantiate(squareObject, new Vector2(position_X * -1, 10), Quaternion.identity);
        Delay = maxDelay;
    }

    private void Update()
    {
        Delay -= Time.deltaTime;
        if(Delay <= 0)
        {
            Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);
            Instantiate(squareObject, new Vector2(position_X * -1, 10), Quaternion.identity);
            Delay = maxDelay;
        }
        
    }
}
