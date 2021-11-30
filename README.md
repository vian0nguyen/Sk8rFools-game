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

 ### 21/11/28
 
 preliminary research. i thought the code for the dress up section would be similar to the dysphoria doll game but i think that involved canvases in a way id like to avoid (overall mega messy and stressy)
 
 thought process:
 
 1. Find all children (of Q) [link](https://forum.unity.com/threads/finding-all-children-of-object.453466/) [link](https://stackoverflow.com/questions/37943729/get-all-children-children-of-children-in-unity3d) -- also whats recursion??
 2. create an array/list from this
 3. cycle through the list <- how? mouse click? press space bar to cycle through list
    A FOR LOOP, increment through the list every time input!!! WHOOOOA

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
