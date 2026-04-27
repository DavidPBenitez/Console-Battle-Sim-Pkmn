using System;

namespace BattleSimulator;

public enum PokemonType
{
Normal, Fire, Water, Grass, 
Electric, Ice, Fighting, Poison, 
Ground, Flying, Psychic, Bug, 
Rock, Ghost, Dragon, Dark, 
Steel, Fairy
}
public static class TypeIcons
{
    public static Dictionary<PokemonType, string> TypeIcon = new Dictionary<PokemonType, string>
    {
        {PokemonType.Normal, "⭐"},
        {PokemonType.Fire, "🔥"},
        {PokemonType.Water, "💧"},
        {PokemonType.Grass, "🌿"},
        {PokemonType.Electric, "⚡"},
        {PokemonType.Ice, "❄️"},
        {PokemonType.Fighting, "👊"},
        {PokemonType.Poison, "☠️"},
        {PokemonType.Ground, "🏔️"},
        {PokemonType.Flying, "🪽"},
        {PokemonType.Psychic, "🌀"},
        {PokemonType.Bug, "🐛"},
        {PokemonType.Rock, "🪨"},
        {PokemonType.Ghost, "👻"},
        {PokemonType.Dragon, "🐉"},
        {PokemonType.Fairy, "🌸"},   
        {PokemonType.Dark, "🌑"},
        {PokemonType.Steel, "⚙️"},
    };
}


// physical attack move:💥 special attack move:✨ Protect: 🧱 Self-Destruct: 💣, Taunt / disable / encore: 🔔🔕🛑 Switching: 🔄
// Status up:📈 ,Status down: 📉 Stat icons: Health=❤️ Attack=⚔, Special attack=🪄, Defense=🛡, Special defense=🫧, Speed=👟
// unicode emojis: https://www.unicode.org/emoji/charts/full-emoji-list.html