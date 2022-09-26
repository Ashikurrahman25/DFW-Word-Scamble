using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Superpow;

public class MainController : BaseController {
    public Text levelNameText,wordText, definitionText;

    private int world, subWorld, level;
    private bool isGameComplete;
    public int currentHint;
    public int maxHint;
    public int hintCount;
    public int tempHint;
    public GameLevel gameLevel;

    public static MainController instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        world = GameState.currentWorld;
        subWorld = GameState.currentSubWorld;
        level = GameState.currentLevel;


        gameLevel = Utils.Load(world, subWorld, level);
        Pan.instance.Load(gameLevel);
        WordRegion.instance.Load(gameLevel);
        maxHint = gameLevel.quizes.Length;
        //if (world == 0 && subWorld == 0 && level == 0)
        //{
        //    Timer.Schedule(this, 0.5f, () =>
        //    {
        //        DialogController.instance.ShowDialog(DialogType.HowtoPlay);
        //    });
        //}

        levelNameText.text = "Level "+ " - " + (level + 1);
        wordText.text = gameLevel.mainWord;
        definitionText.text = gameLevel.definition;
    }

    public void OnComplete()
    {
        if (isGameComplete) return;
        isGameComplete = true;

        Timer.Schedule(this, 1f, () =>
        {
            DialogController.instance.ShowDialog(DialogType.Win);
            Sound.instance.Play(Sound.Others.Win);
        });
    }

    private string BuildLevelName()
    {
        return world + "-" + subWorld + "-" + level;
    }

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogController.instance.IsDialogShowing())
        {
            DialogController.instance.ShowDialog(DialogType.Pause);
        }
    }
}
