using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScale : MonoBehaviour
{
    public GameObject circleObject;
    
    public float max_ScaleX, min_ScaleX;        //������ x�� �ִ밪, ������ x��  �ּҰ�
    public float max_ScaleY, min_ScaleY;        //������ y�� �ִ밪, ������ y�� �ּҰ�
    public float scale_Speed;                   //�������� ���ϴ� �ӵ�
    public float max_Delay;                     //�������� �ִ밪

    private float Delay;
    private bool onScale;
    private void Start()
    {
        Delay = max_Delay;
    }

    private void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)
        {
            if (circleObject.transform.localScale.x <= min_ScaleY && circleObject.transform.localScale.y <= min_ScaleY)
            {
                onScale = true;
            }
            else if (circleObject.transform.localScale.x >= max_ScaleY && circleObject.transform.localScale.y >= max_ScaleY)
            {
                onScale = false;
            }

            Delay = max_Delay;
        }
        if(onScale)
        {
            transform.localScale = new Vector3(transform.localScale.x + scale_Speed * Time.deltaTime, transform.localScale.y + scale_Speed * Time.deltaTime, 1);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - scale_Speed * Time.deltaTime, transform.localScale.y - scale_Speed * Time.deltaTime, 1);
        }
        
    }
}
