using UnityEngine;

public class GameplayBGMStarter : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayBGM(
                GameManager.Instance.gameplayBGM
            );
        }
    }
}