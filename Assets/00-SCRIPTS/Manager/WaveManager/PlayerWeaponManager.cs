using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponManager : Singleton<PlayerWeaponManager>
{
    // Start is called before the first frame update

    [Header("Weapons info")]
    public Transform weaponsParent;
    public List<Weapon> unAssignedWeapons, assignedwWeapons;

    public List<Weapon> weaponToUpgrade;
    public List<Weapon> fullyLevelWeaon = new List<Weapon>();


    public LevelUpSelectionButton[] levelUpButon;
    private void OnEnable()
    {
        WaveManager.Instant.onPlayerLevelUp += SetRandomCard;
    }
    private void OnDestroy()
    {
        WaveManager.Instant.onPlayerLevelUp -= SetRandomCard;

    }
    void Start()
    {
        // WaveManager.Instant.onPlayerLevelUp += SetRandomCard;
        
        SetUpUnAssignedWeapons();
        //ran dom vũ khi ban đàu

        int randWeapon = Random.Range(0, unAssignedWeapons.Count);
        // Debug.Log("rane "+randWeapon);

        AddWeapon(randWeapon);
    }



    public void SetRandomCard()
    {

        weaponToUpgrade.Clear();
        List<Weapon> cardStore = new List<Weapon>();
        cardStore.AddRange(unAssignedWeapons);
        cardStore.AddRange(assignedwWeapons);

        // Ngẫu nhiên chọn đến 3 vũ khí khác nhau
        while (weaponToUpgrade.Count < 3 && cardStore.Count > 0)
        {
            int selectRand = Random.Range(0, cardStore.Count);
            weaponToUpgrade.Add(cardStore[selectRand]);

            // Loại bỏ vũ khí đã chọn để tránh chọn lại
            cardStore.RemoveAt(selectRand);
        }

        // Cập nhật UI để hiển thị các vũ khí trong weaponToUpgrade
        for (int i = 0; i < UIManager.Instant.levelUpButon.Length; i++)
        {
            if (i < weaponToUpgrade.Count)
            {

                UIManager.Instant.levelUpButon[i].UpdateButtonDisplay(weaponToUpgrade[i].GetComponent<Weapon>());

            }
            else
            {
                UIManager.Instant.levelUpButon[i].gameObject.SetActive(false); // Ẩn nút nếu không có vũ khí nào
            }
        }
        // Cập nhật để ẩn hiển thị các nút vũ khí đã max cấp
        for (int i = 0; i < UIManager.Instant.levelUpButon.Length; i++)
        {
            if (i < weaponToUpgrade.Count)
            {
                bool isFullyLeveled = fullyLevelWeaon.Contains(weaponToUpgrade[i]);
                UIManager.Instant.levelUpButon[i].gameObject.SetActive(!isFullyLeveled); // Hiển thị hoặc ẩn nút dựa trên cấp độ
            }
        }
    }

    // Update is called once per frame
    public void AddWeapon(int indexRand)
    {

        if (indexRand < unAssignedWeapons.Count)
        {
            assignedwWeapons.Add(unAssignedWeapons[indexRand]);
            unAssignedWeapons[indexRand].gameObject.SetActive(true);
            unAssignedWeapons.RemoveAt(indexRand);
        }
    }
    public void AddWeapon(Weapon weaponToAdd)
    {

        weaponToAdd.gameObject.SetActive(true);
        assignedwWeapons.Add(weaponToAdd);
        unAssignedWeapons.Remove(weaponToAdd);

    }
    void SetUpUnAssignedWeapons()
    {
        unAssignedWeapons = new List<Weapon>();

        foreach (Transform weapon in weaponsParent)
        {
            unAssignedWeapons.Add(weapon.GetComponent<Weapon>());
        }
    }
}
