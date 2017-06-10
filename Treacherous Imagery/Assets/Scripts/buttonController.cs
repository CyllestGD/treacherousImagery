using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {
    public void startGame() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainLevel");
    }
    public void creditsScreen() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("CreditsScreen");
    }
    public void exitGame() {
        Application.Quit();
    }
    public void backButton() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu");
    }
}
