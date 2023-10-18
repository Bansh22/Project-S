using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs; // 캐릭터 프리팹 배열
    public Transform characterSpawnPoint; // 캐릭터가 생성될 위치
    public Text selectedCharacterText; // 선택한 캐릭터를 나타내는 UI 텍스트

    private GameObject selectedCharacter; // 선택한 캐릭터의 현재 인스턴스

    // 캐릭터를 선택하는 함수
    public void SelectCharacter(int characterIndex)
    {
        // 이전에 선택한 캐릭터를 제거
        if (selectedCharacter != null)
        {
            Destroy(selectedCharacter);
        }

        // 선택한 캐릭터 프리팹을 생성하고 캐릭터 스폰 포인트에 배치
        selectedCharacter = Instantiate(characterPrefabs[characterIndex], characterSpawnPoint.position, Quaternion.identity);

        // 선택한 캐릭터 정보 표시
        selectedCharacterText.text = "Selected Character: " + characterPrefabs[characterIndex].name;
    }

    // 게임 시작 시 호출
    private void Start()
    {
        // 기본 캐릭터 선택 (예: 첫 번째 캐릭터)
        SelectCharacter(0);
    }

    // 선택한 캐릭터를 저장하는 함수
    public void SaveSelectedCharacter()
    {
        // 선택한 캐릭터 데이터를 저장하거나 플레이어 프로필에 저장
       // PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();
    }

    // 선택한 캐릭터를 불러오는 함수
    public void LoadSelectedCharacter()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        SelectCharacter(selectedCharacterIndex);
    }
}
