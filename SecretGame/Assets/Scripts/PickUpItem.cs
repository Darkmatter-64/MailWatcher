using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PickUpItem : MonoBehaviour
{

    public bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public GameObject LetterText;
    public float HoldingTime;
    private bool OnCollisition;
    public SpriteRenderer sr;
    public Animator animator;
    public int animnumber = 0;
    public AudioSource audioSr;
    public AudioClip[] audioClips;
    public bool PlayedSound = false;
    private float pi1 = 0.8f;
    private float pi2 = 1.8f;

    public int CurrentDay = 1;
    // Start is called before the first frame update
    private void Start()
    {
        if (animnumber == 0)
        {
            animator.Play("LetterIdle");
        }
        else if (animnumber == 1)
        {
            animator.Play("LetterAppear1");
        }
        else if (animnumber == 2)
        {
            animator.Play("LetterAppear2");
        }
        else if (animnumber == 3)
        {
            animator.Play("LetterAppear3");
        }
        LetterText.SetActive(false);
        startPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Out")
        {
            OnCollisition = true;
            //dragging = false;
            //transform.position = startPosition;
        }
    }
    private void Update()
    {
        if (CurrentDay != CameraMove.TheDay)
        { 
            Destroy(gameObject);
        }
        if (dragging == true && CameraMove.CanOpenLetter == true)
        {
            if (HoldingTime > 0.09f && PlayedSound == false)
            {
                PlayedSound = true;
                audioSr.pitch = Random.Range(pi1, pi2);
                audioSr.PlayOneShot(audioClips[2]);

            }
            if (HoldingTime <= 1)
            {
                HoldingTime = HoldingTime + Time.deltaTime;
            }
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        if (dragging == false && OnCollisition == true)
        {
            OnCollisition = false;
            dragging = false;
            transform.position = startPosition;

        }
    }
    private void OnMouseDown()
    {
        PlayedSound = false;
        if (CameraMove.ItemInHand != sr)
        {
            sr.sortingOrder = CameraMove.ItemInHand.sortingOrder + 1;
            CameraMove.ItemInHand = sr;
        }
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            audioSr.pitch = Random.Range(pi1, pi2);
            audioSr.PlayOneShot(audioClips[0]);
            LetterText.SetActive(true);
            CameraMove.CanOpenLetter = false;
        }
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false && CameraMove.CanOpenLetter == true)
        {

            audioSr.pitch = Random.Range(pi1, pi2);
            audioSr.PlayOneShot(audioClips[1]);
            startPosition = transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-23,23));
        }
    }
    public void Clouse()
    {
        LetterText.SetActive(false);
        CameraMove.CanOpenLetter = true;
        audioSr.pitch = Random.Range(pi1, pi2);
        audioSr.PlayOneShot(audioClips[1]);
    }




}