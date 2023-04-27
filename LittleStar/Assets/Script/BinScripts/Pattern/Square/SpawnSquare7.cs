using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare7 : MonoBehaviour
{
    [Header("�簢�� ��ֹ��� ������Ű�� ������Ʈ�� �̵���Ŵ")]

    public float max_Delay;
    public GameObject squareObject;
    private bool upDown;
    private float Delay;

    private void Start()
    {
        Delay = 0;
        upDown = true;
    }

    private void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0 && upDown)
        {
            Instantiate(squareObject, new Vector2(10, 3), Quaternion.identity);
            Delay = max_Delay;
            upDown = false;
        }
        else if(Delay <= 0 && !upDown)
        {
            Instantiate(squareObject, new Vector2(10, -3), Quaternion.identity);
            Delay = max_Delay;
            upDown = true;
        }
    }
}
