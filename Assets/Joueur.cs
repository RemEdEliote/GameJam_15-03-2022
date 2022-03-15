using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public float speed = 0.05f;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        void Start () {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0f * Time.deltaTime, 0f, 1f, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0f * Time.deltaTime, 0f, -0.1f, Space.World);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") !=0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal"), -4.79f, -3.75f), -0f, -3.75f);
            
        }
    }
}
