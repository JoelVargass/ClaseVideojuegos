using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaVictoria : MonoBehaviour
{
    public GameObject panelGanaste;

    void Start()
    {
        if (panelGanaste != null)
        {
            panelGanaste.SetActive(false);
        }
        
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador") || collision.CompareTag("Player"))
        {
            GanarJuego();
        }
    }

    void GanarJuego()
    {
        Debug.Log("¡Has ganado!");

        if (panelGanaste != null)
        {
            panelGanaste.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Falta asignar el panelGanaste en el Inspector.");
        }

        Time.timeScale = 0f;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}