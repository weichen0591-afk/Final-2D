# GDIM 31 Final: 2D
## Devlogs
Wei Chen, He/Him

### Milestone 1
One technical problem I encountered while building my final game was that sometimes my cat could not jump even when it was standing on the ground. At first, I thought something above the cat was blocking it, or there was something wrong with my collider settings. However, after testing the game several times in different locations, I noticed that the problem could also happen when there was nothing above the cat. Therefore, I went back to my Player.cs script and checked how the game determines whether the player is standing on the ground. I realized that the OnCollisionEnter2D() method only checks when a collision first happens, which might cause the _isGrounded variable to become incorrect in some situations.
To solve this problem, I added an OnCollisionStay2D() method to my Player class. Inside this method, I used a for loop to check all the collision contact points with objects that have the Ground tag. Additionally, I detected if the normal Y of the contact was higher than 0.5f and if the vertical velocity of the player was lower or equal to 0.0f. If both conditions were met, I set _isGrounded to true. This allowed the game to keep checking whether the cat was standing on a surface instead of only checking when the collision first happened. After making these changes, I tested my game again, and the jumping worked much better. Through this experience, I learned that a problem in gameplay is not always caused by the settings in Unity. Sometimes, I need to go back to my code and think carefully about when a method runs and how it affects the game.

### Milestone 2
TODO.

## Playtesting Reports
### Milestone 1
#### Report 1
TODO.

#### Report 2
TODO.

### Milestone 2
#### Report 1
TODO.

#### Report 2
TODO.

## Open-Source Assets
- [Interior sprites](https://rcpstd.itch.io/interior-tileset-asset-pack-16x16)
- [Ninja cat sprites](https://opengameart.org/content/cat-fighter-sprite-sheet)
- [Food sprites](https://ghostpixxells.itch.io/pixelfood)
- [More food and item sprites](https://ipixl.itch.io/pixel-art-items-part-1)