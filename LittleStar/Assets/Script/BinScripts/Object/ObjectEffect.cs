using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour
{
    public SpriteRenderer Object;
    public float ColorSpeed;
    private void Start()
    {
        Object.color = new Color(1, 0, 0, 1);
        StartCoroutine("Effect");
    }

    IEnumerator Effect()
    {
        float Color_g = Object.color.g;
        float Color_b = Object.color.b;

        if (Object.color == new Color(1, 0, 0, 1))      //�������� 0.8���� �Ͼ������ õõ�� �ٲ�
        {
            Object.color = new Color(1, Color_g + ColorSpeed * Time.deltaTime, Color_b + ColorSpeed * Time.deltaTime, 1);
        }
        else if (Object.color == new Color(1, 1, 1, 1))     //�Ͼ翡�� �ٽ� �������� õõ�� �ٲ�
        {
            Object.color = new Color(1, Color_g - ColorSpeed * Time.deltaTime, - ColorSpeed * Time.deltaTime, 1);
        }

        yield return null;
    }
}
