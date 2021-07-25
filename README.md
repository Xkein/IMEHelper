## IME Helper for windows
Code mainly come from [ryancheung's MonoGame.IMEHelper](https://github.com/ryancheung/MonoGame.IMEHelper).
## Getting started

### Initialize a IMEHandler instance in your game Initialize method

```c#
   imeHandler = new WinFormsIMEHandle(WindowHandle);
   imeHandler.TextInput += (s, e) => { ... };
```

### If your want to render Composition String

```#
   imeHandler = new WinFormsIMEHandler(WindowHandle);
   imeHandler.TextInput += (s, e) => { ... };
   imeHandler.TextComposition += (s, e) => { ... };
```

*Note that `TextComposition` event only works on WindowsDX platform due to limitation of the underlying platform*

### Start Text Composition

`imeHandler.StartTextComposition();`

### Stop Text Composition

`imeHandler.StopTextComposition();`
`

## License

MonoGame.IMEHelper is released under the [The MIT License (MIT)](https://github.com/ryancheung/MonoGame.IMEHelper/blob/master/LICENSE.txt).
