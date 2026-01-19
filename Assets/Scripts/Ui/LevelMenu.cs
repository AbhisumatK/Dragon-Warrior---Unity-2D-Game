using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour
{
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
                levelButtons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
        string LevelName = "Level " + levelId;
        SceneManager.LoadScene(LevelName);
    }
}