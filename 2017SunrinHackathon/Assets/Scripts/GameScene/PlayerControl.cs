using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour {
    public static PlayerControl instance;
    public GameObject[] batteryList = new GameObject[6];
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
    public float cmRotation;
    public float battery;
    public int coal;
    public int petroleum;
    public float speed = 3.0f;
    public Stage1SoundManager sm;
    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start () {
        sm.BGM();
        battery = 50;
        gameOver = false;
        realClear = false;
        isGameClear = false;
        cmRotation = 0;
        instance = this;
        coal = 0;
        petroleum = 0;
        onGround = true;
        isTurn = false;
        isJump = false;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene("selectScene");
            }
        }
        if (transform.position.y < -5)
        {
            gameOver = true;
        }
        if (!isGameClear && Time.timeScale!=0)
            battery -= Time.deltaTime * 1.5f;
        if (battery <= 0)
        {
            gameOver = true;
        }
        else
        {
            if (battery >= 50)
            {
                batteryList[5].SetActive(true);
                batteryList[4].SetActive(true);
                batteryList[3].SetActive(true);
                batteryList[2].SetActive(true);
                batteryList[1].SetActive(true);
                batteryList[0].SetActive(true);
            }
            else if(battery >= 40)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(true);
                batteryList[3].SetActive(true);
                batteryList[2].SetActive(true);
                batteryList[1].SetActive(true);
                batteryList[0].SetActive(true);
            }
            else if (battery >= 30)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(false);
                batteryList[3].SetActive(true);
                batteryList[2].SetActive(true);
                batteryList[1].SetActive(true);
                batteryList[0].SetActive(true);
            }
            else if (battery >= 20)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(false);
                batteryList[3].SetActive(false);
                batteryList[2].SetActive(true);
                batteryList[1].SetActive(true);
                batteryList[0].SetActive(true);
            }
            else if (battery >= 10)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(false);
                batteryList[3].SetActive(false);
                batteryList[2].SetActive(false);
                batteryList[1].SetActive(true);
                batteryList[0].SetActive(true);
            }
            else if (battery >= 0)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(false);
                batteryList[3].SetActive(false);
                batteryList[2].SetActive(false);
                batteryList[1].SetActive(false);
                batteryList[0].SetActive(true);
            }
            else if (battery <= 0)
            {
                batteryList[5].SetActive(false);
                batteryList[4].SetActive(false);
                batteryList[3].SetActive(false);
                batteryList[2].SetActive(false);
                batteryList[1].SetActive(false);
                batteryList[0].SetActive(false);
            }
        }
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        if (Input.GetMouseButtonDown(0) && !isGameClear)
        {
            if (Time.timeScale == 0)
            {
                battery = 50;
                Time.timeScale = 1;
            }
            else if (Stage1.instance.StageList[Stage1.instance.index] == 0)
            {
                sm.space();
                if (onGround && transform.position.y >= 0)
                { 
                    rb.velocity = new Vector3(0f, 10f, 0f);
                    onGround = false;
                }
            }
            else if (Stage1.instance.StageList[Stage1.instance.index] == 1)
            {
                sm.space();
                transform.Rotate(Vector3.forward * 90);
                cmRotate = true;
            }
            else if (Stage1.instance.StageList[Stage1.instance.index] == 2)
            {
                sm.space();
                transform.Rotate(-Vector3.forward * 90);
                cmRotate = true;
            }
            if (isJump)
            {
                isJump = false;
                Stage1.instance.index++;
            }
            if (isTurn)
            {
                isTurn = false;
                Stage1.instance.index++;
            }
        }
        if (realClear)
        {
            Time.timeScale = 0;
            clear.SetActive(true);
            if (Input.GetMouseButtonDown(0)){
                SceneManager.LoadScene("Stage1Ending");
            }
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            over.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Stage1");
            }
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
            if (Stage1.instance.StageList[Stage1.instance.index] == 1)
            {
                cmRotation += Time.smoothDeltaTime * 9.0f;
                if (cmRotation > 3)
                {
                    cmRotate = false;
                    cmRotation = 0;
                }
                cm.transform.Rotate(new Vector3(0, 0, cmRotation));

            }
            else if (Stage1.instance.StageList[Stage1.instance.index] == 2)
            {
                cmRotation -= Time.smoothDeltaTime * 9.0f;
                if (cmRotation < -3)
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
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.smoothDeltaTime * 2.0f);
            if (transform.position.y >= 4)
            {
                realClear = true;
            }
        }
        if(transform.position.y > 10.0f && isGameClear)
        {
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Finish")
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
            if (Stage1.instance.StageList[Stage1.instance.index] == 0)
                Stage1.instance.index++;
            isTurn = true;
        }            
        else if (coll.gameObject.tag == "Coal")
        {
            coal++;
            battery += 0.1f;
            if (coal != 0 && coal % 10 == 0)
                speed += 0.1f;
        }
        else if (coll.gameObject.tag == "Petroleum")
        {
            petroleum++;
            battery += 0.1f;
            if (petroleum != 0 && petroleum % 10 == 0)
                speed += 0.1f;
        }
        Destroy(coll.gameObject);
    }
}
