using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMeteor2 : MonoBehaviour
{
    [Header("���ε� ������ ������ ���� ������")]

    public GameObject circleObject;     //������ų ������Ʈ
    public float max_Delay;              //������Ʈ�� ������ �����ö��� ������ �ִ밪
    public float max_SpawnDelay;        //������Ʈ ���� �������� �ִ밪
    [SerializeField] private float default_posY;         //������Ʈ�� �ʱ� y���� �����ų ����

    private float Delay;                //������Ʈ�� ������ �����ö��� ������
    public float spawnDelay;           //������Ʈ ���� ������
    private float posY;                 //������Ʈ�� y���� �����ų ����

    private int random_X1;               //������Ʈ�� x���� �������� ����
    private int random_X2;               //������Ʈ2�� x���� �������� ����

    private void Start()
    {
        spawnDelay = max_SpawnDelay;         //���� �����̰� �ʱ�ȭ
        Delay = max_Delay;              //�����̰� �ʱ�ȭ
        posY = default_posY;                                    //y��ǥ���� �⺻ ��ǥ������ ����

    }

    private void Update()
    {
        Delay -= Time.deltaTime;
        spawnDelay -= Time.deltaTime;

        if (Delay <= 0)
        {
            if (posY > -6f)      //y�� -6���� ũ�� ��� ������Ŵ
            {
                Instantiate(circleObject, new Vector2(random_X1, posY), Quaternion.identity);
                Instantiate(circleObject, new Vector2(random_X2, posY), Quaternion.identity);
                posY--;
            }
            else             //-6 ������ �������� �������� x��ǥ�� �ٲٰ� y��ǥ���� �⺻ ��ǥ������ �ٲ�
            {
                if (spawnDelay <= 0)
                {
                    random_X1 = Random.Range(-6, -3);
                    random_X2 = Random.Range(2, 6);

                    posY = default_posY;
                    spawnDelay = max_SpawnDelay;
                    //if (random_X1 - random_X2 == 2.5f)
                    //{
                    //    random_X1 = Random.Range(-5, 5);
                    //    random_X2 = Random.Range(-5, 5);
                    //}
                    //else
                    //{
                    //    posY = default_posY;
                    //    spawnDelay = max_SpawnDelay;
                    //}
                }
            }
            Delay = max_Delay;
        }
    }
}
