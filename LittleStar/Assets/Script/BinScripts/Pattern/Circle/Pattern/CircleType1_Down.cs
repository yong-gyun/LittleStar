using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleType1_Down : MonoBehaviour
{
    [Header("���� ���� ��ġ���� �������� �� �� ����")]

    public GameObject circleObject;                     //������Ʈ�� �갳�ϱ��� ������Ʈ
    public GameObject fragment;                         //�갳�� �� ������Ʈ
    public float Speed, minHieght, maxHieght;           //������Ʈ �̵� �ӵ�, �ּ� ����, �ִ� ����
    public bool onColor;                                //������Ʈ�� �ö��� �������� �Ǻ����� bool ����

    private SpriteRenderer circleColor;                 //�� �� ����
    private float Slow, posY;                           //������Ʈ�� �������� ����, ������Ʈ�� �ʱ� ��ǥ��
    private bool onSlow;                                //������Ʈ�� ���ο�, �������� �Ǻ����� bool ����
    private bool onEnd;

    private void Start()
    {
        circleColor = circleObject.GetComponent<SpriteRenderer>();
        posY = circleObject.transform.position.y;       //������Ʈ�� �ʱⰪ ����
        Slow = 1f;                                      
    }
    private void FixedUpdate()
    {
        StartCoroutine("Effect");
        transform.Translate(Vector2.down * Speed * Time.deltaTime * Slow);
        Down();
    }


    private void Down()     //������Ʈ�� ������ �����Ǽ� �Ʒ��� ������
    {

        if (transform.position.y <= minHieght)        //y �ּҰ����� �۾����� ������Ʈ ���ο�
        {
            onSlow = true;
        }
        
        if (transform.position.y <= maxHieght)       //y �ִ밪 ���� �۾����� ������Ʈ �갳
        {
            onEnd = true;
        }

        if (onSlow)
        {
            Slow = 0.2f;
        }
        
        if (onEnd)
        {
            Shot();
            Destroy(this.gameObject);
        }
    }
    private void Shot()                                 //������Ʈ �갳
    {
        for(int i = 0; i < 360; i += 48)
        {
            Fade.i.OnFade(0.1f);
            GameObject temp = Instantiate(fragment);            //�갳�� ������Ʈ ����
            Destroy(temp, 2f);                                      //�갳�� ������Ʈ�� 2�� �� ����

            temp.transform.position = circleObject.transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator Effect()        //������ �� ������Ʈ �� ����
    {
        if(onColor)
        {
            yield return new WaitForSeconds(0.1f);
            circleColor.color = new Color(1, 0, 0, 1);
            onColor = false;
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            circleColor.color = new Color(1, 1, 1, 1);
            onColor = true;
        }
    }

}
