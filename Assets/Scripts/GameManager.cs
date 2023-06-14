using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public double Totaltoast;
    double clicksPerSecond = 0;
    double clickPower = 1;
    double prizeUpg1 = 10;
    double prizeUpg2 = 25;
    double prizeUpg3 = 40;   
    double clicks = 0;
    double restoC;
    double ClicksDisplay;
    double restoUpg1;
    double Upg1Display;
    double restoUpg2;
    double Upg2Display;
    double restoUpg3;
    double Upg3Display;
    int Upg3 = 0;
    double restoCP;
    double restoCPS;
    double PorcentTpc;
    public int QuantUpg1 = 0;
    public int QuantUpg2 = 0;
    public int QuantUpg3 = 0;
    int largura = Screen.width;
    int altura = Screen.height;
    double Upg1Power = 0;
    double Upg2Power = 0;
    int saved = 0;


    public GameObject plusObject;
    public TMP_Text plusText;
    public TMP_Text clickText;
    public TMP_Text ClickPerSecondText;
    public TMP_Text Upg3Text;
    public TMP_Text prizeText1;
    public TMP_Text prizeText2;
    public TMP_Text QuantUpg1Text;
    public TMP_Text QuantUpg2Text;
    public TMP_Text QuantUpg3Text;
    public GameObject geleia;

    private void Start() {
        InvokeRepeating("IncreaseClicks",1f,1f);

        clicks = PlayerPrefs.GetFloat("clicks",0);
        if(clicks == 0){
                Upg3 = 0;
                clicksPerSecond = 0;
                clickPower = 1;
                prizeUpg1 = 10;
                prizeUpg2 = 25;
                prizeUpg3 = 40;   
                clicks = 0;
                QuantUpg1 = 0;
                QuantUpg2 = 0;
                QuantUpg3 = 0;
                Upg1Power = 0;
                Upg2Power = 0;
                Upg1Power = 1;
                Upg2Power = 0.1f;
        }
        else Load();
               
        //Valores que cada upgrade vai aumentar
        if(QuantUpg1 < 10) Upg1Power = 1;
        else if(QuantUpg1 >= 10 && QuantUpg1 < 20) Upg1Power = 5;
        else if (QuantUpg1 >= 20) Upg1Power = 10;


        if(QuantUpg2 < 10) Upg2Power = 0.1;
        else if(QuantUpg2 >= 10 && QuantUpg2 < 20) Upg2Power = 0.5;
        else if (QuantUpg2 >= 20) Upg2Power = 1;
    }
    private void Update() {
            //Formatação quantidade de Toasts
            if(clicks <= 1000){
                ClicksDisplay = clicks;
                if(restoC == 0) clickText.text = "Toasts: " + ClicksDisplay;
                else clickText.text = "Toasts: " + ClicksDisplay.ToString("N2");
            }

            else if(clicks >= 1000 && clicks < 1000000){
                ClicksDisplay = clicks / 1000;
                if(restoC == 0) clickText.text = "Toasts: " + ClicksDisplay + "Mil";
                else clickText.text = "Toasts: " + ClicksDisplay.ToString("N2") + "Mil";
            }

            else if(clicks >= 1000000){
                ClicksDisplay = clicks / 1000000;
                if(restoC == 0) clickText.text = "Toasts: " + ClicksDisplay + "Million";
                else clickText.text = "Toasts: " + ClicksDisplay.ToString("N2") + "Million";
            }


            //Formatação Upg1
            if(prizeUpg1 <= 1000){
                Upg1Display = prizeUpg1;
                if(restoUpg1 == 0) prizeText1.text = "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display;
                else prizeText1.text = "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display.ToString("N2");
            }

            else if(prizeUpg1 >= 1000 && prizeUpg1 < 1000000){
                Upg1Display = prizeUpg1 / 1000;
                if(restoUpg1 == 0) prizeText1.text = "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display + "Mil";
                else prizeText1.text = "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display.ToString("N2") + "Mil";
            }

            else if(prizeUpg1 >= 1000000){
                Upg1Display = prizeUpg1 / 1000000;
                if(restoUpg1 == 0) prizeText1.text =  "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display + "Million";
                else prizeText1.text = "+" + Upg1Power + " Click Power Upgrade: " + Upg1Display.ToString("N2") + "Million";
            }


            //Formataçao Upg2
            if(prizeUpg2 <= 1000){
                Upg2Display = prizeUpg2;
                if(restoUpg2 == 0) prizeText2.text = "+" + Upg2Power.ToString("N1") + " Click Power Upgrade: " + Upg2Display;
                else prizeText2.text = "+" + Upg2Power.ToString("N1") + " Click Power Upgrade: " + Upg2Display.ToString("N2");
            }

            else if(prizeUpg2 >= 1000 && prizeUpg2 < 1000000){
                Upg2Display = prizeUpg2 / 1000;
                if(restoUpg2 == 0) prizeText2.text = "+" + Upg2Power.ToString("N2") + " Click Power Upgrade: " + Upg2Display + "Mil";
                else prizeText2.text = "+" + Upg2Power.ToString("N1") + " Click Power Upgrade: " + Upg2Display.ToString("N2") + "Mil";
            }

            else if(prizeUpg2 >= 1000000){
                Upg2Display = prizeUpg2 / 1000000;
                if(restoUpg2 == 0) prizeText2.text = "+" + Upg2Power.ToString("N2") + " Click Power Upgrade: " + Upg2Display + "Million";
                else prizeText2.text = "+" + Upg2Power.ToString("N1") + " Click Power Upgrade: " + Upg2Display.ToString("N2") + "Million";
            }


             //Formatação Upg3       
             if(prizeUpg3 <= 1000){
                Upg3Display = prizeUpg3;
                if(restoUpg3 == 0 && Upg3 == 0) Upg3Text.text = "1%TPS + Click Power: " + Upg3Display;
                else if(Upg3 == 1 && restoUpg3 == 0) Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display;
                else Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display.ToString("N2");
            }

            else if(prizeUpg3 >= 1000 && prizeUpg3 < 1000000){
                Upg3Display = prizeUpg3 / 1000;
                if(Upg3 == 1 && restoUpg3 == 0) Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display + "Mil";
                else Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display.ToString("N2") + "Mil";
            }

            else if(prizeUpg3 >= 1000000){
                Upg3Display = prizeUpg3 / 1000000;
                if(Upg3 == 1 && restoUpg3 == 0) Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display + "Million";
                else Upg3Text.text = "+1%TPS + Click Power: " + Upg3Display.ToString("N2") + "Million";
            }
       
        if(restoCP == 0) plusText.text = "+ " + clickPower;
        else plusText.text = "+ " + clickPower.ToString("N2");

        if(restoCPS == 0) ClickPerSecondText.text = "Toasts Per Second: " + clicksPerSecond;
        else ClickPerSecondText.text = "Toasts Per Second: " + clicksPerSecond.ToString("N2");

        QuantUpg1Text.text = "" + QuantUpg1;
        QuantUpg2Text.text = "" + QuantUpg2;
        QuantUpg3Text.text = "" + QuantUpg3;

        if(QuantUpg1 >= 25 && QuantUpg2 >= 25 && QuantUpg3 >= 25){
            geleia.gameObject.SetActive(true);
        }
        else geleia.gameObject.SetActive(false);

        restoC = (clicks % 1);   
        restoUpg1 = (prizeUpg1 % 1);
        restoUpg2 = (prizeUpg2 % 1);
        restoUpg3 = (prizeUpg3 % 1);
        restoCP = (clickPower % 1);
        restoCPS = (clicksPerSecond % 1); 
        PorcentTpc = (clicksPerSecond * QuantUpg3/100); 

        saved = 1;
        save();
        
       
    }
    public void Click(){
        clicks= clicks + clickPower;
        Totaltoast = Totaltoast + clickPower;
        plusObject.SetActive(false);
        plusObject.transform.position = new Vector3(Random.Range((largura / 6),(largura / 6) + (largura / 5) +1),Random.Range((altura/2) + (altura/6),(altura/2) + (altura /4) ),0);
        plusObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(Fly());
    }
    
    public void ShopUpg1(){
        if (clicks>=prizeUpg1){
            clicks -= prizeUpg1;
            QuantUpg1++;
            if(QuantUpg1 < 10){
                Upg1Power = 1;
                clickPower= clickPower +1;
            }
            else if (QuantUpg1 < 20 && QuantUpg1 >= 10){
                Upg1Power = 5; 
                clickPower = clickPower +5;
            }     
            else if (QuantUpg1 >= 20){
                Upg1Power = 10;
                 clickPower= clickPower +10;
            }
            prizeUpg1 = prizeUpg1 * 1.3f ;
            if(Upg3 == 1) RefreshUpg3();
        }
    }

    public void ShopUpg2(){
        if(clicks>=prizeUpg2){
            clicks -=prizeUpg2;
            QuantUpg2++;
            if(QuantUpg2 < 10){
                Upg2Power = 2.5f;
                clicksPerSecond = clicksPerSecond + 0.1f;
            }
            else if(QuantUpg2 < 20 && QuantUpg2 >= 10){
                Upg2Power = 5.5f;
                clicksPerSecond = clicksPerSecond + 0.5f;
            }
            else if(QuantUpg2 >= 20){
                Upg2Power = 10.0F;
                clicksPerSecond = clicksPerSecond + 1.0f;
            }
            prizeUpg2 = prizeUpg2 * 1.4f;
            if(Upg3 == 1) RefreshUpg3();
        }
    }
    public void ShopUpg3(){
        if(clicks>=prizeUpg3){
            clicks -=prizeUpg3;
            prizeUpg3 = prizeUpg3 * 1.6f;
            Upg3 = 1;
            QuantUpg3++;
            RefreshUpg3();
        }
    }

    private void IncreaseClicks(){
        clicks = clicks + clicksPerSecond;
        Totaltoast = Totaltoast + clicksPerSecond;
    }
    private void RefreshUpg3(){
        clickPower =  clickPower + (PorcentTpc);
    }

    IEnumerator Fly(){
        for(int i=0;i<=19;i++){
            yield return new WaitForSeconds(0);

            plusObject.transform.position = new Vector3(plusObject.transform.position.x,plusObject.transform.position.y +2, 0);
        }
        plusObject.SetActive(false);
    }

    public void Reset(){
        Upg3 = 0;
        clicksPerSecond = 0;
        clickPower = 1;
        prizeUpg1 = 10;
        prizeUpg2 = 25;
        prizeUpg3 = 40;   
        clicks = 0;
        QuantUpg1 = 0;
        QuantUpg2 = 0;
        QuantUpg3 = 0;
        Upg1Power = 0;
        Upg2Power = 0;
        Upg1Power = 1;
        Upg2Power = 0.1f;
    }

    private void Load(){
        clicks = PlayerPrefs.GetFloat("clicks",0);
        clickPower = PlayerPrefs.GetFloat("clickPower",0);
        clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond",0);
        prizeUpg1 = PlayerPrefs.GetFloat("prizeUpg1",0);
        prizeUpg2 = PlayerPrefs.GetFloat("prizeUpg2",0);
        prizeUpg3 = PlayerPrefs.GetFloat("prizeUpg3",0);
        QuantUpg1 = PlayerPrefs.GetInt("QuantUpg1",0);
        QuantUpg2 = PlayerPrefs.GetInt("QuantUpg2",0);
        QuantUpg3 = PlayerPrefs.GetInt("QuantUpg3",0);
        Upg3 = PlayerPrefs.GetInt("Upg3",0);
        PorcentTpc = PlayerPrefs.GetFloat("PorcentTPS",0);
        saved = PlayerPrefs.GetInt("saved",0);
    }

    private void save(){
        PlayerPrefs.SetFloat("clicks",(float)clicks);
        PlayerPrefs.SetFloat("clickPower",(float)clickPower);
        PlayerPrefs.SetFloat("clicksPerSecond",(float)clicksPerSecond);
        PlayerPrefs.SetFloat("prizeUpg1",(float)prizeUpg1);
        PlayerPrefs.SetFloat("prizeUpg2",(float)prizeUpg2);
        PlayerPrefs.SetFloat("prizeUpg3",(float)prizeUpg3);
        PlayerPrefs.SetInt("QuantUpg2",(int)QuantUpg2);
        PlayerPrefs.SetInt("QuantUpg1",(int)QuantUpg1);
        PlayerPrefs.SetInt("QuantUpg3",(int)QuantUpg3);
        PlayerPrefs.SetInt("Upg3",(int)Upg3);
        PlayerPrefs.SetFloat("PorcentTPS",(float)PorcentTpc);
        saved = 1;
    }
}
