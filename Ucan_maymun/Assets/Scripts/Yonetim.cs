using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yonetim : MonoBehaviour
{
    public static Yonetim instance;

    //sahne geçiþleri bu scriptten kontrol edilecek

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void RestartGame()
    {
        Invoke("LoadGameplay", 2f);
    }

    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void Next_Game()
    {
        Invoke("NextGame", 2f);
    }
    void NextGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);


    }

    public void Exit_Game()
    {
        Invoke("Exit", 2f);
    }
    void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);//aktif sahne indexine +1 ekle


    }

    public void Main_Menu()// olmasada olur
    {
        Invoke("MainMenu", 2f);
    }
    void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);//Ana menuye geri dön


    }




}
