using UnityEngine;

// Plinko — Casilla del fondo: suma sus puntos cuando una bola entra en su trigger.
public class PlinkoCasilla : MonoBehaviour
{
    public int puntos = 10;
    public float duracionDestello = 0.3f;

    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;
    private float destello;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlinkoBola bola = other.GetComponent<PlinkoBola>();

        if (bola != null)
        {
            bola.Terminar(puntos);
            destello = duracionDestello;
        }
    }

    void Update()
    {
        if (destello > 0f)
        {
            destello -= Time.deltaTime;
            spriteRenderer.color = Color.Lerp(colorOriginal, Color.white, destello / duracionDestello);
        }
    }

    void OnGUI()
    {
        // Muestra los puntos de la casilla encima de ella.
        Vector3 pantalla = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.6f);
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 18;
        estilo.fontStyle = FontStyle.Bold;
        estilo.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(pantalla.x - 30, Screen.height - pantalla.y - 12, 60, 24), puntos.ToString(), estilo);
    }
}
