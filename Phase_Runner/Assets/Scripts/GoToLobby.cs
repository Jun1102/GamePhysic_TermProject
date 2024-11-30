using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLobby : MonoBehaviour
{
    void Update()
    {
        if (ScreenFadeImage.isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
