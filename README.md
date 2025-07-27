# Descripción del Proyecto

 - Nombre del proyecto: **Sales Date Prediction APP**
 - Resumen:
	 - Este proyecto es una SPA (Single Page Application) construida con Angular para el frontend y ASP.NET Core para el backend.
	 - Permite gestionar clientes, empleados, productos, transportistas y órdenes.
	 - Implementa un sistema de predicción de fechas de pedidos basado en datos históricos.
	 - Se incluye un gráfico de barras interactivo para la visualización de datos usando D3.js.

# Tecnologías Utilizadas

 - Backend:
	 - ASP.NET Core 9.0.
	 - Entity Framework Core para acceso a datos.
	 - Principios SOLID y patrón Unit of Work.
	 - Swagger/OpenAPI para documentar y consumir el API.
- Frontend:
	- Angular 17 con Bootstrap 5.
	- Ng-select para selectores dinámicos.
	- NgbModal para modales.
	- D3.js para gráficos de barras.
- Base de Datos:
	- SQL Server.
	- Procedimientos almacenados para operaciones CRUD y predicción de datos.


## Configuración del Proyecto

**Backend**

 1. Clonar el repositorio.
 2. Crear la base de datos en SQL Server y ejecutar los siguientes scripts se encuentran en el back en  la carpeta llamada `StroredProcedures`:
  - **Procedimientos almacenados:**
	 - `GetNextOrderPrediction`: Predicción de próximas órdenes.
	 - `GetClientOrders`: Listar órdenes por cliente.
	 - `GetEmployees`: Listar empleados.
	 - `GetProducts`: Listar productos.
	 - `GetShippers`: Listar transportistas.
	 - `AddNewOrderWithProducts`: Insertar una nueva orden con productos.
   - **User-Defined Table Types:**
		- `OrderDetailsType`: Tipo de tabla para detalles de órdenes.
 3. Modificar el archivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=StoreSample;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "AllowedHosts": "*",
  "CorsPolicy": {
    "AllowedOrigins": "https://localhost:4200"
  }
}

```

4. Habilitar Swagger para pruebas:
	- `app.UseSwagger(); app.UseSwaggerUI();`
5.	**Ejecutar el proyecto en SSL** (asegúrate de que el certificado esté habilitado en el entorno de desarrollo).

 **FrontEnd**

1. Instalar dependencias: 

	    npm install
2. Modificar la base URL en `api-configuration`  en los servicios generados por OpenAPI:

		  export  class  ApiConfiguration {
			    rootUrl:  string  =  'https://localhost:7206';
		    }
	- Asegúrate de que apunten a `https://localhost:7206` o el que estes usando.    
3. Ejecutar Angular con SSL:

	      ng serve --ssl

## Arquitectura
#### **Backend**

-   **Principios SOLID:**
    -   **Single Responsibility:** Cada clase tiene una responsabilidad única, como los repositorios (`CustomerRepository`, `OrderRepository`) y los servicios (`CustomerService`).
    -   **Dependency Inversion:** Uso de interfaces (`ICustomerRepository`, `ICustomerService`) para desacoplar dependencias.
-   **Patrón Unit of Work:**
    -   Implementación de una clase `UnitOfWork` para gestionar las transacciones y coordinar repositorios.

#### **Frontend**

-   Modularización en Angular:
    -   **SharedModule:** Contiene componentes compartidos como la tabla dinámica.
    -   **Lazy Loading:** Implementado en los módulos (`CustomerModule`, `OrderModule`).
    -   **Ng-select y NgbModal:** Usados para una experiencia de usuario fluida.
  ## Funcionalidades Implementadas

-   **Frontend:**
    -   Listar clientes con predicción de próximas órdenes.
    -   Filtrar clientes por nombre usando un input dinámico.
    -   Modales para agregar nuevas órdenes y ver detalles.
    -   Tabla dinámica con paginación y ordenamiento.
    -   Gráfico interactivo de barras con D3.js.
-   **Backend:**
    -   Procedimientos almacenados para listar, buscar y predecir datos.
    -   Endpoint para insertar una nueva orden con productos.
    
 ## Pruebas

-   **Backend:**
    -   Pruebas unitarias para repositorios y servicios.
    -   Uso de Moq para simular dependencias.
    -   Ejemplo:
		    

			   [Fact]
			public async Task GetCustomerPredictionsAsync_ReturnsPredictions()
			{
		    // Arrange
		    var mockRepo = new Mock<ICustomerRepository>();
		    mockRepo.Setup(repo => repo.GetCustomerPredictionsAsync())
		            .ReturnsAsync(new List<CustomerPredictionDto> { ... });
		    var service = new CustomerService(mockRepo.Object);
		    // Act
		    var result = await service.GetCustomerPredictionsAsync();

		    // Assert
		    Assert.NotNull(result);
		    Assert.Single(result);
			}
	## Detalles Adicionales

-   **CORS:** Asegúrate de configurar correctamente los orígenes permitidos en el backend para evitar errores al consumir el API desde Angular.
-   **Gráfico D3.js:**
    -   Implementa validación de entrada en el input para evitar errores al crear el gráfico.
    -   Asegúrate de incluir etiquetas en las barras con los valores.


