using Assets.Scripts;
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

	private void Start()
	{
        max_cooltime = FindHint.Instance.GetCompassCol();
	}

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
        FindHint.Instance.SetCoolTime(isCoroutineRunning);
		cooltime = FindHint.Instance.GetCompassCol();
		while (cooltime > 0.0f)
        {
            if(cooltime < 27f && cooltime > 26f)
                FindHint.Instance.SetCoolTime(false);
            cooltime -= Time.deltaTime;

            incooltime.fillAmount = cooltime / max_cooltime;

            yield return new WaitForFixedUpdate();
        }
        isCoroutineRunning=false;
	}
}
