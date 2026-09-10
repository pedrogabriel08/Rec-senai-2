using UnityEngine;


[RequireComponent(typeof(CharacterController))]
    public class Jogador : MonoBehaviour
{
    [Header("Velocidades")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;

    [Header("Mouse")]
    public float mouseSensitivity = 2f;
    public Transform playerCamera; // arraste a câmera filha aqui
    public float maxLookAngle = 89f;

    [Header("Gravidade")]
    public float gravity = -20f; // mantém o jogador no chão; sem pulo

    private CharacterController controller;
    private float cameraPitch = 0f;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;

        // Trava e oculta o cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotaciona personagem no eixo Y (girar corpo)
        transform.Rotate(Vector3.up * mouseX);

        // Rotaciona câmera no eixo X (inclinação), clamped
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);

        if (playerCamera != null)
            playerCamera.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }

    private void HandleMovement()
    {
        // Entrada de movimento local
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Seleciona velocidade (correr com Left Shift)
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        move = move.normalized * speed;

        // Gravidade: aplica sempre para manter o jogador "colado" ao chão (sem pulo)
        if (controller.isGrounded)
        {
            // pequeno valor negativo para garantir contato com o solo
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 velocity = move + Vector3.up * verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
