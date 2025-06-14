# Sk8rFools-game
code base for unity skaterfools game

<details>
<summary> ### FOR WHEN GIT POOPS OUT</summary>

this should _theoretically_ work..

1. open command prompt
2. jump to directory command `popd` [source](https://blogs.umass.edu/Techbytes/2014/11/14/file-navigation-with-windows-command-prompt/) - if that doesn't work typing `D:` or whatever your disk name will get you to the right directory
3. type `git add -A` (im pretty sure) - this just commits whatever is sitting in github that's presumably been screaming errors
4. `git config --global core.autocrlf true` setting this makes the endings error go away.. maybe
5. `git commit -A`
6. write your commit message `<esc> [COMMIT MESSAGE HERE??] :wq <enter>` [source](https://stackoverflow.com/questions/13340329/how-to-save-a-git-commit-message-from-windows-cmd)
 </details>

# Dev Diary

### 25/06/14
Stefan - Added Y sorting to sprites so we don't have to do any funky sprite ordering in code.  Would like to add a reminder that to any new sprites that the player might potentially be in front of/behind to make sure the pivot to the sprite is towards the bottom Unity's sprite editor to prevent funkiness with the sorting.

### 25/06/08

finally sat down and thought about the whole adventure part of this game

<details>
<summary> Player path, linear narrative gameplay</summary>

this should _theoretically_ work..

1. START: home! we discover pokey is gone. _clue_: a missing wheel from skateboard, another is slobbery
2. skate shop _clue_: try on clothes, find ice cream and pokey fur and slobber
3. (optional) alligator grill: they sell ice cream but NO, cones are from mr scoops specifically
4. mr. scoops stand _clue_: "that dog loves to take cones to bait seagulls and chase them"
5. beach/further along board walk _clue_: behind a pole or potted plant, we spot pokey's waggy tail! --> turns out to be a kite!
6. Kite shop! we return the kite and pokey was chillin with his bud poppy in the back.
 </details>

### 24/01/23

Hello its been a while. i futzed around with the code. I'm thinking through the quest system still. I forgot to check below to see what I was thinking.

I think the below system might not work? I'm thinking through if a search and "jump to scene" system would work better.

could possibly use save VAR system, to recall where the player is at with the quest and do a conditional so we can track where the player has already been while giving them the flexibility to complete searches without getting hints.

things id like:
* have the player freeze position until their done talking
* get global unity variables working (and changing them from ink stories)
* need to make a list of needed assets (NPC for Kite_shop, skate_shop, etc)
* make a list of assets already made that is ready to be implemented
* need to maybe prototype the sequence of seeking and hiding logic

 ### 22/08/20
 
 KNOTS Directed via unity code!
 
 here's how the system will work:
 
 * save the knot name in the coords scriptable object 
 * knotName will be changed in the teleportation code
 * on entering a scene the knot for that scene will play a knot like "skateShop"
 * after exiting the scene "after_[sceneName]" will play for all objects (NPCs, items, main)
 
 ### 22/08/17 (an hr later)
 
 stefan sat with me and made sure my code logic made sense and we made a cool down script to make sure the player wasnt doing double taps on accident
 
 ### 22/08/17
 
 for the last few days i;ve been coming back to this project which is so exciting to be motivated again to work in it. problem solving in unity can be a pain in the ass but it really is so gratifying.
 
 some things ive gotten done
 
 * teleportation (BOTH clay and Q) + position saving SOOORTA
 * scene transition
 * cam transition
 * asset implimentation (KT's interior and exterior, dressing room, rest of the beach front)
 * made that exit sign in the dressing room :thumbs:
 
 TODO:
 
 * need more hats designed
 * need to animate and think about pokey events, whats in the game and why? can we pick things up? maybe pokey is leaving a trail of something
 * the figma file needs organization help
 * KT interior needs objects seperated by layers if we want to interact and walk around
 * NPC ANIMATION T- T
 * dialog system..... hhhh sigh
 
 ### 21/12/13
 
 todo:
 
 * player pref hat saving
 * player pref environment position saving
 * implement art assets

 ### 21/12/05
 
 GOT THE CLOSET CYCLING TO WORK!!!!! im a genius!!!
 
 i could probably use playerPrefs to save which hat you're wearing so you can wear it anywhere
 
 todo:
 
 * BUG: cycling where its adding another list item which is the same as the start of the list
 * BUG(if i bothered): wanna set custom loadIntoScene positions based on where you enter the skate shop [LINK](https://forum.unity.com/threads/load-scene-and-player-position.416434/)
 * i keep forgetting i need an exit sign in the changing room
 
 ### 21/11/28
 
 preliminary research. i thought the code for the dress up section would be similar to the dysphoria doll game but i think that involved canvases in a way id like to avoid (overall mega messy and stressy)
 
 thought process:
 
 1. Find all children (of Q) [link](https://forum.unity.com/threads/finding-all-children-of-object.453466/) [link](https://stackoverflow.com/questions/37943729/get-all-children-children-of-children-in-unity3d) -- also whats recursion??
 2. create an array/list from this
 3. cycle through the list <- how? mouse click? press space bar to cycle through list
    A FOR LOOP, increment through the list every time input and only display that object!!! WHOOOOA [link](https://stackoverflow.com/questions/46358717/how-to-loop-through-and-destroy-all-children-of-a-game-object-in-unity)

 ### 21/11/28
 
 WOW!! I LOVE THIS GAMe i got in:
 * sorting order code
 * started a test scene for a dressing room feature (implimented a test mirror)
 * have reverse controls for reflection effect in
 * blocked by getting some scaling feature mapped to position.y to work 
(EDIT) that shit worked
 
 corran assisted big time with trying to get the code `ScaleChange.cs` for this scaling to work properly.
 the behavior we want is that as the position.y gets smaller the scale gets bigger and the reverse to have the effect that Q is stepping closer and further away from a mirror.
 
### 21/11/08

TLDR TODO: 
* sorting layers [vid](https://www.youtube.com/watch?v=HM17mAmLd7k)
* investigate dialogue system - something was weird and hard? probably NPC implimentation maybe dialog choices?

AND WE'RE BACKK!! Not sure how longs its been, probably mONTHs but we're back. i spent SO much time reimplimenting art assets and relearning animations and controllers in unity holy shit. TY ray for sitting with me in the build that was fun. and fun to have a code partner for when im SmaSHing my head against the wall lol. i think taking a step back a bit once the prototype is cleaned up will help me figure out some nice to haves and scope (what needs to get done for an mvp)

hey speaking of: 

#### what needs to get done for an mvp?
* maybe all objects are implimented
* have one npc
* one location?
* find the dog
* rewrite scripts
