using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public AudioSource menuBGM;

    public void PlayGame()
    {
        if (menuBGM != null)
            menuBGM.Stop();

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
