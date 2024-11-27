using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooltimeUI : MonoBehaviour
{
    private float cooltime = 0.0f;
    private float max_cooltime = 30.0f;
    public Image incooltime;
    private bool isCoroutineRunning = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCoroutineRunning)
        {
            if (cooltime <= 0)
            {
                StartCoroutine(CoolTime());
            }
        }
    }
    public IEnumerator CoolTime()
    {
        isCoroutineRunning = true;
        cooltime = 30.0f;
        while(cooltime > 0.0f)
        {
            cooltime -= Time.deltaTime;

            incooltime.fillAmount = cooltime / max_cooltime;

            yield return new WaitForFixedUpdate();
        }
        isCoroutineRunning=false;
    }
}
