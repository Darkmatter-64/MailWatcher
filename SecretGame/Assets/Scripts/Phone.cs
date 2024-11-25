using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject TextCloud;
    public Text TextFromPhone;
    public Text ShowNumber;
    public static string PhoneNumber = "";
    public GameObject AppearWhenUse;
    public GameObject DissapearWhenUse;
    public bool Day1Accepted = false;
    public bool Day4Accepted = false;
    public bool Day9Accepted = false;
    public static bool DaySpetial = false;
    [Header("Numbers")]
    public string[] Numbers;
    public float Timer = 0;
    public int IntTimer = 0;
    private bool ItWorks = false;
    public static bool StartWrite = false;
    private int NumberThatWas = 99999;
    private string TextToWrite = "";
    private string TextThatIsWriting;
    private bool SlashWorcked = false;
    [Header("PhoneStrings")]
    public string[] PhoneStringsDay1;
    public string[] PhoneStringsDay2;
    public string[] PhoneStringsDay3;
    public string[] PhoneStringsDay4;
    public string[] PhoneStringsDay5;
    public string[] PhoneStringsDay6;
    public string[] PhoneStringsDay7;
    public string[] PhoneStringsDay8;
    public string[] PhoneStringsDay9;
    public string[] CallsFromBoss;
    private string[] PhoneStrings;
    public bool IsThereSuchNumber;
    [Header("Pimpka")]
    public Sprite SpriteGray;
    public Sprite SpriteRed;
    public Sprite SpriteGreen;
    public SpriteRenderer srPimpka;
    private bool TelefonoWorkds;
    // Start is called before the first frame update
    void Start()
    {
        AppearWhenUse.SetActive(false);
        DissapearWhenUse.SetActive(true);
        TextCloud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraMove.TheDay == 1 && Day1Accepted == false)
        {
            DaySpetial = true;
        }
        else if (CameraMove.TheDay != 1 && Day1Accepted == false)
        {
            srPimpka.sprite = SpriteGray;
            DaySpetial = false;
            Day1Accepted = true;
        }
        if (CameraMove.TheDay == 4 && Day4Accepted == false)
        {
            DaySpetial = true;
        }
        else if (CameraMove.TheDay != 4 && Day4Accepted == false)
        {
            srPimpka.sprite = SpriteGray;
            DaySpetial = false;
            Day4Accepted = true;
        }
        if (CameraMove.TheDay == 9 && Day9Accepted == false)
        {
            DaySpetial = true;
        }
        else if (CameraMove.TheDay != 9 && Day9Accepted == false)
        {
            srPimpka.sprite = SpriteGray;
            DaySpetial = false;
            Day9Accepted = true;
        }

        if (DaySpetial == true)
        {
            srPimpka.sprite = SpriteGreen;
        }


        if (CameraMove.TheDay == 1)
        {
            PhoneStrings = PhoneStringsDay1;
        }
        else if (CameraMove.TheDay == 2)
        {
            PhoneStrings = PhoneStringsDay2;
        }
        else if (CameraMove.TheDay == 3)
        {
            PhoneStrings = PhoneStringsDay3;
        }
        else if (CameraMove.TheDay == 4)
        {
            PhoneStrings = PhoneStringsDay4;
        }
        else if (CameraMove.TheDay == 5)
        {
            PhoneStrings = PhoneStringsDay5;
        }
        else if (CameraMove.TheDay == 6)
        {
            PhoneStrings = PhoneStringsDay6;
        }
        else if (CameraMove.TheDay == 7)
        {
            PhoneStrings = PhoneStringsDay7;
        }
        else if (CameraMove.TheDay == 8)
        {
            PhoneStrings = PhoneStringsDay8;
        }
        else if (CameraMove.TheDay == 9)
        {
            PhoneStrings = PhoneStringsDay9;
        }
        ShowNumber.text = PhoneNumber;

        if (PhoneNumber.Length > 4)
        {
            PhoneNumber = "";
        }
        if (StartWrite == true)
        {
            if (SlashWorcked == false)
            {
                Timer += Time.deltaTime * 23f;
            }
            IntTimer = (int)Timer;
            if (IntTimer < TextToWrite.Length && NumberThatWas != IntTimer && TextToWrite[IntTimer] != '/')
            {
                TextFromPhone.text += TextToWrite[IntTimer];
                NumberThatWas = IntTimer;
                SlashWorcked = false;
            }
            else if (IntTimer == TextToWrite.Length)
            { 
                StartCoroutine(WaitSomeTime());
            }

            if (IntTimer < TextToWrite.Length && NumberThatWas != IntTimer && TextToWrite[IntTimer] == '/' && SlashWorcked == false)
            {
                SlashWorcked = true; 
                NumberThatWas = IntTimer;
                StartCoroutine(WaitToClearTime());
            }
        }


    }
    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(1f);
        TextFromPhone.text += "";
        StartWrite = false;
        NumberThatWas = 99999;
        Timer = 0;
        IntTimer = 0;
        TextCloud.SetActive(false);
        AppearWhenUse.SetActive(false);
        DissapearWhenUse.SetActive(true);
        CameraMove.CanOpenLetter = true;
        TelefonoWorkds = false;
        srPimpka.sprite = SpriteGray;
    }
    private IEnumerator WaitToClearTime()
    {
        yield return new WaitForSeconds(1f);
        TextFromPhone.text = "";
        Timer += 1;
    }


    public void ClousePhone()
    {
        TextFromPhone.text += "";
        StartWrite = false;
        NumberThatWas = 99999;
        Timer = 0;
        IntTimer = 0;
        TextCloud.SetActive(false);
        AppearWhenUse.SetActive(false);
        DissapearWhenUse.SetActive(true);
        CameraMove.CanOpenLetter = true;
        TelefonoWorkds = false;
        srPimpka.sprite = SpriteGray;
    }
    private void OnMouseDown()
    {
        if (PhoneNumber.Length == 4 && DaySpetial == false)
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i].Equals(PhoneNumber) && i < Numbers.Length)
                {
                    CameraMove.CanOpenLetter = false;
                    ItWorks = true;
                    StartWrite = true;
                    //TextFromPhone.text = PhoneStringsDay1[i];
                    TextToWrite = PhoneStrings[i];
                    Debug.Log(TextToWrite);
                    PhoneNumber = "";
                    TextCloud.SetActive(true);
                    AppearWhenUse.SetActive(true);
                    DissapearWhenUse.SetActive(false);
                    TextFromPhone.text = "";
                    TelefonoWorkds = true;
                    srPimpka.sprite = SpriteGreen;
                }
                else if (i == Numbers.Length -1 && TelefonoWorkds == false)
                {
                    PhoneNumber = "";
                    StartCoroutine(RedPimpka());
                }
            }

        }
        if (DaySpetial == true)
        {
            if (CameraMove.TheDay == 1)
            {
                Day1Accepted = true;
                TextToWrite = CallsFromBoss[0];
            }
            else if (CameraMove.TheDay == 4)
            {
                TextToWrite = CallsFromBoss[1];
                Day4Accepted = true;
            }
            else if (CameraMove.TheDay == 9)
            {
                TextToWrite = CallsFromBoss[2];
                Day9Accepted = true;
            }
            DaySpetial = false;
            CameraMove.CanOpenLetter = false;
            ItWorks = true;
            StartWrite = true;
            Debug.Log(TextToWrite);
            PhoneNumber = "";
            TextCloud.SetActive(true);
            AppearWhenUse.SetActive(true);
            DissapearWhenUse.SetActive(false);
            TextFromPhone.text = "";
            TelefonoWorkds = true;
            srPimpka.sprite = SpriteGreen;
        }
    }
    private IEnumerator RedPimpka()
    {
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteRed;
        yield return new WaitForSeconds(0.1f);
        srPimpka.sprite = SpriteGray;
    }

}