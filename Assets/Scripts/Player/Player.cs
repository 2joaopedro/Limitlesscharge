using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    private Movement movement;
    void Start()
    {
        movement = gameObject.AddComponent<Movement>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        movement.Move(rig, speed,anim);
    }
}
