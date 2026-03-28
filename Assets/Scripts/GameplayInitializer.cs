using UnityEngine;

public class GameplayInitializer : MonoBehaviour
{
    void Awake()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
    }
}
