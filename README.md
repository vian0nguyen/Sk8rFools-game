# Sk8rFools-game
code base for unity skaterfools game

<details>
<summary> ### FOR WHEN GIT POOPS OUT</summary>

this should _theoretically_ work..

1. open command prompt
2. jump to directory command `popd` [source](https://blogs.umass.edu/Techbytes/2014/11/14/file-navigation-with-windows-command-prompt/) - if that doesn't work typing `D:` or whatever your disk name will get you to the right directory
3. type `git add -a` (im pretty sure) - this just commits whatever is sitting in github that's presumably been screaming errors
4. `git config --global core.autocrlf true` setting this makes the endings error go away.. maybe
5. `git commit -a`
6. write your commit message `<esc> [COMMIT MESSAGE HERE??] :wq <enter>` [source](https://stackoverflow.com/questions/13340329/how-to-save-a-git-commit-message-from-windows-cmd)
 </details>

# Dev Diary

### 21/11/28
 WOW!! I LOVE THIS GAMe i got in:
 * sorting order code
 * started a test scene for a dressing room feature (implimented a test mirror)
 * have reverse controls for reflection effect in
 * blocked by getting some scaling feature mapped to position.y to work 
 
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
