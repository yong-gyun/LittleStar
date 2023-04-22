using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHieghtDownandUp : MonoBehaviour
{
    [Header("�簢�� ������Ʈ�� �Ʒ����� �ھƳ��� ������ ������")]

    [SerializeField] private GameObject squareObject_Up;        //�ö󰡴� ������Ʈ
    [SerializeField] private GameObject squareObject_Down;      //�������� ������Ʈ
    
    [Header ("������Ʈ�� ������ ��ǥ��")]
    [SerializeField] private int max_PositionX;
    [SerializeField] private int min_PositionX;
    [SerializeField] private int max_PositionY;
    [SerializeField] private int min_PositionY;

    private int random_PositionX;       //x ��ǥ���� �������� ���� �����ų ����

    [SerializeField] private float Delay;

    private void Start()
    {
        StartCoroutine("StartPattern");
    }

    IEnumerator StartPattern()
    {
        random_PositionX = Random.Range(min_PositionX, max_PositionX);

        Instantiate(squareObject_Down, new Vector2(random_PositionX, max_PositionY), Quaternion.identity);      //�������� ������Ʈ ����
        yield return new WaitForSeconds(Delay);

        Instantiate(squareObject_Up, new Vector2(random_PositionX, min_PositionY), Quaternion.identity);        //�ö󰡴� ������Ʈ ����
        yield return new WaitForSeconds(Delay);

        StartCoroutine("StartPattern");
    }
}
