using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;


    public void StartGame()
    {
        if ((Persistence.Instance.playerName = nameInputField.text) != "")
        {
            if (Persistence.Instance.playerName == "RESET")
            {
                Persistence.Instance.bestScore = 0;
                Persistence.Instance.bestPlayer = "";

                FindObjectOfType<MainManager>().DisplayBestScore();

                FindObjectOfType<Persistence>().SaveBestPlayer();
            }
            else
            {
                SceneManager.LoadScene("main");
            }
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
