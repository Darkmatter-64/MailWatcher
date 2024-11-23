using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public string WriteNumber = "";
    public Sprite Sprite1;
    public Sprite Sprite2;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        sr.sprite = Sprite1;
        if (Phone.StartWrite == false)
        {
            if (Phone.PhoneNumber.Length < 4)
            {
                Phone.PhoneNumber += WriteNumber;
                Debug.Log(Phone.PhoneNumber);
            }
            else
            {
                Phone.PhoneNumber = "";
            }
        }
    }
    private void OnMouseUp()
    {
        sr.sprite = Sprite2;
        StartCoroutine(RunIt());
    }


    private IEnumerator RunIt()
    {
        yield return new WaitForSeconds(0.1f);
        sr.sprite = Sprite1;

    }
}
