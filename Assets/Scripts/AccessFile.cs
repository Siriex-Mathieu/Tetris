import System.IO;
using System;
/**
 * Classe qui permet d'accéder et modifier des fichiers, principalement des fichiers config .cfg
 */
public class AccessFile
{
    public static void Set(string field, string value, FileName file)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(file);
        string line;
        System.IO.StreamWriter writer = new System.IO.StreamWriter(file);
        writer.Close();
        while ((line = reader.ReadLine()) != string.Empty)
        {
            string[] id_value = line.Split('=');
            switch (id_value[0])
            {
                case field
                    break;
            }
        }
        writer.Write(field + " = "+value);

        reader.Close();
    }
    public static void Main(string[] args) {
        Set("Doss", "Test", FileName.KeySettings);
        System.Console.WriteLine("test")
    }


}


/**
 * Pour que tout se passe correctement, à chaque ajout de fichier .cfg, il faut que le fichier soit ajouté pour que le système le prenne en compte.
 */
public enum FileName
{
    KeySettings = "../Settings/KeysSetting.cfg",
    GlobalSettings = "../Settings/GlobalSetting.cfg"

}