# About

Use `MaterialSymbols.cs` (or `MaterialIcons.cs`) to replace confusing and arcane unicode strings with a clean and descriptive property.

This:

```
// Huh? What icon is this? What font is it from? 😭
submitButton.Text = "/ue869";
```

Becomes this:

```
// Obviously a build icon from Material Symbols! 😊👍
submitButton.Text = MaterialSymbols.Build;
```

The end result is cleaner, more readable and more maintainable code.

# Using Material Design To C#

It's super easy to use MaterialDesign To C#.

Simply download the class for your desired Material Design icon set (see below), place it into your project and start using it.

**You should also ensure that you have added the corresponding Material Design font file(s) into your projects.**

You can use an icon in C# like so:

```
var fileIcon = MaterialSymbols.Build;
```

You can use an icon in XAML by:

* Adding a namespace reference to `MaterialDesign`: `xmlns:md="clr-namespace:MaterialDesign"`;
* Referencing a icon using `x:Static`: `<Label Text="{x:Static md:MaterialSymbols.Build}"/>`

Voila! All done!

# Downloads

### Material Icons
**[Get MaterialIcons.cs here](MaterialIcons.cs?raw=1)**

**[Download the Material Icon font assets here](https://github.com/google/material-design-icons/tree/master/font)**

### Material Symbols (NEW)
**[Get MaterialSymbols.cs here](MaterialSymbols.cs?raw=1)**

**[Download the Material Symbols font assets here](https://github.com/google/material-design-icons/tree/master/variablefont)**

# Using FontAwesome?

If you're using FontAwesome, [check out fa2cs](https://github.com/matthewrdev/fa2cs), a static class file containing string constants for all FontAwesome icon codes.
