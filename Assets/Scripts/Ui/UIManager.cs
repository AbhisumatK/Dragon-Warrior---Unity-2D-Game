using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioClip pauseSound;

    private void Awake()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

#region GAME_OVER
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
#endregion

#region PAUSE
    public void PauseGame(bool status)
    {
        SoundManager.instance.PlaySound(pauseSound);
        pauseScreen.SetActive(status);

        // if the game is paused, stop time; else, resume time; time scale 0 = paused, 1 = normal speed, 0.5 = half speed, etc.
        if(status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        
    }

    public void SoundVolume()
    {
        SoundManager.instance.changeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.changeMusicVolume(0.2f);
    }
#endregion

}