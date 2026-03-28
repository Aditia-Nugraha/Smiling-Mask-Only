using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskMovement : MonoBehaviour
{
    private Vector3 targetPos;
    private float moveSpeed;

    private MaskSpawner spawner;
    private MaskSide side;
    private Animator animator;

    public SpriteRenderer bodyRenderer;
    public GameObject floatingScorePrefab;

    public AudioClip hitNotSmileSFX;
    public AudioClip smileEnterHouseSFX;

    public bool isSmileMask;

    public void Init(
        Vector3 target,
        float speed,
        MaskSpawner maskSpawner,
        MaskSide maskSide
    )
    {
        targetPos = target;
        moveSpeed = speed;
        spawner = maskSpawner;
        side = maskSide;

        SetFacingBySide();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

    void SetFacingBySide()
    {
        bodyRenderer.flipX = false;

        if (side == MaskSide.Right)
        {
            bodyRenderer.flipX = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("House")) return;
        ReachHouse();
    }

    void ReachHouse()
    {
        if (isSmileMask)
        {
            GameManager.Instance.PlaySFX(smileEnterHouseSFX);

            SpawnFloatingScore(20);
            GameManager.Instance.AddScore(20);

            spawner.SpawnMaskFromSide(side);
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.SetGameOverReason(
                GameOverReason.NotSmileMaskEnteredHouse
            );

            SceneManager.LoadScene(2);
        }
    }

    public void OnHitByBullet()
    {
        if (isSmileMask)
        {
            GameManager.Instance.SetGameOverReason(
                GameOverReason.ShotSmileMask
            );

            SceneManager.LoadScene(2);
        }
        else
        {
            GameManager.Instance.PlaySFX(hitNotSmileSFX);

            SpawnFloatingScore(10);
            GameManager.Instance.AddScore(10);

            spawner.SpawnMaskFromSide(side);
            Destroy(gameObject);
        }
    }

    void SpawnFloatingScore(int amount)
    {
        if (floatingScorePrefab == null) return;

        Vector3 spawnPos = transform.position + Vector3.up * 0.5f;

        GameObject scoreObj = Instantiate(
            floatingScorePrefab,
            spawnPos,
            Quaternion.identity
        );

        FloatingScore floatingScore =
            scoreObj.GetComponent<FloatingScore>();

        if (floatingScore != null)
        {
            floatingScore.Init(amount);
        }
    }
}
