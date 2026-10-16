using UnityEngine;

public class JugadorControllerJetpack : MonoBehaviour
{
    public float fuerza = 2.6f;

    public float fuerzaSalto = 3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // movimiento 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(
            horizontal,
            vertical
        );

        rb.AddForce(direccion * fuerza);
    }

    void Update()
    {


        // salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(
                Vector2.up * fuerzaSalto,
                ForceMode2D.Impulse
            );
        }


        // dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float direccionHorizontal = Input.GetAxisRaw("Horizontal");

            if (direccionHorizontal == 0) 
            {
                direccionHorizontal = 1; 
            }

            transform.Translate(new Vector2(direccionHorizontal, 0) * 1.2f);
        }
    }
}