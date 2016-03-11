# ForestFire

A simple model to simulate a forest fire - https://en.wikipedia.org/wiki/Forest-fire_model

This is an application built in C# using WinForms (yeah, I know... WinForms is pretty old)... WinForms offers a pretty easy to use API for programmatically drawing things (in a PictureBox) where I got frustrated a little bit with trying to implement basic drawing with WPF.

###for forest - just make the paint event draw based on the forest each cycle thru. if a tree is Tree.OnFire in the forest array - set it to burnt and set its neighbors that are alive on fire. IE dont try to look for adjacent rectangles, but for adjacent Trees in the forest array



#GIF IMAGE HERE
