using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType5 : MonoBehaviour
{
    public GameObject circleObject;     //������ų ������Ʈ
    public float maxDelay;              //�������� �ִ밪
    public float positionY;             //������Ʈ�� ������ų y ��ǥ��
    public int max_PositionX;         //�������� ���� ������Ʈ�� x ��ǥ �ִ밪
    public int min_PosiitonX;         //�������� ���� ������Ʈ�� x ��ǥ �ּҰ�

    private float Delay;                //������Ʈ�� ���� ������
    private int RandomX;                //�������� ���� ������Ʈ x���� �����ų ���� 
    void Start()
    {
            
    }

    void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)      //�����̰��� 0 ���ϷεǸ� ������Ʈ ����
        {
            RandomX = Random.Range(min_PosiitonX, max_PositionX);       //x ��ǥ���� �������� ������       
            Instantiate(circleObject, new Vector2(RandomX, positionY), Quaternion.identity);        //������Ʈ ����
            Delay = maxDelay;           //�����̰��� �ִ밪���� �ʱ�ȭ
        }
    }
}
