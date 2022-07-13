using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   public static bool DO_NOT = false; 

   [SerializeField]
   private int _state;
   [SerializeField]
   private int _cardValue;
   [SerializeField]
   private bool _initialized = false;

   private Sprite _cardBack;
   private Sprite _cardFace;

   private GameObject _manager;

    void Start()
    {
        _state = 0;
        _manager = GameObject.FindGameObjectWithTag("Manager");

    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardBack = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();

    }

    void flipCard()
    {
        if(_state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if(_state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
    }

    public int cardValue
    {
        get{return _cardValue;}
        set{_cardValue = value;}
    }

    public int state
    {
        get{return _state;}
        set{_state = value;}
    }

    public bool initialized
    {
        get{return _initialized;}
        set{_initialized = value;}
    }

    public void falseCheck()
    {
        StartCoroutine(pause()); //gives buffer for when cards are flipped over/how long to wait to flip cards back over
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if(_state == 0)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if(_state ==1)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
        DO_NOT = false;

    }







}
