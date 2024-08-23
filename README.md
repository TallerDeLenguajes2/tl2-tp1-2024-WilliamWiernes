# Desarrollo TP N°1 
## Punto 2.a
### :question: ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
De las relaciones que se pueden considero que por:
- Composición (parte de):
    - Pedidos -> Cliente, debido a que si se elimina el pedido el cliente también.
    - Cadetería -> Cadete, un cadete no puede existir sin una cadetería.
- Agregación (tiene un):
    - Cadete -> Pedidos, ya que el cadete no depende de la existencia del pedido.

### :question: ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- Cadetería podría tener métodos como:
    - AgregarCadete(), EliminarCadete(), AsignarPedido(), ReasignarPedido() y alguna opción para AgregarCadetesCSV()
- Y la clase Cadete:
    - JornalACobrar(), AgregarPedido(), EliminarPedido() y por ejemplo poder ContarPedidosEntregados()

### :question: Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
En base a los principios de abstracción (mostrar únicamente información relevante) y ocultamiento (proteger los datos), todos los campos o atributos deberían ser privados, pudiendo acceder a ellos a través de los métodos y propiedades.

### :question: ¿Cómo diseñaría los constructores de cada una de las clases?


### :question: ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?