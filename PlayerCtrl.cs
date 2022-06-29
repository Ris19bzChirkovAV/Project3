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
    public Image healthPanel;
    private float health = 1.0F;
    public bool bombWait = false;
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
    private bool OnDown = false;
    private bool OnStop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //touch = GameObject.Find("touch");
        touch.enabled = false;
        StartCoroutine(DelHealth());
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

        if (OnDown)
        {
            CurrentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            speedX = CurrentMousePosition.x - startMousePosition.x;
            speedY = CurrentMousePosition.y - startMousePosition.y;
            if (speedX < 0)
                sr.flipX = true;
            else
                sr.flipX = false;
           // rb.AddForce(new Vector3(speedX * speedMul, speedY * speedMul, 0));
           rb.velocity = new Vector3(speedX * speedMul, speedY * speedMul, 0);
        }

        if (!Input.GetMouseButton(0) && OnDown)
        {
            touch.enabled = false;
            OnDown = false;
            OnStop = true;
            StopMulX = speedX / FrameMul;
            StopMulY = speedY / FrameMul;
           // rb.velocity = new Vector3(0, 0, 0);
        }

        if (OnStop && !Input.GetMouseButton(0))
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
            
    }

    public void AttackBomb()
    {
        if (!bombWait)
        {
            Instantiate(bomb, new Vector3(transform.position.x + 1.5F, transform.position.y - 2, 0), Quaternion.identity);
            bombWait = true;
            bombPanel.fillAmount = 0;
            StartCoroutine(WaitBomb());
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void addHealth(float _health)
    {
        Debug.Log(health);
        health += _health;
        if (health >= 1.0F)
            health = 1.0F;
        healthPanel.fillAmount = health;
    }

    IEnumerator WaitBomb()
    {
        yield return new WaitForSeconds(0.05F);
        if (bombPanel.fillAmount >= 0.99F)
        {
            bombWait = false;
            StopCoroutine(WaitBomb());
        }
        else
        {
            bombPanel.fillAmount += 0.01F;
            StartCoroutine(WaitBomb());
        }

    }

    IEnumerator DelHealth()
    {
        yield return new WaitForSeconds(0.5F);
        addHealth(-0.005F);
        StartCoroutine(DelHealth());
    }
}
