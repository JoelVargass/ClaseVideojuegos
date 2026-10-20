using UnityEngine;

// Plinko — Avisa al juego cuando la bola llega a una casilla o se pierde.
public class PlinkoBola : MonoBehaviour
{
    public PlinkoJuego juego;
    public float tiempoMaximo = 20f;

    private bool terminada;
    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;

        // Si se sale de la pantalla o se queda atorada demasiado tiempo, se elimina sin puntos.
        if (transform.position.y < -7f || tiempo > tiempoMaximo)
        {
            Terminar(0);
        }
    }

    public void Terminar(int puntos)
    {
        if (terminada)
        {
            return;
        }

        terminada = true;

        if (juego != null)
        {
            juego.BolaTermino(puntos);
        }

        Destroy(gameObject);
    }
}
