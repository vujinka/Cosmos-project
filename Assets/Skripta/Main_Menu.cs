using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Menager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Probica");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
