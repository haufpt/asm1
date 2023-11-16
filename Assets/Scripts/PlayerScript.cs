using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    
    public ParticleSystem psBui;

    private bool isPlaying = true;
    
    private Animator ani;
    
    private bool isNen;
    

   public int diemCoinMacDinh=0;

    public TMP_Text txtCoin;
    
    public int diemTimeMacDinh=0;

    public TMP_Text txtTime;
    
    public TMP_Text txtName;

    public TMP_Text textMetter;

    public TMP_Text Metter;
    public TMP_Text Score;
    public GameObject panelGameOver;
    private float distanceTraveled = 0.0f; // Khoảng cách nhân vật đã di chuyển
    private float lastXPosition; // Vị trí của nhân vật trong khung hình trước đó
    
    public AudioSource soundCoin;
    
   

    public AudioSource soundTime;
    


    public ThanhMau thanhMau;
    public float mauHienTai;
    public float mauToiDa = 100;


    bool isRight;
    bool isLeft;
    bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
        String name = PlayerPrefs.GetString("UserName", "");
        
        txtName.text = name;

        if (PlayerPrefs.GetInt("countCoin"+name) <= 0 || PlayerPrefs.GetInt("countCoin"+name) == null)
        {
            PlayerPrefs.SetInt("countCoin"+name, diemCoinMacDinh);
            PlayerPrefs.SetInt("countTime"+name, diemTimeMacDinh);
            
            txtTime.text = "" + PlayerPrefs.GetInt("countTime"+name, 0);
            txtCoin.text = "" + PlayerPrefs.GetInt("countCoin"+name, 0);
            
        }

        else 
        {
            txtTime.text = "" + PlayerPrefs.GetInt("countTime"+name, 0);
            txtCoin.text = "" + PlayerPrefs.GetInt("countCoin"+name, 0);
        }

        mauHienTai=mauToiDa;
        thanhMau.capNhatThanhMau(mauHienTai, mauToiDa);

        textMetter.text = ""+(int)distanceTraveled;
        lastXPosition = transform.position.x;
        

    }

   
    void Update()
    {

        
        Vector3 vector3 = transform.position;
        vector3.y = vector3.y + 1.5f;
        txtName.transform.position = vector3;
       
        Vector2 scale = transform.localScale;
        //moi vo game player dung yen
        ani.SetBool("isRunning", false);
        //end
        
        //bui theo sau lung player khi move
        Quaternion rotation = psBui.transform.localRotation;
        

        if(isRight){
             //bui
            rotation.y = 180;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            //end
            
            //animation
            ani.SetBool("isRunning", true);
            //end
            
            scale.x = 1;
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }

        if(isLeft){
             //bui
            rotation.y = 0;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            //end
            
            //animation
            ani.SetBool("isRunning", true);
            //end
            
            scale.x = -1;
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }

        if(isUp){
             ani.SetBool("isRunning", false);

        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            //bui
            rotation.y = 180;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            //end
            
            //animation
            ani.SetBool("isRunning", true);
            //end
            
            scale.x = 1;
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //bui
            rotation.y = 0;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            //end
            
            //animation
            ani.SetBool("isRunning", true);
            //end
            
            scale.x = -1;
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        //update scale
        transform.localScale = scale;
        
        
        //nhay len
        if (Input.GetKey(KeyCode.Space))
        {
            if (isNen)
            {
                //transform.Translate(Vector3.up * 5f * Time.deltaTime);
                rb.AddForce(new Vector2(0, 270));
                isNen = false;
                 ani.SetBool("isRunning", false);
            }
           
        }
        //end
        
        //get key: nhan giu nut
        //get key down; nhan phim 1 lan
        //get key up; tha ra
        
        //show menu and pause game
        

        

        // Tính toán khoảng cách nhân vật đã di chuyển trên trục x
        float deltaX = Mathf.Abs(transform.position.x - lastXPosition);
        distanceTraveled += deltaX;
        textMetter.text = ""+(int)distanceTraveled;
        // Cập nhật vị trí x của nhân vật trong khung hình trước đó
        lastXPosition = transform.position.x;



        
    }

    //khi player cham vao gach co tag la nen
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "nen")
        {
            isNen = true;
        }

        if (other.gameObject.tag == "trai")
        {
            mauHienTai -=10;
            thanhMau.capNhatThanhMau(mauHienTai, mauToiDa);
            if(mauHienTai<0){

                
                Metter.text = ""+(int)distanceTraveled;
                Score.text = ""+txtCoin.text;
                panelGameOver.SetActive(true);
                Time.timeScale = 0;
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            
            String name = PlayerPrefs.GetString("UserName", "");
            
            soundCoin.Play();
            
            int coin = PlayerPrefs.GetInt("countCoin"+name, 0);
            coin++;
            txtCoin.text = "" + coin;
            PlayerPrefs.SetInt("countCoin"+name, coin);

            
            Destroy(other.gameObject);
         
        }
        if (other.gameObject.tag == "time")
        {
           
            String name = PlayerPrefs.GetString("UserName", "");
            soundTime.Play();
            
            int time = PlayerPrefs.GetInt("countTime"+name, 0);
            time+=10;
            txtTime.text = "" + time;
            PlayerPrefs.SetInt("countTime"+name, time);
            
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "key")
        {

            SceneManager.LoadScene(2);
        }
         if (other.gameObject.tag == "keyend")
        {
            SceneManager.LoadScene(3);
        }
    }

    public void leftButton(){
        isUp=false;
        isLeft=true;
        isRight=false;
        
    }

    public void rightButton(){
        isUp=false;
        isRight=true;
        isLeft=false;
    }

    public void upButton(){
        isLeft=false;
        isRight=false;
        isUp=true;
    }

    public void jumpButton(){
         rb.AddForce(new Vector2(0, 270));
    }



}
