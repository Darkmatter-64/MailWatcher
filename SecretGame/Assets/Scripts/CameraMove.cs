using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInputH;
    private float moveInputV;
    public float speed = 3f;
    public static bool OnLetter = false;
    public static bool CanOpenLetter = true;
    public static Image LetterUIImage;
    public static int TheDay = 1;
    public static SpriteRenderer ItemInHand;
    public SpriteRenderer FirstItem;
    public GameObject[] DeilyBox;
    public GameObject EscapeMenu;
    private bool IsGameStoped = false;

    public Animator ObjectAnimator;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        EscapeMenu.SetActive(false);
        TheDay = 1;
        ItemInHand = FirstItem;
        OnLetter = false;
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        DeilyBox[TheDay-1].SetActive(true);
        if (CanOpenLetter == true)
        {
            moveInputH = Input.GetAxis("Horizontal");
            moveInputV = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(moveInputH * speed, moveInputV * speed);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGameStoped == false)
            {
                CanOpenLetter = false;
                IsGameStoped = true;
                EscapeMenu.SetActive(true);
            }
            else
            {
                CanOpenLetter = true;
                IsGameStoped = false;
                EscapeMenu.SetActive(false);
            }
        }
    }

    public void Return()
    {
        CanOpenLetter = true;
        IsGameStoped = false;
        EscapeMenu.SetActive(false);
    }
    public void MainMenu()
    {
        Panel.SetActive(true);
        ObjectAnimator.Play("CanvasMaskCode2");
    }

}
