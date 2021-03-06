using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class CardScript : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    private string btnName;

    public TextMeshPro cardTitle, cardContent;

    private ArrayList urls;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        int targetFps = VuforiaRenderer.Instance.GetRecommendedFps(VuforiaRenderer.FpsHint.NONE);
        urls = new ArrayList();
        urls.Add("https://api.whatsapp.com/send?phone=5548999726498&text=Bom dia!");
        urls.Add("fb://page/382171845278904");
        urls.Add("instagram://user?username=vini.vieiraaa");
        urls.Add("https://www.linkedin.com/in/viniciustomevieira/");
        urls.Add("http://globoesporte.globo.com/");

        if (Application.targetFrameRate != targetFps){
            Debug.Log("Setting frame rate to " + targetFps + "fps");
            Application.targetFrameRate = targetFps;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray rayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
            RaycastHit hit;
            if(Physics.Raycast(rayTouch, out hit)){
                btnName = hit.transform.name;
                switch(btnName){
                    case "Logo_zap": 
                        executarAnimacao("whatsapp"); 
                        cardTitle.text = "Whatsapp";
                        cardContent.text = "Clique aqui para acessar"; 
                        break;
                    case "Logo_insta": executarAnimacao("instagram");
                        cardTitle.text = "Instagram";
                        cardContent.text = "Clique aqui para acessar"; 
                        break;
                    case "Logo_facebook": executarAnimacao("facebook");
                        cardTitle.text = "Facebook";
                        cardContent.text = "Clique aqui para acessar"; 
                        break;
                    case "Logo_linkedin": executarAnimacao("linkedin"); 
                        cardTitle.text = "Linkedin";
                        cardContent.text = "Clique aqui para acessar"; 
                        break;
                    case "Logo_site": executarAnimacao("site"); 
                        cardTitle.text = "Site";
                        cardContent.text = "Clique aqui para acessar";
                        break;
                    case "Logo_zap_card": abrirSite(cardTitle.text); break;
                }                                    
            }
        }
    }

    void executarAnimacao(string botao){
        if(animator.GetBool(botao)){
            animator.SetBool(botao, false);
        }else{
            animator.SetBool(botao, true);
        }
    } 
    void abrirSite(string site){
        switch(site){
            case "Whatsapp": Application.OpenURL(urls[0].ToString()); break;
            case "Facebook": Application.OpenURL(urls[1].ToString()); break;
            case "Instagram": Application.OpenURL(urls[2].ToString()); break;
            case "Linkedin": Application.OpenURL(urls[3].ToString()); break;
            case "Site": Application.OpenURL(urls[4].ToString()); break;
        }
    }
}