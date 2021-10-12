using UnityEngine;
/**
 * Classe qui permet d'accéder et modifier des fichiers, principalement des fichiers config .cfg
 */
public class AccessFile : MonoBehaviour
{
    public static void test(string field, string value, FileName file){
        string text = System.IO.File.ReadAllText(FileNameMap.map[(int)file]);
        Settings s = Settings.CreateFromJson(text);
        print(s.toString());
        s.move_down = "Test";
        print(s.SaveToString());
        System.IO.File.WriteAllText(FileNameMap.map[(int)file],s.SaveToString());
    }

    public static void Set(string field, string value, FileName file){
        
    }
}


/**
 * Pour que tout se passe correctement, a chaque ajout de fichier .cfg, il faut que le fichier soit ajouté pour que le système le prenne en compte.
 */
public enum FileName
{
    stringKeySettings = 0,
    GlobalSettings = 1

}
public static class FileNameMap{
    public static string[] map = new string[] {"Assets/Settings/Keys.json","Assets/Settings/Keys.json"};

}


[System.Serializable]
public class Settings{
    public string move_left;
    public string move_right;
    public string move_down;
    public string drop;
    public string turn_left;
    public string turn_right;
    public string stock;

    public Settings(string move_left, string move_right, string move_down, string drop, string turn_left, string turn_right, string stock){
        this.move_left = move_left;
        this.move_down = move_down;
        this.move_right = move_right;
        this.drop = drop;
        this.turn_left = turn_left;
        this.turn_right = turn_right;
        this.stock = stock;
    }

    public string toString(){
        return this.move_left +" \n"+this.move_right +" \n"+this.move_down +" \n"+this.drop + " \n"+this.turn_left + " \n"+this.turn_right + " \n"+this.stock + " \n"; 
    }

    public static Settings CreateFromJson(string text){
        return JsonUtility.FromJson<Settings>(text);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    
    
}