# TextBasedCombat
 Text Based RPG Combat like MUDs of the ol' days.

 I originally created something similar using Python while at work running our simulators.
 Those computers are kept in a secret space... so I am unable to extract them from the work
 computers and continue working on them (I had so, so many little projects). So I guess now
 is a good time to start over using C#, although I will be missing some of the niceties that
 come with using Python like list comprehension and tuple unpacking.

 ## History
 I played MUDs (Multi-User Dungeons) in the 90's and even a little in the early 2000's.
 What I love about MUDs is that they are like interactive novels. Everything is text-based,
 and you build this world in your head based on the descriptions you read. Where current
 day games are judged on their graphics, in MUDs you are limited by your own imagination.

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


If you have any comments, questions, suggestions, whatever, email me at james.bieling@outlook.com

Thanks, and enjoy.
