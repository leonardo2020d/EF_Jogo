using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GerenciadorPassageiros : MonoBehaviour
{
    public GameObject prefabPassageiro;
    public Transform conteudoPainel;

    private List<Passageiro> passageiros = new List<Passageiro>();

    // Método para adicionar um passageiro à lista e criar um painel representando suas informações
    public void AdicionarPassageiro(Passageiro passageiro)
    {
        passageiros.Add(passageiro);

        // Cria uma cópia do prefab de passageiro e coloca-o como filho do conteúdo do painel
        GameObject passageiroGO = Instantiate(prefabPassageiro, conteudoPainel);
        passageiroGO.SetActive(true);

        // Atualiza as informações do passageiro na UI
        AtualizarInfoPassageiro(passageiroGO, passageiro);
    }

    // Método para atualizar as informações de um passageiro no painel
    private void AtualizarInfoPassageiro(GameObject passageiroGO, Passageiro passageiro)
    {
        // Acesse os elementos de UI do painel do passageiro usando GetComponentInChildren<Text>() e GetComponentInChildren<Button>()

        // Por exemplo:
        Text precoText = passageiroGO.GetComponentInChildren<Text>();
        precoText.text = "Preço: " + passageiro.preco.ToString();

        Text destinoText = passageiroGO.transform.Find("Destino").GetComponent<Text>();
        destinoText.text = "Destino: " + passageiro.destino.name;

        Button botaoAceitar = passageiroGO.GetComponentInChildren<Button>();
        botaoAceitar.onClick.AddListener(() => AceitarCorrida(passageiro));
    }

    // Método chamado quando o botão de aceitar corrida é clicado
    private void AceitarCorrida(Passageiro passageiro)
    {
        Debug.Log("Corrida aceita! Preço: " + passageiro.preco + ", Destino: " + passageiro.destino.name);
        // Faça aqui a lógica para pegar a corrida e levá-la ao destino, usando o passageiro como base.
    }
}
