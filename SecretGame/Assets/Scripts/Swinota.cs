using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinota : MonoBehaviour
{
    public bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public float HoldingTime;
    private bool OnCollisition;
    public SpriteRenderer sr;
    public Animator animator;
    public AudioSource audioSr;
    public AudioClip audioClips;

    public int CurrentDay = 1;
    // Start is called before the first frame update
    private void Start()
    {
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
        if (dragging == true && CameraMove.CanOpenLetter == true)
        {
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
        audioSr.PlayOneShot(audioClips);
        animator.Play("SwinotaPress");
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
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false && CameraMove.CanOpenLetter == true)
        {
            startPosition = transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-23, 23));
        }
    }

}