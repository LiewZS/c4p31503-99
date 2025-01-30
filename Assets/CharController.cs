using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public CoinManager coinManager;
    public GameAudio gameAudio;

    float jumpForce = 400.0f;
    float walkForce = 15.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&
                this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");

            this.rigid2D.AddForce(transform.up * this.jumpForce);

            gameAudio.PlayJumpSE();
        }

        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;


        float speedx = Mathf.Abs(this. rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key,1,1);
        }

        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        if(transform.position.y < -30)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("ƒS[ƒ‹");
            SceneManager.LoadScene("ClearScene");
        }

        if (other.CompareTag("Coin"))
        {
            gameAudio.PlayGetCoinSE();
            Destroy(other.gameObject);
            coinManager.coin++;
        }
    }
}
