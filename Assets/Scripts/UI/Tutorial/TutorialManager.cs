using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    public string[] tutorialMessages; // Array de mensagens do tutorial.
    private int currentMessageIndex = 0;
    private bool tutorialPaused = false;
    public GameObject botaopf;

    private void Start()
    {
        /*Inicialize as mensagens do tutorial.
        tutorialMessages = new string[]
        {
            "Bem-vindo ao tutorial!",
            "Pressione qualquer tecla para continuar.",
            "Aqui está uma dica importante.",
            "Pressione novamente para continuar.",
            "Você aprendeu tudo o que precisa saber. Divirta-se!"
        };*/

        // Inicialmente, esconda o painel de tutorial.
        tutorialPanel.SetActive(false);

        // Inicie o tutorial.
        MostrarProximaMensagem();
        botaopf.SetActive(false);
    }

    public void MostrarProximaMensagem()
    {
        if (currentMessageIndex < tutorialMessages.Length)
        {
            // Atualize o texto do tutorial.
            tutorialText.text = tutorialMessages[currentMessageIndex];

            // Pause o tutorial para aguardar a entrada do jogador.
            tutorialPaused = true;

            // Mostre o painel de tutorial.
            tutorialPanel.SetActive(true);

            // Avance para a próxima mensagem.
            currentMessageIndex++;
        }
        else
        {
            // Se todas as mensagens do tutorial foram exibidas, desative o painel e encerre o tutorial.
            tutorialPanel.SetActive(false);
            tutorialPaused = false;
            currentMessageIndex = 0;
            botaopf.SetActive(true);
        }
    }
}
