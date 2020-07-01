using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Text countText;          
    public Text resultText;			

    private Rigidbody2D rb2d;
    
    private int count;              

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        resultText.text = "";
        SetCountText();
    }

    //Movement
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    //Checks and deals with collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);          
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    //Counts the score
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
            resultText.text = "Good Job!";
    }
}
