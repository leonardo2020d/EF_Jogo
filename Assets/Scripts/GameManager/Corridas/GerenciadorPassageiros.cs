using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GerenciadorPassageiros : MonoBehaviour
{
    public GameObject prefabPassageiro;
    public Transform conteudoPainel;

    private List<Passageiro> passageiros = new List<Passageiro>();

    // M�todo para adicionar um passageiro � lista e criar um painel representando suas informa��es
    public void AdicionarPassageiro(Passageiro passageiro)
    {
        passageiros.Add(passageiro);

        // Cria uma c�pia do prefab de passageiro e coloca-o como filho do conte�do do painel
        GameObject passageiroGO = Instantiate(prefabPassageiro, conteudoPainel);
        passageiroGO.SetActive(true);

        // Atualiza as informa��es do passageiro na UI
        AtualizarInfoPassageiro(passageiroGO, passageiro);
    }

    // M�todo para atualizar as informa��es de um passageiro no painel
    private void AtualizarInfoPassageiro(GameObject passageiroGO, Passageiro passageiro)
    {
        // Acesse os elementos de UI do painel do passageiro usando GetComponentInChildren<Text>() e GetComponentInChildren<Button>()

        // Por exemplo:
        Text precoText = passageiroGO.GetComponentInChildren<Text>();
        precoText.text = "Pre�o: " + passageiro.preco.ToString();

        Text destinoText = passageiroGO.transform.Find("Destino").GetComponent<Text>();
        destinoText.text = "Destino: " + passageiro.destino.name;

        Button botaoAceitar = passageiroGO.GetComponentInChildren<Button>();
        botaoAceitar.onClick.AddListener(() => AceitarCorrida(passageiro));
    }

    // M�todo chamado quando o bot�o de aceitar corrida � clicado
    private void AceitarCorrida(Passageiro passageiro)
    {
        Debug.Log("Corrida aceita! Pre�o: " + passageiro.preco + ", Destino: " + passageiro.destino.name);
        // Fa�a aqui a l�gica para pegar a corrida e lev�-la ao destino, usando o passageiro como base.
    }
}
