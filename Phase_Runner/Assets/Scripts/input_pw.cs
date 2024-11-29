using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;


public class input_pw : MonoBehaviour
{
    private AudioSource inputSound;
    public TMP_InputField password_text_input;
    public UnityEngine.UI.Button input_button;
    public UnityEngine.UI.Button exitButton;
    private string password_text = null;
    static public bool isPWobjON = false;

    private void Awake()
    {
        password_text_input.onValueChanged.AddListener(OnTextChanged);
        inputSound = GetComponent<AudioSource>();
        password_text = password_text_input.GetComponent<TMP_InputField>().text;
    }

    void OnEnable()
    {
        isPWobjON = true;
        if (PlayerController.isCursorlocked == true)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerController.isCursorlocked = false;
        }
    }

    private void OnDisable()
    {
        isPWobjON = false;
        password_text_input.text = "";
        if(exitButton != null)
        {
            exitButton.OnPointerExit(null);
        }
        if (PlayerController.isCursorlocked == false)
        {
            PlayerController.isCursorlocked = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void InputPassword()
    {
        password_text = password_text_input.text;
        if (password_text == "1234")
            Debug.Log("����");
        else
            Debug.Log("����");
    }

    void OnTextChanged(string text)
    {
        inputSound.Play();
    }
}
