using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {
    public void startGame() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelOne");
    }
    public void creditsScreen() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Credits");
    }
    public void exitGame() {
        Application.Quit();
    }
    public void backButton() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu");
    }
}
