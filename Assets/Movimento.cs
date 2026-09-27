using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
    private Vector3 velocidadeMovimento;
    
    private float velocidadeAtual;
    private float velocidadeAndar = 3f;
    private float velocidadeCorrer = 7f;
    
    private float gravidade = -9.81f;
    private float alturaPulo = 1.2f;
    private bool estaNoChao;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Verificar se está no chão
        estaNoChao = character.isGrounded;
        if (estaNoChao && velocidadeMovimento.y < 0)
        {
            velocidadeMovimento.y = -2f;
        }

        // 2. Obter entradas de movimento (W, A, S, D)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        inputs = new Vector3(moveX, 0, moveZ);

        // 3. Verificar se há movimento e gerir andar/correr
        if (inputs != Vector3.zero)
        {
            transform.forward = inputs; // Roda o personagem para a direção do movimento
            animator.SetBool("walking", true); // Garante que a animação de andar está ativa

            // Se mantiver o Shift premido, corre; caso contrário, anda
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocidadeAtual = velocidadeCorrer;
                animator.SetBool("running", true);
            }
            else
            {
                velocidadeAtual = velocidadeAndar;
                animator.SetBool("running", false);
            }
        }
        else
        {
            // Se estiver parado, desativa tudo
            animator.SetBool("walking", false);
            animator.SetBool("running", false);
            velocidadeAtual = 0f;
        }
        
        // Aplica o movimento horizontal
        character.Move(inputs * velocidadeAtual * Time.deltaTime);

        // 4. Mecânica de Pulo (Barra de Espaço)
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            velocidadeMovimento.y = Mathf.Sqrt(alturaPulo * -2f * gravidade);
            animator.SetTrigger("jump");
        }

        // 5. Aplicar Gravidade Vertical
        velocidadeMovimento.y += gravidade * Time.deltaTime;
        character.Move(velocidadeMovimento * Time.deltaTime);
    }
}