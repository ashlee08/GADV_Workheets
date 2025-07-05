using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile
{
    private float speed;
   
    public Projectile(float initialSpeed)
    {
        speed = initialSpeed;
    }

    public void Fire()
    {
        if (speed > 0)
        {
            Debug.Log($"Firing projectile at speed {speed}");
        }
        else
        {
            Debug.Log($"Cannot fire: speed too low.");
            AutoFire();
        }
    }

    private void AutoFire()
    {
        speed = 100;
        Debug.Log("Speed was zero. AutoFire set speed to 100 and launched!");
    }
}
public class Player
{
    private int health;  // now private

    // Constructor to set starting health
    public Player(int startingHealth)
    {
        health = Mathf.Clamp(startingHealth, 0, 10);  // optional cap at 10
    }

    // Reduces health by given amount
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    // Returns current health
    public int GetHealth()
    {
        return health;
    }
}

public class ScoreTracker
{
    private int score;

    // Adds to score (you can add validation here if needed)
    public void AddScore(int amount)
    {
        if (amount > 0)
        {
            score += amount;
        }
    }

    // Resets the score to 0
    public void ResetScore()
    {
        score = 0;
    }

    // Returns current score
    public int GetScore()
    {
        return score;
    }
}

public class TreasureChest
{
    // Virtual method - can be overridden
    public virtual void Unlock()
    {
        Debug.Log("You unlock the chest.");
    }
    public void Unlock(bool hasToken)
    {
        if (hasToken)
        {
            Debug.Log("You unlock the chest with a key and a special token! Bonus treasure!");
        }
        else
        {
            Unlock(); // Call the basic unlock, which will polymorphically call the overridden method if it exists
        }
    }

    // Non-virtual method - shared by all chests
    public void Shake()
    {
        Debug.Log("You hear something rattle inside the chest.");
    }
}
public class AncientChest : TreasureChest
{
    public override void Unlock()
    {
        Debug.Log("You unlock the ancient chest with an ancient key.");
    }
}
public class MagicChest : TreasureChest
{
    public override void Unlock()
    {
        Debug.Log("You cast a spell to unlock the magic chest.");
    }
}

public class Main : MonoBehaviour
{
    private Projectile projectile; // to demonstrate AutoFire and Fire methods
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player(10);
        player.TakeDamage(3);
        Debug.Log("Player health: " + player.GetHealth());
        projectile = new Projectile(0);

        AncientChest ancientChest = new AncientChest();
        Debug.Log("Test ancient chest unlock method:");
        ancientChest.Unlock(); // Calls the overridden method in AncientChest
        Debug.Log("Test ancient chest unlock overload method hasToken=True:");
        ancientChest.Unlock(true);
        Debug.Log("Test ancient chest unlock overload method hasToken=False:");
        ancientChest.Unlock(false);
        MagicChest magicChest = new MagicChest();
        Debug.Log("Test magic chest unlock method:");
        magicChest.Unlock(); // Calls the overridden method in MagicChest
        Debug.Log("Test magic chest unlock overload method hasToken=True:");
        magicChest.Unlock(true);
        Debug.Log("Test magic chest unlock overload method hasToken=False:");
        magicChest.Unlock(false);
        Debug.Log("Test ancient check shake method:");
        ancientChest.Shake(); // Calls the base method in TreasureChest
        Debug.Log("Test magic check shake method:");
        magicChest.Shake(); // Calls the base method in TreasureChest
        List<TreasureChest> chests = new List<TreasureChest> { ancientChest, magicChest };
        Debug.Log("Test polymorphism with a list of chests List<TreasureChest> chests:");
        foreach (TreasureChest chest in chests)
        {
            chest.Unlock(); // Calls the appropriate overridden method based on the actual type
            chest.Shake(); // Calls the base method in TreasureChest
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            projectile.Fire(); // Should trigger AutoFire
        }
    }
}
