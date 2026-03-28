using UnityEngine;

public class MaskSpawner : MonoBehaviour
{
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform housePoint;

    public GameObject smileMaskPrefab;
    public GameObject[] notSmileMaskPrefabs;

    private float time1 = 5f;
    private float time2 = 4f;
    private float time3 = 3f;
    private float time4 = 2f;

    void Start()
    {
        SpawnMaskFromSide(MaskSide.Left);
        SpawnMaskFromSide(MaskSide.Right);
    }

    public void SpawnMaskFromSide(MaskSide side)
    {
        Vector3 spawnPos = side == MaskSide.Left
            ? leftSpawn.position
            : rightSpawn.position;

        bool spawnSmile = Random.value > 0.75f;

        GameObject prefabToSpawn = spawnSmile
            ? smileMaskPrefab
            : GetRandomNotSmileMask();

        GameObject maskObj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        MaskMovement maskMovement = maskObj.GetComponent<MaskMovement>();
        if (maskMovement == null)
        {
            Debug.LogError("MaskMovement not found!");
            return;
        }

        float speed = CalculateMoveSpeed(spawnPos);

        maskMovement.Init(
            housePoint.position,
            speed,
            this,
            side
        );
    }

    GameObject GetRandomNotSmileMask()
    {
        int unlockedCount = GetUnlockedNotSmileMaskCount();
        unlockedCount = Mathf.Clamp(unlockedCount, 1, notSmileMaskPrefabs.Length);

        int index = Random.Range(0, unlockedCount);
        return notSmileMaskPrefabs[index];
    }

    int GetUnlockedNotSmileMaskCount()
    {
        int score = GameManager.Instance != null ? GameManager.Instance.GetScore() : 0;

        if (score < 100)
            return 1;
        else if (score < 300)
            return 2;
        else
            return 3;

    }

    float GetMoveTimeByScore()
    {
        int score = GameManager.Instance != null ? GameManager.Instance.GetScore() : 0;

        if (score < 100)
            return time1;
        else if (score < 300)
            return time2;
        else if (score < 500)
            return time3;
        else
            return time4;
    }

    float CalculateMoveSpeed(Vector3 spawnPos)
    {
        float distance = Vector3.Distance(spawnPos, housePoint.position);
        float moveTime = GetMoveTimeByScore();

        return distance / moveTime;
    }
}
