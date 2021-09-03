# About

Material Design To C# creates a C# file that contains string constants for all Material Design icon codes.

**[Get MaterialDesignIcons.cs here](https://raw.githubusercontent.com/matthewrdev/md2cs/master/MaterialDesignIcons.cs)**

**[Download the Material Design Icon font assets here](https://github.com/google/material-design-icons/tree/master/font)**

# Benefits

Use MaterialDesign To C# to replace confusing and arcane unicode strings with a clean and descriptive property.

This:

```
// Huh? What icon is this? What font is it from? 😭
submitButton.Text = "/ue869";
```

Becomes this:

```
// Obviously a build icon from MaterialDesign! 😊👍
submitButton.Text = MaterialDesignIcons.Build;
```

The end result is cleaner, more readable and more maintainable code.

# Using Material Design To C#

It's super easy to use MaterialDesign To C#.

Simply download [MaterialDesignIcons.cs](MaterialDesignIcons.cs) and place it into your project to start using it.

**[Ensure that you have added the Material Design font file into your projects.](https://github.com/google/material-design-icons/tree/master/font)**

You can use an icon in C# like:

```
var fileIcon = MaterialDesignIcons.Build;
```

You can use an icon in XAML by:

 * Adding a namespace reference to `MaterialDesign`: `xmlns:md="clr-namespace:MaterialDesign"`;
 * Referencing a icon using `x:Static`: `<Label Text="{x:Static md:MaterialDesignIcons.Build}"/>`

Voila! All done!

# Using FontAwesome?

If you're using FontAwesome, [check out fa2cs](https://github.com/matthewrdev/fa2cs), a static class file containing string constants for all FontAwesome icon codes.
