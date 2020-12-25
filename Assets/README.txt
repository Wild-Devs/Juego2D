Si vscode da problemas con el omnisharp (Mensaje en la esquina diciendo "Some projects have problems loading | Extension: C#"):
-Entrar al archivo "Assembly-CSharp-Editor.csproj", línea 16, cambiar la versión de v4.8 a la versión instalada en el ordenador.
-Entrar al archivo "Assembly-CSharp.csproj", línea 16, cambiar la versión de v4.8 a la versión instalada en el ordenador.
-En vscode usar Ctrl+shift+P -> Developer: Reload Window

Si el problema persiste cambiar el output de vscode a omnisharp y mirar la versión que te pide, descargar en el link que se te indica.