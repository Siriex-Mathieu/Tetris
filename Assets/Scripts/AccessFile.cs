/**
 * Classe qui permet d'acc�der et modifier des fichiers, principalement des fichiers config .cfg
 */

public class AccessFile
{
    public static void Set(string field, string value, FileName file)
    {

    }


}


/**
 * Pour que tout se passe correctement, � chaque ajout de fichier .cfg, il faut que le fichier soit ajout� pour que le syst�me le prenne en compte.
 */
public enum FileName
{
    KeySettings = "../Settings/KeysSetting.cfg",
    GlobalSettings = "../Settings/GlobalSetting.cfg"

}