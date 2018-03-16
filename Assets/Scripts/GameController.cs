using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject startScreen;
    WordController wc;

    private void Start()
    {
        wc = GetComponent<WordController>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame(bool word)
    {
        wc.StartGame(word);
        startScreen.SetActive(false);
    }
}
