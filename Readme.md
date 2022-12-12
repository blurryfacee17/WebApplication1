# Пример реализации экрана ввода:
  https://www.reddit.com/r/RenPy/comments/ga3i4b/custom_input_screen/?utm_medium=android_app&utm_source=share

  Перезапускает текущее взаимодействие. Помимо прочего, это позволяет отображать изображения, добавленные в сцену, повторно оценивать экраны и запускать любые переходы в очереди.
  Это делает что-либо только при вызове из взаимодействия (например, из действия). Вне взаимодействия эта функция не имеет никакого эффекта.
```renpy.restart_interaction() 
```
  
# Делает action из MyFunc.
  ```MyAction = renpy.curry(MyFunc) 
  ```
  ```Action Function(MyFunc)
  ```
  
# Сохраняет строку input в переменную
  ```input value VariableInputValue("variable")
  ```
