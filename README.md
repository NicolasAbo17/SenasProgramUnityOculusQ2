

### Descripción
Este es demo de realidad virtual para la clase de Realidad Mixta de la Universidad de los Andes.  La aplicación consiste en un entrenamiento en realidad virtual para el aprendizaje y practica  del alfabeto de señas colombiano. Este entrenador VR se  realizo en Unity y corre en Oculus Quest 2 que usa HandTacking para poder reconocer los gestos de las manos.

Para la practica del alfabeto se tienen dos modos: 

![Instrucciones del entrenador](https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2/blob/master/instrucciones.png)
Instrucciones del entrenador
![Advertencia del entrenador](https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2/blob/master/advertencia.png)
Advertencia del entrenador

El modo entrenador/practica (botón verde) -> Muestra como hacer cada gesto para cada letra. El usuario deberá usar su mano derecha para imitar estos gestos. Cuando el programa detecte un gesto igual o muy similar al pedido, se empezara a contar 5 segundos para “aprobar” el gesto. Por cada gesto correcto se dará un punto. Si el usuario desea saltar a la siguiente letra, en la parte izquierda encuentran un botón amarillo que cambiara a la siguiente letra sin sumar ningún punto.

![modo de entrenador](https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2/blob/master/entrenamiento.png)
modo de entrenador

El modo prueba (botón azul) -> Pretende medir el aprendizaje del alfabeto practicado en el modo entrenador. En esta modo se muestran las letras que el usuario debe representar con la seña correspondiente. Si la seña se representa correctamente, se sumara un punto. Si no recuerda la seña y desea seguir con la otra letras, también esta la opción de saltar a la siguiente con el botón amarillo. 

![modo de prueba](https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2/blob/master/practica.png)
modo de prueba
![saltar letras en el modo de prueba y practica](https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2/blob/master/saltar.png)
saltar letras en el modo de prueba y practica

Hay dos letras, la S y la Z, que en la practica de la vida real se realizan con algún movimiento. Pero, para efectos prácticos del demo, solo se reconocerá el gesto inicial que se muestre en la imagen alusiva. Sin embargo, en dichas imágenes se mostrara el movimiento que se debería hacer con cada gesto para ponerlo en practica.

Finalmente, cuando se desee terminar con el juego, esta el botón rojo que realiza dichas acciones. 

### Instrucciones para desarrollo
1.	Clone el proyecto.  Git clone https://github.com/NicolasAbo17/SenasProgramUnityOculusQ2.git

2.	Abra Unity Hub -> Add, Seleccione el proyecto clonado anteriormente

3.	Seleccionar la versión de Unity(2019.3.24f1) y abra el proyecto 

Nota: Si se quiere hacer una prueba rápida, en el Simulator Controller hay una opción de isTest que carga únicamente 5 letras para probar. Solo debe chequear la casilla y ya puede probarlo como test. 

### Instrucciones de uso del apk
1.	Verificar que en configuración Dispositivos  manos y controladores  activar la opción seguimiento de manos 

2.	Al instalar el APK va a aparecer en la pestaña orígenes desconocidos, esto lo puedes activar utilizando el UI de Oculus para la pagina de aplicaciones 

3.	Correr el APK y seguir las instrucciones de la descripción 

### Referencias
La clase FileHandler, que se usa para guardar y recuperar archivos json que contienen datos de cada una de las letras, fue tomada de: https://github.com/MichelleFuchs/StoringDataJsonUnity 

Las imágnes son sacadas de este video: https://www.youtube.com/watch?v=SKeBZpjWTko
