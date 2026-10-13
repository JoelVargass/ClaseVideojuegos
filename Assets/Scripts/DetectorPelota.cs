using UnityEngine;

public class DetectorPelota : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la pelota choca con una pared
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Busca el script de control de juego y ejecuta la derrota
            ControlJuego control = FindAnyObjectByType<ControlJuego>();
            if (control != null)
            {
                control.Perder();
            }
        }
    }
}