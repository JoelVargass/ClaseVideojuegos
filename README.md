# Notas
Videojuego

## Ejercicio 1 — Movimiento directo con Transform

![Escena01 de desplazamientio lateral](image.png)

* **¿Qué sucede cuando duplicas la velocidad?**
  R= El objeto comienza a desplazarse con más fluidez en el eje x

* **¿Cambiar la escala modifica la velocidad?**
  R= No, solo hará que visualmente ocupe mas espacio horizontalmente y menos verticalmente.

* **¿Por qué el objeto puede seguir desplazándose sin tener un Rigidbody2D?**
  R= Porque el objeto solo está moviendose entre coordenadas, es decir, solo está desplazándosela en eje x, no tiene físicas de caída o peso añadidas

* **¿Qué pasaría si intentaras utilizar este mismo enfoque para simular una pelota que rebota sobre una plataforma?**
  R= Fallaría debido que para que la pelota rebote necesitamos físicas y al estar con un objeto sin rigidbody la pelota atravesaría el objeto y caería al infinito

---

## Ejercicio 2 — Impulsos y fuerzas con Rigidbody2D
![Escena02 impulso vertical de pelota](image-1.png)

* **¿Qué sucede cuando aumentas la fuerza del impulso?**
  R= El objeto se eleva mas en el eye vertical

* **¿Qué cambia cuando Gravity Scale es igual a cero?**
  R= La pelota ya no desciende y comienza a elevarse lentamente de acuerdo a la fuerza aplicada, mientras menos sea la fuerza menos es lo que tarda en frenar, al contrario si aplicamos mas fuerza el objeto comienza a elevarse cada vez más.

* **¿Por qué la pelota cae más rápidamente cuando aumentas la escala de gravedad?**
  R= Porque al obtener más atracción hacía abajo el objeto tiende a descender con mayor velocidad

* **¿Qué diferencia hay entre mantener una fuerza continua y aplicar un impulso?**
  R= Al aplicar una fuerza continua el objeto no tendrá una fuerza opuesta que lo arrastre hacía abajo, mientras que al aplicar un impulso se aplica una fuerza de un solo momento.

* **¿Qué función cumple el Rigidbody2D en esta escena?**
  R= En el caso de la pelota define la colisión con otro objeto, la masa del objeto y la gravedad aplicada, al verse modificados estos aspectos hacen que la pelota sea mas pesada, con la gravedad que no tenga caída o al contrario obtener mayor fuerza y velocidad de caída

---

## Ejercicio 3 — Velocidad, gravedad y colisiones

![Escena03 Fuerza aplicada de manera horizontal ](image-4.png)

* **¿Por qué la pelota comienza a moverse horizontalmente?**
  R= Porque usamos linearVelocity en el vector 2 aplicando la velocidadHorizontal de 4f para que empiece con una fuerza horizontal al iniciar la simulación.

* **¿Por qué termina cayendo si su velocidad vertical inicial es cero?**
  R= Inicia en 0 pero la gravedad por si sola permita que gane velocidad al iniciar la simulación.

* **¿Qué diferencia observas entre asignar linearVelocity y aplicar un impulso con AddForce()?**
  R= con linearVelocity aplico una fuerza inicial ignorando toda aquella fuerza con la que ya viene y Addforce  aplica una fuerza de golpe, pero toma en cuenta la velocidad e inercia previa del objeto.

* **¿Qué sucede cuando desactivas la gravedad?**
  R= Cuando desactivo la gravedad el objeto no caerá y seguirá una trayectoria en el eje x de acuerdo a la fuerza aplicada hasta detenerse eventualmente.

* **¿Qué papel desempeñan los colliders?**
  R= Los colliders permiten al objeto detectar la interacción o choque con otros objetos

* **¿Por qué cambiar el material físico puede modificar el rebote?**
  R= Permite que con la fuerza del rebote se aplique una fuerza como una reacción de rechazo acorde a la fuerza con la que viene el objeto con el que colisiona.

* **Linear Damping:**
  Aplica una fuerza o lentitud como si fuera una pared invisible que dificulta el movimiento

---

## Tabla de Pruebas

| Prueba | Fuerza de nave | Gravedad de pelota | Resultado observado |
| :---: | :---: | :---: | :--- |
| **1** | 4 | 1 | La fuerza reducida de la nave fue insuficiente para desplazarla con rapidez, lo que provocó que el impacto de la pelota la desequilibrara y volcara con facilidad al no alcanzar a cubrir el extremo a tiempo. |
| **2** | 8 | 1 | Al duplicar la fuerza, la nave respondió con mayor agilidad; sin embargo, al no haber amortiguamiento o control de inercia, la pelota generó un impacto brusco en los extremos que terminó volteando la nave repentinamente. |
| **3** | 8 | 2 | La pelota cae con mayor velocidad y aplicando más fuerza al impactar con la nave, al tener mas gravedad aplicada el rebote se dificulta por ende aparenta ser más pesado. |


## Reflexión final

1. **¿En qué se diferencia Transform.Translate() de Rigidbody2D.AddForce()?**

Transform.Translate() mueve el objeto modificando sus coordenadas, sin involucrar físicas ni masa. Al contrario de Rigidbody2D.AddForce() que aplica una fuerza sobre un objeto físico, la cual interactúa con la masa y las colisiones del entorno.

2. **¿Qué diferencia hay entre aplicar un impulso y asignar linearVelocity?**

Asignar linearVelocity establece una velocidad inicial directa ignorando la inercia o la fuerza con la que el objeto ya venía, mientras que al aplicar con AddForce() ejerce una fuerza de golpe que se suma con la velocidad e inercia previa del objeto.

3. **¿Qué papel desempeña la gravedad?**

Actúa como una fuerza constante que atrae los objetos hacia abajo haciendo que los objetos ganen velocidad y desciendan de acuerdo a los valores de la gravedad aplicados.

4. **¿Por qué necesitamos colliders para detectar contactos físicos?**
Porque los colliders definen la forma y los límites de los objetos; sin ellos, el motor de físicas que usa Unity no sabría en qué momento exacto ocurre un choque o interacción y los elementos se atravesarían mutuamente.

5. **¿Qué propiedad modificaste para mejorar el equilibrio?**

Modifiqué la fuerza de desplazamiento de la nave y la gravedad aplicada a la pelota, además modifiqué en Constraints el freeze rotation z para evitar que al rebotar con la nave esta se volteé con la fuerza aplicada por la pelota y así facilitar el juego.

6. **¿Qué problema encontraste durante las pruebas y cómo lo resolviste?**

El principal problema fue que el impacto de la pelota desequilibraba y volcaba la nave fácilmente, y en otras pruebas el empuje era demasiado brusco en los extremos. Lo resolví experimentando con distintas combinaciones de fuerza en la nave y escala de gravedad en la pelota para comprender cómo equilibrar el peso y la velocidad de reacción de la nave.

7. **Si tuvieras que construir un proyectil, ¿qué técnica elegirías y por qué?**

Elegiría linearvelocity o un impulso con AddForce(), ya que al tratarse de un proyectil necesito que responda a la física, tenga velocidad inicial controlada y pueda colisionar o verse afectado por la gravedad al ser disparado (esto siendo opcional).

8. **¿Qué cambiarías si quisieras una nave que se desplazara de manera más controlada y sin inercia?**

Ahora que comprendí y descubrí Linear Damping jugaría con su configuración para aumentar la fuerza o fricción que me permite aplciar para que la nave frene al instante en cuanto el jugador deje de presionar las teclas.

---

# Clase — New Input System

## Ejercicio 1 — Configurar las acciones de entrada

* **¿Por qué creamos una acción llamada `Move` en lugar de escribir cada tecla en el script?**
  R= Para que el script solo reciba la dirección a la que se quiere mover el jugador sin importar qué tecla se presionó, así las teclas se configuran desde el editor y se pueden cambiar sin tocar el código.

* **¿Qué diferencia existe entre una acción y un binding?**
  R= La acción es lo que el jugador quiere hacer (moverse, saltar o cambiar de color) y el binding es la tecla o botón que activa esa acción, por ejemplo la barra espaciadora para `Jump`.

* **¿Por qué `Move` utiliza `Vector2`?**
  R= Porque el movimiento necesita dos ejes al mismo tiempo, el horizontal (x) y el vertical (y), con un solo valor no podríamos representar una diagonal.

* **¿Qué ventaja tiene asignar WASD y las flechas a una misma acción?**
  R= Que el jugador puede usar la distribución que le resulte más cómoda y el script sigue funcionando igual, porque ambas mandan el mismo valor a la acción `Move`.

* **Si quisiéramos agregar un gamepad, ¿qué parte de la configuración podríamos ampliar?**
  R= Los bindings de cada acción dentro de `PlayerControls`, por ejemplo agregar el stick izquierdo a `Move` y un botón del control a `Jump`, sin modificar los scripts.

---

## Ejercicio 2 — Mover un personaje con el New Input System

* **¿Qué función cumple `OnMove()`?**
  R= Recibe el valor de la acción `Move` cada vez que cambia y lo guarda en la variable `movimiento`, para que después `Update()` lo use para mover al personaje.

* **¿Por qué no utilizamos `Input.GetKey()`?**
  R= Porque ahora el proyecto usa el New Input System y con él desactivamos el sistema clásico, además así el script ya no depende de teclas específicas sino de acciones.

* **¿Qué relación existe entre `PlayerInput` y `MovimientoInput`?**
  R= `PlayerInput` es el que lee las acciones de `PlayerControls` y con `Send Messages` le manda el mensaje `OnMove` a `MovimientoInput`, que es quien realmente mueve al objeto.

* **¿Qué ocurriría si el nombre de la acción fuera `Movement` y el método siguiera llamándose `OnMove`?**
  R= El personaje no se movería, porque `PlayerInput` buscaría un método llamado `OnMovement` y al no encontrarlo el mensaje no llegaría a ningún lado.

* **¿Por qué podemos cambiar las teclas sin modificar el código?**
  R= Porque las teclas están guardadas en los bindings del archivo `PlayerControls` y el script solo conoce el nombre de la acción.

* **¿Qué sucede al presionar dos direcciones a la vez?**
  R= El personaje se mueve en diagonal pero no más rápido, porque el `2D Vector Composite` normaliza el vector por defecto (modo Digital Normalized). Si se cambia el modo a Digital la diagonal sí va más rápido, y en código se podría controlar con `movimiento.normalized`.

---

## Ejercicio 3 — Fuerzas, impulso y cambio de color

* **¿Qué diferencia existe entre el movimiento del ejercicio 2 y el del ejercicio 3?**
  R= En el ejercicio 2 el objeto solo cambia sus coordenadas con `Transform.Translate()` y se detiene al soltar la tecla, en el ejercicio 3 se le aplica una fuerza al `Rigidbody2D`, por lo que acelera y sigue avanzando por inercia después de soltar.

* **¿Por qué utilizamos `FixedUpdate()` para aplicar fuerzas?**
  R= Porque las físicas se calculan en intervalos fijos de tiempo, al aplicar la fuerza ahí el movimiento es constante y no depende de los FPS.

* **¿Qué función cumple `ForceMode2D.Impulse`?**
  R= Aplica toda la fuerza de golpe en un solo momento, por eso el objeto sale disparado hacia arriba al presionar espacio en lugar de ir acelerando poco a poco.

* **¿Por qué el cambio de color no necesita modificar el `Rigidbody2D`?**
  R= Porque el color lo controla el `SpriteRenderer`, que solo se encarga de cómo se ve el objeto, no de sus físicas.

* **¿Qué ventaja tiene separar el movimiento y el cambio de color en scripts diferentes?**
  R= Que cada script tiene una sola tarea, así puedo reutilizar el cambio de color en otro objeto (como en la nave del reto) o modificar el movimiento sin afectar lo demás.

---

## Reto final — Nave de equilibrio con New Input System

* **Personalizar controles:**
  R= Agregué la tecla `Enter` como segundo binding de `Jump` desde Input Actions y al presionarla la pelota recibe el impulso igual que con espacio, sin cambiar nada en `PelotaInput`.

* **Detectar la caída:**
  R= Al mover la nave y dejar caer la pelota la consola muestra el mensaje "La pelota cayó al suelo."

## Tabla de Pruebas

| Prueba | Fuerza de nave | Gravedad de pelota | Resultado observado |
| :---: | :---: | :---: | :--- |
| **1** | 8 | 1 | Con los valores de la guía (masa de la pelota 1 e impulso 4) el peso de la pelota es mayor que la fuerza de la nave, por lo que la nave se hunde hasta el suelo aunque se mantenga presionada W. Además, si la pelota cae un poco descentrada la nave se inclina y la pelota termina cayendo. |
| **2** | 8 | 1 | Activé Freeze Rotation Z en la nave y bajé la masa de la pelota a 0.33, la nave ya no se voltea y W sí logra subirla, pero sin presionar W se sigue hundiendo y al soltar las teclas se desliza mucho por la inercia. |
| **3** | 20 | 1 | Agregué Linear Damping de 3, la nave se mueve más rápido pero todavía se desliza al soltar y al frenar la pelota sale rodando y cae al suelo. |
| **4** | 60 | 1 | Subí la masa de la nave a 3, el Linear Damping a 6 y bajé la masa de la pelota a 0.25 con impulso de 1.5. La nave frena casi al instante al soltar las teclas, los golpes de la pelota casi no la mueven y solo baja lentamente, así que basta con presionar W de vez en cuando. Esta fue la configuración que dejé. |
| **5** | 60 | 0.7 | La pelota sube más alto y tarda más en caer, lo que da más tiempo para acomodar la nave, pero se acerca demasiado al borde de la cámara, por eso preferí dejar la gravedad en 1. |

## Reflexión final

1. **¿Qué diferencia existe entre una acción y un binding?**

La acción es lo que el jugador quiere hacer, como moverse o saltar, mientras que el binding es la tecla o botón con el que se activa esa acción.

2. **¿Por qué una acción `Move` puede utilizar varias distribuciones de teclas?**

Porque una acción puede tener varios bindings, tanto WASD como las flechas mandan el mismo `Vector2`, así que al script le llega la misma información sin importar cuál se use.

3. **¿Qué función cumple `PlayerInput`?**

Conecta el archivo de acciones `PlayerControls` con el objeto y se encarga de avisarle a los scripts mediante mensajes como `OnMove`, `OnJump` u `OnChangeColor` cuando el jugador activa una acción.

4. **¿Qué relación existe entre `OnMove` y la acción `Move`?**

`PlayerInput` busca un método con el prefijo `On` seguido del nombre de la acción, por eso la acción `Move` llama al método `OnMove`, si los nombres no coinciden el método nunca se ejecuta.

5. **¿Qué diferencias encontraste entre utilizar `Transform` y aplicar fuerzas?**

Con `Transform` el objeto se mueve exactamente lo que le indico y se detiene al soltar la tecla, pero no tiene físicas. Con fuerzas el objeto acelera, tiene inercia y reacciona a los choques, lo cual es más realista pero hay que ajustar la masa y el damping para que sea fácil de controlar.

6. **¿Qué problema encontraste durante la migración?**

Al dejar activo solo el New Input System las escenas anteriores dejaron de funcionar y marcan error, porque sus scripts todavía usan `Input.GetKey()`. También, con los valores de la guía la pelota hundía la nave hasta el suelo, lo resolví aumentando la masa y el Linear Damping de la nave y bajando la masa de la pelota.

7. **¿Cómo agregarías un gamepad a este sistema?**

Agregando nuevos bindings del gamepad a las acciones que ya existen en `PlayerControls`, como el stick izquierdo para `Move` y un botón para `Jump`, sin necesidad de modificar los scripts.

8. **¿Qué ventajas tendría separar los mapas de acciones de distintos estados del juego?**

Que solo se activen las acciones que corresponden en cada momento, por ejemplo un mapa para jugar y otro para un menú de pausa, así una misma tecla no activa cosas que no debería. También ayudaría a que la nave y la pelota no reciban las mismas entradas.

**Ventajas del New Input System frente al sistema clásico:**

Permite separar lo que hace el jugador de las teclas que usa, se pueden asignar varios controles a una misma acción, los controles se cambian desde el editor sin tocar el código y es más fácil agregar otros dispositivos como un gamepad.
