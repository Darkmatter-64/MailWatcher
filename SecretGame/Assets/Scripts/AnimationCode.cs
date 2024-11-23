using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnDestroy() 
    { 
        Destroy(gameObject);
    }
    public void OnDissapear()
    {
        gameObject.SetActive(false);
    }
    public void OnDissapeaTwoItems()
    {
        Item2.SetActive(false);
        Item1.SetActive(false);
    }
}
