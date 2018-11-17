using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecon : MonoBehaviour
{
    public string[] keywords = new string[] { };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    protected PhraseRecognizer recognizer;

    private string wordRecon;

    private bool isClicking;
    private bool record;
    [SerializeField]
    private float coolDown = 1f;
    private float cool;
    private bool canSpell;


    private bool channelLight;

    [SerializeField]
    private Animator Light;

    private void Start()
    {

        //results.text = "You said: <b>" + word + "</b>";
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        wordRecon = args.text;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyBindings.keys["CancelSpell"]))
        {
            CancelSpell();
        }

        if (Input.GetKey(KeyBindings.keys["CastSpell"]))
        {
            isClicking = true;
        }
        else if(Input.GetKeyUp(KeyBindings.keys["CastSpell"]))
        {
            isClicking = false;
            cool = coolDown;
            canSpell = true;
        }

        if(isClicking && !recognizer.IsRunning)
        {
            wordRecon = "";
            recognizer.Start();
        }
        else if(!isClicking && recognizer.IsRunning)
        {
            recognizer.Stop();
        }
        if (canSpell)
        {
            cool -= Time.deltaTime;
        }
        
        if (cool <= 0 && canSpell)
        {
            ProcesWord(wordRecon);
        }
    }

    private void CancelSpell()
    {
        if (channelLight)
        {
            channelLight = false;
            Light.SetBool("Create", false);
        }
    }

    private void ProcesWord(string word)
    {

        if(word != "")
        {
            switch (word)
            {
                case "Ergo Luxo":
                    if(!isClicking)
                        InLumen();
                        wordRecon = "";
                        break;
                case "Luxo Vera":
                    if (!isClicking)
                        Bomb();
                        wordRecon = "";
                        break;
            }
        }
        else
        {
            print("No Spell");
        }
        canSpell = false;
    }

    private void InLumen()
    {
        channelLight = true;
        Light.SetBool("Create", true);
        print("InLumen");
        wordRecon = "";
    }

    private void Bomb()
    {
        print("Bomb");
        wordRecon = "";
    }

    private void Wrong()
    {
        print("Wrong");
        wordRecon = "";
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}