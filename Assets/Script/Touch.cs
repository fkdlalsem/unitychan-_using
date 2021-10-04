﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{

    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;
    //모션 스테이트의 ID 얻기
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Face_Happy", false);
        animator.SetBool("Face_Angry", false);
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);
        if(Input.GetMouseButtonDown(0))
        {
            //스크린에서 바라보고있는 곳에 레이를 쏜다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //재생중인지 확인
            if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
            		animator.SetBool("Motion_Idle", true);
            else
            		animator.SetBool("Motion_Idle", false);
            
            //맞앗으면 hit!
            if(Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                }
                else if (hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                }
            }
        }
    }
}
