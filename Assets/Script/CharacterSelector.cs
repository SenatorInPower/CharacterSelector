using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class CharacterSelector
{
    private static string pathHiro;

    private GameObject hiro;

    private string path = "Assets/Prefabs/References/Char";



    public void LoadHiro()
    {
        pathHiro = $"{path + UnityEngine.Random.Range(0, 16)}";

        ReleaseHiro();
        
        AsyncOperationHandle<GameObject> hiroHendler = Addressables.InstantiateAsync(pathHiro);


        hiroHendler.Completed += HiroCriation;
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

    }

}
