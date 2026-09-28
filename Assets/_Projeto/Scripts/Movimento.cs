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

        // 3. Verificar se há movimento e gerir andar/correr com a Blend Tree
        if (inputs != Vector3.zero)
        {
            transform.forward = inputs; // Roda o personagem para a direção do movimento

            // Se mantiver o Shift premido, corre; caso contrário, anda
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocidadeAtual = velocidadeCorrer;
                animator.SetFloat("Velocidade", 1f); // Valor 1 = Running na Blend Tree
            }
            else
            {
                velocidadeAtual = velocidadeAndar;
                animator.SetFloat("Velocidade", 0.5f); // Valor 0.5 = Walking na Blend Tree
            }
        }
        else
        {
            // Se estiver parado, zera a velocidade na Unity e na Blend Tree
            velocidadeAtual = 0f;
            animator.SetFloat("Velocidade", 0f); // Valor 0 = Idle na Blend Tree
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