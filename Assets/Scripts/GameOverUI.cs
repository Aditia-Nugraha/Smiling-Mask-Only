using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI reasonText;
    public AudioClip failSFX;

    void Start()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.PlaySFX(failSFX);
        finalScoreText.text = "Score : " + GameManager.Instance.GetScore();

        switch (GameManager.Instance.GetGameOverReason())
        {
            case GameOverReason.ShotSmileMask:
                reasonText.text = "You shot a SMILE MASK!";
                break;

            case GameOverReason.NotSmileMaskEnteredHouse:
                reasonText.text = "A NOT SMILE MASK entered the house!";
                break;

            default:
                reasonText.text = "";
                break;
        }

        if (GameManager.Instance != null && GameManager.Instance.bgmSource != null)
        {
            GameManager.Instance.bgmSource.Stop();
        }

    }

    public void PlayAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(0);
    }
}
