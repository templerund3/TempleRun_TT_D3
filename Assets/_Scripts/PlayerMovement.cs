using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private DashTrail dashtrail;

    private bool isGround;
    private bool doubleJump;
    private Transform posCheckGround;
    private float jumpForce = 8f;
    public GameObject gameVirtual;

    [Header("Item")]
    private GameObject effectRun;
    private GameObject shieldPlayer;
    private GameObject magnetPlayer;
    private bool isShield;
    private bool isMagnet;

    float timeCounter = 0f;
    float trailTime = 1.5f;

    private Color[] colorPlayer = new Color[] { Color.white, Color.green, Color.black, Color.red };


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        posCheckGround = transform.GetChild(0);
        dashtrail = GetComponent<DashTrail>();
        effectRun = transform.GetChild(1).gameObject;
        shieldPlayer = transform.GetChild(2).gameObject;
        magnetPlayer = transform.GetChild(3).gameObject;
    }

    void Update()
    {
        if (GameState.Instance.gamestate == STATE.PLAYING)
        {
            isGround = Physics2D.OverlapCircle(posCheckGround.position, 0.05f, 1 << 8);
            if (isGround)
            {
                doubleJump = false;
                dashtrail.SetEnabled(false);
                effectRun.SetActive(true);
            }
            else
            {
                dashtrail.SetEnabled(true);
                effectRun.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && isGround)
            {
                Jump();
            }
            if (Input.GetMouseButtonDown(0) && !isGround && !doubleJump)
            {
                Jump();
                doubleJump = true;
            }
            if(transform.position.y <= -6f)
            {
                MusicController.Instance.PlayDieSound();
                StartCoroutine(ActionTimer(0.5f, null, () => GameOver()));
                GameState.Instance.gamestate = STATE.GAMEOVER;
            }

        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gold"))
        {
            MusicController.Instance.PlayCoinSound();
            GameManager.Instance.coin++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            isShield = true;
            shieldPlayer.SetActive(true);
            shieldPlayer.GetComponent<SpriteRenderer>().color = colorPlayer[PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT)];
            StartCoroutine(ActionTimer(5f, null, () =>
           {
               isShield = false;
               shieldPlayer.SetActive(false);
           }));
        }
        if (collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            isMagnet = true;
            magnetPlayer.SetActive(true);
            magnetPlayer.GetComponent<SpriteRenderer>().color = colorPlayer[PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT)];
            StartCoroutine(ActionTimer(5f, null, () =>
            {
                isMagnet = false;
                magnetPlayer.SetActive(false);
            }));
        }
        if (collision.CompareTag("ElectricOBstacle"))
        {
            if (!isShield)
            {
                anim.SetBool("EDie", true);
                MusicController.Instance.PlayDieSound();
                StartCoroutine(ActionTimer(0.5f, null, () => GameOver()));
                GameState.Instance.gamestate = STATE.GAMEOVER;
            }
            else
            {
                isShield = false;
                shieldPlayer.SetActive(false);
            }
        }
        if (collision.CompareTag("Obstacle"))
        {
            if (!isShield)
            {
                anim.SetBool("isDie", true);
                MusicController.Instance.PlayDieSound();
                StartCoroutine(ActionTimer(0.5f, null, () => GameOver()));
                GameState.Instance.gamestate = STATE.GAMEOVER;
            }
            else
            {
                isShield = false;
                shieldPlayer.SetActive(false);
            }
        }
        if (collision.CompareTag("Spring"))
        {
            MusicController.Instance.PlayJumpSound();
            collision.GetComponent<Animator>().enabled = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.5f);
        }
        if (collision.CompareTag("Finish"))
        {
            GameState.Instance.gamestate = STATE.GAMEWIN;
            int star = 0;
            if (GameManager.Instance.coin >= 3)
            {
                star = 1;
            }
            if (GameManager.Instance.coin >= 5)
            {
                star = 2;
            }
            if (GameManager.Instance.coin >= 10)
            {
                star = 3;
            }
            PlayerPrefs.SetString(ContsInGame.STARLEVEL + GameManager.Instance.level, star.ToString());
            PlayerPrefs.SetString(ContsInGame.STARLEVEL + (GameManager.Instance.level + 1), "0");
            PlayerPrefs.SetInt(ContsInGame.COIN, PlayerPrefs.GetInt(ContsInGame.COIN) + GameManager.Instance.coin);
            UIManager.Instance.txtCoinWin.text = GameManager.Instance.coin.ToString();
            UIManager.Instance.starWinGame.sprite = UIManager.Instance.sprStar[star];
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
        MusicController.Instance.PlayWinSound();
        GameManager.Instance.panelGameWin.SetActive(true);
        Destroy(gameObject);
    }

    public void GameOver()
    {
        MusicController.Instance.PlayLoseSound();
        GameManager.Instance.panelGameOver.SetActive(true);
        Destroy(gameObject);
    }

    public bool IsMagnet()
    {
        return isMagnet;
    }

}
