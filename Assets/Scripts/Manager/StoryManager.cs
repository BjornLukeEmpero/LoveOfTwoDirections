// 스토리의 진행을 총괄하는 코드

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryManager : MonoBehaviour
{
    // 페이드 인 아웃 관할
    [Header("페이드 인 아웃 관할")]
    // 페이드 패널
    public Image introPanel;
    // 처음 시간
    private float time = 0f;
    // 페이드 종료 시간
    private float overTime = 2f;
    // 페이드 인 ~ 아웃 작동

    // 대화 관할
    [Header("대화 관할")]
    // 말하는 사람 표시
    [SerializeField] public Text talkNameTxt;
    // 대사 표시
    [SerializeField] public Text contextsTxt;
    // 대사 출력 스크린 화면
    [SerializeField] public GameObject go_Dialogue;

    //DialogueEvent dialogue;


    Dialogue[] dialogues;



    // 캐릭터 관할
    [Header("캐릭터 관할")]
    // 캐릭터 1 표시
    public string[] chara1;
    // 캐릭터 2 표시
    public string[] chara2;
    // 캐릭터 3 표시
    public string[] chara3;





    // 대화 중인지 여부를 체크한다
    private bool isDialogue = false;
    // theIC가 InteractionController에 접근하게 해줌
    InteractionController theIC;


    // 시작할 시
    public void Start()
    {
        // theIC를 InteractionController에 접근
        theIC = FindObjectOfType<InteractionController>();
        // 페이드 인 아웃 실행
        StartCoroutine(IntroFadeFlow());
    }

    IEnumerator IntroFadeFlow()
    {
        // 패널 활성화
        introPanel.gameObject.SetActive(true);
        // 컬러의 알파 값 변수 선언 후 introPanel로 초기화
        Color alpha = introPanel.color;
        // 알파 값이 1보다 적으면 반복
        while (alpha.a < 1f)
        {
            // 매 프레임 deltatime을 overTime값으로 나누어 Time에 더해준다
            time += Time.deltaTime / overTime;
            // 0부터 1까지 부드럽게 변화를 준다
            alpha.a = Mathf.Lerp(0, 1, time);
            // alpha값을 매 프레임 이미지의 컬러 값에 대입한다
            introPanel.color = alpha;
            // 잠시 후 null 반환
            yield return null;
        }
        time = 0f;

        while (alpha.a > 0f)
        {
            // 매 프레임 deltatime을 overTime 값으로 나누어 Time에 더해준다
            time += Time.deltaTime / overTime;
            // 1부터 0까지 부드럽게 변화를 준다
            alpha.a = Mathf.Lerp(1, 0, time);
            // alpha값을 매 프레임 이미지의 컬러 값에 대입한다
            introPanel.color = alpha;
            // 잠시 후 null 반환
            yield return null;
        }
        // 패널 비활성화
        introPanel.gameObject.SetActive(false);
        // 잠시 후 Null 반환 
        yield return null;


        // 1초 후 ShowDialogue 실행
        //StartCoroutine(ShowDialogue());
    }

    // 대화창 실행 시 글자 출력 공백으로 초기화
    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        // 대화를 공백으로 초기화
        contextsTxt.text = "";
        // 대사를 말하는 인물의 이름을 초기화
        talkNameTxt.text = "";        
        // dialogues에는 p_dialogues의 내용이 저장된다
        dialogues = p_dialogues;
        // 밑의 대사창의 활성화해 보이게 한다
        SettingUI(true);
    }

    private void SettingUI(bool p_flag)
    {
        go_Dialogue.SetActive(p_flag);
    }

}
