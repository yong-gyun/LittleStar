using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHieght : MonoBehaviour
{
    [Header("�簢���� ���η� ����")]

    [SerializeField] private GameObject squareObject;       //������ų ���� ������Ʈ
    [SerializeField] private float spawnDelay;              //���̽�ų ������Ʈ�� ���� �����̰�

    [Header("��ǥ��")]
    [SerializeField] private int max_PositionX;             //������Ʈ�� y���� �������� ���� (�ִ밪)
    [SerializeField] private int min_PositionX;             //������Ʈ�� y���� �������� ���� (�ּҰ�)    

    private int random_PositionX;                           //�������� ���� ������Ʈ�� y ��ǥ��
    private int positionY = 8;
    private int Count = 0;
    private void Start()
    {
        StartCoroutine("SpawnSquare");
    }

    IEnumerator SpawnSquare()
    {
        random_PositionX = Random.Range(min_PositionX, max_PositionX);

        yield return new WaitForSeconds(spawnDelay);
        Count++;
        if (Count == 3)
        {
            Fade.i.OnFade(0.1f);
            Count = 0;
        }
        Instantiate(squareObject, new Vector2(random_PositionX, positionY), Quaternion.identity);
        StartCoroutine("SpawnSquare");
    }
}
