using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public string fullText2;
    public string fullText3;
    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText (){
        for (int i =0; i<fullText.Length;i++ ){
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(3f);
        this.GetComponent<Text>().text="";

         for (int i =0; i<fullText2.Length;i++ ){
            currentText = fullText2.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(3f);
        this.GetComponent<Text>().text="";

        for (int i =0; i<fullText3.Length;i++ ){
            currentText = fullText3.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(3f);
        this.GetComponent<Text>().text="";
    }

}
