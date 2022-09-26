using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseDialog : Dialog {

    public bool gotHint;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject quizPanel;
    public Text reasoningText, questionText;
    public bool isQuiz;
    protected override void Start()
    {
        base.Start();
        
        if(isQuiz)
            questionText.text = MainController.instance.gameLevel.quizes[MainController.instance.currentHint].question;
    }

    public void OnContinueClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        CUtils.LoadScene(0, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnShareClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHowToPlayClick()
    {
        Sound.instance.PlayButton();
        DialogController.instance.ShowDialog(DialogType.HowtoPlay);
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            if (MainController.instance.gameLevel.quizes[MainController.instance.currentHint].isCorrect)
            {
                gotHint = true;
                winPanel.SetActive(true);
                quizPanel.SetActive(false);
                reasoningText.text = MainController.instance.gameLevel.quizes[MainController.instance.currentHint].reasoning;
                MainController.instance.tempHint++;

            }
            else
            {
                gotHint = false;
                lostPanel.SetActive(true);
                quizPanel.SetActive(false);
            }
        }
        else
        {
            if (MainController.instance.gameLevel.quizes[MainController.instance.currentHint].isCorrect)
            {
                gotHint = false;
                lostPanel.SetActive(true);
                quizPanel.SetActive(false);
            }
            else
            {
                gotHint = true;
                winPanel.SetActive(true);
                quizPanel.SetActive(false);
                reasoningText.text = MainController.instance.gameLevel.quizes[MainController.instance.currentHint].reasoning;
                MainController.instance.tempHint++;

            }
        }

        MainController.instance.currentHint++;

        
    }

    public void CloseHint()
    {
        //if (gotHint)
        //    WordRegion.instance.ShowHint(MainController.instance.currentHint-1);

        Close();
    }

    public override void OnDialogCompleteClosed()
    {
        base.OnDialogCompleteClosed();
        if (gotHint)
        {
            WordRegion.instance.ShowHint(MainController.instance.hintCount);

            if ((float)MainController.instance.tempHint % 2f == 0)
                MainController.instance.hintCount++;
        }

       
    }


}
