using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script para ser chamado pelo botão "Jogar".
/// Permite carregar uma cena ou ativar o root do jogo e desativar o menu.
/// </summary>
public class BotaoJogar : MonoBehaviour
{
    private const string TargetScene = "SampleScene";

    // Método a ser atribuído ao OnClick do botão
    public void Jogar()
    {
        SceneManager.LoadScene(TargetScene);
    }
}