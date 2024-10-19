using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  public void JumpForce(Rigidbody2D rig, float jumpForce) {
        if(Input.GetKeyDown(KeyCode.Space)) {
           rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
   }
}
