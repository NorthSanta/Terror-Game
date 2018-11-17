using UnityEngine;
using UnityEngine.UI;

public class Assign_Decisions : MonoBehaviour {

    public int Choice1, Choice2, Choice3, Choice4;

    public Text xText, bText, yText, aText;

    public Decisions Decisions;
    public GameObject panel;

    public GameObject EventSlider;
    public static bool screaming;
    public static bool stomping;
    public static bool struggling;
    public Animation anim;
    int key = 2;
	// Use this for initialization
	void Start () {
        Decision_effects.screamSlider = EventSlider;
        //Decision_effects.screaming = screaming;
    }
	
	// Update is called once per frame
	void Update () {
        if (Player_Movement.inDecision)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Decision_effects.GetChoice(Choice1);
                //cridar funcio amb choice 3;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Decision_effects.GetChoice(Choice2);
                //cridar funcio amb id 3;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Decision_effects.GetChoice(Choice3);
                //cridar funcio amb id 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Decision_effects.GetChoice(Choice4);
                //cridar funcio amb id 3;
            }
        }
        else if(!Player_Movement.inDecision)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
        }
        TimeToScream(anim);
        TimeToStomp();
        TimeToStruggle();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            assign();
        }
    }

    public void assign()
    {
        Player_Movement.inDecision = true;
        panel.SetActive(true);
        if(Choice1 == -1)
        {
            xText.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            xText.gameObject.transform.parent.gameObject.SetActive(true);
        }

        if (Choice2 == -1)
        {
            bText.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            bText.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (Choice3 == -1)
        {
            yText.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            yText.gameObject.transform.parent.gameObject.SetActive(true);
        }
        if (Choice4 == -1)
        {
            aText.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            aText.gameObject.transform.parent.gameObject.SetActive(true);
        }
        xText.text = Decisions.decisions[Choice1];
        bText.text = Decisions.decisions[Choice2];
        yText.text = Decisions.decisions[Choice3];
        aText.text = Decisions.decisions[Choice4];
    }
    public static void Scream(GameObject slider, bool scream)
    {
        slider.SetActive(true);
        screaming = scream;
    }

    public static void Stomp(GameObject slider, bool stomp)
    {
        slider.SetActive(true);
        stomping = stomp;
    }

    public static void Struggle(GameObject slider, bool strugle)
    {
        slider.SetActive(true);
        struggling = strugle;
    }

    private void TimeToScream(Animation anim)
    {
        if (screaming)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
            if (Input.GetKey(KeyCode.W))
            {

                if (EventSlider.GetComponent<Slider>().value < 1)
                {
                    Debug.Log("Screamingingingi");
                    EventSlider.GetComponent<Slider>().value += Time.deltaTime;
                }
                else
                {
                    screaming = false;
                    EventSlider.SetActive(false);
                    EventSlider.GetComponent<Slider>().value = 0;
                    //play screamANIM;
                    panel.SetActive(true);
                }
            }
        }
    }

    private void TimeToStomp()
    {
        if (stomping)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {

                if (EventSlider.GetComponent<Slider>().value < 1)
                {
                    Debug.Log("Stompinggigiginging");
                    EventSlider.GetComponent<Slider>().value += 0.2f;
                }
                else
                {
                    stomping = false;
                    EventSlider.SetActive(false);
                    EventSlider.GetComponent<Slider>().value = 0;
                    //play screamANIM;
                    panel.SetActive(true);
                }
            }
        }
    }

    private void TimeToStruggle()
    {
        if (struggling)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.A) && key != 0)
            {
                key = 0;
                if (EventSlider.GetComponent<Slider>().value < 1)
                {
                    Debug.Log("Struglinlingingg");
                    EventSlider.GetComponent<Slider>().value += 0.1f;
                }
                else
                {
                    stomping = false;
                    EventSlider.SetActive(false);
                    EventSlider.GetComponent<Slider>().value = 0;
                    //play screamANIM;
                    panel.SetActive(true);
                }
            }else if (Input.GetKeyDown(KeyCode.D) && key != 1)
            {
                key = 1;
                if (EventSlider.GetComponent<Slider>().value < 1)
                {
                    Debug.Log("Struglinlingingg");
                    EventSlider.GetComponent<Slider>().value += 0.1f;
                }
                else
                {
                    stomping = false;
                    EventSlider.SetActive(false);
                    EventSlider.GetComponent<Slider>().value = 0;
                    //play screamANIM;
                    panel.SetActive(true);
                }
            }
        }
    }
}
