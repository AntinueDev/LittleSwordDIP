
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LittleSword.Common;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Logger = LittleSword.Common.Logger;
using Object = UnityEngine.Object;

//using Object = System.Object;

public class AddressableManager : Singleton<AddressableManager>
{
    // 캐싱용 딕셔너리
    private Dictionary<string, Object> cachedAssets = new();
    // 핸들 해제시 사용할 딕셔너리
    private Dictionary<string, AsyncOperationHandle> loadedHandles = new();

    // Addressable 비동기 방식으로 로딩 및 반환
    public async Task<T> LoadAssetAsync<T>(string address) where T : Object
    {
        // 캐싱에서 검색
        if (cachedAssets.TryGetValue(address, out Object cachedAsset))
        {
            Logger.Log("캐시된 에셋 로드");
            return (T)cachedAsset;
        }
        
        var handle = Addressables.LoadAssetAsync<T>(address);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Logger.Log("새로 로드한 에셋");
            cachedAssets[address] = handle.Result;
            loadedHandles[address] = handle;
            return handle.Result;
        }
        else
        {
            // 로드 실패한 핸들을 해제
            Addressables.Release(handle);
            return null;
        }
    }
    
    // 모든 캐시 삭제 
    public void ReleaseAllAssets()
    {
        foreach (var handle in loadedHandles.Values)
        {
            Addressables.Release(handle);
        }
        cachedAssets.Clear();
        loadedHandles.Clear();
        Logger.Log("모든 캐시 어드레서블 해제");
    }

    private void OnDestroy()
    {
        ReleaseAllAssets();
    }
}
