using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Image touch;
    public Image bombPanel;
    public Image bombPanel2;
    public Image healthPanel;
    public Image blood1;
    public Image GoldRush;
    private float health = 1.0F;
    public bool bombWait = false;
    public bool bombWait2 = false;
    public GameObject bomb;
    [SerializeField] private float speedMul;
    private Vector3 startMousePosition;
    private Vector3 CurrentMousePosition;
    private float speedX;
    private float speedY;
    private float StopMulX;
    private float StopMulY;
    private int CountFrame = 0;
    [SerializeField] private int FrameMul;
    public bool OnDown = false;
    private bool OnStop = false;
    private float maxSpeed;
    GameObject bomb1;
    public GameObject bomb2;
    GameObject bomb3;
    public int gold = 0;
    public Text text;
    private bool brake = false;
    private AudioSource audioSource;
    public AudioClip blair1;
    public AudioClip blair2;
    public AudioClip goldRushClip;
    private float timeWaitBombs;
    private bool goldRushBool = false;
    private float delHealthCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        text = GameObject.Find("GoldCount").GetComponent<Text>();
        touch.enabled = false;
        bomb1 = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        bomb1.transform.parent = gameObject.transform;
        bomb3 = Instantiate(bomb2, new Vector3(transform.position.x - 0.1F, transform.position.y - 0.2F, 0), Quaternion.identity);
        bomb3.transform.parent = gameObject.transform;
        StartCoroutine(DelHealth());
        StartCoroutine(goldRush());
        text.text = "" + gold;
        audioSource = GetComponent<AudioSource>();
        delHealthCount = PlayerPrefs.GetFloat("DelHealthCount");
        timeWaitBombs = PlayerPrefs.GetFloat("TimeWaitBombs");
        maxSpeed = PlayerPrefs.GetFloat("MaxSpeed");
        Debug.Log(delHealthCount);
        Debug.Log(timeWaitBombs);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && !OnDown)
        {
            touch.enabled = true;
            
            startMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            touch.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            OnDown = true;
        }
        if (OnDown && Input.touchCount < 2)
        {

            CurrentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (CurrentMousePosition.x < 0.7F)
            {
                brake = false;
                speedX = CurrentMousePosition.x - startMousePosition.x;
                speedY = CurrentMousePosition.y - startMousePosition.y;
                if (Mathf.Abs(speedX) > Mathf.Abs(maxSpeed))
                {
                    if (speedX > 0)
                        speedX = maxSpeed;
                    else
                        speedX = maxSpeed * -1.0F;
                }
               
                if (speedX < 0)
                    sr.flipX = true;
                else
                    sr.flipX = false;
                // rb.AddForce(new Vector3(speedX * speedMul, speedY * speedMul, 0));
                rb.velocity = new Vector3(speedX * speedMul, speedY * 30, 0);
            }
            else
                brake = true;

        }

        if (!Input.GetMouseButton(0) && OnDown || brake)
        {
            touch.enabled = false;
            OnDown = false;
            OnStop = true;
            StopMulX = speedX / FrameMul;
            StopMulY = speedY / FrameMul;
            
           // rb.velocity = new Vector3(0, 0, 0);
        }

        if (OnStop && !Input.GetMouseButton(0) || OnStop && brake)
        {
            speedX -= StopMulX;
            speedY -= StopMulY;
            rb.velocity = new Vector3(speedX * speedMul, speedY * 30, 0);
            if (speedX < 0.01F && speedX > -0.01F)
            {
                OnStop = false;
                rb.velocity = new Vector3(0,0,0);
            }

        }

        if (text.fontSize > 61)
            text.fontSize--;

            
    }

    public void AttackBomb()
    {
        if (!bombWait)
        {
            audioSource.PlayOneShot(blair1);
            bomb1.GetComponent<Bomb>().goBoom();
            bomb1.GetComponent<Rigidbody2D>().isKinematic = false;
            bomb1.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            bombWait = true;
            bombPanel.fillAmount = 1;
            bombPanel.color = new Vector4(0, 0, 0, 0.85F);
            StartCoroutine(WaitBomb());
            StartCoroutine(timeBomb());
        }
    }

    public void AttackBomb2()
    {
        Debug.Log("Attact");
        if (!bombWait2)
        {
            audioSource.PlayOneShot(blair2);
            bomb3.GetComponent<bomb2>().goBoom();
            bomb3.GetComponent<Rigidbody2D>().isKinematic = false;
            bomb3.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, 0, 0);
            bombWait2 = true;
            bombPanel2.fillAmount = 1;
            bombPanel2.color = new Vector4(0, 0, 0, 0.85F);
            StartCoroutine(WaitBomb2());
            StartCoroutine(timeBomb2());
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menuLevel()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + gold);
    }
    public void addHealth(float _health)
    {
        if (_health < -0.01F)
            blood1.GetComponent<blood>().go();
        health += _health;
        if (health <= 0)
            health = 0;
        if (health >= 1.0F)
            health = 1.0F;
        healthPanel.fillAmount = health;
    }

    public void addGold(int _gold)
    {
        gold += _gold;
        text.text = "" + gold;
        text.fontSize = 110;
        if (!goldRushBool)
            GoldRush.fillAmount += (float)_gold * 0.002F;
        if (GoldRush.fillAmount > 0.98F && !goldRushBool)
        {
            goldRushBool = true;
            audioSource.PlayOneShot(goldRushClip);
            StartCoroutine(goldTime());
            timeWaitBombs = 0.0001F;
        }
    }

    IEnumerator goldTime()
    {
        yield return new WaitForSeconds(0.05F);
        GoldRush.fillAmount -= 0.002F;
        if (GoldRush.fillAmount < 0.01F)
        {
            audioSource.Stop();
            timeWaitBombs = PlayerPrefs.GetFloat("TimeWaitBombs");
            goldRushBool = false;
            StopCoroutine(goldTime());

        }
        else
            StartCoroutine(goldTime());
    }

    IEnumerator goldRush()
    {
        yield return new WaitForSeconds(0.05F);
        GoldRush.fillAmount -= 0.002F;
        StartCoroutine(goldRush());
    }

    IEnumerator WaitBomb()
    {
        yield return new WaitForSeconds(timeWaitBombs);
        if (bombPanel.fillAmount <= 0.1F)
        {
            bombWait = false;
            StopCoroutine(WaitBomb());
            bomb1 = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            bomb1.transform.parent = gameObject.transform;
            bombPanel.color = new Vector4(0, 0, 0, 0);
        }
        else
        {
            bombPanel.fillAmount -= 0.01F;
            StartCoroutine(WaitBomb());
        }

    }

    IEnumerator WaitBomb2()
    {
        yield return new WaitForSeconds(timeWaitBombs);
        if (bombPanel2.fillAmount <= 0.1F)
        {
            bombWait2 = false;
            StopCoroutine(WaitBomb2());
            bomb3 = Instantiate(bomb2, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            bomb3.transform.parent = gameObject.transform;
            bombPanel2.color = new Vector4(0, 0, 0, 0);
        }
        else
        {
            bombPanel2.fillAmount -= 0.01F;
            StartCoroutine(WaitBomb2());
        }

    }

    IEnumerator timeBomb()
    {
        yield return new WaitForSeconds(0.5F);
        bomb1.GetComponent<CircleCollider2D>().isTrigger = false;
    }

    IEnumerator timeBomb2()
    {
        yield return new WaitForSeconds(0.5F);
        bomb3.GetComponent<CircleCollider2D>().isTrigger = false;
    }

    IEnumerator DelHealth()
    {
        yield return new WaitForSeconds(0.5F);
        addHealth(delHealthCount);
        StartCoroutine(DelHealth());
    }


}
