using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public GameObject panelGameOver; // Arrastra aquí tu PanelGameOver desde la jerarquía

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Nave") && collision.gameObject.CompareTag("Pared"))
        {
            Perder();
        }
    }

    public void Perder()
    {
        Debug.Log("¡Has perdido!");
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true); // Muestra la pantalla de Game Over
        }
        Time.timeScale = 0f; // Pausa el tiempo del juego
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Restaura el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}