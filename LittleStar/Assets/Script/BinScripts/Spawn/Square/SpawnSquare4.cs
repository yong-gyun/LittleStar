using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare4 : MonoBehaviour
{
    [Header("�簢�� ���� ���� (���������� ����)")]

    public GameObject squareObject;  //������ų ������Ʈ
    public float max_SpawnDealy;     //���� �������� �ִ밪
    public float defualt_Delay;      //������ �ʱⰪ
    public float defualt_X;          //������Ʈ�� ������ �ʱ� ��ǥ�� X
    public int maxCount;             //ī��Ʈ�� �ִ밪

    private float spawnCount;        //������Ʈ�� � ��������� ������ ī��Ʈ 
    private float position_X;        //������Ʈ�� ���� ��ǥ�� X
    private float spawnDlay;         //���� ������
    private float Delay;             //������Ʈ ���� ������

    private void Start()
    {
        position_X = defualt_X;
        spawnCount = 0;
    }

    private void Update()
    {
        spawnDlay -= Time.deltaTime;
        Delay -= Time.deltaTime;
        SpawnSquare();
    }

    private void SpawnSquare()
    {
        if(spawnDlay <= 0)
        {
            if (Delay <= 0)
            {
                //������Ʈ ����
                Instantiate(squareObject, new Vector2(position_X, 10), Quaternion.identity);

                Delay = defualt_Delay;          //�����̸� �ʱ� ���·� ��������
                position_X += 3f;               //x ��ǥ���� ��ȯ������
                spawnCount++;                   //������Ʈ�� ��� �����Ǿ����� ������
            }

        }
        
        
        if(spawnCount == maxCount)      //������Ʈ�� �ִ밪���� �����Ǹ� �ʱⰪ���� �ʱ�ȭ
        {
            spawnCount = 0;                  //������Ʈ ī��Ʈ�� 0���� �ٲ�
            position_X = defualt_X;          //������Ʈ�� x ��ǥ���� �ʱⰪ���� ��������
            spawnDlay = max_SpawnDealy;      //���� �����̸� �ִ밪���� �ʱ�ȭ��
        }

    }
}
