using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject TextCloud;
    public Text TextFromPhone;
    public static string PhoneNumber = "";
    public string[] Numbers;
    public float Timer = 0;
    public int IntTimer = 0;
    private bool ItWorks = false;
    private bool StartWrite = false;
    private int NumberThatWas = 99999;
    private string TextToWrite = "";
    private string TextThatIsWriting;
    private bool SlashWorcked = false;
    [Header("PhoneStrings")]
    public string[] PhoneStringsDay1;
    public string[] PhoneStringsDay2;
    public string[] PhoneStringsDay3;
    public bool IsThereSuchNumber;
    // Start is called before the first frame update
    void Start()
    {
        TextCloud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneNumber.Length == 4)
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i].Equals(PhoneNumber))
                {
                    ItWorks = true;
                    StartWrite = true;
                    //TextFromPhone.text = PhoneStringsDay1[i];
                    TextToWrite = PhoneStringsDay1[i];
                    Debug.Log(TextToWrite);
                    PhoneNumber = "";
                    TextCloud.SetActive(true);
                    TextFromPhone.text = "";
                }
            }

        }
        if (PhoneNumber.Length >= 4)
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
                Debug.Log("F");
                NumberThatWas = IntTimer;
                StartCoroutine(WaitToClearTime());
            }
        }


    }
    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(0.6f);
        TextFromPhone.text += "";
        StartWrite = false;
        NumberThatWas = 99999;
        Timer = 0;
        IntTimer = 0;
        TextCloud.SetActive(false);
    }
    private IEnumerator WaitToClearTime()
    {
        yield return new WaitForSeconds(0.6f);
        TextFromPhone.text = "";
        Timer += 1;
    }

}