using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWidth : MonoBehaviour
{
    [Header("�簢���� ���η� ����")]

    [SerializeField] private GameObject squareObject;       //������ų ���� ������Ʈ
    [SerializeField] private float spawnDelay;              //���̽�ų ������Ʈ�� ���� �����̰�
    
    [Header ("��ǥ��")]
    [SerializeField] private int max_PositionY;             //������Ʈ�� y���� �������� ���� (�ִ밪)
    [SerializeField] private int min_PositionY;             //������Ʈ�� y���� �������� ���� (�ּҰ�)    
    private int Count = 0;
    private int random_PositionY;                           //�������� ���� ������Ʈ�� y ��ǥ��
    private int positionX = 8;

    private void Start()
    {
        StartCoroutine("SpawnSquare");
    }

    IEnumerator SpawnSquare()
    {
        random_PositionY = Random.Range(min_PositionY, max_PositionY);

        yield return new WaitForSeconds(spawnDelay);
        Count++;
        if(Count == 3)
        {
            Fade.i.OnFade(0.1f);
            Count = 0;
        }
        Instantiate(squareObject, new Vector2(positionX, random_PositionY), Quaternion.identity);
        StartCoroutine("SpawnSquare");
    }
}
