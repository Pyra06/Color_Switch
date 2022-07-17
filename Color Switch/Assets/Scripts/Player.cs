using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color colorBlue;
    public Color colorPurple;
    public Color colorCyan;
    public Color colorRed;
    public Color colorGreen;
    public Color colorYellow;

    void Start()
    {
        SetRandomColor();    
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Debug.Log("Game Over");
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 6);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 2:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 3:
                currentColor = "Red";
                sr.color = colorRed;
                break;
            case 4:
                currentColor = "Green";
                sr.color = colorGreen;
                break;
            case 5:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
        }
    }
}
