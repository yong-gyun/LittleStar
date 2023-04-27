using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float ColorSpeed;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 0, 0, 1);
        StartCoroutine("Effect");
    }

    IEnumerator Effect()
    {
        float Color_g = spriteRenderer.color.g;
        float Color_b = spriteRenderer.color.b;

        if (spriteRenderer.color == new Color(1, 0, 0, 1))      //�������� 0.8���� �Ͼ������ õõ�� �ٲ�
        {
            spriteRenderer.color = new Color(1, Color_g + ColorSpeed * Time.deltaTime, Color_b + ColorSpeed * Time.deltaTime, 1);
        }
        else if (spriteRenderer.color == new Color(1, 1, 1, 1))     //�Ͼ������ �ٽ� �������� õõ�� �ٲ�
        {
            spriteRenderer.color = new Color(1, Color_g - ColorSpeed * Time.deltaTime, - ColorSpeed * Time.deltaTime, 1);
        }

        yield return null;
    }
}
