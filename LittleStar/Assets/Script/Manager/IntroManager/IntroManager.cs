using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public static IntroManager i;

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
        round = 4;
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

        //���� ��縦 ����� �Ǹ� ���� ��縦 ��� �غ�
        if (IsOffDialogue())
        {
            //���� ����(�� �Լ����� �Ǽ���)
            round--;

            Intro();
        }

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

    void Intro()
    {

        #region Dialogue.2
        if (round == 4 && time >= 4)
        {
            //���â ����(�ʼ�, ��簡 ���â ��ġ���� ������)(���â ���?, ��ġ, ũ��)
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1200, 250));

            //��� ����(��Ʈ ������, ����, Ÿ���� �ð�, ����)
            DialogueManager.i.OnTxt(50, "�簨�������� ��ۼҸ���\n����ϰ� ����´�.", 2f, new Color(255, 255, 255, 255));

            //Nextâ ���� (��ġ, ũ��, Ÿ��)
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);

            //�ð��� �����
            isStop = true;

            //���� �����
            round++;
        }

        if (round == 5)
        {
            //���â�� �������� Ȯ��
            if (IsOffDialogue())
            {
                //���â ���ֱ� (���� �ڵ����� ����)
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));

                //�ð��� �귯��
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.3
        if (round == 6 && time >= 5.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(-400, 400), new Vector2(500, 230));
            DialogueManager.i.OnTxt(50, "[���]\n��ħ��ȣ! ��ħ��ȣ!",
                1.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(-2.5f, 1.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.4
        if (round == 8 && time >= 6.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(900, 230));
            DialogueManager.i.OnTxt(50, "����� ������ �帰 ���� ���� ���.",
                2.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -2), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 9)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));

                //�ʵ� ����
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(1.7f, 1.7f));

                Player.transform.position = new Vector2(0, 0);
                isStop = false;
            }
        }
        #endregion


        //�ʵ� ũ�� ���� �̺�Ʈ1
        #region Dialogue.5
        if (round == 10 && time >= 7f)
        {
            float scale = (2 - (time - 7f));
            FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
            if (scale <= 1)
            {
                scale = 1;
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
                time = 7f;
                round++;
            }
        }
        #endregion


        //�ʵ� ũ�� ���� �̺�Ʈ2
        #region Dialogue.6
        if (round == 11 && time >= 7.5f)
        {
            float scale = (1 + (time - 7.5f));
            FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
            if (scale >= 1.8f)
            {
                scale = 1.8f;
                FieldManager.FieldMng.OnField(true, new Vector2(0, 0), new Vector2(scale, scale));
                time = 7.5f;
                round++;
                DialogueManager.i.OnDialogueNext(new Vector2(0, 0), new Vector2(1, 1), GameManager.NextSpriteState.Next);
            }
        }

        if (round == 12)
        {
            if (IsOffDialogue())
            {
                time = 8;
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.7
        if (round == 13 && time >= 8f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "�̰��� GBSW ����б�.",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 14)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.8
        if (round == 15 && time >= 8.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "����� �̰��� �л��̴�.",
                1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.9
        if (round == 17 && time >= 9f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "�׸��� ���� ����� �����߰�,\nħ�뿡�� �Ͼ �غ� �� ��, ��� �ؾ��Ѵ�.",
                4f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.10
        if (round == 19 && time >= 11f)
        {
            BGMManager.i.BgmPause();
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "�׶� \"�����\"�� ��Ÿ����.",
                2.5f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -1.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.11
        if (round == 21 && time >= 11.5f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 100), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "�� \"�����\" �̶�� ���� ��ġ �̺Ұ� ���Ƽ�,",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -0.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 22)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.12
        if (round == 23 && time >= 12f)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 300), new Vector2(1500, 230));
            DialogueManager.i.OnTxt(50, "�ѹ� ������ �Ǹ�, ���������� ����� �� �̴�.",
                3.3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, 0.8f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.13
        if (round == 25 && time >= 14f)
        {
            //Ÿ���� ���� ����
            DialogueManager.i.SetTypinigSound(1);

            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 300));
            DialogueManager.i.OnTxt(90, "����1.\n�̺Ұ� �����.",
                3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0f, -2f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 26)
        {
            if (IsOffDialogue())
            {
                //Ÿ���� ���� ����
                DialogueManager.i.SetTypinigSound(0);

                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;

                //�� ����
                GameManager.GM.SetScene(GameManager.NowScene.introBattle);
            }
        }
        #endregion
    }
}
