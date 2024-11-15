using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class input_pw : MonoBehaviour
{
    public TMP_InputField password_text_input;
    public Button input_button;
    private string password_text = null;

    private void Awake()
    {
        password_text = password_text_input.GetComponent<TMP_InputField>().text;
    }

    void Update()
    {
        
    }
    
    public void InputPassword()
    {
        password_text = password_text_input.text;
        if (password_text == "1234")
            Debug.Log("정답");
        else
            Debug.Log("오답");
    }
}
