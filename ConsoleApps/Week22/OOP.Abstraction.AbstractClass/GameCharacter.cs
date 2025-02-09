using System;
using System.Collections.Generic;

namespace OOP.Abstraction.AbstractClass
{
    /// <summary>
    /// Represents an abstract game character with basic properties and methods.
    /// </summary>
    public abstract class GameCharacter
    {
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the level of the character.
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// Gets the current health of the character.
        /// </summary>
        public double Health { get; protected set; }

        /// <summary>
        /// Gets the maximum health of the character.
        /// </summary>
        public double MaxHealth { get; protected set; }

        /// <summary>
        /// Gets the stats of the character.
        /// </summary>
        protected Dictionary<string, double> Stats { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCharacter"/> class.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="level">The level of the character.</param>
        protected GameCharacter(string name, int level)
        {
            Name = name;
            Level = level;
            Stats = new Dictionary<string, double>();
            InitializeStats();
        }

        /// <summary>
        /// Initializes the stats of the character. This method must be implemented by derived classes.
        /// </summary>
        public abstract void InitializeStats();

        /// <summary>
        /// Levels up the character. This method must be implemented by derived classes.
        /// </summary>
        public abstract void LevelUp();

        /// <summary>
        /// Calculates the damage dealt by the character based on the attack type. This method must be implemented by derived classes.
        /// </summary>
        /// <param name="attackType">The type of attack.</param>
        /// <returns>The damage dealt by the character.</returns>
        public abstract double CalculateDamage(string attackType);

        /// <summary>
        /// Takes damage and reduces the character's health. This method must be implemented by derived classes.
        /// </summary>
        /// <param name="damage">The amount of damage taken.</param>
        public abstract void TakeDamage(double damage);

        /// <summary>
        /// Uses the character's special ability. This method must be implemented by derived classes.
        /// </summary>
        public abstract void UseSpecialAbility();

        /// <summary>
        /// Heals the character by a specified amount.
        /// </summary>
        /// <param name="amount">The amount to heal.</param>
        public virtual void Heal(double amount)
        {
            Health = Math.Min(Health + amount, MaxHealth);
        }

        /// <summary>
        /// Determines whether the character is alive.
        /// </summary>
        /// <returns>True if the character is alive; otherwise, false.</returns>
        public virtual bool IsAlive()
        {
            return Health > 0;
        }

        /// <summary>
        /// Updates the character's stats.
        /// </summary>
        /// <param name="stat">The name of the stat.</param>
        /// <param name="value">The value of the stat.</param>
        protected virtual void UpdateStats(string stat, double value)
        {
            if (Stats.ContainsKey(stat))
                Stats[stat] = value;
            else
                Stats.Add(stat, value);
        }
    }

    /// <summary>
    /// Represents a warrior character with specific properties and methods.
    /// </summary>
    public class Warrior : GameCharacter
    {
        /// <summary>
        /// Gets the current rage of the warrior.
        /// </summary>
        public double Rage { get; private set; }

        /// <summary>
        /// Gets the maximum rage of the warrior.
        /// </summary>
        public double MaxRage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Warrior"/> class.
        /// </summary>
        /// <param name="name">The name of the warrior.</param>
        /// <param name="level">The level of the warrior.</param>
        public Warrior(string name, int level) : base(name, level)
        {
            MaxRage = 100;
            Rage = MaxRage;
        }

        /// <summary>
        /// Initializes the stats of the warrior.
        /// </summary>
        public override void InitializeStats()
        {
            MaxHealth = 100 + (Level * 10);
            Health = MaxHealth;
            UpdateStats("Strength", 10 + (Level * 2));
            UpdateStats("Defense", 8 + (Level * 1.5));
            UpdateStats("Agility", 5 + Level);
        }

        /// <summary>
        /// Levels up the warrior.
        /// </summary>
        public override void LevelUp()
        {
            Level++;
            InitializeStats();
            Rage = MaxRage;
            Console.WriteLine($"{Name} has reached level {Level}!");
        }

        /// <summary>
        /// Calculates the damage dealt by the warrior based on the attack type.
        /// </summary>
        /// <param name="attackType">The type of attack.</param>
        /// <returns>The damage dealt by the warrior.</returns>
        public override double CalculateDamage(string attackType)
        {
            double baseDamage = Stats["Strength"] * 1.5;
            return attackType switch
            {
                "normal" => baseDamage,
                "heavy" => baseDamage * 2.0,
                "special" => baseDamage * 3.0,
                _ => baseDamage
            };
        }

        /// <summary>
        /// Takes damage and reduces the warrior's health.
        /// </summary>
        /// <param name="damage">The amount of damage taken.</param>
        public override void TakeDamage(double damage)
        {
            double reducedDamage = damage * (100 / (100 + Stats["Defense"]));
            Health -= reducedDamage;
            Rage = Math.Min(Rage + (reducedDamage * 0.5), MaxRage);

            if (!IsAlive())
                Console.WriteLine($"{Name} has fallen in battle!");
        }

        /// <summary>
        /// Uses the warrior's special ability.
        /// </summary>
        public override void UseSpecialAbility()
        {
            if (Rage >= 30)
            {
                Console.WriteLine($"{Name} uses Berserker Rage!");
                UpdateStats("Strength", Stats["Strength"] * 1.5);
                Rage -= 30;
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough rage!");
            }
        }
    }

    /// <summary>
    /// Represents a mage character with specific properties and methods.
    /// </summary>
    public class Mage : GameCharacter
    {
        /// <summary>
        /// Gets the current mana of the mage.
        /// </summary>
        public double Mana { get; private set; }

        /// <summary>
        /// Gets the maximum mana of the mage.
        /// </summary>
        public double MaxMana { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mage"/> class.
        /// </summary>
        /// <param name="name">The name of the mage.</param>
        /// <param name="level">The level of the mage.</param>
        public Mage(string name, int level) : base(name, level)
        {
            MaxMana = 100 + (Level * 10);
            Mana = MaxMana;
        }

        /// <summary>
        /// Initializes the stats of the mage.
        /// </summary>
        public override void InitializeStats()
        {
            MaxHealth = 70 + (Level * 7);
            Health = MaxHealth;
            UpdateStats("Intelligence", 15 + (Level * 2.5));
            UpdateStats("Defense", 4 + Level);
            UpdateStats("MagicResistance", 8 + (Level * 1.5));
        }

        /// <summary>
        /// Levels up the mage.
        /// </summary>
        public override void LevelUp()
        {
            Level++;
            InitializeStats();
            MaxMana += 10;
            Mana = MaxMana;
            Console.WriteLine($"{Name} has reached level {Level}!");
        }

        /// <summary>
        /// Calculates the damage dealt by the mage based on the attack type.
        /// </summary>
        /// <param name="attackType">The type of attack.</param>
        /// <returns>The damage dealt by the mage.</returns>
        public override double CalculateDamage(string attackType)
        {
            double baseDamage = Stats["Intelligence"] * 2.0;
            return attackType switch
            {
                "fire" => baseDamage * 1.5,
                "ice" => baseDamage * 1.2,
                "arcane" => baseDamage * 2.0,
                _ => baseDamage
            };
        }

        /// <summary>
        /// Takes damage and reduces the mage's health.
        /// </summary>
        /// <param name="damage">The amount of damage taken.</param>
        public override void TakeDamage(double damage)
        {
            double reducedDamage = damage * (100 / (100 + Stats["MagicResistance"]));
            Health -= reducedDamage;

            if (!IsAlive())
                Console.WriteLine($"{Name} has been defeated!");
        }

        /// <summary>
        /// Uses the mage's special ability.
        /// </summary>
        public override void UseSpecialAbility()
        {
            if (Mana >= 50)
            {
                Console.WriteLine($"{Name} casts Arcane Explosion!");
                // Implementation of area damage
                Mana -= 50;
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana!");
            }
        }
    }
}
