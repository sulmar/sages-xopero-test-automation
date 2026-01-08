using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.Core;

public class FolderBackup 
{
    public string FolderPath { get; set; }
    public List<FileBackup> FileBackups { get; set; } // kolekcja

    public FolderBackup(string folderPath, List<FileBackup> fileBackups)
    {
        FolderPath = folderPath;
        FileBackups = fileBackups;
    }

    public void Backup()
    {
        if (FileBackups.Count == 0)
            throw new Exception("Brak plikow");


        foreach (FileBackup fileBackup in FileBackups) // Iteracja po zbiorze elementów
        {
            try
            {
                fileBackup.Backup();
            }
            catch(FormatException)
            {
                continue;
            }
        }
    }


    public long CalculateTotalSize()
    {
        long totalSize = 0;

        //foreach (FileBackup fileBackup in FileBackups)
        //{
        //    totalSize = totalSize + fileBackup.FileSizeInBytes;
        //}

        //foreach (FileBackup fileBackup in FileBackups)
        //{
        //    totalSize += fileBackup.FileSizeInBytes;
        //}

        // Linq (oparty o wyrazenia lambda, czyli funkje strzalkowe)
        totalSize = FileBackups.Sum(file => file.FileSizeInBytes);

        return totalSize;
    }
}
