using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Square1 : MonoBehaviour
{
    [Header("���� ������ �������� �����̸��� �簢���� ���� �ӵ��� ������")]

    public GameObject circleObject;     //���������� �� ������Ʈ
    public GameObject squareObject;     //���������� �簢�� ������Ʈ
    public float max_SpawnDaly;         //������Ʈ ���� ������ �ִ밪
    public float max_SquareDelay;       //�簢�� ������Ʈ ���� ������ �ִ밪

    private float spawnDelay;                   //���� ������
    private float squareDelay;                  //�簢�� ���� ������

    private int random_PositionX_Circle;        //���� x��ǥ�� �������� ���� ������ ���� 
    private int random_PositionX_Square;        //�簢���� x��ǥ�� �������� ���� ������ ����
    private void Start()
    {
        spawnDelay = 0;
        squareDelay = max_SquareDelay;
    }
    void Update()
    {
        spawnDelay -= Time.deltaTime;
        squareDelay -= Time.deltaTime;

        if (spawnDelay <= 0)
        { 
            random_PositionX_Circle = Random.Range(-8, 9);
            Instantiate(circleObject, new Vector2(random_PositionX_Circle, 5), Quaternion.identity);
            spawnDelay = max_SpawnDaly;
        }
        
        if(squareDelay <= 0)
        {
            random_PositionX_Square = Random.Range(-6, 7);
            Instantiate(squareObject, new Vector2(random_PositionX_Square, 5), Quaternion.identity);
            squareDelay = max_SquareDelay;
        }
    }
}
