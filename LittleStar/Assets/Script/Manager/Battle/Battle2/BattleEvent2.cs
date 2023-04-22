//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BattleEvent2 : MonoBehaviour
//{
//    #region Singleton
//    public static BattleEvent2 i;

//    private void Awake()
//    {
//        if(i == null)
//        {
//            i = this;
//        }
//        else
//        {
//            Destroy(this);
//        }
//    }
//    #endregion

//    #region Set_Field
//    public int events = 0;
//    public int round = 0, choose = 0;
//    public float time = 0f;

//    public bool isStop = false;

//    public bool nowEvent = false, startEvent = false, isFirst = false;

//    [Header("---------------------State---------------------")]
//    public bool isInBathRoom = false;
//    public bool isFrontCabinet = false, isFrontBad = false,
//        isClearBathRoom = false, isClearCabinet = false, hair       = false,
//        dry             = false, top            = false, bottom     = false;

//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        events = 0;

//        isInBathRoom = isFrontCabinet =  isFrontBad = isClearBathRoom = 
//        isClearCabinet = hair = dry = top = bottom = false;
//}

//    bool IsOffDialogue()
//    {
//        //���� ��簡 �����ٸ� true �ƴϸ� false ����.
//        if (!DialogueManager.i.onDialogue)
//        {
//            return true;
//        }
//        return false;
//    }

//    public void SetChoose(int _choose)
//    {
//        choose = _choose;
//    }

//    private void Update()
//    {
//        switch (events)
//        {
//            case 1:
//                Event1();
//                break;

//            case 2:
//                Event2();
//                break;

//            default:
//                break;
//        }
//    }

//    public void Event1()
//    {
//        if (!isStop)
//        {
//            time += Time.deltaTime;
//        }

//        isClearCabinet = (bottom && top);
//        isClearBathRoom = (hair && dry);

//        #region EventMain

//        //first
//        #region event0
//        if (!isFirst)
//        {
//            if (round == 0 && time >= 0)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "����� ħ�뿡�� �Ͼ��.", 0.5f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                isStop = true;
//                round++;
//            }

//            if (round == 1)
//            {
//                if (IsOffDialogue())
//                {
//                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                    round=0;
//                    time = -0.5f;
//                    isFirst = true;
//                    isStop = false;
//                }
//            }
//        }
//        #endregion

//        //nani o
//        #region event1
//        if (round == 0 && time >= 0)
//        {
//            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//            DialogueManager.i.OnTxt(50, "���� �� �ؾ�����?", 0.5f, new Color(255, 255, 255, 255));
//            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            isStop = true;
//            round++;
//        }

//        if (round == 1)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 1.5f;
//                isStop = false;
//            }
//        }
//        #endregion

//        //hint dialogue
//        #region event2
//        if (round == 2 && time >= 2)
//        {
//            if (!isClearBathRoom)
//            {
//                if (!isInBathRoom)
//                {
//                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                    DialogueManager.i.OnTxt(50, "�켱 �ľ�� �ڴ�.", 1f, new Color(255, 255, 255, 255));
//                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                }
//                else
//                {
//                    if (!hair)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "���� �Ӹ��� ���ƾ߰ڴ�.", 1f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else if (!dry)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "���� ���� �۾ƾ߰ڴ�.", 1f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                }
//            }
//            else if(!isClearCabinet)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "���� ���� �Ծ�� ����.", 1f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            else
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "���������� ħ�뿡 ������ ������ ���� ����", 2f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 3)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 1.5f;
//                isStop = false;
//            }
//        }
//        #endregion

//        //invisible next
//        #region event3
//        if (round == 4 && time >= 2.5f)
//        {
//            if (isInBathRoom)
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.hair);
//                DialogueManager.i.OnBattleNext(new Vector2(-4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.dry);
//                DialogueManager.i.OnBattleNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.BattleSpriteState.exit);
//            }
//            else if (isFrontCabinet)
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.top);
//                DialogueManager.i.OnBattleNext(new Vector2(-4, 3), new Vector2(1, 1), GameManager.BattleSpriteState.bottom);
//                DialogueManager.i.OnBattleNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.BattleSpriteState.exit);
//            }
//            else
//            {
//                DialogueManager.i.OnBattleNext(new Vector2(5, 4f), new Vector2(1, 1), GameManager.BattleSpriteState.bathRoom);
//                DialogueManager.i.OnBattleNext(new Vector2(-3, -3f), new Vector2(1, 1), GameManager.BattleSpriteState.cabinet);
//                DialogueManager.i.OnBattleNext(new Vector2(-1, 0f), new Vector2(1, 1), GameManager.BattleSpriteState.bad);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 5)
//        {
//            //���â�� �������� Ȯ��
//            if (IsOffDialogue())
//            {
//                round++;
//                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
//                isStop = false;
//            }
//        }
//        #endregion

//        //calculate
//        #region event4
//        if (round == 6 && time >= 3f)
//        {
//            switch (choose)
//            {
//                case 1:
//                    #region 1
//                    if (isClearBathRoom && isClearCabinet)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ħ�� �տ� ����.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontBad = true;
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "���� �ٸ� ������ ���Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 2:
//                    #region 2
//                    if (isClearBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "�� �ʿ䰡 ����.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� �ı����� ȭ��Ƿ� ����.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isInBathRoom = true;
//                    }
//                    #endregion
//                    break;

//                case 3:
//                    #region 3
//                    if (isClearBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ���� �Ա� ���� ĳ������� ����.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontCabinet = true;
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "�ϴ� �İ� ���� ���� ����.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 21:
//                    #region 21
//                    if (hair)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "�Ӹ��� �̹� ���Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� �Ӹ��� ���Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        hair = true;
//                    }
//                    #endregion
//                    break;

//                case 22:
//                    #region 22
//                    if (hair)
//                    {
//                        if (dry)
//                        {
//                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                            DialogueManager.i.OnTxt(50, "����� �̹� ���⸦ �� �۾Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
//                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        }
//                        else
//                        {
//                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                            DialogueManager.i.OnTxt(50, "����� ���⸦ �۾Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
//                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                            dry = true;
//                        }
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "�켱 �Ӹ��� ���ƾ� �Ѵ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    #endregion
//                    break;

//                case 31:
//                    #region 31
//                    if (top)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� �̹� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        top = true;
//                    }
//                    #endregion
//                    break;

//                case 32:
//                    #region 32
//                    if (bottom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� �̹� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                    }
//                    else
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        bottom = true;
//                    }
//                    #endregion
//                    break;

//                case 4:
//                    #region 4
//                    if (isInBathRoom)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ȭ��ǿ��� ���Դ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isInBathRoom = false;
//                    }
//                    if (isFrontCabinet)
//                    {
//                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                        DialogueManager.i.OnTxt(50, "����� ĳ����� �տ��� ���Դ�.", 0.5f, new Color(255, 255, 255, 255));
//                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//                        isFrontCabinet = false;
//                    }
//                    #endregion
//                    break;

//                default:
//                    break;
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 7)
//        {
//            //���â�� �������� Ȯ��
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
//                isStop = false;
//                time = 0;
//                round = 0;
//                EndEvent();
//            }
//        }
//        #endregion

//        #endregion
//    }

//    public void Event2()
//    {
//        if (!isStop)
//        {
//            time += Time.deltaTime;
//        }

//        #region event1
//        if (round == 0 && time >= 0)
//        {
//            if (!isFirst)
//            {
//                BGMManager.i.SetBGMVolume(1);
//                //Fade.i.OnFade(3);
//            }
//            round++;
//        }

//        if (round == 1)
//        {
//            BGMManager.i.SetBGMVolume(1 - time);
//            if (1 - time <= 0)
//            {
//                time = 4f;
//                round++;
//            }
//        }
//        #endregion

//        #region event2
//        if (round == 2 && time >= 6)
//        {
//            GameManager.GM.nowBattle = false;
//            if (!isFirst)
//            {
//                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
//                DialogueManager.i.OnTxt(50, "����� ���� �غ� ���´�.", 1.5f, new Color(255, 255, 255, 255));
//                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            }
//            isStop = true;
//            round++;
//        }

//        if (round == 3)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                time = 6f;
//                isStop = false;
//            }
//        }
//        #endregion

//        #region event3
//        if (round == 4 && time >= 6.5f)
//        {
//            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 300));
//            DialogueManager.i.OnTxt(90, "Stage2. ��غ�\nClear!!!", 0f, new Color(255, 255, 255, 255));
//            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
//            BGMManager.i.SetEftVolume(1);
//            BGMManager.i.EFTPlay(2);
//            isStop = true;
//            round++;
//        }

//        if (round == 5)
//        {
//            if (IsOffDialogue())
//            {
//                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
//                round++;
//                isStop = false;
//            }
//        }
//        #endregion

//        #region event4
//        if (round == 6 && time >= 7f)
//        {
//            Fade.i.OnFade(3);
//            round++;
//        }
//        #endregion

//        #region event5
//        if (round == 7 && time >= 13f)
//        {
//            GameManager.GM.SetScene(GameManager.NowScene.thirdScene);
//        }
//        #endregion

//    }

//    #region Set_End_Event
//    public void SetEvent(int _events)
//    {
//        if (!nowEvent)
//        {
//            events = _events;
//            startEvent = true;
//            nowEvent = true;
//        }
//    }

//    public void EndEvent()
//    {
//        if (isClearBathRoom && isFrontBad && isClearCabinet)
//        {
//            events = 0;
//            time = 0;
//            round = 0;
//            nowEvent = false;
//        }
//    }

//    public bool IsOffEvent()
//    {
//        return (!nowEvent && startEvent);
//    }
//    #endregion
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent2 : MonoBehaviour
{
    #region Singleton
    public static BattleEvent2 i;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    #region Set_Field
    public int events = 0;
    public int round = 0, choose = 0;
    public float time = 0f;

    public bool isStop = false;

    public bool nowEvent = false, startEvent = false, isFirst = false;

    [Header("---------------------State---------------------")]
    public bool isInBathRoom = false;
    public bool isFrontCabinet = false, isFrontBad = false,
        isClearBathRoom = false, isClearCabinet = false, hair = false,
        dry = false, top = false, bottom = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        events = 0;

        isInBathRoom = isFrontCabinet = isFrontBad = isClearBathRoom =
        isClearCabinet = hair = dry = top = bottom = false;
    }

    bool IsOffDialogue()
    {
        //���� ��簡 �����ٸ� true �ƴϸ� false ����.
        if (!DialogueManager.i.onDialogue)
        {
            return true;
        }
        return false;
    }

    public void SetChoose(int _choose)
    {
        choose = _choose;
    }

    private void Update()
    {
        switch (events)
        {
            case 1:
                Event1();
                break;

            case 2:
                Event2();
                break;

            case 3:
                EventLast();
                break;

            default:
                break;
        }
    }

    public void Event1()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        #region EventMain

        //first
        #region event0
        if (!isFirst)
        {
            if (round == 0 && time >= 0)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "����� ħ�뿡�� �Ͼ��.", 0.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                isStop = true;
                round++;
            }

            if (round == 1)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    round++;
                    isFirst = true;
                    isStop = false;
                }
            }
        }
        #endregion

        //hint dialogue
        #region event2
        if (round == 2 && time >= 2)
        {
            if (!isClearBathRoom)
            {
                if (!hair)
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "���� �Ӹ��� ���ƾ߰ڴ�.", 1f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                }
                else if (!dry)
                {
                    DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                    DialogueManager.i.OnTxt(50, "���� ���� �۾ƾ߰ڴ�.", 1f, new Color(255, 255, 255, 255));
                    DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                }
            }
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        //invisible next
        #region event3
        if (round == 4 && time >= 2.5f)
        {
            if(!hair)
                DialogueManager.i.OnBattleNext(new Vector2(4, 0), new Vector2(1, 1), GameManager.BattleSpriteState.hair);
            if(!dry)
            DialogueManager.i.OnBattleNext(new Vector2(-4, 0), new Vector2(1, 1), GameManager.BattleSpriteState.dry);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            //���â�� �������� Ȯ��
            if (IsOffDialogue())
            {
                round++;
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
            }
        }
        #endregion

        //calculate
        #region event4
        if (round == 6 && time >= 3f)
        {
            switch (choose)
            {
                case 21:
                    #region 21
                    if (hair)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "�Ӹ��� �̹� ���Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "����� �Ӹ��� ���Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        hair = true;
                    }
                    #endregion
                    break;

                case 22:
                    #region 22
                    if (hair)
                    {
                        if (dry)
                        {
                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                            DialogueManager.i.OnTxt(50, "����� �̹� ���⸦ �� �۾Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        }
                        else
                        {
                            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                            DialogueManager.i.OnTxt(50, "����� ���⸦ �۾Ҵ�.", 0.5f, new Color(255, 255, 255, 255));
                            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                            dry = true;
                        }
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "�켱 �Ӹ��� ���ƾ� �Ѵ�.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            //���â�� �������� Ȯ��
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
                time = 1.5f;
                round = 2;

                isClearBathRoom = (hair && dry);
                if (isClearBathRoom)
                {
                    EndEvent();
                    isFirst = false;
                }
            }
        }
        #endregion

        #endregion
    }

    public void Event2()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }


        #region EventMain

        //first
        #region event0
        if (!isFirst)
        {
            if (round == 0 && time >= 0)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "����� ȭ��ǿ��� ���� ĳ��� �տ� ����.", 0.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                isStop = true;
                round++;
            }

            if (round == 1)
            {
                if (IsOffDialogue())
                {
                    DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                    round = 2;
                    isFirst = true;
                    isStop = false;
                }
            }
        }
        #endregion

        //hint dialogue
        #region event2
        if (round == 2 && time >= 2)
        {
            if(!isClearCabinet)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "���� ���� �Ծ�� �ڴ�.", 1f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            }
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 1.5f;
                isStop = false;
            }
        }
        #endregion

        //invisible next
        #region event3
        if (round == 4 && time >= 2.5f)
        {
            if (!top)
                DialogueManager.i.OnBattleNext(new Vector2(0, 3), new Vector2(1, 1), GameManager.BattleSpriteState.top);

            if (!bottom)
                DialogueManager.i.OnBattleNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.BattleSpriteState.bottom);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            //���â�� �������� Ȯ��
            if (IsOffDialogue())
            {
                round++;
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
            }
        }
        #endregion

        //calculate
        #region event4
        if (round == 6 && time >= 3f)
        {
            switch (choose)
            {
                case 31:
                    #region 31
                    if (top)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "����� �̹� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "����� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        top = true;
                    }
                    #endregion
                    break;

                case 32:
                    #region 32
                    if (bottom)
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "����� �̹� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                    }
                    else
                    {
                        DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                        DialogueManager.i.OnTxt(50, "����� ���Ǹ� �Ծ���.", 0.5f, new Color(255, 255, 255, 255));
                        DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
                        bottom = true;
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            //���â�� �������� Ȯ��
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 300), new Vector2(1200, 250));
                isStop = false;
                time = 1.5f;
                round = 2;
                if (bottom && top)
                {
                    EndEvent();
                    isFirst = false;
                }
            }
        }
        #endregion

        #endregion
    }


    public void EventLast()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        #region event1
        if (round == 0 && time >= 0)
        {
            if (!isFirst)
            {
                BGMManager.i.SetBGMVolume(1);
                //Fade.i.OnFade(3);
            }
            round++;
        }

        if (round == 1)
        {
            BGMManager.i.SetBGMVolume(1 - time);
            if (1 - time <= 0)
            {
                time = 4f;
                round++;
            }
        }
        #endregion

        #region event2
        if (round == 2 && time >= 6)
        {
            GameManager.GM.nowBattle = false;
            if (!isFirst)
            {
                DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
                DialogueManager.i.OnTxt(50, "����� ���� �غ� ���´�.", 1.5f, new Color(255, 255, 255, 255));
                DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            }
            isStop = true;
            round++;
        }

        if (round == 3)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                time = 6f;
                isStop = false;
            }
        }
        #endregion

        #region event3
        if (round == 4 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 300));
            DialogueManager.i.OnTxt(90, "Stage2. ��غ�\nClear!!!", 0f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            BGMManager.i.SetEftVolume(1);
            BGMManager.i.EFTPlay(2);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                round++;
                isStop = false;
            }
        }
        #endregion

        #region event4
        if (round == 6 && time >= 7f)
        {
            Fade.i.OnFade(3);
            round++;
        }
        #endregion

        #region event5
        if (round == 7 && time >= 13f)
        {
            GameManager.GM.SetScene(GameManager.NowScene.thirdScene);
            round++;
        }
        #endregion

    }

    #region Set_End_Event
    public void SetEvent(int _events)
    {
        if (!nowEvent)
        {
            events = _events;
            startEvent = true;
            nowEvent = true;
            isStop = false;
        }
    }

    public void EndEvent()
    {
        events = 0;
        time = 0;
        round = 0;
        nowEvent = false;
        isStop = true;
        isClearCabinet = (bottom && top);
        /*if (isClearBathRoom && isFrontBad && isClearCabinet)
        {
            events = 0;
            time = 0;
            round = 0;
            nowEvent = false;
        }*/
    }

    public bool IsOffEvent()
    {
        return (!nowEvent && startEvent);
    }
    #endregion
}
