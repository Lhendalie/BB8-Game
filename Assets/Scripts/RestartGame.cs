using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{

    public Transform spawnPoint;//Add empty gameobject as spawnPoint
    //public Transform particle;
    public Transform checkPoint;
    public Transform checkPoint1;
    public GameObject teleport0;
    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;
    public AudioClip gameAudio;

    public Text countText;
    public Text resultText;
    public Text livesText;

    private int countCoins;
    private int countLives;

    void Start()
    {
        countCoins = 0;
        countLives = 3;
        resultText.text = "";
        SetCountText();
        SetLivesText();
        //teleport0.SetActive(true);
        teleport1.SetActive(false);
        teleport3.SetActive(false);
    }

    //Checks and deals with collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<Renderer>().enabled = false;
            other.gameObject.tag = "none";
            countCoins = countCoins + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Death"))
        {
            if (teleport1.activeSelf == true)
            {
                transform.position = checkPoint.position;
            }
            else if (teleport3.activeSelf == true)
            {
                transform.position = checkPoint1.position;
            }
            else
            {
                transform.position = spawnPoint.position;
            }
            countLives = countLives - 1;
            SetLivesText();

            if (countLives < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (other.gameObject.CompareTag("Finish"))
        {      
            SceneManager.LoadScene("EndScene");
        }
        if (other.gameObject.CompareTag("checkPoint"))
        {
            teleport0.SetActive(false);
            teleport1.SetActive(true);
        }

        if (other.gameObject.CompareTag("checkPoint1"))
        {
            teleport1.SetActive(false);
            teleport2.SetActive(false);
            teleport3.SetActive(true);
        }
    }

    //Counts the score
    void SetCountText()
    {
        countText.text = "Score: " + countCoins.ToString();
    }

    //Counts lives
    void SetLivesText()
    {
        livesText.text = "Lives: " + countLives.ToString();
        if (countLives < 0)
        {
            Debug.Log("Game Over");
        }
    }
}
