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
    private float health = 1.0F;
    public bool bombWait = false;
    public bool bombWait2 = false;
    public GameObject bomb;
    [SerializeField] private float speedMul;
    private Vector3 startMousePosition;
    private Vector3 CurrentMousePosition;
    private Vector3 oldMousePosition;
    private float speedX;
    private float speedY;
    private float StopMulX;
    private float StopMulY;
    private int CountFrame = 0;
    [SerializeField] private int FrameMul;
    private bool OnDown = false;
    private bool OnStop = false;
    public bool OnClick = false;
    public float maxSpeed;
    GameObject bomb1;
    public GameObject bomb2;
    GameObject bomb3;
    public int gold = 0;
    public Text text;
    private bool brake = false;

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
        text.text = "" + gold;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && !OnDown && OnClick)
        {
            touch.enabled = true;
            
            startMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            touch.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            OnDown = true;
        }

        if (OnDown && OnClick)
        {

            CurrentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (CurrentMousePosition.x < 0.7F)
            {
                brake = false;
                speedX = CurrentMousePosition.x - startMousePosition.x;
                speedY = CurrentMousePosition.y - startMousePosition.y;
                if (speedX > maxSpeed)
                    speedX = maxSpeed;
                if (speedX < 0)
                    sr.flipX = true;
                else
                    sr.flipX = false;
                // rb.AddForce(new Vector3(speedX * speedMul, speedY * speedMul, 0));
                rb.velocity = new Vector3(speedX * speedMul, speedY * speedMul, 0);
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
            CountFrame++;
            speedX -= StopMulX;
            speedY -= StopMulY;
            rb.velocity = new Vector3(speedX * speedMul, speedY * speedMul, 0);
            if (CountFrame > FrameMul)
            {
                OnStop = false;
                CountFrame = 0;
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
            bomb1.GetComponent<Bomb>().goBoom();
            bomb1.GetComponent<Rigidbody2D>().isKinematic = false;
            bomb1.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            bombWait = true;
            bombPanel.fillAmount = 0;
            StartCoroutine(WaitBomb());
            StartCoroutine(timeBomb());
        }
    }

    public void AttackBomb2()
    {
        if (!bombWait2)
        {
            bomb3.GetComponent<bomb2>().goBoom();
            bomb3.GetComponent<Rigidbody2D>().isKinematic = false;
            bomb3.GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, 0, 0);
            bombWait2 = true;
            bombPanel2.fillAmount = 0;
            StartCoroutine(WaitBomb2());
            StartCoroutine(timeBomb2());
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void addHealth(float _health)
    {
       // Debug.Log(health);
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
    }

    IEnumerator WaitBomb()
    {
        yield return new WaitForSeconds(0.05F);
        if (bombPanel.fillAmount >= 0.99F)
        {
            bombWait = false;
            StopCoroutine(WaitBomb());
            bomb1 = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            bomb1.transform.parent = gameObject.transform;
        }
        else
        {
            bombPanel.fillAmount += 0.01F;
            StartCoroutine(WaitBomb());
        }

    }

    IEnumerator WaitBomb2()
    {
        yield return new WaitForSeconds(0.05F);
        if (bombPanel2.fillAmount >= 0.99F)
        {
            bombWait2 = false;
            StopCoroutine(WaitBomb2());
            bomb3 = Instantiate(bomb2, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            bomb3.transform.parent = gameObject.transform;
        }
        else
        {
            bombPanel2.fillAmount += 0.01F;
            StartCoroutine(WaitBomb2());
        }

    }

    public void OnClickDown()
    {
        OnClick = true;
    }

    public void OnClickUp()
    {
        OnClick = false;
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
        addHealth(-0.005F);
        StartCoroutine(DelHealth());
    }


}
