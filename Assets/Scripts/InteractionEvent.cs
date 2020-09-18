using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    // Dialogue에 접근해 DialogueEvent 클래스 조작
    [SerializeField] DialogueEvent dialogue;

    // 몇 번째 줄부터 몇 번째 줄까지의 데이터를 꺼내온다
    public Dialogue[] GetDialogue()
    {
        // dialogue.dialogues에 DatabaseManager에 있는 데이터를 줄에 따라 대입한다
        dialogue.dialogue = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        // dialogue.dialogues에 데이터 반환
        return dialogue.dialogue;
    }

}
