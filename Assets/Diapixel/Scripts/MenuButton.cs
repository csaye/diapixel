using UnityEngine;
using UnityEngine.SceneManagement;

namespace Diapixel
{
    public class MenuButton : MonoBehaviour
    {
        public void SwitchScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
