using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform relativeTransform;
    public float speed = 1f;
    public float rotateSpeed = 0.2f;

    private int playerID;
    private float input_H, input_V;
    private Animator playerAnim;
    private Vector3 dir;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerID = GetComponent<Player>().playerID;
    }

    void Update()
    {
        if (!GameManager.gameManager.gameOver)
        {
            if (playerID == 0)
            {
                input_H = Input.GetAxisRaw("Horizontal");
                input_V = Input.GetAxisRaw("Vertical");
            }
            else if (playerID == 1)
            {
                input_H = Input.GetAxisRaw("Horizontal2");
                input_V = Input.GetAxisRaw("Vertical2");
            }

            dir = new Vector3(input_H, 0, input_V);

            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
                playerAnim.SetBool("isWalk", true);
            }
            else
            {
                playerAnim.SetBool("isWalk", false);
            }
        }       
    }

    private void FixedUpdate()
    {     
        if(!GameManager.gameManager.gameOver)
            transform.Translate(dir * speed * Time.deltaTime, relativeTransform);
    }
}
