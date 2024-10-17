using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    // Define o ângulo de rotação para cada tecla pressionada
    public float rotationAngle = 45f; // Ângulo de rotação (em graus) por tecla pressionada
    public float rotationSpeed = 200f; // Velocidade de rotação para suavidade
    private Quaternion targetRotation; // Rotação alvo

    // Definir o ângulo de rotação inicial da câmera
    private void Start()
    {
        targetRotation = transform.rotation;
    }

    // Atualiza a cada frame
    void Update()
    {
        // Rotacionar no sentido horário ao pressionar "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera(-rotationAngle);
        }
        // Rotacionar no sentido anti-horário ao pressionar "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCamera(rotationAngle);
        }

        // Suaviza a transição para a rotação alvo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Função para atualizar a rotação alvo da câmera
    private void RotateCamera(float angle)
    {
        targetRotation *= Quaternion.Euler(0f, angle, 0f); // Aplica a rotação no eixo Y
    }
}

