using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuCamera : MonoBehaviour
{
    private int CamPosition = 1;
    private float[] BabaPosition;
    private float[] speedValue, bomb1Value, bomb2Value, bomb1Radius, bomb2Radius;
    [SerializeField] float speed;
    public Image speedBar;
    public Image bomb1Bar;
    public Image bomb2Bar;
    public Image bomb1RadiusBar;
    public Image bomb2RadiusBar;
    public Image LoadImage;
    public Text text;
    System.Random rand = new System.Random();
    public GameObject comet;
    void Start()
    {
        LoadImage.gameObject.SetActive(false);
        BabaPosition = new float[4];
        speedValue = new float[4];
        bomb1Value = new float[4];
        bomb2Value = new float[4];
        bomb1Radius= new float[4];
        bomb2Radius = new float[4];
        for (int i = 0; i < 4; i++)
        {
            string baba = "BabaYaga" + (i + 1);
            BabaPosition[i] = GameObject.Find(baba).transform.position.x;
        }
        speedValue[0] = 0.3F;
        speedValue[1] = 0.5F;
        speedValue[2] = 0.7F;
        speedValue[3] = 0.9F;
        bomb1Value[0] = 0.25F;
        bomb1Value[1] = 0.45F;
        bomb1Value[2] = 0.65F;
        bomb1Value[3] = 0.8F;
        bomb2Value[0] = 0.5F;
        bomb2Value[1] = 0.65F;
        bomb2Value[2] = 0.80F;
        bomb2Value[3] = 0.95F;
        bomb1Radius[0] = 0.1F;
        bomb1Radius[1] = 0.15F;
        bomb1Radius[2] = 0.20F;
        bomb1Radius[3] = 0.25F;
        bomb2Radius[0] = 0.3F;
        bomb2Radius[1] = 0.4F;
        bomb2Radius[2] = 0.5F;
        bomb2Radius[3] = 0.6F;
        text = GameObject.Find("BabaName").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CamPosition == 1)
            text.text = "Baba Yaga1";
        else if (CamPosition == 2)
            text.text = "Baba Yaga2";
        else if (CamPosition == 3)
            text.text = "Baba Yaga3";
        else
            text.text = "Baba Yaga4";
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(BabaPosition[CamPosition - 1], transform.position.y, transform.position.z), speed * Time.deltaTime);
        if (Mathf.Abs(speedBar.fillAmount - speedValue[CamPosition - 1]) > 0.005F)
            if (speedBar.fillAmount > speedValue[CamPosition - 1])
                speedBar.fillAmount -= 0.004F;
            else
                speedBar.fillAmount += 0.004F;
        if (Mathf.Abs(bomb1Bar.fillAmount - bomb1Value[CamPosition - 1]) > 0.005F)
            if (bomb1Bar.fillAmount > bomb1Value[CamPosition - 1])
                bomb1Bar.fillAmount -= 0.004F;
            else
                bomb1Bar.fillAmount += 0.004F;
        if (Mathf.Abs(bomb2Bar.fillAmount - bomb2Value[CamPosition - 1]) > 0.005F)
            if (bomb2Bar.fillAmount > bomb2Value[CamPosition - 1])
                bomb2Bar.fillAmount -= 0.004F;
            else
                bomb2Bar.fillAmount += 0.004F;
        if (Mathf.Abs(bomb1RadiusBar.fillAmount - bomb1Radius[CamPosition - 1]) > 0.005F)
            if (bomb1RadiusBar.fillAmount > bomb1Radius[CamPosition - 1])
                bomb1RadiusBar.fillAmount -= 0.004F;
            else
                bomb1RadiusBar.fillAmount += 0.004F;
        if (Mathf.Abs(bomb2RadiusBar.fillAmount - bomb2Radius[CamPosition - 1]) > 0.005F)
            if (bomb2RadiusBar.fillAmount > bomb2Radius[CamPosition - 1])
                bomb2RadiusBar.fillAmount -= 0.004F;
            else
                bomb2RadiusBar.fillAmount += 0.004F;
        if (rand.Next(1,100) == 50)
        {
            var com = Instantiate(comet, new Vector3((float)rand.Next((int)transform.position.x - 70, (int)transform.position.x + 70),
                (float)rand.Next((int)transform.position.y + 20, (int)transform.position.y + 70), 0), Quaternion.identity);
            com.GetComponent<comet>().Go((float)rand.Next(1, 30), (float)rand.Next(-20, 0));
        }
    }

    public void CameraLeft()
    {
        CamPosition--;
        if (CamPosition < 1)
            CamPosition = 4;
    }

    public void CameraRight()
    {
        CamPosition++;
        if (CamPosition > 4)
            CamPosition = 1;
    }

    public void GoScene()
    {
        LoadImage.gameObject.SetActive(true);
        LoadImage.GetComponent<loadScenes>().enabled = true;
        //SceneManager.LoadScene("SampleScene");
    }

    public void Exit1()
    {
        Application.Quit();
    }
}
