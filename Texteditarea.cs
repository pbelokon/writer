using Godot;
using System;

public partial class Texteditarea : CodeEdit
{
    public override void _Ready()
    {
        GuttersDrawLineNumbers = true; 
    }
}
