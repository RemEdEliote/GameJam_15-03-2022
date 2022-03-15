using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class Joueur : MonoBehaviour
{
    public float speed = 0.05f;
    public float flySpeed = 1f;
    public float minPos = -3.75f;
    public float maxPos = 3.75f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoretime;
    private int _scoreValue;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                Mathf.Clamp(transform.position.z + Input.GetAxis("Horizontal") * speed, minPos, maxPos));
        }

        transform.position += transform.up * flySpeed;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Miam"))
        {
           // _scoreValue= _scoreValue+ 10;
           // scoreText.text = "temps restant : " + _scoreValue;
            _scoreValue++;
            scoreText.text = "Score : " + _scoreValue;
            Destroy((other.gameObject));
        } 
    }
   
}
