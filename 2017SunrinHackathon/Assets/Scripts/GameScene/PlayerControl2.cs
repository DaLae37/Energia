using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerControl2 : MonoBehaviour
{
    public GameObject pause;
    public Image BatteryImage;
    public static PlayerControl2 instance;
    public GameObject clear;
    public GameObject over;
    public bool onGround;
    public Camera cm;
    private Rigidbody rb;
    public bool gameOver;
    public bool isGameClear;
    public bool isTurn;
    public bool isJump;
    public bool cmRotate;
    public bool realClear;
    public bool isPause;
    public float cmRotation;
    public float battery;
    public int ura;
    public float speed;
    public Stage2SoundManager sm;
    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        sm.BGM();
        battery = 100;
        gameOver = false;
        isPause = false;
        realClear = false;
        isGameClear = false;
        cmRotation = 0;
        instance = this;
        ura = 0;
        speed = 3.5f;
        onGround = true;
        isTurn = false;
        isJump = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Pause();
            }
        }
        if (transform.position.y < -5)
        {
            gameOver = true;
        }
        if (!isGameClear && Time.timeScale != 0)
            battery -= Time.deltaTime * 2.8f;
        if (battery <= 0)
        {
            gameOver = true;
        }
        else
        {
            BatteryImage.fillAmount = (float)(battery / 100f);
        }
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        if (Input.GetMouseButtonDown(0) && !isGameClear)
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (Time.timeScale == 0)
                {
                    battery = 100;
                    Time.timeScale = 1;
                }
                else if (Stage2.instance.StageList[Stage2.instance.index] == 0)
                {
                    sm.space();
                    if (onGround && transform.position.y >= 0)
                    {
                        rb.velocity = new Vector3(0f, 10f, 0f);
                        onGround = false;
                    }
                }
                else if (Stage2.instance.StageList[Stage2.instance.index] == 1)
                {
                    sm.space();
                    transform.Rotate(Vector3.forward * 90);
                    cmRotate = true;
                }
                else if (Stage2.instance.StageList[Stage2.instance.index] == 2)
                {
                    sm.space();
                    transform.Rotate(-Vector3.forward * 90);
                    cmRotate = true;
                }
                if (isJump)
                {
                    isJump = false;
                    Stage2.instance.index++;
                }
                if (isTurn)
                {
                    isTurn = false;
                    Stage2.instance.index++;
                }
            }
        }
        if (realClear)
        {
            Time.timeScale = 0;
            clear.SetActive(true);
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            over.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (!isGameClear)
        {
            transform.position += transform.up * Time.smoothDeltaTime * speed;
        }
        cm.transform.position = new Vector3(transform.position.x, cm.transform.position.y, transform.position.z);
        if (cmRotate)
        {
            if (Stage2.instance.StageList[Stage2.instance.index] == 1)
            {
                cmRotation += Time.smoothDeltaTime * 9.0f;
                if (cmRotation > 5)
                {
                    cmRotate = false;
                    cmRotation = 0;
                }
                cm.transform.Rotate(new Vector3(0, 0, cmRotation));

            }
            else if (Stage2.instance.StageList[Stage2.instance.index] == 2)
            {
                cmRotation -= Time.smoothDeltaTime * 9.0f;
                if (cmRotation < -5)
                {
                    cmRotate = false;
                    cmRotation = 0;
                }
                cm.transform.Rotate(new Vector3(0, 0, cmRotation));
            }
        }
        if (isGameClear)
        {
            rb.useGravity = false;
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.smoothDeltaTime * 2.0f, transform.position.z);
            if (transform.position.y >= 4)
            {
                realClear = true;
            }
        }
        if (transform.position.y > 10.0f && isGameClear)
        {
            Time.timeScale = 0;
        }
    }
    public void Pause()
    {
        if (!isPause)
        {
            isPause = true;
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isPause)
        {
            isPause = false;
            pause.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            Debug.Log("clear");
            isGameClear = true;
        }
        if (coll.gameObject.tag == "Ground" && onGround == false)
            onGround = true;
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Jump")
        {
            isJump = true;
        }
        else if (coll.gameObject.tag == "Turn")
        {
            if (Stage2.instance.StageList[Stage2.instance.index] == 0)
                Stage2.instance.index++;
            isTurn = true;
        }
        else if (coll.gameObject.tag == "Coal")
        {
            ura++;
            battery += 0.1f;
            if (ura != 0 && ura % 10 == 0)
                speed += 0.1f;
        }
        Destroy(coll.gameObject);
    }
}
