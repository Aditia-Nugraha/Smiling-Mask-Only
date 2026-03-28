using UnityEngine;
using TMPro;

public class FloatingScore : MonoBehaviour
{
    public float moveUpSpeed = 1f;
    public float lifeTime = 1f;
    public float fadeSpeed = 2f;

    private TextMeshPro text;
    private Color textColor;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
        textColor = text.color;
        text.sortingOrder = 10;
    }

    public void Init(int scoreAmount)
    {
        text.text = "+" + scoreAmount;
    }

    void Update()
    {
        transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;

        textColor.a -= fadeSpeed * Time.deltaTime;
        text.color = textColor;

        if (textColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
