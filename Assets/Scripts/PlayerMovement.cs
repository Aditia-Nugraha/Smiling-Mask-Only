using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float minX;
    public float maxX;

    public SpriteRenderer bodyRenderer;

    public Transform firePointTransform;

    public GameObject bulletPrefab;

    public Animator animator;

    public AudioSource shootAudio;
    public AudioClip shootSFX;

    private bool isFacingRight = true;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);

        transform.position += movement * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if (horizontal != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
            Shoot();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        bodyRenderer.flipX = !bodyRenderer.flipX;

        Vector3 firePointPos = firePointTransform.localPosition;
        firePointPos.x *= -1;
        firePointTransform.localPosition = firePointPos;
    }

    void Shoot()
    {
        if (shootAudio != null && shootSFX != null)
        {
            shootAudio.PlayOneShot(shootSFX);
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePointTransform.position,
            Quaternion.identity
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        Vector2 dir = isFacingRight ? Vector2.right : Vector2.left;

        bulletScript.SetDirection(dir);
    }

}
