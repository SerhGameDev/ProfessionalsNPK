using System.Data;
using Core.Infrastructure;
using UnityEngine.SceneManagement;

namespace Core.Menu
{
    public sealed class MiniGamePanel : Panel
    {
        public void OpenGame(int id) => SceneManager.LoadScene(id);
    }

}