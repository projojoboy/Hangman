using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WordController : MonoBehaviour {

    string[] randomWord = { "car", "plane", "boat", "motor", "dragon", "horse", "dog", "cat", "house", "window", "pants", "road", "human", "bed", "pig", "phone", "computer", "hat", "television", "floor", "helicopter", "clock", "stairs", "train", "pistol", "uppercase", "dot" };
    string wrongLetters = "";
    string resultWord;
    string theWord;
    string inputLetter;
    string ownWord;

    bool gameStart = false;

    int letterLeftToWin;
    int level = 0;

    [SerializeField] Text wrongLetterText;
    [SerializeField] Text theWordText;
    [SerializeField] InputField input;
    [SerializeField] GameObject ingameUI;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject particles;

    GalgController galg;

    // Use this for initialization
    void Start()
    {
        galg = GetComponent<GalgController>();
    }

    public void OwnWord(string word)
    {
        ownWord = word;
    }

    public void StartGame(bool random)
    {
        if (random)
            theWord = randomWord[Random.Range(0, randomWord.Length)];
        else
            theWord = ownWord;

        ingameUI.SetActive(true);

        letterLeftToWin = theWord.Length;
        for (int i = 0; i < theWord.Length; i++)
        {
            resultWord = resultWord + ".";
        }

        theWordText.text = resultWord;
        gameStart = true;
    }

    public void GetInput(string guess)
    {
        if (input.text != "" && input.text != ".")
        {
            if (theWord.Contains(guess))
            {
                int i = theWord.IndexOf(guess);
                while(i != -1)
                {
                    resultWord = resultWord.Substring(0, i) + guess + resultWord.Substring(i + 1);
                    theWord = theWord.Substring(0, i) + "." + theWord.Substring(i + 1);
                    i = theWord.IndexOf(guess);
                    letterLeftToWin--;
                }
                theWordText.text = resultWord;
            }
            else
            {
                if (!wrongLetters.Contains(guess) && !resultWord.Contains(guess)){
                    wrongLetters = wrongLetters + " " + guess;
                    wrongLetterText.text = wrongLetters;
                    galg.Levels(level);
                    level++;
                }
            }
            input.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            input.Select();
            input.ActivateInputField();
        }

        if(letterLeftToWin == 0 && gameStart)
        {
            ingameUI.SetActive(false);
            winScreen.SetActive(true);
            particles.SetActive(true);
        }

        if(level == 12)
        {
            ingameUI.SetActive(false);
            loseScreen.SetActive(true);
        }
    }
}
