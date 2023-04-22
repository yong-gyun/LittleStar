using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType2 : MonoBehaviour
{
    [Header("���� ���������� �����Ǿ� ���ư�")]
    public GameObject circleObject;
    public float max_Timer;

    private float randomY, Timer;
    private void Start()
    {
        Timer = max_Timer;
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        spawnObject();
    }
    
    private void spawnObject()      //������Ʈ ���� �Լ�
    {
                              //y��ǥ�� �������� ��������.
        Vector2 randomPos = new Vector3(10, randomY);       
        if(Timer <= 0f )
        {
            randomY = Random.Range(-3, 4);
            Instantiate(circleObject, randomPos, Quaternion.identity);
            Timer = max_Timer;
        }
    }
}
