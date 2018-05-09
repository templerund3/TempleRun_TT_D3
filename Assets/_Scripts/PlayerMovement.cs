using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGround;
    private bool doubleJump;
    private Transform posCheckGround;
    private float jumpForce = 8f;
    public GameObject gameVirtual;

    [Header("Item")]
    public GameObject shieldPlayer;
    public GameObject Objshield;
    private bool isShield;
    private bool isMagnet;

    float timeCounter = 0f;
    float trailTime = 1.5f;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        posCheckGround = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.gamestate == STATE.PLAYING)
        {
            isGround = Physics2D.OverlapCircle(posCheckGround.position, 0.05f, 1 << 8);
            if (isGround)
            {
                doubleJump = false;
                GameObject obj = Instantiate(gameVirtual, transform.position + new Vector3(0, 0, 1),Quaternion.identity);
                Destroy(obj, 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.Space) && !isGround && !doubleJump)
            {
                Jump();
                doubleJump = true;
            }

        }
    }

    public void Jump()
    {
        //gameVirtual.transform.position = transform.position;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gold"))
        {
            GameManager.Instance.coin++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Shield"))
        {
            Objshield = Instantiate<GameObject>(shieldPlayer, transform);
            isShield = true;
            StartCoroutine(ActionTimer(5f, null , () =>
            {
                isShield = false;
                if (Objshield != null)
                {
                    Destroy(Objshield);
                }
            }));
        }
        if (collision.CompareTag("Magnet"))
        {
            isMagnet = true;
            StartCoroutine(ActionTimer(5f,null, () => isMagnet = false));
        }
        if (collision.CompareTag("ElectricOBstacle"))
        {
            if (!isShield)
            {
                anim.SetBool("EDie", true);
                StartCoroutine(ActionTimer(0.5f, null, () => GameOver()));
                GameState.Instance.gamestate = STATE.GAMEOVER;
            }
            else
            {
                isShield = false;
                if (Objshield != null)
                {
                    Destroy(Objshield);
                }
            }
        }
        if (collision.CompareTag("Obstacle"))
        {
            if (!isShield)
            {
                anim.SetBool("isDie", true);
                StartCoroutine(ActionTimer(0.5f, null, () => GameOver()));
                GameState.Instance.gamestate = STATE.GAMEOVER;
            }
            else
            {
                isShield = false;
                if (Objshield != null)
                {
                    Destroy(Objshield);
                }
            }
        }
        if (collision.CompareTag("Spring"))
        {
            collision.GetComponent<Animator>().enabled = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.5f);
        }
        if (collision.CompareTag("Finish"))
        {
            GameState.Instance.gamestate = STATE.GAMEWIN;
            GameWin();
        }
    }

    public IEnumerator ActionTimer(float time, UnityAction actionBegin = null, UnityAction actionEnd = null)
    {
        if (actionBegin != null)
            actionBegin();
        yield return new WaitForSeconds(time);
        if (actionEnd != null)
            actionEnd();
    }

    public void GameWin()
    {
        GameManager.Instance.panelGameWin.SetActive(true);
        Destroy(gameObject);
    }

    public void GameOver()
    {
        GameManager.Instance.panelGameOver.SetActive(true);
        Destroy(gameObject);
    }

}
