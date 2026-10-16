using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            Debug.Log("¡El jugador se pinchó!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}