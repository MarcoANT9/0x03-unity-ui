using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //================================================================================
    // Public Variables ==============================================================
    //================================================================================
    public Image winLoseBG;
    public int health = 5;
    public float speed = 1000f;
    public Text healthText;
    public Text scoreText;
    public Text winLoseText;
    
    private int score = 0;
    private Rigidbody rb_player;

    //================================================================================
    // Start is called before the first frame update =================================
    //================================================================================
    void Start()
    {
            rb_player = GetComponent<Rigidbody>();
    }
    //================================================================================
    // Update is called once per frame ===============================================
    //================================================================================
    void FixedUpdate()
    {
        // Move Up
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb_player.AddForce(0, 0, speed * Time.deltaTime);
        }
        // Move Down
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb_player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        // Move Left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb_player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        // Move Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb_player.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    //================================================================================
    // Other Functions ===============================================
    //================================================================================     
    // Collision detection
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            // Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            // Debug.Log($"Health: {health}");
            SetHealthText();
            if (health == 0)
            {
                winLoseText.color = Color.white;
                winLoseText.text = $"Game Over!";
                winLoseBG.color = Color.red;
                winLoseBG.gameObject.SetActive(true);
                SceneManager.LoadScene("maze");
            }
        }

        if (other.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            winLoseText.color = Color.black;
            winLoseText.text = $"You Win!";
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            SceneManager.LoadScene("maze");
            
        }
    }
    // ----
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    // ----
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    // ----

}
