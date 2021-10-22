using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class CharacterSelector
{
    private string pathHiro;

    private GameObject hiro;

    private const string path = "Assets/Prefabs/References/Char";

    bool first=true;

    AsyncOperationHandle<GameObject> hiroHendler;

    public void LoadHiro()
    {
        if (first || hiroHendler.IsDone)
        {
            pathHiro = $"{path + UnityEngine.Random.Range(0, 16)}";

            ReleaseHiro();

            hiroHendler = Addressables.InstantiateAsync(pathHiro);
            if (first)
            {
                hiroHendler.Completed += HiroCriation;
                first = false;
            }
        }
    }

    private void HiroCriation(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        hiro = obj.Result;
        
    }
    void ReleaseHiro()
    {
        if (hiro)
        {
            Addressables.Release(hiro);
        }

    }
    public void LoadScen()
    {
        ReleaseHiro();

        SceneManager.LoadScene("Game");
        SceneManager.sceneLoaded += delegate { Addressables.InstantiateAsync(pathHiro); };
        Addressables.Release(hiroHendler);

    }
  
}
