using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isGrounded; // Para verificar se está no chão
    private bool isJumping;  // Verificar se está no meio de um salto
    public float airControl = 0.2f; // Controle de movimento no ar (menor que 1 para reduzir no ar)
    public float gravityScale = 2f; // Controle da gravidade extra quando caindo
    private float coyoteTime = 0.2f; // Tempo de tolerância após sair da plataforma
    private float coyoteTimeCounter; // Contador de coyote time
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D
    }

    public void JumpForce(Rigidbody2D rig, float jumpForce, float speed)
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || coyoteTimeCounter > 0))
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce); // Aplica o pulo diretamente na velocidade
            isJumping = true;
            coyoteTimeCounter = 0f; // Reseta o coyote time quando pular
        }

        // Controle da gravidade ao cair (queda mais rápida)
        if (rig.velocity.y < 0)
        {
            rig.velocity += Vector2.up * Physics2D.gravity.y * (gravityScale - 1) * Time.deltaTime;
        }

        // Permite o movimento no ar, mas com controle reduzido
        float horizontal = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(horizontal * speed * (isGrounded ? 1f : airControl), rig.velocity.y);
    }

    void Update()
    {
        // Atualiza o contador de coyote time
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // Define que o jogador está no chão
            isJumping = false; // Reseta o estado de pulo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false; // Define que o jogador não está mais no chão
        }
    }
}
