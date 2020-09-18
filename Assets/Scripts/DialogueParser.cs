// CSV 파일을 불러와 대사와 UI에 반영시키는 코드

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;
 
public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        // 대사 목록 생성
        List<Dialogue> dialogueList = new List<Dialogue>();
        // CSV 파일을 가져온다
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);
        // 한 줄씩 띄워서 데이터를 읽는다
        string[] data = csvData.text.Split(new char[] { '\n' });

        for(int i = 1; i < data.Length; i++)
        {
            // 콤마 단위로 쪼개기 위한 장치
            string[] row = data[i].Split(new char[]{ ','});

            // 대사 리스트 생성
            Dialogue dialogue = new Dialogue();

            //현재 말하는 캐릭터의 이름을 넣는다
            dialogue.talkName = row[2];
            
            //List<string> talkNameList = new List<string>();
            // string로 입력되는 대사를 List로 바꾼다
            List<string> contextList = new List<string>();

            
            
            
            
            
            // 대사 출력
            do
            {
                
                // 대사 추가
                contextList.Add(row[3]);
                Debug.Log(row[3]);
                // 추가된 인덱스의 값이 data의 길이보다 짧다면
                if (++i < data.Length)
                {
                    // 콤마 단위로 쪼개기 위한 장치 
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    //해당 반복문을 빠져나온다
                    break;
                } 
            }
            // 다음 값이 공백이 아님
            while (row[0].ToString() != "");
            
            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }
        // dialogueList에 배열로 변환시켜 반환
        return dialogueList.ToArray();
    }
    


    /* Second
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static List<Dictionary<string, object>> Read(string CsvFileName)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(CsvFileName) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                
                
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
    */
}
