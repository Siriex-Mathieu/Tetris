/**
 * Classe qui permet d'accéder et modifier des fichiers, principalement des fichiers config .cfg
 */

public class AccessFile
{
    public static void Set(string field, string value, FileName file)
    {

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