# Test Unitarios
## Estructura de la solución de ejemplo
```
DA12025 --> Solution 
├── Domain --> proyecto de tipo libreria de clases
│   ├── Car.cs 
│   ├── Van.cs
│   └── Vehicle.cs
└── ConsoleApp --> proyecto de consola
    ├── Program.cs
```

Vamos a realizar test unitarios de la clase `Vehicle`  del proyecto `Domain` utilizando el framework *MS-Test*
### Class Vehicle

```cs
public class Vehicle
{
    private int _doorQuantity;
    private string _chassisColor;

    public int DoorQuantity
    {
        get => _doorQuantity;
        set
        {
            if (value < 2 || value > 5)
            {
                throw new ArgumentException("Door quantity cannot be less than 2 or bigger than 5");
            }
            _doorQuantity = value;
        }
    }

    public string ChassisColor
    {
        get => _chassisColor;
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Chassis color cannot be null or empty");
            }
            _chassisColor = value;
        }
    }

    public Vehicle(int doorQuantity, string chassisColor)
    {
        DoorQuantity = doorQuantity;
        ChassisColor = chassisColor;
    }

    public virtual void TurnOn()
    {
    }
}		 
```

### Constructor:
- Se espera que al instanciar la clase `Vehicle` se le pase en el constructor `doorQuantity` y `chassisColor`.

### Metodo TurnOn
- **`TurnOn()`**: Método virtual para encender el vehículo que puede ser sobrescrito en las clases derivadas. En la solucion de ejemplo el método es sobrescrito tanto en `Car` como en `Van`.

## Car y Van
- Ambas clases son derivadas de `Vehicle` (`Car : Vehicle`) (`Van : Vehicle`).
- Se usa el `base(doorQuantity, chasisColor)` para llamar al consturctor de la clase `Vehicle`.
- `TurnOn()`:  tiene la palabra clave `override` para poder sobreseciribr el metodo de la clase padre.

```cs
public class Car : Vehicle
{
    public Car(int doorQuantity, string chassisColor) : base(doorQuantity, chassisColor)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine($"Turning on car with {DoorQuantity} doors and chassis color {ChassisColor}");
    }
}
```

```cs
public class Van: Vehicle
{
    public Van(int doorQuantity, string chassisColor) : base(doorQuantity, chassisColor)
    {
    }
    
    public override void TurnOn()
    {
        Console.WriteLine($"Turning on van with {DoorQuantity} doors and chassis color {ChassisColor}");
    }
}
```

## Unit Tests
- Para realizar los tests agregamos un proyecto `UnitTest` de tipo `MSTest`.
- La estructura de este proyecto es ideal que sea similar al proyecto que va a testear poniendo `tests` al final.

```
DA12025
├── Domain
│   ├── Car.cs
│   ├── Van.cs
│   └── Vehicle.cs
│
├── Domain.Tests
│   ├── CarTests.cs
│   ├── VanTests.cs
│   └── VehicleTests.cs
│
└── ConsoleApp
    ├── Program.cs
``` 

### Clase `VehicleTests`
- **`[TestClass]`**: Marca la clase como una clase de pruebas para el framework `MSTest` indicando que contiene métodos que deben ejecutarse como pruebas.

### Inicialización
- **`[TestInitialize]`**: Se ejecuta antes de cada método de prueba para preparar el entorno de pruebas como inicializar variables o configurar el estado necesario.

### Métodos de Prueba
- **`[TestMethod]`**: Marca un método como una prueba unitaria que debe ser ejecutada por el framework de pruebas.

### Arrange Act Assert
En MSTest (framework de pruebas unitarias para .NET), Arrange, Act y Assert son tres etapas fundamentales dentro del patrón AAA (Arrange, Act, Assert) que se utiliza para estructurar las pruebas de manera clara y comprensible. Este patrón ayuda a organizar las pruebas de manera coherente, facilitando su mantenimiento y lectura.

1. Arrange (Preparar):
En esta fase se preparan todos los elementos necesarios para la prueba, como instanciar objetos, configurar mocks, establecer valores iniciales, y preparar el entorno para que la prueba pueda ejecutarse correctamente.

2. Act (Ejecutar):
En esta fase se ejecuta el código que se está probando, utilizando los datos o los objetos configurados en el paso anterior. Aquí se realiza la acción principal de la prueba.

3. Assert (Verificar):
En esta fase se verifica que el resultado de la acción (act) sea el esperado. Aquí es donde se validan las expectativas, como comparar el valor obtenido con el valor esperado.

### Ejemplo
- El siguiente ejemplo valida cuando la cantidad de pruebas del vehiculo es correcta

```cs
[TestMethod]
    public void NewVehicle_WhenDoorQuantityIsCorrect_ThenDoorQuantityIsValid()
    {
        //arrange
        Vehicle vehicle;
        //act
        vehicle = new Vehicle(3, "Green");
        //assert
        Assert.AreEqual(3, vehicle.DoorQuantity);
    }
```

- En este ejemplo si la cantidad de puertas es incorrecta, se le dice al framework que para esta prueba se espera que se reciba una excepcion, en este caso del tipo ArgumentException.

```cs
[TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NewVehicle_WhenDoorQuantityIsMoreThanFive_ThenThrowException()
    {
        //arrange
        Vehicle vehicle;
        //act
        vehicle = new Vehicle(6, "Green");
    }
```
### Cobertura de las pruebas
#### Propósito de la cobertura
- La cobertura de código mide qué porcentaje del código productivo fue ejecutado durante las pruebas.
- El objetivo es saber si la lógica de negocio (lo que hace el sistema) está siendo probado adecuadamente.

- Tomando de ejemplo esta estructura dentro de la solución *DA12025* y asumiendo que se quiere verificar si la cobertura del proyecto Domain esta por encima del 90%:

```
DA12025
├── Domain
│
├── Domain.Tests

``` 

Cuando se obtienen los porcentajes de cobertura para ambos proyectos, la que interesa en si es la de Domain y no la de Domain.Tests, éste solo contiene el cómo se prueba, no el código que irá a producción.
Evaluar la cobertura de Domain.Tests no aporta valor ya que siempre va a ejecutarse al 100% (cuando se corren los tests, se ejecuta el código asociado a cada uno).