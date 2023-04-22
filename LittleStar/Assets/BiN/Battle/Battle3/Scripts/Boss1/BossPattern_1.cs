using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern_1 : MonoBehaviour
{
    [Header("������ �����ǰ� �� �� ���� �ʵ� �׵θ��� ���ε� ������ ����")]

    [SerializeField] private GameObject circleObject;        //������ų ���� ������Ʈ

    [Header ("������Ʈ�� ������ų ��ǥ��")]
    [SerializeField] private int max_PositionX;
    [SerializeField] private int min_PositionX;
    [SerializeField] private int max_PositionY;
    [SerializeField] private int min_PositionY;

    [SerializeField] private float Delay;
    void Start()
    {
        StartCoroutine("FieldSpawn");        
    }

    IEnumerator FieldSpawn()
    {
        for(int i = 0; i < 2; i++)
        {
            for (int j = min_PositionX; j <= max_PositionX; j += 2)
            {
                Instantiate(circleObject, new Vector2(j, max_PositionY), Quaternion.identity);
                yield return new WaitForSeconds(Delay);
            }

            Instantiate(circleObject, new Vector2(max_PositionX, 0f), Quaternion.identity);

            for (int j = max_PositionX; j >= min_PositionX; j -= 2)
            {
                Instantiate(circleObject, new Vector2(j, min_PositionY), Quaternion.identity);
                yield return new WaitForSeconds(Delay);
            }

            Instantiate(circleObject, new Vector2(min_PositionX, 0f), Quaternion.identity);

            yield return new WaitForSeconds(3.5f);
        }
        
        
        
    }

    
}
