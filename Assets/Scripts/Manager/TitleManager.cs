// 타이틀 화면을 관리하는 코드

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // 새로 시작할지를 묻는 경고창
    public GameObject[] popUpDlg;
    // 팝업창 작동 여부 체크
    private bool popUpDlgOn = false;

    // 새로 시작 버튼을 누를 시
    public void NewStart()
    {
        if (popUpDlgOn == false)
        {
            //새로 시작할지를 묻는 경고창을 띄운다
            popUpDlg[0].gameObject.SetActive(true);
            //팝업창 활성화
            popUpDlgOn = true;
        }
    }

    // 새로 시작할지를 묻는 경고창이 뜰 때 확인을 누르면
    public void NewStartOK()
    {
        //프롤로그로 이동한다
        SceneManager.LoadScene("Intro");
    }
    
    // 새로 시작할지를 묻는 경고창이 뜰 때 취소를 누르면
    public void NewStartCancel()
    {
        // 경고창을 닫는다
        popUpDlg[0].gameObject.SetActive(false);
        // 팝업창 비활성화
        popUpDlgOn = false;
    }

    public void Update()
    {
        //플랫폼이 안드로이드인 상태에서
        if(Application.platform == RuntimePlatform.Android)
        {
            //팝업창이 꺼진 상태에서 뒤로가기 버튼을 누를 시
            if (popUpDlgOn == false && Input.GetKey(KeyCode.Escape))
            {
                //애플리케이션 종료
                Application.Quit();
            }
            else
            {
                NewStartCancel();
            }
        }
    }
    
    //나가기 버튼을 누를 시 게임 종료
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying
            = false;

#else
        Application.Quit();
#endif
    }

   
}
