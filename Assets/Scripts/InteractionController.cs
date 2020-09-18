using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{

    
    
    // StoryManager에 접근
    
    public Button nextDlgBtn;
    StoryManager SM;

    void Start()
    {
        // StroyManager을 사용 가능하게 함
        SM = FindObjectOfType<StoryManager>();
        
    }

    
    public void ClickNextBtn()
    {

        SM.ShowDialogue(nextDlgBtn.GetComponent<InteractionEvent>().GetDialogue());

    }
    
    
}
