using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginUser : MonoBehaviour
{
    public TMP_InputField edtUser;

    
    public Selectable first;

    private EventSystem eventSystem;

    public Button btnLogin;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        first.Select();
        edtUser.text = PlayerPrefs.GetString("UserName", "");
    }

    // Update is called once per frame
    void Update()
    {
        //nhan enter de login
        if (Input.GetKey(KeyCode.Return))
        {
            btnLogin.onClick.Invoke();
        }
        //end

        // //nhan nut tab de chuyen
        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     //FindSelectableOnDown di chuyen xuong
        //     Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
        //     if (next != null)
        //     {
        //         next.Select();
        //     }
        // }
        // //end
        
        // //nhan nut shift de di chuyen

        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     //FindSelectableOnUp di chuyen len
        //     Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
        //     if (next != null)
        //     {
        //         next.Select();
        //     }
        // }
        // //end
    }

    public void quaMan()
    {
        PlayerPrefs.SetString("UserName", edtUser.text);
        SceneManager.LoadScene(1);
    }
    
}
