using Godot;
using System;
using System.Data;
using System.Runtime.Serialization;

public partial class main : Control
{
    public FileDialog OpenFile;
    public FileDialog SaveFileAs;
    public CodeEdit Content; 

    public override void _Ready()
    {
        OpenFile = GetNode<FileDialog>("%OpenDialog");
        SaveFileAs = GetNode<FileDialog>("%SaveAsDialog");
        Content = GetNode<CodeEdit>("%TEXTEDITAREA"); 
    }
    public void OnOpenPressed()
    {
        OpenFile.Popup();
    }

    public void OnSaveAsPressed()
    {
        SaveFileAs.Popup();
    }

    public void OnFileSelected(String path)
    {
        var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);

        if (file == null)
        {
            GD.Print("error opening file");
            return;
        }
        Content.Text = file.GetAsText();
    }
    
    public void OnFileSaveAsSelected(String path)
    {
        var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        GD.Print("hello"); 
        if (file == null)
        {
            GD.Print("error saving file");
            return;
        }

        file.StoreString(Content.Text);
        file.Close(); 
    }


}
