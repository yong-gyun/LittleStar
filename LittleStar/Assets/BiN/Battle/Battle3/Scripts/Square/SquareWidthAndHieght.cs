using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWidthAndHieght : MonoBehaviour
{
    [Header ("������ų ������Ʈ")]
    [Space(10f)]
    [Header ("������Ʈ�� ���� ���η� ����")]
    
    [SerializeField] private GameObject width_SquareObject;
    [SerializeField] private GameObject hieght_SquareObject;

    [Header ("���� ���� ���� ������")]
    [SerializeField] private float width_Delay;
    [SerializeField] private float hieght_Delay;
    
    [Header ("������Ʈ�� ������ ��ǥ��")]
    [SerializeField] private int max_PositionX;
    [SerializeField] private int min_PositionX;
    [SerializeField] private int max_PositionY;
    [SerializeField] private int min_PositionY;

    private int random_PositionX;
    private int random_PositionY;
    private int fade_Count = 0;
    private void Start()
    {
        StartCoroutine("SpawnSquare");
    }
    IEnumerator SpawnSquare()
    {
        random_PositionX = Random.Range (min_PositionX, max_PositionX);
        random_PositionY = Random.Range(min_PositionY, max_PositionY);
        if (fade_Count == 2)
        {
            Fade.i.OnFade(0.1f);
            fade_Count = 0;
        }

        Instantiate(width_SquareObject, new Vector2(max_PositionX, random_PositionY), Quaternion.identity);
        fade_Count++;
        yield return new WaitForSeconds(width_Delay);

        Instantiate(hieght_SquareObject, new Vector2(random_PositionX, 8f), Quaternion.identity);
        fade_Count++;
        yield return new WaitForSeconds(hieght_Delay);
        
        StartCoroutine("SpawnSquare");
    }

}
