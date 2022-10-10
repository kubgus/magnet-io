using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        try
        {
            string u = PlayerPrefs.GetString("username");
            if (u.Length <= 0)
            {
                u = "Username";
            }

            input.text = u;
        } catch { }
    }

    public void LoadGame()
    {
        PlayerPrefs.SetString("username", input.text);
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu(float time)
    {
        Invoke("TrueLoadMenu", time);
    }

    void TrueLoadMenu()
    {
        //TU SA LOADNE MAIN MENU
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsMenu()
    {
        PlayerPrefs.SetString("username", input.text);
        SceneManager.LoadScene("Options");
    }
}
