using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public void Move(Rigidbody2D rig, float speed, Animator anim) {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        rig.MovePosition(rig.position + movement * speed * Time.deltaTime);

        if(movement.x > 0) {
            anim.SetInteger("Base", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(movement.x < 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetInteger("Base", 1);
        }
        else {
            anim.SetInteger("Base", 0);
        }
    }
}
