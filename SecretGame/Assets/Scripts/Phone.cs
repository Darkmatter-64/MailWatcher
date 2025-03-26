using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public float speed = 23f;
    public GameObject TextCloud;
    public GameObject AnsweCloud;
    public TMP_InputField TheTextNumber;
    public bool AnsweredDay4 = false;
    public int AnswerDay4;
    public bool AnsweredDay8 = false;
    public int AnswerDay8;
    public Text TextFromPhone;
    public Text ShowNumber;
    public static string PhoneNumber = "";
    public GameObject AppearWhenUse;
    public GameObject DissapearWhenUse;
    public bool Day1Accepted = false;
    public bool Day4Accepted = false;
    public bool Day5Accepted = false;
    public bool Day8Accepted = false;
    public bool Day9Accepted = false;
    public static bool DaySpecial = false;
    public bool GoodEnding = false;
    public GameObject ShadowBody;
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
    [Header("Voices")]
    public AudioClip[] audioClips;
    public AudioSource audioSr;
    public AudioSource audioSr2;
    public bool FemaleVoice = false;
    public bool AlreadyDidSound = false;
    [Header("SpetialItems")]
    public GameObject CherdakMessage;
    public GameObject[] Pigs;
    public GameObject[] Ducks;

    // Start is called before the first frame update
    void Start()
    {
        audioSr.mute = true;
        ShadowBody.SetActive(false);
        AnsweCloud.SetActive(false);
        AppearWhenUse.SetActive(false);
        DissapearWhenUse.SetActive(true);
        TextCloud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Improving the flow
        if (PhoneNumber.Length > 4)
        {
            FemaleVoice = true;
        }
        else // PhoneNumber.Length <= 4
        {
            FemaleVoice = false;
        }


        Dictionary<int, bool> acceptedDict = new Dictionary<int, bool>();
        acceptedDict.add(1, Day1Accepted);
        acceptedDict.add(4, Day4Accepted);
        acceptedDict.add(5, Day5Accepted);
        acceptedDict.add(8, Day8Accepted);
        acceptedDict.add(9, Day9Accepted);

        int[] days = { 1, 4, 5, 8, 9 };

        foreach(int d in days)
        {
            if (!acceptedDict[d])
            {
                if (CameraMove.TheDay == d)
                {
                    DaySpecial = true;
                }
                else
                {
                    srPimpka.sprite = SpriteGray;
                    DaySpecial = false;
                    Day1Accepted = true;
                }
            }
        }

        
        

        if (DaySpecial == true)
        {
            audioSr.mute = false;
            srPimpka.sprite = SpriteGreen;
        }
        else
        {
            audioSr.mute = true;
        }


        if (AnswerDay4 == 17)
        {
            CherdakMessage.SetActive(false);
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
        else if (CameraMove.TheDay == 8)
        {
            PhoneStrings = PhoneStringsDay8;
        }
        else if (CameraMove.TheDay == 9)
        {
            if (AnswerDay8 == 26)
            {
                SceneManager.LoadScene("GoodEnding");
            }
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
                Timer += Time.deltaTime * speed;
            }
            IntTimer = (int)Timer;
            if (IntTimer < TextToWrite.Length && NumberThatWas != IntTimer && TextToWrite[IntTimer] != '/')
            {
                TextFromPhone.text += TextToWrite[IntTimer];
                NumberThatWas = IntTimer;
                SlashWorcked = false;
                if (FemaleVoice == true && TextToWrite[IntTimer] != ' ' && speed != 200)
                {
                    audioSr2.PlayOneShot(audioClips[2]);
                }
                else if (FemaleVoice == false && TextToWrite[IntTimer] != ' ' && speed != 200)
                {
                    audioSr2.PlayOneShot(audioClips[3]);
                }
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
        if (CameraMove.TheDay == 4 && TextToWrite == PhoneStringsDay4[0] && AnsweredDay4 == false)
        {
            AnsweCloud.SetActive(true);
        }
        else if (CameraMove.TheDay == 8 && TextToWrite == PhoneStringsDay8[0] && AnsweredDay8 == false)
        {
            AnsweCloud.SetActive(true);
        }
        else
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
            DaySpecial = false;
            speed = 23f;
            if (CameraMove.TheDay == 9)
            {
                ShadowBody.SetActive(true);
            }
            StartCoroutine(SoudClousePhone());
        }
    }
    private IEnumerator WaitToClearTime()
    {
        yield return new WaitForSeconds(1f);
        TextFromPhone.text = "";
        Timer += 1;
        speed = 23f;
    }

    public void SkipText()
    {
        speed = 200f;
    }

    public void AcceptHouseNumber()
    {
        if (CameraMove.TheDay == 4)
        {
            PhoneStringsDay4[0] = CallsFromBoss[6];
            AnsweredDay4 = true;
            AnswerDay4 = Int32.Parse(TheTextNumber.text);
        }
        if (CameraMove.TheDay == 8)
        {
            PhoneStringsDay8[0] = CallsFromBoss[6];
            AnsweredDay8 = true;
            AnswerDay8 = Int32.Parse(TheTextNumber.text);
        }
        TheTextNumber.text = "";
        ClousePhone();
    }
    public void ClousePhone()
    {
        audioSr2.PlayOneShot(audioClips[1]);
        DaySpecial = false;
        AnsweCloud.SetActive(false);
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
        if (CameraMove.TheDay == 9)
        {
            ShadowBody.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (PhoneNumber.Length == 4 && DaySpecial == false)
        {
            if (PhoneNumber == "1667")
            {
                Pigs[CameraMove.TheDay + 1].SetActive(true);
            }
            if (PhoneNumber == "1776")
            {
                Ducks[CameraMove.TheDay + 1].SetActive(true);
            }
            audioSr2.PlayOneShot(audioClips[0]);
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
        if (DaySpecial == true)
        {
            audioSr2.PlayOneShot(audioClips[0]);
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
            else if (CameraMove.TheDay == 5)
            {
                if (AnsweredDay4 == false)
                {
                    TextToWrite = CallsFromBoss[2];
                }
                else if (AnswerDay4 != 17 && AnswerDay4 != 26)
                {
                    TextToWrite = CallsFromBoss[3];
                }
                else if (AnswerDay4 == 17)
                {
                    TextToWrite = CallsFromBoss[4];
                }
                else if (AnswerDay4 == 26)
                {
                    TextToWrite = CallsFromBoss[5];
                }
                Day5Accepted = true;
            }
            else if (CameraMove.TheDay == 8)
            {
                TextToWrite = CallsFromBoss[7];
                Day8Accepted = true;
            }
            else if (CameraMove.TheDay == 9)
            {
                if (AnsweredDay8 == false)
                {
                    TextToWrite = CallsFromBoss[8];
                }
                else if (AnswerDay8 != 26)
                {
                    TextToWrite = CallsFromBoss[9];
                }
                else if (AnswerDay8 == 26)
                {
                    GoodEnding = true;
                }
                Day9Accepted = true;
            }
            DaySpecial = false;
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
    private IEnumerator SoudClousePhone()
    {
        yield return new WaitForSeconds(0.1f);
        if (AlreadyDidSound == false)
        {
            AlreadyDidSound = true;
            audioSr2.PlayOneShot(audioClips[1]);
        }
        yield return new WaitForSeconds(0.5f);
        AlreadyDidSound = false;

    }

}