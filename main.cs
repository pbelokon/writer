using Godot;
using System;
using System.Runtime.Serialization;

public partial class main : Control
{
    public FileDialog OpenFile;
    public FileDialog SaveFile; 

    public override void _Ready()
    {
        OpenFile = GetNode<FileDialog>("%OpenDialog");
        SaveFile = GetNode<FileDialog>("%SaveDialog"); 
    }
    public void OnOpenPressed()
    {
        OpenFile.Popup();
    }

    public void OnSavePressed()
    {
        SaveFile.Popup(); 
    }


}
