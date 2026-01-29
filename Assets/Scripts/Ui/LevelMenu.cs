using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour
{
    [SerializeField] int max_no_levels;
    public Button[] levelButtons;

    public void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < levelReached; i++)
        {
            if (i < levelButtons.Length)
                levelButtons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
        string LevelName = "Level " + levelId;
        if(levelId <= max_no_levels)
            SceneManager.LoadScene(LevelName);
        else
            SceneManager.LoadScene(levelId + 1);
    }
}