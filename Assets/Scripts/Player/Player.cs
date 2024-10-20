using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    public float jumpForce;
    private Movement movement;
    private Jump jump;
    void Start()
    {
        movement = gameObject.AddComponent<Movement>();
        jump = gameObject.AddComponent<Jump>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        movement.Move(rig, speed,anim);
        jump.JumpForce(rig, jumpForce,speed);
        
    }
}
