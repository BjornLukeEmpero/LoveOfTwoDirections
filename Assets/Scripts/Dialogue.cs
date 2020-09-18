// 대화의 진행을 담당하는 코드

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [Tooltip("말하는 사람")]
    // 말하는 사람
    public string talkName;
    [Tooltip("대사")]
    // 대사
    public string[] contexts;
}

[System.Serializable]
public class DialogueEvent
{
    // 어떤 이벤트인지 이름을 정한다
    //public string name;
    
    // 대사를 추출해 꺼내온다
    public Vector2 line;
    // 
    public Dialogue[] dialogue;
}
