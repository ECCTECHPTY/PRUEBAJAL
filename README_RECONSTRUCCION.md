# Cargador OpenKM — código fuente v1.1.8 (reconstruido)

## Aviso importante

**Este NO es el código fuente original entregado por el autor de la versión 1.1.8.**
Esa versión fue distribuida únicamente como binarios compilados
(`NewCargaOpenKmCedulacion.exe` + `.pdb`, paquete `NewMigracionCed`), sin proyecto
fuente. Ante esa ausencia, este proyecto fue **reconstruido a partir de dos fuentes**:

1. El código fuente real y completo de la versión **1.1.3**, que sí estaba disponible
   (`CargadorOpenKm-master.zip`) y que se usó como base.
2. Un análisis por **ingeniería inversa** (desensamblado a IL con `monodis` y lectura
   de metadatos/bytecode con las librerías Python `dnfile`/`dncil`) del ejecutable
   1.1.8, comparado instrucción por instrucción contra 1.1.3 para aislar los cambios
   reales.

Sobre esa base, se aplicaron **únicamente** los cambios que el análisis de IL confirmó
que existen en 1.1.8. Todo lo demás es exactamente el código de 1.1.3.

## Cambios aplicados en esta reconstrucción

1. **`Form1.cs` → `getFlujo()`**: reescrita por completo para mapear explícitamente
   cada metadato a su flujo de trabajo (workflow), incluyendo Organización Electoral
   (que en 1.1.3 nunca disparaba flujo) y varios metadatos de Registro Civil que antes
   se cargaban sin flujo. Se agregó también el `Log.Information("GetFlujo() Metadato: ...")`
   inicial, confirmado en el IL de 1.1.8 y ausente en 1.1.3.
2. **`Form1.cs` → `Instancia_SelectedIndexChanged()`**: se agregaron los 5 metadatos
   nuevos confirmados en el combo de 1.1.8: `RC_ADOPCIONES`, `RC_CERTIFICACIONES`,
   `OE_RENUNCIA_PARTIDOS`, `OE_INSCRIPCION_PARTIDOS`, `OE_ACTA_JUNTA_CONCEJAL`.
3. **`Form1.Designer.cs`**: título de la ventana actualizado de
   `"Cargador OpenKm 1.1.3"` a `"Cargador OpenKm 1.1.8"`.

El resto del archivo (controles, servidores, rutas, carpetas de error, `getCampo()`,
`TrimFileName()`, `OptimizePdfImages()`, `AssignMetadata()`, `ProcessDocuments()`,
`UploadDocument()`, `RunWorkFlow()`, `IniciarProceso_Click()`, etc.) se dejó **idéntico**
a 1.1.3, porque el análisis de IL confirmó que esos métodos no cambiaron entre versiones.

Ver el "Manual Técnico — Cargador OpenKM" (sección 8, "Registro de cambios v1.1.3 -> v1.1.8")
para el detalle completo, tabla por metadato, de este análisis.

## Verificación realizada sobre este código reconstruido

- Se validó el **balance de llaves y paréntesis** de `Form1.cs` contra el original.
- Se compiló con el compilador `mcs` de Mono en modo `-target:library` para confirmar
  que **no hay errores de sintaxis** (los únicos errores obtenidos son de ensamblados
  no disponibles en este entorno Linux — `System.Windows.Forms.dll` / `System.Drawing.dll`,
  que solo existen en Windows/.NET Framework — no errores de parseo del código).
- **No fue posible compilar y enlazar el .exe final** en este entorno (no hay Windows
  ni el toolchain de .NET Framework 4.7.2 con Windows Forms disponible aquí).

## Qué falta para confirmar al 100%

Antes de usar este código como reemplazo oficial del repositorio de 1.1.8, se recomienda:

1. Compilarlo en un equipo con Visual Studio / .NET Framework 4.7.2 y confirmar que el
   `.exe` resultante coincide funcionalmente con el binario original (mismas cadenas,
   mismo comportamiento).
2. Si se cuenta con el archivo `.pdb` original, usar una herramienta de descompilación
   C# (ILSpy, dotPeek) sobre el `.exe` de 1.1.8 para un cotejo línea por línea contra
   este archivo, y así detectar cualquier diferencia menor (nombres de variables locales,
   comentarios, formato) que la reconstrucción por IL no pueda capturar al 100%.
3. Recuperar o solicitar el repositorio fuente oficial de 1.1.8 si existe, y usar este
   documento únicamente como referencia de respaldo.

## Rediseño de interfaz (julio 2026)

Además de la reconstrucción de 1.1.8 descrita arriba, se rediseñó la pantalla principal
(`Form1.Designer.cs`) con un estilo más moderno: encabezado con color institucional,
tarjeta blanca para los campos del formulario, tarjetas de color para los contadores
"Archivos encontrados" / "Con error", botón de acción destacado y barra de progreso
delgada. **Ningún nombre de control usado por `Form1.cs` fue modificado** (`Instancia`,
`MetaDato`, `Usuario`, `Clave`, `DirectorioFuentes`, `SeleccionarRuta`, `Cantidad`,
`Error`, `IniciarProceso`, `progressBar1`, `CanProc`, `DialogoFolder`), por lo que la
lógica de negocio original permanece intacta. El único agregado a `Form1.cs` es el
método `CardPanel_Paint`, que dibuja el borde de la tarjeta principal.

Se verificó que `Form1.Designer.cs` y `Form1.cs` no introducen errores de sintaxis:
al compilar con `mcs` (Mono) sin las referencias de Windows Forms/GDI+ (no disponibles
en este entorno Linux), la cantidad y el tipo de errores es equivalente a la del código
original bajo las mismas condiciones — todos por ensamblados de Windows ausentes, ninguno
de sintaxis. La verificación visual final debe hacerse compilando en Windows/Visual Studio.



```
CargadorOpenKm-v1.1.8/
├── NewCargaOpenKmCedulacion.sln
├── .gitignore / .gitattributes
└── NewCargaOpenKmCedulacion/
    ├── Form1.cs                 <- lógica de negocio (actualizado, ver arriba)
    ├── Form1.Designer.cs        <- controles visuales (título actualizado)
    ├── Form1.resx
    ├── Program.cs               <- sin cambios respecto a 1.1.3
    ├── App.config
    ├── packages.config
    ├── NewCargaOpenKmCedulacion.csproj
    ├── OKMRest.dll / RestSharp.dll / Newtonsoft.Json.dll   <- dependencias (de 1.1.3)
    └── Properties/
```

Nota: las DLL de PdfSharp y Serilog (referenciadas por el proyecto vía NuGet, ver
`packages.config`) no se incluyen en este zip; se restauran automáticamente al abrir
el proyecto en Visual Studio con NuGet Package Restore habilitado.
