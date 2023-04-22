using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUp : MonoBehaviour
{
    [Header("�簢�� ������Ʈ�� �Ʒ����� ���� �̵�")]

    public SpriteRenderer squareObject;     //������ ������Ʈ�� �÷��� �ٲٱ� ���� ��������Ʈ ����

    public float scaleSpeed;                //������ ���� �ӵ� ����
    public float colorSpeed;                //�� ���� �ӵ� ����
    public float objectSpeed;               //������Ʈ�� �����϶��� ���ǵ尪
    public float minHieght;                 //�ּ� �̵� ����
    public float maxHieght;                 //�ִ� �̵� ����    
    [SerializeField] private bool onFade;
    private bool onColor, onDestroy, isColor, isMove, destroyObj, onScale;

    //x -0.5 -> 0.5 -> 0 -> �÷� ���� -> ������ ���� �ϸ� ���İ� ���� -> ����


    private void Start()
    {
        onScale = false;
        //���� �Ͼ������ ����
        isMove = true;
        squareObject.color = new Color(1, 0, 0, 1);
    }
    private void Update()
    {
        //������Ʈ �̵� �ڵ�
        if (transform.position.y < maxHieght && isMove)        //������Ʈ�� -2���� �̵��ϸ� 0��ǥ�� �̵�
        {
            transform.Translate(Vector2.up * objectSpeed * Time.deltaTime);
        }
        else if (transform.position.y > minHieght)        //������Ʈ�� -2���� �̵�
        {
            transform.Translate(Vector2.down * objectSpeed * Time.deltaTime);

            if (onFade)
                Fade.i.OnFade(0.1f);
            isMove = false;
            onColor = true;
        }
        if (onColor)     //�̵� �� ����Ʈ ȿ��
            StartCoroutine("Effect", 2f);

    }

    IEnumerator Effect()
    {
        float g = squareObject.color.g + colorSpeed * Time.deltaTime;       //�׸� �� ����
        float b = squareObject.color.b + colorSpeed * Time.deltaTime;       //��� �� ����
        float a = squareObject.color.a - colorSpeed * Time.deltaTime;       //���� �� ����

        if (transform.localScale.x < 1f && onScale)      //������Ʈ�� y ũ�⸦ �ø�
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleSpeed * Time.deltaTime, transform.localScale.y, transform.localScale.z);
        }

        if (squareObject.color == new Color(1, 1, 1, 1))
        {
            isColor = true;
        }

        if (isColor)        //�÷��� ����� �ٲ�
        {
            squareObject.color = new Color(1, 0, 0, 1);
            isColor = false;
        }
        else                //�ٲٰ� �� �� �÷� ����
        {
            squareObject.color = new Color(1, g, b, a);
            destroyObj = true;
            onScale = true;
        }

        if (a < 0.3f && destroyObj)      //���İ��� 0.3 �����϶� ������Ʈ ����
        {
            Destroy(this.gameObject);
        }

        yield return null;
    }
}
