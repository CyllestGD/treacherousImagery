using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    //public int index;
    //public string sceneName;
    //public Image black;
    //public Animator anim;

    public void playButton()
    {
        //StartCoroutine(Fading());
        SceneManager.LoadSceneAsync("Instructions");
    }
    public void startGame()
    {
        SceneManager.LoadSceneAsync("MainLevel");
    }
    public void aboutButton()
    {
        //StartCoroutine(Fading());
        SceneManager.LoadSceneAsync("About");
    }
    public void creditsScreen()
    {
        SceneManager.LoadSceneAsync("Credits1");
    }
    public void credits1Forward()
    {
        SceneManager.LoadSceneAsync("Credits2");
    }
    public void credits2Back()
    {
        SceneManager.LoadSceneAsync("Credits1");
    }
    public void credits2Forward()
    {
        SceneManager.LoadSceneAsync("Credits3");
    }
    public void credits3Back()
    {
        SceneManager.LoadSceneAsync("Credits2");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void menuButton()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    //IEnumerator Fading()
    //{
    //    anim.SetBool("Fade", true);
    //    yield return new WaitUntil(() => black.color.a == 1);
    //    //SceneManager.LoadScene(index);
    //}
}
