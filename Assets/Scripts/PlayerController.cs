using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject HealthBar;

    public float time = 100;
    public Text timeTxt;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed);

        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
                moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        time -= Time.deltaTime;
        HealthBar.GetComponent<Slider>().value += Time.deltaTime;
        timeTxt.text = ((int)time).ToString();

        if (HealthBar.GetComponent<Slider>().value == 100)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
            



    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Adam":
                panel.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case "Kadin":
                panel2.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.Confined;
                PlayerPrefs.SetInt("yildiz", PlayerPrefs.GetInt("yildiz") + 1);
                break;
            case "KotuAdam":
                panel3.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.Confined;
                break;

        }
        
        

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButonDevam()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        HealthBar.GetComponent<Slider>().value += 5;
    }
}
