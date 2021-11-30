using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class playButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer sr; //charger le SpriteRenderer
    public Sprite normal; //charger l'image normale
    public Sprite hover; //charger l'image quand elle devra etre surlignée
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>(); //load le SpriteSenderer
    }

    // Update is called once per frame
    void Update()
    { 
        //ne rien mettre
    }

    public void OnPointerEnter(PointerEventData eventData){
        sr.sprite = hover; //changer d'image quans la souris est dessus
    }


    public void OnPointerExit(PointerEventData eventData){
        sr.sprite = normal; //changer d'image quans la souris n'est plus dessus
    }
}
