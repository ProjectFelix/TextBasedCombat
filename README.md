# TextBasedCombat
 Text Based RPG Combat like MUDs of the ol' days.

 I originally created something similar using Python while at work running our simulators.
 Those computers are kept in a secret space... so I am unable to extract them from the work
 computers and continue working on them. So I thought this would be a good opportunity to
 re-create a fun project while also learning C#!

 ## History
 I played MUDs (Multi-User Dungeons) in the 90's and even a little in the early 2000's.
 What I love about MUDs is that they are like interactive novels. Everything is text-based,
 and you build this world in your head based on the descriptions you read. Where current
 day games are judged on their graphics, in MUDs you are limited only by your imagination.

 ## Plans
 This project is the beginning of a rudimentary custom MUD. Well, I guess this would be
 more of a Single user Dungeon... so SUD? But I am starting with combat, because that
 is the most exciting part of MUDs to me. To that end, I need to decide on a system:
  1. ###### Delay-based
    Players and NPCs have delays in their attacks based on weapons. Players can choose
    between lower dmg/lower delay weapons, or higher damage/higher delay weapons. This
    is similar to how current day MMO's handle combat, and I have only ever seen ONE
    MUD use this style of combat - and it was a MUD attempting to simulate EverQuest, which
    is a game I played for 5 years and am very fond of. However, this is very tricky to do
    with a console app, although I think I have found a good way of dealing with it using
    the Parallel class in System.Threading.Tasks. This is what I have started with as a
    sort of challenge to myself, feel free to check it out.

  2. ###### Round-based
    This is the way 99.9% of MUDs handle combat. Every second or so, a round of combat is
    calculated and displayed. Damage is based on weapons, but everyone has the same attack
    interval. You can get more attacks by learning skills such as Second Attack, Third attack,
    etc. The nice thing about round-based combat is it is much more clean for a console app.
    I can display a round of combat, and then print a prompt displaying the player's current
    stats such as health, mana, maybe status-effects if I decide to implement that down the line.

I will start off by creating both systems of combat, where I can switch off between the two to see
how everything looks, and maybe further down the line I can settle on one and focus on cleaning it
up. But, this is just a personal side project, and dont have to worry about appeasing a player base.

Update 19/03/2020:
  Okay, I think I have the basic foundation complete. We have a player, we have a template for mobs,
  we have rooms, and we have a starter combat algorithm

###### Plans for the future:
- Stats! What is an RPG without stats!? This will lay down the foundation for the next item...
- Items! What is an RPG without items!? Im thinking I will create some basic player armor slots.
- Inventory. Gotta store all those phat lewtz in your backpack until you can sell the stuff you dont need.
- Skills. Why worry about mitigating damage when you can maybe dodge an attack entirely?
- Spells. Now cast fireballs at your enemies or heal yourself. Or cast fireballs at yourself. Im not judging.
- Experience. With exp, we can level, get stronger, gain skill points, etc.
- Loot! Now we have everything in place to start slaying and getting sweet, sweet loot.
- Many more ideas, but we have quite the list already....


If you have any comments, questions, suggestions, whatever, email me at james.bieling@outlook.com

Thanks, and enjoy.
