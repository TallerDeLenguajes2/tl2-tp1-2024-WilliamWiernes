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
    - AsignarPedido(), ReasignarPedido() y alguna opción para AgregarCadetesCSV()
- Y la clase Cadete:
    - JornalACobrar() y por ejemplo poder ContarPedidosEntregados()

### :question: Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
En base a los principios de abstracción (mostrar únicamente información relevante) y ocultamiento (proteger los datos), todos los campos o atributos deberían ser privados, pudiendo acceder a ellos a través de los métodos y propiedades.

### :question: ¿Cómo diseñaría los constructores de cada una de las clases?
El diseño de los constructores se basa en el tipo de relaciones que existen entre las clases. Por ejemplo, para la clase Cadeteria se podría pasar una lista de Cadetes o genera una vacía utilizando métodos y propiedades para rellanarla después. En este caso se hace uso de la segunda opción, debido a la relación de composición que presentan estas dos clases, de forma que si una instancia de cadeteria se elimina su lista de cadetes también lo hará. Este concepto también se puede ver aplicado en la clase Pedido en relación a Cliente.

### :question: ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
Se podría cambiar el tipo de relación entre la clase Pedido y Cliente, y de esta manera que los clientes puedan existir de manera independiente. Con esto se lograría cada cliente pueda tener varios pedidos, siendo esta una forma de abordar el problema desde un punto de vista más realista.