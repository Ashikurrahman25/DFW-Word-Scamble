using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Level", menuName = "Levels/NewLevel", order = 1)]
public class GameLevel : ScriptableObject
{
    public string word;
    public string answers;
    public string validWords;
    [TextArea]
    public string mainWord;

    [TextArea]
    public string definition;

    public QuizProperty[] quizes;
}

[System.Serializable]
public class QuizProperty
{
    public string question;
    public string reasoning;
    public bool isCorrect;
}

