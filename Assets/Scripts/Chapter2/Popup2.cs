using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Popup2 : MonoBehaviour
{ 
    public static Popup2 instance;
    private Animator animator;
    public Queue<PrologueBase.Info> prologueInfo;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (instance != null)
        {
        }
        else
        {
            instance = this;
        }
        
    }

    public void Start()
    {
        //audio = GetComponent<AudioSource>();
        GameLoad(); 
    }

    //로드/세이브
    public void GameSave(){
        PlayerPrefs.SetInt("LoadId2",DialogueManager2.instance.thisId);
        PlayerPrefs.Save(); 
    }

    public void GameLoad(){
        if (!PlayerPrefs.HasKey("LoadId2")){
            if (PlayerPrefs.HasKey("Department")){
                PlayerPrefs.SetInt("LoadId2", 0);
            }
            return;
        } 
        int thisId = PlayerPrefs.GetInt("LoadId2");
        DialogueManager2.instance.thisId = thisId;
    }
   
   //데이터 초기화 = 새로시작
    public void newGame(){
        PlayerPrefs.DeleteKey("LoadId2");
        PlayerPrefs.DeleteKey("Department");
    }

   public void Close()
   {
       StartCoroutine(CloseAfterDelay());
   }

   private IEnumerator CloseAfterDelay()
   {
       animator.SetTrigger("close");
       yield return new WaitForSeconds(0.5f);
       gameObject.SetActive(false);
       animator.ResetTrigger("close");
   }

   public void GameOver(){
       PlayerPrefs.DeleteKey("LoadId2");
   }

   public void GameOverLoad(){
       SceneManager.LoadScene(3);
   }

}
