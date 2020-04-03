using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public InputField daxil;
  //  public Slider s1;
    public float sd1,  ferqucundeyer,inputDeyer;
    public  AudioSource audioData;
    public GameObject errorPanel;
    SerialPort sp = new SerialPort("COM4", 9600);
    SerialPort sp2 = new SerialPort("COM3", 9600);
    public string deyer1,deyer2;
    public Text tez1, tez2, ferqtext;//, IT1;
    public Image errorMan;
    public string daxiledilen;
    void Start()
    {
        errorPanel.SetActive(false);
        sp.Open();
        sp.ReadTimeout = -1;
        sp2.Open();
        sp2.ReadTimeout = -1;
        errorMan.GetComponent<Image>().color = new Color32(255, 255, 225, 225);
        tez1.GetComponent<Text>();
        tez2.GetComponent<Text>();
        ferqtext.GetComponent<Text>();
        audioData = GetComponent<AudioSource>();
       // IT1.GetComponent<Text>();
        

    }
    private void LateUpdate()
    {
        // sd1 = s1.value;
        daxiledilen = daxil.text;
        string[] inputDeyer= daxiledilen.Split(',');
      //  IT1.text = "" + ferqucundeyer;

        ferqucundeyer = float.Parse(inputDeyer[0]);

    }
    
    void Update()
    {

        if (sp.IsOpen && sp2.IsOpen)
        {
            deyer1 = sp.ReadLine();
            deyer2 = sp2.ReadLine();
        }
       
        else {
            errorPanel.SetActive(true);
        }  


        string[] bir  = deyer1.Split(',');
        string[] iki  = deyer2.Split(',');
        float IMP1 = float.Parse(bir[0]);
        float IMP2 = float.Parse(iki[0]);
        float ferq =  Mathf.Abs( IMP1 - IMP2);
        Debug.Log(ferq);
        tez1.text = "" + IMP1;
        tez2.text = "" + IMP2;
        ferqtext.text = "" + ferq;
        Debug.Log(ferqucundeyer);
        if (ferq >= ferqucundeyer)
        {
            Debug.Log("asasas");

            errorMan.GetComponent<Image>().color = new Color32(255, 0, 0, 225);
            audioData.Play();
        }
        else
        {
            errorMan.GetComponent<Image>().color = new Color32(255, 225, 225, 225);
            audioData.Stop();
        }
    }
    

}
