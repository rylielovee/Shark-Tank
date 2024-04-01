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

### Wander State

The sharks wander trying to find the player. They must be in a certain range of the player to seek them out. 

#### Steering Behaviors

Behaviors: Wander (not in range of the player or jellyfish) and Flee (if near jellyfish)
    
Obstacles: jellyfish

Seperation: other NPC sharks
   
#### State Transistions

When the shark goes out of range of the player or the jellyfish.

When the shark collides with the player.
   
### Attack State

When in range of the player, the shark will seek the player with a little bit of increased speed.

#### Steering Behaviors

Behaviors: Seek (if in range of player)

Obstacles: jellyfish

Seperation: other NPC sharks
   
#### State Transistions

When the shark gets in range with the player. 


## Jellyfish

The jellyfish float around the screen and will stun the player if they collide.

### Wander State

Wander around the screen hoping to bump into a player or NPC sharks.

#### Steering Behaviors

Behaviors: Wander and stay within bounds

Seperation: other jellyfish
   
#### State Transistions

They are always in this state.


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

