using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    [Header("������ �����ǰ� ���� ȭ�鿡 õõ�� ��Ÿ��")]

    [SerializeField] private GameObject boss_Object;         //������ų ���� ������Ʈ
    
    private void Start()
    {
        Instantiate(boss_Object, new Vector2(0f, 8f), Quaternion.identity);
    }

}
