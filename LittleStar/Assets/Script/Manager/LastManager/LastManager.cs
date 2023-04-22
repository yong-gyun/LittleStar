using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastManager : MonoBehaviour
{
    public static LastManager i;

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

    public float time;

    public bool isStop;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        round = 0;
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }

        Intro();
        /*if (IsOffDialogue())
        {
            round--;
        }*/
    }

    bool IsOffDialogue()
    {
        if (!DialogueManager.i.onDialogue)
        {
            round++;
            return true;
        }
        return false;
    }

    void Intro()
    {
        #region Dialogue.1
        if (round == 0 && time >= 1)
        {
            BGMManager.i.BGMPlay(6);
            round++;
        }
        #endregion

        #region Dialogue.2
        if (round == 1 && time >= 17)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 0), new Vector2(1500, 500));
            DialogueManager.i.OnTxt(50, "������ :\n\t���, ���� : �ѿ��(19)\n\t�ý���, �̺�Ʈ, ��� : �ֿ���(17)", 3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -3f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 2)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.3
        if (round == 3 && time >= 20)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 100), new Vector2(1500, 700));
            DialogueManager.i.OnTxt(50, "���۱�\nEffect Audio : EffectLab\n" +
"intro backGroundMusic: �ƹ潺 ����Ʈ�� OZ�� ��������� ������ �뷡\n" +
"��Ʈ: https://fonts.cafe24.com�� ī�� �����\n" +
"Battle1: emotion�� ������ ���Ҹ� Ʈ�� ���ͽ�\n" +
"Battle2: a_hisa�� Rainy Waltz\n" +
"Battle3: Just Shapes & Beats�� T'ILL IT'S OVER\n" +
"Ending: ToTheMoon�� For River" +
"GameOver BGM: HEMIO���� ȣ���� �� ��", 8f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 4)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.4
        if (round == 5 && time >= 30)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 400));
            DialogueManager.i.OnTxt(80, "�Ұ���\n\t�ѿ�� : �� �ð� ���� �� �־�����....\n\t�ֿ��� : ���� ��´�.", 3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 6)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.5
        if (round == 7 && time >= 40)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "������ �ٻ� �׵鿡��", 1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 8)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.6
        if (round == 9 && time >= 42)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "�Ϸ簡 ������ �׵鿡��", 1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 10)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.7
        if (round == 11 && time >= 44)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "�׵��� ���� ������ �ʾ�����,", 1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 12)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
            }
        }
        #endregion

        #region Dialogue.8
        if (round == 13 && time >= 46)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "�׵��� ���� ������ �ʴ´�.", 1f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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

        #region Dialogue.9
        if (round == 15 && time >= 50)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 300));
            DialogueManager.i.OnTxt(100, "[����� ��� �����Ͽ���!]", 3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
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
        if (round == 17 && time >= 51)
        {
            DialogueManager.i.OnBase(true, new Vector2(0, 200), new Vector2(1500, 200));
            DialogueManager.i.OnTxt(50, "Thank you for Play!", 3f, new Color(255, 255, 255, 255));
            DialogueManager.i.OnDialogueNext(new Vector2(0, -4f), new Vector2(1, 1), GameManager.NextSpriteState.DialogueNext);
            isStop = true;
            round++;
        }

        if (round == 18)
        {
            if (IsOffDialogue())
            {
                DialogueManager.i.OnBase(false, new Vector2(0, 0), new Vector2(0, 0));
                isStop = false;
                Fade.i.OnFade(5);
                time = 0;
            }
        }
        #endregion

        #region Dialogue.10
        if (round == 19)
        {
            if(time >= 5)
            {
                BGMManager.i.BgmPause();
                BGMManager.i.SetBGMVolume(1);
                GameManager.GM.SetScene(GameManager.NowScene.firstScene);
                round++;
            }
            else
            {
                BGMManager.i.SetBGMVolume(1 - (time / 5.0f));
            }
        }
        #endregion
    }
}
