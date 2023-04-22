using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType3 : MonoBehaviour
{
    [Header("���� ������ Ŀ���� ���� �� �����Ǵ� �ڵ�")]

    public SpriteRenderer circleObject;     //�������� �ִ� �������� �ٲ�� �� ��������Ʈ
    public float scaleSpeed;                //������ ũ�� ��ȯ�� ���� ����
    public float colorSpeed;                //������Ʈ�� ���� �ٲ�� �ӵ�
    public float maxScale;                  //������Ʈ�� �ִ� ũ��
    public float minScale;                  //������Ʈ�� �ּ� ũ��
    public float Timer;
    
    private bool isBoom;                    //���� �������� ���������� �Ǻ� ���� bool ����
    private bool isScale;                   //���� ũ�⸦ �Ǻ� ���� bool ����
    private bool onColor;                   //�� ������ Ȱ��ȭ ������ bool ����
    private void Start()
    {
        isScale = true;
        circleObject.color = new Color(1, 0, 0, 0.5f);
    }
    
    private void LateUpdate()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
            StartCoroutine("onScale");
    }

    IEnumerator onScale()
    {
        float speed = Time.deltaTime * scaleSpeed;
        StartCoroutine("onEffect");
        if (isScale)
        {
            if (transform.localScale.x < maxScale && transform.localScale.y < maxScale)
            {   
                transform.localScale = new Vector3(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime, 1);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                isScale = false;
            }

        }
        else if (!isScale)
        {
            if (transform.localScale.x > minScale && transform.localScale.y > minScale)
            {
                transform.localScale = new Vector3(transform.localScale.x - speed * Time.deltaTime, transform.localScale.y - speed * Time.deltaTime, 1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator onEffect()
    {
        float g = circleObject.color.g + colorSpeed * Time.deltaTime;
        float b = circleObject.color.b + colorSpeed * Time.deltaTime;
        float a = circleObject.color.a + colorSpeed * Time.deltaTime;

        if (circleObject.color == new Color(1, 0, 0, 0.5f))
        {
            onColor = true;
        }

        if(onColor && g < 0.8f || b < 0.8f)
        {
            circleObject.color = new Color(1, g, b, a);
        }
        else if(circleObject.color == new Color(1, 1, 1, 1))
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }

    }
}