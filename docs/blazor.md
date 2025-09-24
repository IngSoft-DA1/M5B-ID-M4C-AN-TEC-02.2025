# Blazor

## **¿Qué es Blazor?**
Blazor es un framework web desarrollado por **Microsoft** que permite a los desarrolladores crear aplicaciones web interactivas utilizando C# y .NET en lugar de JavaScript. Permite la creación de aplicaciones del lado del cliente con una arquitectura basada en componentes. Hay dos modelos de hosting principales para Blazor:

Blazor WebAssembly: se ejecuta del lado del cliente en el navegador web mediante WebAssembly.

Blazor Server: se ejecuta en el servidor, con una conexión en tiempo real con el cliente mediante SignalR. 
Este modelo reduce la carga del lado del cliente y permite tiempos de carga iniciales rápidos.

## **Estructura tipica de un proyecto Blazor**
- **wwwroot**: carpeta raíz del proyecto que contiene los recursos estáticos públicos de la aplicación.
- **Components/Pages**: contiene los componentes Razor enrutables de la aplicación de Blazor utilizando la extension ".razor".
- **Components/Layout**: contiene otros componentes de la interfaz de usuario en forma de archivos con extension .razor que son 
utilizados de forma global en la aplicacion.

## **Componentes Destacados**
- **MainLayout.razor**: componente principal del diseño de la aplicación.
- **NavMenu.razor**: implementa el menú de navegación de la barra lateral.
- **Imports.razor**: incluye directivas Razor comunes para incluir en los componentes de la aplicación como directivas "@using" 
para espacios de nombres.
- **App.razor**: componente raíz de la aplicación que configura el enrutamiento del lado cliente mediante el componente Router. El componente Router intercepta la navegación del explorador y representa la página que coincide con la dirección solicitada.
- **Program.cs**: Es el punto de entrada de la aplicación que configura el host de WebAssembly. En el se agrega y configura la inyeccion de dependencias de los servicios de la aplicacion. 

## **Algunas directivas en Blazor**
- **`@page`**: Define la URL de una página específica.
- **`@code`**: Permite vincular código C# con HTML dentro de un componente Blazor.
- **`@inject`**: Permite inyectar dependencias o servicios en los componentes.
- **`@bind`**: Es utilizada para la sincronizacion de cambios en forma bidireccional entre un elemento de la interfaz de usuario (como un "input field") y una propiedad en el codigo del componente. Si el usuario cambia el input field, la property se actualiza automaticamente y viceversa.

## **Servicios**
- Los servicios contienen la lógica de negocio de la aplicación.
- Pueden ser inyectados dentro de los diferentes componentes para poder ejecutar diferentes metodos asociados al mismo.

### **Tiempo de vida de los servicios**
- **Singleton**: Se crea una única instancia del servicio. Todos los componentes que requieran del mismo, recibirán la misma instancia dentro de la aplicacion.

- **Scoped**: Un servicio "Scoped" tiene un alcance a un "circuito" unicamente. Un circuito es creado cuando un usuario se conecta con el servidor y se mantiene mientras dure la sesión. Si el usuario navega entre componentes del mismo circuito, la misma instancia del servicio es utilizada.

- **Transient**: Cada vez que un componente requiere de un servicio "Transient" siempre recibe una nueva instancia del mismo dentro de la aplicación.

## ¿Cómo aplicar estilos a diferentes componentes dentro de la aplicación?
- Cuando se crea una aplicacion del tipo Blazor Server la misma viene por defecto con Bootstrap incluido. Dicho framework es sumamente utilizado en diseño web, posee excelente documentacion con ejemplos y es responsive.
- Otra alternativa es crear para cada componente una hoja de estilo CSS. La misma deberá estar en el mismo directorio
que el componente y tener un nombre del estilo "NombredelComponente.razor.css"