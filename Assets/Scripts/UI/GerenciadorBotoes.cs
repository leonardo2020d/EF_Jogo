using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorBotoes : MonoBehaviour
{
    public GameObject botaoObjetoPrefab;
    public Transform conteudoPainel;
    private Dictionary<GameObject, GameObject> botoesObjetos = new Dictionary<GameObject, GameObject>();
    public GameObject panelCorridaSelecionada;
    public TextMeshProUGUI valor;
    public TextMeshProUGUI nomePas;
    public TextMeshProUGUI distancia;
    public Passageiro passageiroAtual;
    
    public Transform player;
    private void Start()
    {
        panelCorridaSelecionada.SetActive(false);
        passageiroAtual = null;
    }
    public void CriarBotoes(List<Passageiro> listaObjetos)
    {
        //LimparBotoes();
        float buttonHeight = botaoObjetoPrefab.GetComponent<RectTransform>().rect.height;
        Vector3 offset = new Vector3(80, -15, 0); 
        foreach (Passageiro objeto in listaObjetos)
        {
            GameObject botaoGO = Instantiate(botaoObjetoPrefab, conteudoPainel);
            botaoGO.SetActive(true);

            // Atualiza o texto do botão com o nome ou a informação do objeto.
            TextMeshProUGUI textoBotao = botaoGO.GetComponentInChildren<TextMeshProUGUI>();
            textoBotao.text = objeto.nome;
            botoesObjetos[botaoGO] = objeto.gameObject;
            // Ajusta a posição do botão.
            RectTransform botaoRect = botaoGO.GetComponent<RectTransform>();
            botaoRect.anchoredPosition = offset;

            // Adicione aqui quaisquer outras configurações que você queira aplicar aos botões.

            // Incrementa o offset para posicionar o próximo botão abaixo do anterior.
            offset += new Vector3(0, -buttonHeight, 0);
            Button botaoComponente = botaoGO.GetComponent<Button>();
            botaoComponente.onClick.AddListener(() => ExibirInformacoesObjeto(botaoGO));
        }
    }
    private void ExibirInformacoesObjeto(GameObject botaoGO)
    {
        panelCorridaSelecionada.SetActive(true);
        // Recupera o objeto associado ao botão no dicionário.
        if (botoesObjetos.TryGetValue(botaoGO, out GameObject objeto))
        {
            valor.text = "Valor: " + objeto.GetComponent<Passageiro>().preco.ToString();
            nomePas.text = "Nome: " + objeto.GetComponent<Passageiro>().nome.ToString();
            distancia.text = "Distância: " + objeto.GetComponent<Passageiro>().distancia.ToString()+ "m";
            passageiroAtual = objeto.GetComponent<Passageiro>();
            objeto.GetComponent<Passageiro>().transform.GetChild(0).gameObject.SetActive(true);
           
       
           
            
            
            Debug.Log("Informações do objeto: " + objeto.GetComponent<Passageiro>().nome);
        }
    }
    public void LimparBotoes()
    {
        foreach (Transform child in conteudoPainel)
        {
            Destroy(child.gameObject);
        }
    }
    public void CorridaAceita()
    {
        passageiroAtual.corridaAceita = true;
    }

}
