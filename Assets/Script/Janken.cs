using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janken : MonoBehaviour
{
    bool flagJanken = false;
    int modeJanken = 0;

    public AudioClip voiceStart;
    public AudioClip voicePon;
	public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;
    const int JANKEN = -1;
    const int GOO    = 0;
    const int CHOKI  = 1;
    const int PAR    = 2;
    const int DRAW   = 3;
    const int WIN    = 4;
    const int LOOSE  = 5;
    
    private Animator animator;
    private AudioSource univoice;
    int myHand;
    int unityHand;
    int flagResult;
    int[,] tableResult = new int[3,3];
	float waitDelay;
    void UnityChanAction (int act)  //이벤트 함수
    {
        switch(act)
            {
                case JANKEN:
                    animator.SetBool("Jacken",true);
                    univoice.clip = voiceStart;
                    break;
                case GOO:
                    animator.SetBool("Goo",true);
                    univoice.clip = voiceGoo;
                    break;
                case CHOKI:
                    animator.SetBool("Choki",true);
                    univoice.clip = voiceChoki;
                    break;  
                case PAR:
                    animator.SetBool("Par", true);
                    univoice.clip = voicePar;
                    break;
                case DRAW:
                    Animator.SetBool("Aiko", true);
                    univoice.clip = voiceDraw;
                    break;
                case WIN:
                    animator.SetBool("Win", true);
                    univoice.clip = voiceWin;
                    break;
                case LOOSE:
                    animator.SetBool("Loose", true);
                	univoice.clip = voiceLoose;
                    break;
            }
        univoice.Play();
    }
    private void OnGUI() {
        if(!flagJanken)
        {
            flagJanken = (GUI.Button(new Rect(10, Screen.height - 110, 100, 100), "묵찌빠"));
        }

        if(modeJanken == 1)
        {
            if(GUI.Button(new Rect(Screen.width/2 -50 -120, Screen.height -110, 100, 100), "묵"))
            {
                myHand = GOO;
                modeJanken++;
            }
            if(GUI.Button(new Rect(Screen.width/2 -50, Screen.height -110, 100, 100), "찌"))
            {
                myHand = CHOKI;
                modeJanken++;
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 50 + 120, Screen.height - 110, 100, 100), "빠"))
            {
                myHand = PAR;
                modeJanken++;
            } 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
        // 결과 테이블 미리 결정 [유니티짱, 플레이어]
        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;
        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;
        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;
    }

    // Update is called once per frame
    void Update()
    {
        //클릭하면 true 묵찌빠 상태이면
        if (flagJanken)
        {
            //게임 모드에 따라
            switch(modeJanken)   
            {
                case 0:  //묵찌빠 시작
                    break;
                case 1:  //입력 대기
                    break;
                case 2:  //판정
                    break;
                case 3:  //결과
                    break;
                default:  //초기화
                    break;
            }
        }
    }
}
