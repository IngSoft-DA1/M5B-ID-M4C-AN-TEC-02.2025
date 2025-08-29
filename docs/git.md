# Conceptos básicos
-  Repositorio: Estructura de directorios donde se almacenan los elementos componentes de software producidos a lo largo de todo el proyecto.
- GIT: es un sistema de control de versiones distribuido que permite gestionar y registrar cambios en el código, facilitando la colaboración entre desarrolladores.
-  `.gitignore`: un archivo en la raíz del repositorio que se utiliza para especificar que archivos no deben ser trackeados por Git. Recomendable usar páginas como gitignore.io para generarlo.
- Root del repositorio: carpeta raiz del mismo.

## Workflow:
![image](https://github.com/user-attachments/assets/ac2fb236-bfb1-4481-83e6-cdf27759be13)

## Commandos Utiles:
- `git init`: crear un repositorio local en tu computadora.
- `git clone [url]`: clonar un repositorio desde un servicio como github a tu computadora.
- `git status`: muestra el estado de los archivos (modificados o que ya estan en el área stage).
- `git add`: en general agrega todo el contenido excepto lo ignorado en el archivo (.gitignore). Puede configurarse con los distintos parámetros. Se puede llegar a usar muchas veces antes de un commit.
- `git add .`: agrega todos los archivos que estén mas abajo del directorio actual (no de la raíz del repositorio) es decir si estoy en en el `root` del `repositorio` y hago `cd sample` y luego `git add .` solo se actualizará el index con los archivos que cambiaron dentro de la carpeta `sample`
- `git add -A`: Es como `git add .` pero no tiene en cuenta el directorio actual donde te encuentras, agrega todos los archivos al área stage.
- `git commit -m "[mensaje]"`: crea un snapshot con los archivos que estan marcados como `staged` incluyendo un mensaje especifico.
- `git pull`:  incorpora los cambios desde el repositorio a la rama actual.
- `git push`:  actualiza las referencias remotas usando las locales.
- `git fetch`: busca y descarga el contenido de un repositorio remoto y actualiza el repositorio local para que coincida con ese contenido.
- `git branch`: lista todas las ramas actuales de un repositorio local.
- `git branch [name]`: crea una nueva rama que referencia al commit de la rama donde estamos poscicionados actualmente.
- `git branch -D [name]`: elimina de forma permanente la rama de nombre `name` de un repositorio local.
- `git checkout [name]`:  sirve para cambiarse a la rama de nombre `name`.
- `git checkout -b [name]`:  crea una rama con nombre `name` y se cambia a ella.
- `git merge [name]` integra los cambios de la rama de nombre `name` a la que estamos poscicionados actualmente. Para el obligatorio deberán utilizar `git merge --no-ff` ya que crea un commit manteniendo el historial.
- `git rebase [name]`: suponiendo el caso en el que HEAD se encuentre apuntando a una branch testing, cuando se ejcuta el comando `git rebase master`, Git rebobinará la branch testing hasta llegar al primer ancestro en común que tenga con master. Luego aplicará los commits restantes de testing encima de los cambios generados en master. Al finalizar la ejecución testing tendrá incluídos los cambios de master. NO USAR PARA EL OBLIGATORIO.

# Git Flow
Es un flujo de trabajo definido para el uso con Git que especifica qué tipo de ramas tener y qué propósito cumplen las mismas.

## Flujo basico:
- Dos ramas base **develop** y **master**.
- Para trabajar en una nueva funcionalidad se utiliza una **rama feature** que tiene como **rama base a develop**. Cuando se termina la funcionalidad la **rama se mergea a develop**.
- **Las ramas feature nunca interactúan con master**
- **Para integrar cambios a la rama master se crean las ramas release desde develop**

## Ramas Features:
Se generan a partir de la rama develop y estan asociadas a una nueva funcionalidad a ser trabajada. Una vez terminada la misma, la rama se mergea a develop. 
Algunos Ejemplos:
- feature/createUser
- feature/deleteUser

## Ventajas
- Cada funcionalidad es englobada en una rama independiente
- El código se vuelve más simple de revisar
- Es más fácil relacionar requerimientos y funcionalidades con el código donde fueron implementadas
- Reduce el porcentaje de conflictos.
- Volver al pasado en el código se vuelve más simple.

## Ramas Bugfix:
Si bien este tipo de ramas no estan comprendidas dentro del flujo de trabajo de Gitflow, son útiles cuando se
debe corregir algun tipo de bug en la rama develop. 
Algunos ejemplos:
- bugfix/footer-styling
- bugfix/user-logout

## Ventajas
- Cada correccion se asocia a una rama especifica
- El código se vuelve más simple de revisar previo a la integración en otra rama
- Es más facil de hacer un rollback en caso que la solución al bug provoque errores en otro lugar
- Minimiza el porcentaje de conflictos.
