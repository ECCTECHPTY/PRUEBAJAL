# Cómo compilar Cargador OpenKM

Este proyecto requiere Windows Forms y .NET Framework 4.7.2, por lo que **debe
compilarse en Windows** (no puede compilarse en Linux/Mac). Dos formas de hacerlo:

## Opción A — Visual Studio (la más simple, ~2 minutos)

1. Instalar [Visual Studio Community](https://visualstudio.microsoft.com/) (gratis)
   con la carga de trabajo **".NET desktop development"** marcada durante la instalación.
2. Abrir `NewCargaOpenKmCedulacion.sln` con doble clic.
3. Visual Studio va a restaurar automáticamente los paquetes NuGet que faltan
   (PdfSharp, Serilog, Serilog.Sinks.File) la primera vez que se abre el proyecto.
   Si no lo hace solo, clic derecho sobre la solución → **"Restaurar paquetes NuGet"**.
4. Barra superior: cambiar de `Debug` a **`Release`**.
5. Menú **Compilar → Compilar solución** (o `Ctrl+Shift+B`).
6. El ejecutable listo queda en:
   `NewCargaOpenKmCedulacion\bin\Release\NewCargaOpenKmCedulacion.exe`
7. Copiar toda la carpeta `bin\Release\` (el `.exe` y todos los `.dll` que lo
   acompañan) al equipo donde se va a usar. No requiere instalador.

## Opción B — Automático con GitHub Actions (sin instalar nada)

Este repositorio ya incluye `.github/workflows/build.yml`, que compila el proyecto
en un runner de Windows cada vez que se sube el código a GitHub.

1. Crear un repositorio en GitHub y subir el contenido de este zip.
2. Ir a la pestaña **Actions** del repositorio — el build corre solo.
   Si no arranca, usar el botón **"Run workflow"** (se ejecuta manualmente vía
   `workflow_dispatch`, ya configurado en el archivo).
3. Cuando termine (unos 2-3 minutos), bajar el `.exe` desde la sección
   **Artifacts** de esa misma ejecución (`CargadorOpenKM-Release`).

## Antes de usarlo en producción

Independientemente de cuál opción uses:

- Probar primero contra un servidor OpenKM de prueba, no directamente contra
  los servidores de producción listados en el manual técnico.
- Confirmar visualmente que la nueva interfaz se ve bien en la resolución de
  pantalla real de los equipos donde se va a usar (fue diseñada y verificada
  solo a nivel de código, no se pudo probar visualmente fuera de Windows).
- Revisar el `README_RECONSTRUCCION.md` — el código de `getFlujo()` fue
  reconstruido por ingeniería inversa y conviene cotejarlo una vez que puedas
  abrirlo en Visual Studio.
