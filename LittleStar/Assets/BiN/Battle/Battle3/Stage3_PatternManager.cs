using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_PatternManager : MonoBehaviour
{
    [Header("�������� 3(������)�� ����� �������� �Ŵ��� ��ũ��Ʈ")]

    #region //Field

    [Tooltip ("���ʵ��� �ο����� ���� Ÿ�̸� ����")]
    [SerializeField] public float battle_Timer;

    [Tooltip ("���° �������� ������ ī��Ʈ ����")]
    [SerializeField] public float battle_Count;
    public bool onStartPattern;
    
    [Header("���� ���� ������")]

    [Tooltip ("���� 1�� ���� ������")]
    [SerializeField] private GameObject boss_Spawner;

    private GameObject bossSpawner;

    [Header("�� & �簢�� ����")]

    [Tooltip ("�簢���� ���� ������ ������")]
    [SerializeField] private GameObject circle_and_square_Pattern;

    private GameObject circleAndSquarePattern;

    [Header("����� ����(��)")]

    [Tooltip ("���� �ֺ����� �����ε� ������ ����")]
    [SerializeField] private GameObject circle_Field_boss;          

    [Tooltip ("�ϴÿ��� ���ε� ������Ʈ�� �������� ������ ������")]
    [SerializeField] private GameObject circle_Meteor;             

    [Tooltip ("4���� �� ������ ������")]
    [SerializeField] private GameObject circle_Field;

    [Tooltip("������Ʈ�� �����ʿ��� �����Ǿ� �������� �̵���")]
    [SerializeField] private GameObject circle_moveLeft;

    [Tooltip ("������Ʈ�� �̵� �� �갳")]
    [SerializeField] private GameObject circle_Boom;

    private GameObject circleFieldboss;
    private GameObject circleMeteor;
    private GameObject circleField;
    private GameObject circleMoveLeft;
    private GameObject circleBoom;

    [Header("����� ����(�簢��)")]

    [Tooltip ("������Ʈ�� ���η� ���������� ����")]
    [SerializeField] private GameObject square_Order_Hieght;        

    [Tooltip ("�Դ� �����ϴ� ������Ʈ�� ����, ���η� ����")]
    [SerializeField] private GameObject square_Width_Hieght;        

    [Tooltip ("�簢�� ������Ʈ�� ���������� �������� �� �������� ���������� �ö�")]
    [SerializeField] private GameObject square_Order_Down;          

    [Tooltip ("�簢�� ������Ʈ�� ���������� �������� �����")]
    [SerializeField] private GameObject square_Hieght;

    [Tooltip ("�簢�� ������Ʈ�� ���ʿ��� �����Ǿ� ���������� �̵���")]
    [SerializeField] private GameObject square_moveLeft;

    [Tooltip ("�簢�� ������Ʈ�� �����ʿ��� �������� �̵��ϸ� �Դ� ������.")]
    [SerializeField] private GameObject square_Width;

    [Tooltip("�簢�� ������Ʈ�� ���� ���η� ���ÿ� ���� ����")]
    [SerializeField] private GameObject square_Width_Down;

    private GameObject squareOrder_Hieght;
    private GameObject square_WidthandHieght;
    private GameObject square_OrderDown;
    private GameObject squareHieght;
    private GameObject squareMoveLeft;
    private GameObject squareWidth;
    private GameObject squareWidthandDown;

    #endregion

    public static Stage3_PatternManager i;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyAllGimic()
    {
        DestroyGimic(squareOrder_Hieght);
        DestroyGimic(square_WidthandHieght);
        DestroyGimic(square_OrderDown);
        DestroyGimic(squareHieght);
        DestroyGimic(squareMoveLeft);
        DestroyGimic(squareWidth);
        DestroyGimic(squareWidthandDown);
        DestroyGimic(circleFieldboss);
        DestroyGimic(circleMeteor);
        DestroyGimic(circleField);
        DestroyGimic(circleMoveLeft);
        DestroyGimic(circleBoom);
        DestroyGimic(bossSpawner);
        DestroyGimic(circleAndSquarePattern);


    }


    void DestroyGimic(GameObject t)
    {
        if (t != null && t.gameObject != null)
        {
            Destroy(t.gameObject);
        }
    }

    void Start()
    {
        //BGMManager.i.BGMPlay(4);
        battle_Timer = 35;
        battle_Count = 0;
        onStartPattern = false;
    }

    void Update()
    {
        battle_Timer += Time.deltaTime;
        if(battle_Timer >= 34f && !onStartPattern)
        {
            battle_Timer = 0;
            StartCoroutine("ii");
            onStartPattern = true;
        }
        if(onStartPattern)
            StartPattern();
    }

    IEnumerator ii()
    {
        if(PlayerInterection.PI.hp < PlayerInterection.PI.maxHp)
        {
            yield return new WaitForSeconds(10.0f);
            if (GameManager.GM.nowBattle && GameManager.GM.nowScene == GameManager.NowScene.thirdBattle)
            {
                PlayerInterection.PI.AddHp(1);
                StartCoroutine("ii");
            }
        }
        else
        {
            yield return null;
            StartCoroutine("ii");
        }
    }

    private void StartPattern()
    {
        if (battle_Timer >= 2f && battle_Count == 0)
        {
            circleAndSquarePattern = Instantiate(circle_and_square_Pattern, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if (battle_Timer >= 8f && battle_Count == 1)
        {
            //Destroy(circleAndSquarePattern.gameObject);
            battle_Count++;
        }
        else if (battle_Timer >= 18f && battle_Count == 2)
        {
            bossSpawner = Instantiate(boss_Spawner, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if (battle_Timer >= 27f && battle_Count == 3)
        {
            circleFieldboss = Instantiate(circle_Field_boss, Vector2.zero, Quaternion.identity);
            Destroy(bossSpawner.gameObject);
            battle_Count++;
        }
        else if (battle_Timer >= 38.5f && battle_Count == 4)
        {
            squareOrder_Hieght = Instantiate(square_Order_Hieght, Vector2.zero, Quaternion.identity);
            Destroy(circleFieldboss.gameObject);
            battle_Count++;
        }
        else if (battle_Timer >= 51f && battle_Count == 5)
        {
            Destroy(squareOrder_Hieght.gameObject);
            battle_Count++;
        }
        else if (battle_Timer >= 53.5f && battle_Count == 6)
        {
            square_WidthandHieght = Instantiate(square_Width_Hieght, Vector2.zero, Quaternion.identity);
            Destroy(squareOrder_Hieght.gameObject);
            battle_Count++;
        }
        else if (battle_Timer >= 58f && battle_Count == 7)
        {
            Destroy(square_WidthandHieght);
            square_OrderDown = Instantiate(square_Order_Down, Vector2.zero, Quaternion.identity);
            squareWidth = Instantiate(square_Width, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if (battle_Timer >= 68 && battle_Count == 8)
        {
            Destroy(square_OrderDown.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 70f && battle_Count == 9)
        {
            Destroy(squareWidth.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 71.5f && battle_Count == 10)
        {
            //circleAndSquarePattern = Instantiate(circle_and_square_Pattern, Vector2.zero, Quaternion.identity);
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            circleFieldboss = Instantiate(circle_Field_boss, Vector2.zero, Quaternion.identity);        //
            battle_Count++;
        }
        else if(battle_Timer >= 89f && battle_Count == 11)
        {
            squareHieght = Instantiate(square_Hieght, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 90 && battle_Count == 12)
        {
            Destroy(circleMeteor.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 106f && battle_Count == 13)
        {
            Destroy(squareHieght.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 113f && battle_Count == 14)
        {
            //Destroy(circleAndSquarePattern.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 115f && battle_Count == 15)
        {
            squareMoveLeft = Instantiate(square_moveLeft, new Vector2(10, 0), Quaternion.identity);
            circleMoveLeft = Instantiate(circle_moveLeft, new Vector2(10, 0), Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 123f && battle_Count == 16)
        {
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 128f && battle_Count == 17)
        {
            Destroy(squareMoveLeft.gameObject);
            //Destroy(circleAndSquarePattern.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 138f && battle_Count == 18)
        {
            Destroy(circleMeteor.gameObject);
            Destroy(circleMoveLeft.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 140f && battle_Count == 19)      //���� ����
        {
            bossSpawner = Instantiate(boss_Spawner, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 150f && battle_Count == 20)
        {
            circleFieldboss = Instantiate(circle_Field_boss, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 158f && battle_Count == 21)
        {
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 168f && battle_Count == 22)
        {
            Destroy(circleMeteor.gameObject);
            circleField = Instantiate(circle_Field, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 172f && battle_Count == 23)
        {
            Destroy(circleField.gameObject);
            circleField = Instantiate(circle_Field, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 176f && battle_Count == 24)
        {
            Destroy(circleField.gameObject);
            squareWidthandDown = Instantiate(square_Width_Down, Vector2.zero, Quaternion.identity); 
            battle_Count++;
        }
        else if(battle_Timer >= 182f && battle_Count == 25)
        {
            Destroy(squareWidthandDown.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 184f && battle_Count == 26)
        {
            Destroy(circleFieldboss.gameObject);
            squareOrder_Hieght = Instantiate(square_Order_Hieght, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 192f&& battle_Count == 27)
        {
            Destroy(squareOrder_Hieght.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 194f && battle_Count == 28)
        {
            circleBoom = Instantiate(circle_Boom, new Vector2(4, -7), Quaternion.identity);
            Destroy(circleBoom.gameObject, 11f);
            battle_Count++;
        }
        else if(battle_Timer >= 196f && battle_Count == 29)
        {
            circleBoom = Instantiate(circle_Boom, new Vector2(-4, -7), Quaternion.identity);
            Destroy(circleBoom.gameObject, 11f);
            battle_Count++;
        }
        else if(battle_Timer >= 200f && battle_Count == 30)
        {
            circleMeteor = Instantiate(circle_Meteor, Vector2.zero, Quaternion.identity);
            battle_Count++;
        }
        else if(battle_Timer >= 203 && battle_Count == 31)
        {
            circleFieldboss = Instantiate(circle_Field_boss, Vector2.zero, Quaternion.identity);
            Destroy(circleFieldboss, 10f);
            battle_Count++;
        }
        else if(battle_Timer >= 224f && battle_Count == 32)
        {
            Destroy(circleAndSquarePattern.gameObject);
            Destroy(circleMeteor.gameObject);
            battle_Count++;
        }
        else if(battle_Timer >= 232f && battle_Count == 33)
        {
            BattleEvent3.i.SetEvent(2);
            battle_Count++;
        }


    }
}
