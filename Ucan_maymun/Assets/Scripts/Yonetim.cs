using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yonetim : MonoBehaviour
{
    public static Yonetim instance;
    public GameObject Bilgi_panel;
    public AudioSource bg_music;
    public AudioSource bg_music_pnl;
    public AudioSource kazandin_music_pnl;
    public AudioSource kaybettin_music_pnl;

    //sahne geçiþleri bu scriptten kontrol edilecek

    void Awake()
    {
        if (instance == null)
            instance = this;
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            Time.timeScale = 0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1;
        }
       
    }

    public void RestartGame()
    {
        Invoke("LoadGameplay", 0.0f);
    }

    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex );
    }

    public void Next_Game()
    {
        Invoke("NextGame", 0.0f);
    }
    void NextGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);//aktif sahne indexine +1 ekle


    }

    public void Exit_Game()
    {
        Invoke("Exit", 0.0f);
    }
    void Exit()
    {
       
        Application.Quit();//oyunu sonlandýr.

    }

    public void Main_Menu()// olmasada olur
    {
        Invoke("MainMenu",0.0f);
    }
    void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);//Ana menuye geri dön

        Time.timeScale = 1;
    }

    public void Oyna()
    {
        bg_music_pnl.Stop();
        Invoke("Play", 0.0f);
        bg_music.Play();
    }

    void Play()
    {
        Time.timeScale = 1;
        Bilgi_panel.SetActive (false);

    }




}
