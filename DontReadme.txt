I'm going to keep my notes here from now on


I've had a lot of issues with this project due to not understanding the code base and guessing how shit works.

Thanks to some help I learned that I can just change the functions in the taskcontroller to async
since the app.MapControllers(); part should handle the way controller's functions are called.

I really how this is true, but I'm basically stumbling in the dark and bruising my shins every 5 minutes.
I hope I don't run out of shin.

I think I've relied too much on using the given resources to solve my problems.
I keep being suggested resources that overexplain a single element, without ever given practical functions for it.
which means they never really help me understand how to put them together.
Which is ass-backwards to how I think most people learn.
If I can see enough contexts of elements working together, I can figure out what each individual part does pretty easily.
But if I just see one element in one context serving one function. I have to guess its capabilities.
And that's basically happened from start to finish in this project.
Especially attributes apparently.
They can apparently be whatever the hell they want, with no conistency, and I just have to look up each one.
Which I won't do.
I don't have time.
but it's good to know.




TODO:

RENAME Classes and namespaces!

Convert controllers to async.

I need to be able to test it.
so I need client dummy?
Or can I get this information out of my browser?
Actually. If I've made it async, and it doesn't crash, I'm happy.



Done:




TodoObject: 
Other possible parameters: PRIORITY: Low
CreationDate
DueDate
LastEdit: DateTime



Async Building: PRIORITY: HIGH.

1) The controller methods need to be made async.
2) Some await calls probably need to be made.
3) And the usertask methods need to be made async as well and called as tasks?
4) Rename interface and usertasks to have async?
or just add async options ontop of it?
Nah.
I like having them as examples for posterity, but I should just have one commented out.
For reference.

5) Figure out how cancellation tokens work. PRIORITY: Low




