using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    // Define o �ngulo de rota��o para cada tecla pressionada
    public float rotationAngle = 45f; // �ngulo de rota��o (em graus) por tecla pressionada
    public float rotationSpeed = 200f; // Velocidade de rota��o para suavidade
    private Quaternion targetRotation; // Rota��o alvo

    // Definir o �ngulo de rota��o inicial da c�mera
    private void Start()
    {
        targetRotation = transform.rotation;
    }

    // Atualiza a cada frame
    void Update()
    {
        // Rotacionar no sentido hor�rio ao pressionar "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera(-rotationAngle);
        }
        // Rotacionar no sentido anti-hor�rio ao pressionar "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCamera(rotationAngle);
        }

        // Suaviza a transi��o para a rota��o alvo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Fun��o para atualizar a rota��o alvo da c�mera
    private void RotateCamera(float angle)
    {
        targetRotation *= Quaternion.Euler(0f, angle, 0f); // Aplica a rota��o no eixo Y
    }
}

