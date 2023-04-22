using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareOrderHieght : MonoBehaviour
{
    [Header ("������Ʈ�� ���η� ���������� �����Ǹ� �̵���")]

    #region //Field

    [SerializeField] private GameObject squareObject_Up;
    [SerializeField] private GameObject squareObject_Down;

    [Header("��ǥ�� ���� ����")]
    [SerializeField] private float min_PositionX;
    [SerializeField] private float max_PositionX;
    [SerializeField] private float min_PositionY;
    [SerializeField] private float max_PositionY;

    [Header("������ ����")]
    [SerializeField] private float Delay;
    [SerializeField] private float spawnDelay;

    #endregion

    private void Start()
    {
        StartCoroutine("UpPattern");
    }
    IEnumerator UpPattern()
    {
        for(float x = min_PositionX; x <= max_PositionX; x++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(squareObject_Up, new Vector2(x, max_PositionY), Quaternion.identity);

            if (x >= max_PositionX)
            {
                yield return new WaitForSeconds(Delay);
                StartCoroutine("DownPattern");
                StopCoroutine("UpPattern");
            }
        }
    }

    IEnumerator DownPattern()
    {
        for (float x = max_PositionX; x >= min_PositionX; x--)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(squareObject_Down, new Vector2(x, min_PositionY), Quaternion.identity);

            if (x <= min_PositionX)
            {
                yield return new WaitForSeconds(Delay);
                StartCoroutine("UpPattern");
                StopCoroutine("DownPattern");
            }
        }
    }
}
