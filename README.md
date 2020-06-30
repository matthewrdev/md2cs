# About

Material Design To C# creates a C# file that contains string constants for all Material Design icon codes.

**[Get MaterialDesignIcons.cs here](MaterialDesignIcons.cs)**

# Benefits

Use MaterialDesign To C# to replace confusing and arcane unicode strings with a clean and descriptive property.

This:

```
submitButton.Text = "/uf00c"; // Huh? What icon is this? What font is it from? 😭
```

Becomes this:

```
submitButton.Text = MaterialDesignIcons.Check; // Obviously a check icon from MaterialDesign! 😊👍
```

The end result is cleaner, more readable and more maintainable code.

# Using Material Design To C#

It's super easy to use MaterialDesign To C#.

Simply download [MaterialDesignIcons.cs](MaterialDesignIcons.cs) and place it into your project:

![Placing MaterialDesignIcons.cs inside a C# project](img/usage.png)

**Ensure that you have added the Material Design font file into your projects!**

You can use an icon in C# like:

```
var fileIcon = MaterialDesignIcons.DonutSmall;
```

You can use an icon in XAML by:

 * Adding a namespace reference to `MaterialDesign`: `xmlns:md="clr-namespace:MaterialDesign"`;
 * Referencing a icon using `x:Static`: `<Label Text="{x:Static md:MaterialDesignIcons.Alicorn}"/>`

Voila! All done!

# Credits

 * [Material Design](https://material.io/resources/icons/?style=baseline): The amazing Material Design icon set.
 * [HtmlAgility Pack](https://html-agility-pack.net/): Used for crawling www.MaterialDesign.com 🙈
 * [QuickType](https://quicktype.io/): Used to generate a C# model to consume https://MaterialDesign.com/cheatsheet.
 * [Assembly Emitter](https://josephwoodward.co.uk/2016/12/in-memory-c-sharp-compilation-using-roslyn): Used to emit the MaterialDesign.IconCodes assembly.
