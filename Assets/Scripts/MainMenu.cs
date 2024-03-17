using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField]private int _currentLevel = 1;

   public void ChangeCurrentLevel(string level)
   {
      Debug.Log($"{level}");
      if (int.Parse(level) <= 0 || int.Parse(level) > 2)
      {
         Debug.LogError($"Недопустимое значение уровня");
         return;
      }
      _currentLevel = int.Parse(level);
   }

   public void StartNewGame()
   {
      SceneManager.LoadScene(1);
   }

   public void SelectLevel()
   {
      SceneManager.LoadScene(_currentLevel);
   }

   public void ExitGame()
   {
      Application.Quit();
   }

}
