// 모든 데이터를 dialogueDic에 저장한다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    // 데이터베이스를 언제 어디서든 쉽게 참조할 수 있게 바꾼다
    public static DatabaseManager instance;
    // csv 파일의 이름을 지정한다
    [SerializeField] string csv_FileName;
    // int 형태로 Dialogue를 찾는다
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();
    // 데이터가 저장되었는가와 아닌가를 확인한다
    public static bool isFinish = false;

    // 시작하기 전에 실행된다
    private void Awake()
    {
        // instance값이 null일 시
        if(instance == null)
        {
            // instance에 자기 자신을 넣는다
            instance = this; 
            // DatabaseManager과 Parser는 같은 객체에 넣어 준다
            DialogueParser theParser = GetComponent<DialogueParser>();
            // CSV 파일명을 받아 dialogue 배열에 넣는다
            Dialogue[] dialogues = theParser.Parse(csv_FileName);
            // 1번째 데이터부터 넣게 하는 장치
            for(int i = 0; i < dialogues.Length; i++)
            {
                // 먼저 0번째가 아니라 1번째 데이터를 찾게 해 대사를 i번째 dialogueDic에 넣어준다
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            //위의 For문이 끝나면 isFinish는 True값을 가진다.
            isFinish = true;
        }
        

       /*List<Dictionary<string, object>> data = DialogueParser.Read("CsvFileName");
       for (var i = 0; i < data.Count; i++)
       {
            // StroyManager의 변수에 접근
            StoryManager sm = new StoryManager();
            sm.talkName = (string)data[i]["talkName"];

            
            Debug.Log(data[i]["nodeID"]);
            Debug.Log(data[i]["destNodeID"]);
            Debug.Log(data[i]["talkName"]);
            Debug.Log(data[i]["contexts"]);
            Debug.Log(data[i]["chara1"]);
            Debug.Log(data[i]["chara2"]);
            Debug.Log(data[i]["chara3"]);
            Debug.Log(data[i]["ageName"]);
            Debug.Log(data[i]["episodeName"]);
            Debug.Log(data[i]["backgroundName"]);
            Debug.Log(data[i]["background"]);
            Debug.Log(data[i]["bgm"]);
            Debug.Log(data[i]["sfx"]);
       }
       */
        

    }
    
    // 대사가 시작되는 라인과 끝나는 라인을 기준으로 꺼내는 대화 내용의 줄을 정한다
    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        // Dialogue의 내용을 dialogueList에 새로 넣는다
        List<Dialogue> dialogueList = new List<Dialogue>();
        // 대사 내용을 꺼내는 코드
        for (int i = 0; i < _EndNum -  _StartNum; i++)
        {
            // 첫번째부터 i번째까지의 내용을 dialogueDic에서 꺼내 dialogueList에 추가한다
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }
        // dialogueList의 내용을 배열로 만들어 반환한다
        return dialogueList.ToArray();
    }
    
}
