# Backend API En NET core 6 

Backend hecho en Net core 6 para crear un api de elementos para escalar y calcular el conjunto óptimo para llevar, no se utilizó entity framework 

importante contar con una base de datos que tenga una tabla element con las siguientes columnas y su id sea auto incrementable ya que nunca se lo pasaremos
![Estructura base de datos](https://github.com/juanda70perez/pruebaTecnicaSolucion/assets/110078515/2b7f084e-f514-44cc-99e9-f47e6150377f)

## Estructura

Se siguió el patron de diseño MVCpara organizar el proyecto 

![Estructura del proyecto](https://github.com/juanda70perez/pruebaTecnicaSolucion/assets/110078515/1dbf188d-4471-4ce7-b931-6c614351f49e)
La carpeta conexión en su archivo conexionBD se encarga de recuperar la cadena de conexión que esta almacenada en appsetting.json ConnectionString aquí es donde debén poner su conexión con la base de datos
En la carpeta datos se encarga de comunicarse con la base de datos para obtener los datos de nuestros modelos, que solo tenemos uno para en este caso
En la carpeta utilidades se tiene pensado poner todas las clases que sirvan para calcular cosas, no se hacen en los controladores para no tener que repetir codigo sino solo llamar la clases alojadas en la carpeta utilidades
El archivó recursividad se encarga de encontrar el conjunto más eficiente que me de las máxima calorias cumpliendo con el mínimo exigido por el usuario con el peso minimo teniendo en cuenta que no se pase del peso máximo puesto por el usuario
es importante aclarar que se llama mochila el modelo que se encarga de almacenar los elementos ya que se parece a la función que cumple una mochila y pensado en el problema de recursividad de la mochila que fue adecuado para este caso
nuestra mochila optima se inicializa con peso -1 porque el peso 0 es un peso valido para una solución posible 

Importante usar politicas cors para el consumo de la parte del front sino se ponen se le niega el acceso al servidor

se tiene que poner en el archivo program.cs estas lineas para añadir politicas
```bash
 builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
app.UseCors("corspolicy");
```
importante después modificarlas para mejorar la seguridad, ya que en este caso estamos permitiendo cualquier conexión de origen

## Demo

Podemos útilizar postman o Swagger que viene con el proyecto cuando eliges Net core para probar nuestras rutas de las apis
![Estuctura de las api](https://github.com/juanda70perez/pruebaTecnicaSolucion/assets/110078515/ca286648-b1df-4416-8757-a159b571c5a9)

## Authors

- [juanda70perez](https://github.com/juanda70perez)
