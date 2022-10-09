using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {
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
}
