// 인트로를 관할하는 코드

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // 페이드 패널
    public Image panel;
    // 처음 시간
    private float time = 0f;
    // 페이드 종료 시간
    private float overTime = 2f;
    // 페이드 인 ~ 아웃 작동

    // 글자 UI에 표시
    public Text txt;
    // 입력받을 글자
    private string typingTxt;

    // 시작 시 FadeFlow 실행
    public void Start()
    {
        StartCoroutine(FadeFlow());
    }

    //페이드 인 아웃 관할
    IEnumerator FadeFlow()
    {
        // 패널 활성화
        panel.gameObject.SetActive(true);
        // 컬러의 알파 값 변수 선언 후 panel로 초기화
        Color alpha = panel.color;
        // 알파 값이 1보다 작으면 반복
        while (alpha.a < 1f)
        {
            // 매 프레임 deltatime을 overTime 값으로 나누어 Time에 더해준다
            time += Time.deltaTime / overTime;
            // 0부터 1까지 부드럽게 변화를 준다
            alpha.a = Mathf.Lerp(0, 1, time);
            // alpha값을 매 프레임 이미지의 컬러 값에 대입한다
            panel.color = alpha;
            // 잠시 후 null 반환
            yield return null;
        }
        time = 0f;
        // 알파 값이 0보다 크면 반복
        while (alpha.a > 0f)
        {
            // 매 프레임 deltatime을 overTime 값으로 나누어 Time에 더해준다
            time += Time.deltaTime / overTime;
            // 1부터 0까지 부드럽게 변화를 준다
            alpha.a = Mathf.Lerp(1, 0, time);
            // alpha값을 매 프레임 이미지의 컬러 값에 대입한다
            panel.color = alpha;
            // 잠시 후 null 반환
            yield return null;
        }
        // 패널 비활성화
        panel.gameObject.SetActive(false);
        // 잠시 후 null 반환
        yield return null;
        // 글자를 출력하는 부분으로 넘어간다
        StartCoroutine(TypingTxt());
    }

    // 타자치듯 글자를 입력하는 효과 관할
    IEnumerator TypingTxt()
    {
        //2초 정도의 지연을 준다
        yield return new WaitForSeconds(1.5f);
        // PrologueTyping.txt를 불러온다
        TextAsset data = Resources.Load("PrologueTyping", typeof(TextAsset)) as TextAsset;
        // 불러온 글자를 한 줄씩 읽는다
        StringReader sr = new StringReader(data.text);
        // 글자를 한 줄씩 읽는다
        typingTxt = sr.ReadLine();
        // typingTxt가 null이 아닐 때 글자를 출력
        while (typingTxt != null)
        {
            //typingTxt에 저장된 글자의 수만큼 반복문을 돌린다
            for (int i = 0; i <= typingTxt.Length; i++)
            {
                // UI에 i의 값만큼 글자 표시
                txt.text = typingTxt.Substring(0, i);
                // 0.05초 간격으로 반복
                yield return new WaitForSeconds(0.02f);
            }
            break;
        }
        Invoke("GoMainPrologue", 3);
    }
    IEnumerator GoMainPrologue()
    {
        SceneManager.LoadScene("Prologue");
        return null;
    }
}
