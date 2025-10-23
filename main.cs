using Godot;
using System;

public partial class main : Control
{
    public FileDialog OpenFile;
    public FileDialog SaveFileAs;
    public CodeEdit Content;

    public FileDialog OpenFolder;

    public ItemList DirTree; 

    public override void _Ready()
    {
        OpenFile = GetNode<FileDialog>("%OpenDialog");
        OpenFolder = GetNode<FileDialog>("%OpenFolderDialog"); 
        SaveFileAs = GetNode<FileDialog>("%SaveAsDialog");
        Content = GetNode<CodeEdit>("%TEXTEDITAREA");
        DirTree = GetNode<ItemList>("%DirTree"); 
    }
    public void OnOpenPressed()
    {
        OpenFile.Popup();
    }

    public void OnSaveAsPressed()
    {
        SaveFileAs.Popup();
    }

    public void OnOpenFolderPressed()
    {
        OpenFolder.Popup(); 
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
    
    public void OnOpenDirSelected(String path)
    {
        var dir = DirAccess.Open(path); 
        
        if (dir != null)
        {
            dir.ListDirBegin();
            string fileName = dir.GetNext(); 

            while (fileName != "")
            {
                if (dir.CurrentIsDir())
                {
                    GD.Print($"Found directory: {fileName}");
                    DirTree.AddItem(fileName); 
                }
                else
                {
                    GD.Print($"Found file: {fileName}");
                    DirTree.AddItem(fileName); 

                }
                

              fileName = dir.GetNext();
            }
        }
    }


}
