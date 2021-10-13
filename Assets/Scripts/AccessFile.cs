using UnityEngine;
[System.Serializable]
public class Settings{
    // Chemin des settings
    private static string path = "Assets/Settings/Setting.json";

    // Singleton
    private static Settings singleton;


    // Les touches
    public string move_left;
    public string move_right;
    public string move_down;
    public string drop;
    public string turn_left;
    public string turn_right;
    public string stock;

    // Le reste l'ajout d'un nouvel attribut doit se faire ici et dans le fichier, il faut aussi que les noms soit les mêmes dans le même ordre, du même type et dans le code, l'attribut doit être privé


    // Constructeur privé
    public Settings(string move_left, string move_right, string move_down, string drop, string turn_left, string turn_right, string stock){
        this.move_left = move_left;
        this.move_down = move_down;
        this.move_right = move_right;
        this.drop = drop;
        this.turn_left = turn_left;
        this.turn_right = turn_right;
        this.stock = stock;
    }

    public static Settings init(){
        // Permet de récupérer le fichier json dans le fichier de type FileName
        string text = System.IO.File.ReadAllText(path);

        // Cela permet de créer un objet setting à partir du json si il n'y en a pas déjà de créé
        if(singleton == null)singleton = Settings.CreateFromJson(text);

        // retourne l'objet
        return singleton;
    }

    public static void Save(){
        // Ecriture du Json de l'objet s dans le fichier
        System.IO.File.WriteAllText(path,singleton.SaveToString());

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