A mod that balances charms! 
It is worth noting that I'm terrible at balancing, so please help me by giving your thoughts and ideas!

# How to install
* Change the game version to `1.5.78.11833`
![How to change the game version](https://media.discordapp.net/attachments/1207486627124093019/1469343521260703867/steambetas2.jpg?ex=69fd4e8a&is=69fbfd0a&hm=753c394259c15c2b3de099d0fec43cc28aebf208aa3326eb36aacb98cdd1bdb0&format=webp&width=2682&height=1546&)
* Locate the `Game Files` folder, you can follow this guide: https://www.reddit.com/r/HollowKnight/comments/1d11mq9/comment/l5qsdds/
* Download and extract the lastest release of Modding API: https://github.com/hk-modding/api/releases
* From `Game Files` folder, move all the files from Modding API folder, to `hollow_knight_Data\Managed`, allow replacing some the files.
* Download and extract the lastest release of the mod.
* From `Game Files` folder, move the mod folder to `hollow_knight_Data\Managed\Mods` (if you don't have the `Mods` folder, create it).
* Launch the game and ENJOY ツ (you can disable the mod in `Main Menu/Options/Mods`).
* If you want to revert back to vanilla, you just need to go to `Steam Library/Hollow Knight/Properties/Installed Files` and choose `Verify integrity of game files`.

# Changes
## Vengeful Spirit & Shade Soul
- Vengeful Spirit's base damage: 15 => 20
- Shade Soul's base damage: 30 => 40

***Wait a minute, I thought this mod only modifies charms!? ...Yeah, well, I just came up with these changes while balancing Shaman Stone. And it just fits so well.***
## Soul Catcher
- Soul gain when Soul Meter is full: 2 => 3.

***This makes Soul Catcher more viable in late game with the help of Soul Vessels without making it too strong in early game.***
## Shaman Stone
- **ALL SPELL DAMAGE** increase: 35%

***Don't worry. This charm is still extremely powerful. I might even want to nerf it to 1% increase.***
## Soul Eater
- Notch cost: 4 => 3.
- Soul gain when Soul Meter is not full: 8 => 7. 

***The 4-notch cost is extremely high and I don't find the benefits really worth it. Hopefully this change makes Soul Eater more efficient to use.***
## Dashmaster
- Increases Mothwing Cloak dash speed by 10% (note that this also applies on Shadow Dash, this is how the original logic works)
- Reduces Shadow Dash cooldown by 10%.

***Mothwing Cloak is overshadowed too much by Shade Cloak, I think this will make them get used more. Oh wait, this also buffs Shadow Dash. Is this too overpowered??? I don't know  ._.***
## Sprintmaster
- Run speed increase: 20% => 25%.
- Speed increase also APPLIES WHEN ON AIR.
- Synergies:
  - Dashmaster:
    - Run speed increase: 35%.

***I always feel so slow when jumping when using this charm. Now it's not anymore. This charm is already good so I have to remove the synergy with Dashmaster, otherwise it will be too overpowered.***
## Grubsong
- Soul gain now SCALES with the amount of damage taken.
- Soul gain when taking damage: 15 => 12.
- Syneries:
  - Grubberfly's Elegy:
    - Soul gain: 25 => 20.

***Grubsong is a little too good for early game. So I think it is fine to nerf it a little bit. However, by scaling soul gain with damage, it remains viable in later stages, especially againsts bosses that deal more than 1 damage. I do think removing synergy is too harsh, but the charm is already too good. I also believe that a charm should only synergy with others if it does not work well with them.***
## Grubberfly's Elegy
- Grubberfly's Elegy now works properly in Patheons with Shell Binding
- Grubberfly's Elegy no longer loses its effect when not at full masks.
- Instead, the less white masks you are currently at, the lower the beam damage is.
- The damage formula:    $Beam Damage = (\frac{currentMasks - 1}{maximumMasks + 1})^2 * nailDamage$
- Doesn't fire beam when the damage is lower than 1.
- Its behavior with Joni's Blessing is not changed.
- 4 maximum masks

| Health  | 4   |  3  |
| ------- | ----|---- |
| Damage  | 8   |  4  |

- 9 maximum masks

| Health  | 9   |  8  |  7  | 6   |  5 |  4 |
| ------- |---- |---- |---- |---- |----|----|
| Damage  | 14  | 11  |  8  |  6  |  4 |  2  |

- 12 maximum masks

| Health  | 12   |  11  |  10  | 9   |  8 |  7 |
| ------- |----- | ---- |----- |---- |----|----|
| Damage  | 16  | 13  |  11    |  8  |  7 |  5  |

***I really like the idea of firing beam with your nail. But I just hate when it becomes completely useless when not at full masks. I think this change is nice since it still incentivizes players to keep their masks staying at high as possible while doesn't punish casual players too much.***
## Heart
- Masks increase: 34% of current maximum maks (round down)
- Means that you will gain extra 3 masks when only have 9 maximum masks

***I do think this charm need a buff to keep up with other charms in the late game.***
## Greed
- Geo drops increase: 20% => 50%
- When being used in Colosseum Of Fools, Greed increases Trials' Geo reward by 25%

***The original increase is almost insignificant which many players didn't bother using it. The use in Colosseum Of Fools is really interesting to me. It encourages high risk, high return playstyle when you have to sacrifice 2 notch slots.***
## Strength
- Damage increase: 50% => 35%.

***This charm certainly needs a nerf, 50% increases in damage is purely evil. Moreover, is it weird when the charm only applies on Nail, don't you think?***
## Heavy Blow
- Notch cost: 2 => 3
- Increases Nail Art damage by: 30%
- Remove increased knockback
- Hits from Great Slash and Dash Slash now count as 2 hit to stagger a boss

***Why increase the knockback when you need to hit the enemies as many as possible. I believe this charm needs some reworks.***
## Quickslash
- Attack speed increase: 46% => 33%

***This charm is really flexible when it can be use to both increase damage output and soul gain. It certainly needs a little nerf!***
## Thorns Of Agony
- Thorn damage: 1x => 2x Nail damage
- No longer inhibits movement when taken hit.
- I have noticed that in best cases, the total damage could be up to 4x Nail damage.

***Cool charm but needs a little buff***
## Baldur Shell
- Can now be restored by the amount of healed masks when player heals at full masks.
- Now caps at 6 blocker hits.

***I feel like this change would encourage a new playstyle without making it overpowered. With this, focusing in Radiant boss fights is no longer entirely useless.***
## Flukenest
- Notch cost: 3 => 2
- Multihits bug has been fixed in the lasted version of the game, but the current Modding API-supportable version haven't yet. However, I fixed it somehow. 
- Vengeful Spirit + Flukenest: 8 flukes x 5 damage (36 => 40)
- Vengeful Spirit + Flukenest + Shaman Stone: 9 flukes x 6 damage (45 => 54)
- Shade Soul + Flukenest: 16 flukes x 5 damage (64 => 80)
- Shade Soul + Flukenest + Shaman Stone: 16 flukes x 7 damage (80 => 112)

***I love how this charm make spell so much stronger and fun to use since it basically makes Vengeful Spirit and Shade Soul a shotgun. I think it deserves more!***
## Glowing Womb
- Damage (both normal and Dung version): 1x Nail damage.
- Only summons 2 Hatchlings after a successul focus.
- Maximum Hatchlings: 6
- Synergies:
  - Deep Focus:
    - Summons 4 Hatchlings after a successful focus.

## Deep Focus
- Notch cost: 4 => 3.
- Focus time increase: 65% => 50%.

***It's a cool charm, but I don't see why it costs 4 notches. I have also lowered its focus time increases a little, and now when combining this charm with Quick Focus, the result is the same as normal.***
## Liveblood Heart
- Notch cost: 2 => 1.

***Because... why not? I have never thought that 2 Liveblood Masks is worth 2 Notches***
## Lifeblood Core
- Liveblood Masks: 4 => 6

***This exorbitant charm should have added MORE THAN FOUR LIVEBLOOD MASKS.***
## Joni's Blessing
- Notch cost: 4 => 2
- Max health increase: 40% => 50%

***At this point, I really wonder why all Liveblood-related charms are so weird. This charm is not a exception. I do think that these changes would make the charm more fun to use.***
## Hiveblood
- Notch cost: 4 => 3.
- Always regenerates masks for player.
- Its behavior with Joni's Blessing is not changed.

***I always hear everyone complains that this charm is not worth using it. Buffing it may be a good idea, but I feel like it is too overpowered?***
## Shade Of Unn
- Notch cost: 2 => 1

***A simple yet profound charm, it has so much potential. But I belive it should only cost 1 notch slot.***
## Sharp Shadow
- Shadow Dash speed increase: 40% => 30%
- Shadow Dash damage: 1x => 1.5x Nail damage
- Note that the increase on Mothwing Cloak dash also applies on Shadow Dash
- Synergies:
  - Dashmaster:
    - Shadow Dash damage: 2x Nail damage

***I do believe this charm is a little too overpowered. But I can't help but buffing it, everyone loves dashing, right...?***
## Weaversong
- Each weaversling now deals: 1/3 Nail damage.
- Each successful hit gain player 3 soul by default.
- Synergies:
  - Grubsong:
    - Soul gain: 5

***I love summoner playstyle, but this charm is really ineffective. I believe the effect that gain player soul on hit would make this charm unique to other summon charms.***
## Dreamshield
- Notch cost: 3 => 2
- Now summons 2 shields at a time.

***I like this change, but wonder if it makes this charm too powerful.***
## Grimmchild
- Damage per shot:
  - Level 2: 5 => 11
  - Level 3: 8 => 16
  - Level 4: 11 => 21
- Grimmchild can now shoots more ***ACCURATELY***.

***As I said before, I love summoner playstyle. Despite this charm's unlimited power, I still buffed it to make it even stronger.***
## Carefree Melody
- No longer relies on luck to block attacks.
- Cooldown: 10 seconds
- Upon activated, decreases player's health to a single mask.
- Taking damage while the charm is on cooldown results in an instant death.

***To put it simple, I hate RNG-based mechanics***