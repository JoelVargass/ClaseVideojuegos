using UnityEngine;

// Actividad 9 — Reto final: Player reactivo.
// Este script se encarga del movimiento con W A S D y le pide a CambioColor que cambie el color.
public class MovimientoReactivo : MonoBehaviour
{
    public float velocidad = 5f;

    private CambioColor cambioColor;

    void Start()
    {
        cambioColor = GetComponent<CambioColor>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            cambioColor.CambiarColor(Color.green);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            cambioColor.CambiarColor(Color.yellow);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            cambioColor.CambiarColor(Color.red);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            cambioColor.CambiarColor(Color.blue);
        }
    }
}
