/**
 * Classe qui permet d'acc�der et modifier des fichiers, principalement des fichiers config .cfg
 */
public class AccessFile
{
/*    public static void Set(string field, string value, FileName file)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(null);
        string line;
        System.IO.StreamWriter writer = new System.IO.StreamWriter(null);
        writer.Close();


        while ((line = reader.ReadLine()) != string.Empty)
        {
            string[] id_value = line.Split('=');
            switch (id_value[0])
            {
                case field:
                    break;
            }
        }
        
        writer.Write(field + " = "+value);

        reader.Close();
    }
*/


}


public class Program
{
    public static void Main(string[] args)
    {
        //AccessFile.Set("Doss", "Test", FileName.KeySettings);

    }
}
/**
 * Pour que tout se passe correctement, � chaque ajout de fichier .cfg, il faut que le fichier soit ajout� pour que le syst�me le prenne en compte.
 */
public static class FileName
{
    public static string stringKeySettings = "../Settings/KeysSetting.cfg";
    public static string GlobalSettings = "../Settings/GlobalSetting.cfg";

}
