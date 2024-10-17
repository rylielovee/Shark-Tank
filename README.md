# Project: Shark Tank

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Rylie Love
-   Section: 01

## Simulation Design

You are a hungry shark trying eat enough fish to be the biggest shark in the ocean. But watch out for other sharks and jellyfish!

### Controls

Controls: WASD

Getting closer to a fish makes the fish flee.

Eating a fish makes you bigger.

Touching a shark, jellyfish, or pufferfish makes you smaller.


## Shark

If a shark collides with the player, the player will decrease in size.

#### Steering Behaviors

Behaviors: Wander (not in range of the player), Seek (if in range of player), stay within bounds
    
Obstacles: Pufferfish

Seperation: other NPC sharks



## Jellyfish

If a jellyfish collides with the player, the player will decrease in size.

#### Steering Behaviors

Behaviors: Wander and stay within bounds

Obstacles: Pufferfish

Seperation: other jellyfish



## Fish

The fish flee around the screen from the player. They are the players food.

#### Steering Behaviors

Behaviors: Flee, flocking(seperation, cohesion, alignment), wander, stay within bounds

Obstacles: None

Seperation: other fish



## Sources
- Art by Rylie Love

## Make it Your Own
- Made all the art
- Made it so the player shark becomes biggeer and smaller depending on what the player does / collides with

## Known Issues

### Requirements not completed


