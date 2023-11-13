using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerBehavior : MonoBehaviour
{
    //1. access (public or private)
    //2. type (int, float, bool)
    //3. name (naming conventions) they always start with a letter that is not capitalized, but you can have multiple words with no spaces and following words could be capitalized
    //4. OPTIONAL: you can give it a value
    //borders: 8.5 and 6.5

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float middleScreen;
    public float bottomScreen;
    public GameObject BulletPrefab;
    public int Lives;
    public TextMeshProUGUI lifeText;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
        speed = 4f;
        horizontalScreenLimit = 9.5f;
        middleScreen = 0.5f;
        bottomScreen = -2.5f;
        Debug.Log(Lives);
        lifeText = GameObject.Find("GameManager").GetComponent<GameManager>().livesText;
        lifeText.text = "lives:" + Lives;
    }

    // Update is called once per frame; if your computer runs at 60 fps
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }

        if (transform.position.y >= middleScreen)
        {
            transform.position = new Vector3(transform.position.x, middleScreen, 0);
        }
        else if (transform.position.y <= bottomScreen)
        {
            transform.position = new Vector3(transform.position.x, bottomScreen, 0);
        }
    }

    void Shooting()
    {
        //if I press SPACE, create a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet
            Instantiate(BulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        Lives--;
        Debug.Log(Lives);
        lifeText.text = "lives:" + Lives;
        // lives -= 1;
        //lives = lives - 1;
        if (Lives <= 0)

        {
            //Game Over
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Destroy(this.gameObject);
        }
    }

    public void GainLife()
    {
        Lives += 1;
        if (Lives >= 3)
        {
            //for keeping three lives.. hopefully
            Lives = 3;
            
        }
    }
}