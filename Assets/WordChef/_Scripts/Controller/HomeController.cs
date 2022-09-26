using UnityEngine.UI;
using Superpow;

public class HomeController : BaseController {
    private const int PLAY = 0;
    private const int FACEBOOK = 1;
    public Text levelName;

    public void OnClick(int index)
    {
        switch (index)
        {
            case PLAY:
                CUtils.LoadScene(1);
                break;
            case FACEBOOK:
                CUtils.LikeFacebookPage(ConfigController.Config.facebookPageID);
                break;
        }
        Sound.instance.PlayButton();
    }

    private void Start()
    {
        //CPlayerPrefs.useRijndael(CommonConst.ENCRYPTION_PREFS);

        GameLevel gameLevel = Utils.Load(Prefs.unlockedWorld, Prefs.unlockedSubWorld, Prefs.unlockedLevel);
        levelName.text = "Level " + (Prefs.unlockedLevel+1).ToString("00") + ": " + gameLevel.word;
        


    }

}
