using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondManager : MonoBehaviour
{
    public static SecondManager i;

    void Awake()
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

    [SerializeField]
    GameObject Player;

    public float time;
    public bool isStop;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        round = 3;
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�ð��� �帣�� �ð� �帣�� �ϱ�
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        Main();

    }
    bool IsOffDialogue()
    {
        //���� ��簡 �����ٸ� true �ƴϸ� false ����.
        if (!DialogueManager.i.onDialogue)
        {
            round++;
            return true;
        }
        return false;
    }

    void Main()
    {
        if (round== 3)
        {
            BGMManager.i.SetBGMVolume(0.5f);
            BGMManager.i.BGMPlay(0);
            round++;
        }

        #region Dialogue.1
        if (round == 4 && time >= 2)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));
            DialogueManager.i.OnTxt(50, "�簨�������� ��Ҹ��� ����´�.", 2, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 5)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
                time = 4;
            }
        }
        #endregion

        #region Dialogue.2
        if (round == 6 && time >= 5.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(-350, 400), new Vector2(500, 200));
            DialogueManager.i.OnTxt(50, "2�� ��ħ��ȣ!",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(-3f, 1.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 7)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.3
        if (round == 8 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�׸��� ���� ���� ���ȴ�.",
                1.8f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 9)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.4
        if (round == 10 && time >= 7)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 25f), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�Ӹ��� ���� ��ȿ� ���̽�\n�簨 �����Բ��� �����ϽŴ�.",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -1.5f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 11)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                time = 6.5f;
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.5
        if (round == 12 && time >= 7.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(-300, 20), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "[�簨 ������]\n�Ͼ�� � �غ��ض�.",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(-2.5f, -1.5f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 13)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.6
        if (round == 14 && time >= 8f)
        {
            BGMManager.i.EFTPlay(3);
            round++;
        }
        #endregion

        #region Dialogue.7
        if (round == 15 && time >= 9.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(-300, 20), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�׸��� �����̴�.",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(-2.5f, -1.5f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 16)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.8
        if (round == 17 && time >= 10f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "����� �Ͼ �ڰ������� �ϰ�,",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 18)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.9
        if (round == 19 && time >= 10.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�ð��� ����,",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 20)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.10
        if (round == 21 && time >= 11f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, -200), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�ٽ� ������...",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 22)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
                time = 8.5f;
            }
        }
        #endregion

        #region Dialogue.11
        if (round == 23 && time >= 11.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, -200), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "��...",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 24)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.12
        if (round == 25 && time >= 12f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, -200), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "������ �����..",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 26)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.13
        if (round == 27 && time >= 13f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, -100), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "����� �ڵ������� �ð��� Ȯ���ߴ�.",
                2f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -3), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 28)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.15
        if (round == 29 && time >= 14f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(70, "8��",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 30)
        {
            if (IsOffDialogue())
            {
                BGMManager.i.BgmPause();
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.16
        if (round == 31 && time >= 14.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�̷� ��ģ...",
                2f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 32)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.17
        if (round == 33 && time >= 15f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "�ٽ� ������ ���۵Ǿ���.",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 34)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.18
        if (round == 35 && time >= 17f)
        {
            //Ÿ���� ���� ����
            DialogueManager.i.SetTypinigSound(1);

            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 300));
            DialogueManager.i.OnTxt(90, "����2.\n��غ�.",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -1f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 36)
        {
            if (IsOffDialogue())
            {
                //Ÿ���� ���� ����
                DialogueManager.i.SetTypinigSound(0);

                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;

                //�� ����
                GameManager.GM.SetScene(GameManager.NowScene.secondBattle);
                round++;
            }
        }
        #endregion
    }
}
