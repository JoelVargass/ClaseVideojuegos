using UnityEngine;
using UnityEngine.InputSystem;

// Plinko — Lanzador controlado con el New Input System.
// Move (A/D o flechas) mueve el lanzador y Jump (espacio) suelta una bola.
public class PlinkoJuego : MonoBehaviour
{
    public float velocidad = 6f;
    public float limiteX = 4f;
    public int bolasIniciales = 10;
    public Sprite spriteBola;
    public float radioBola = 0.2f;
    public float rebote = 0.5f;

    private Vector2 movimiento;
    private int puntaje;
    private int bolasRestantes;
    private int bolasEnJuego;
    private PhysicsMaterial2D materialBola;

    void Awake()
    {
        materialBola = new PhysicsMaterial2D("MaterialBola");
        materialBola.bounciness = rebote;
        materialBola.friction = 0.1f;
        Reiniciar();
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        if (bolasRestantes > 0)
        {
            SoltarBola();
        }
        else if (bolasEnJuego == 0)
        {
            Reiniciar();
        }
    }

    void Update()
    {
        Vector3 posicion = transform.position;
        posicion.x += movimiento.x * velocidad * Time.deltaTime;
        posicion.x = Mathf.Clamp(posicion.x, -limiteX, limiteX);
        transform.position = posicion;
    }

    void SoltarBola()
    {
        bolasRestantes--;
        bolasEnJuego++;

        GameObject bola = new GameObject("Bola");
        // Un pequeño desfase aleatorio para que dos bolas soltadas en el mismo lugar no caigan igual.
        bola.transform.position = transform.position
            + Vector3.down * 0.4f
            + Vector3.right * Random.Range(-0.05f, 0.05f);
        bola.transform.localScale = Vector3.one * radioBola * 2f;

        SpriteRenderer sr = bola.AddComponent<SpriteRenderer>();
        sr.sprite = spriteBola;
        sr.color = Color.HSVToRGB(Random.value, 0.6f, 1f);
        sr.sortingOrder = 2;

        CircleCollider2D colisionador = bola.AddComponent<CircleCollider2D>();
        colisionador.sharedMaterial = materialBola;

        Rigidbody2D rb = bola.AddComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        bola.AddComponent<PlinkoBola>().juego = this;
    }

    public void BolaTermino(int puntos)
    {
        puntaje += puntos;
        bolasEnJuego--;

        if (puntos > 0)
        {
            Debug.Log("+" + puntos + " puntos. Total: " + puntaje);
        }
    }

    void Reiniciar()
    {
        puntaje = 0;
        bolasRestantes = bolasIniciales;
    }

    void OnGUI()
    {
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 22;
        estilo.fontStyle = FontStyle.Bold;

        GUI.Label(new Rect(20, 15, 400, 30), "Puntaje: " + puntaje, estilo);
        GUI.Label(new Rect(20, 45, 400, 30), "Bolas: " + bolasRestantes, estilo);

        if (bolasRestantes == 0 && bolasEnJuego == 0)
        {
            GUI.Label(new Rect(20, 85, 600, 30), "¡Juego terminado! Espacio para reiniciar", estilo);
        }
    }
}
