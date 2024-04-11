# Project: Shark and Fish Game

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

_REPLACE OR REMOVE EVERYTING BETWEEN "\_"_

### Student Info

-   Name: Rylie Love
-   Section: 01

## Simulation Design

You are a hungry shark trying eat enough fish to be the biggest shark in the ocean. But watch out for other sharks and jellyfish!

### Controls

Controls: WASD

Getting closer to a fish makes the fish flee.

Touching a shark makes you smaller.

Touching a jellyfish stuns you for a second.

Once you are big enough to eat the other sharks and you eat them, the game is over.



## Shark

If a shark collides with the player, the player will decrease in size.

#### Steering Behaviors

Behaviors: Wander (not in range of the player), Seek (if in range of player)
    
Obstacles: None

Seperation: other NPC sharks



## Jellyfish

The jellyfish float around the screen and will stun the player if they collide.

#### Steering Behaviors

Behaviors: Wander and stay within bounds

Obstacles: None

Seperation: other jellyfish



## Fish

The fish flee around the screen from the player. They are the players food.

#### Steering Behaviors

Behaviors: Flee

Obstacles: Coral (that is placed around the screen)

Seperation: other fish



## Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_

## Make it Your Own

- _List out what you added to your game to make it different for you_
- _If you will add more agents or states make sure to list here and add it to the documention above_
- _If you will add your own assets make sure to list it here and add it to the Sources section

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_

### Requirements not completed

_If you did not complete a project requirement, notate that here_

