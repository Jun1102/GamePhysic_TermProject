using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    static public bool isHTPON = false;
    public Button startBtn;
    public Button quitBtn;
    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isHTPON == true)
        {
            startBtn.GetComponent<Button>().enabled = false;
            quitBtn.GetComponent<Button>().enabled = false;
            this.GetComponent<Button>().enabled = false;
            startBtn.GetComponent<EventTrigger>().enabled = false;
            quitBtn.GetComponent<EventTrigger>().enabled = false;
            this.GetComponent<EventTrigger>().enabled = false;
        }
        else if(isHTPON == false)
        {
            startBtn.GetComponent<Button>().enabled = true;
            quitBtn.GetComponent<Button>().enabled = true;
            this.GetComponent<Button>().enabled = true;
            startBtn.GetComponent<EventTrigger>().enabled = true;
            quitBtn.GetComponent<EventTrigger>().enabled = true;
            this.GetComponent<EventTrigger>().enabled = true;
        }
    }


    public void HTPON()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        isHTPON = true;
    }

    public void HTPOFF()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        isHTPON=false;
    }
}
