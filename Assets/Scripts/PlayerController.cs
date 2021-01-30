using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0f;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winTextObject; 
    private int count = 0;
    private int numOfPickups = 0;
    void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numOfPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
        SetCountText();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementX, 0f, movementY) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if(count == numOfPickups)
                winTextObject.gameObject.SetActive(true);
        }
    }

    void SetCountText()
    {
        countText.text = $"Count: {count}";
    }
}
