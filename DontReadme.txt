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

It's still confusing to me how to structure tasks, since I can technically nest them almost indefinitely.
It feels like it would be enough to just have the controller methods themselves be tasks. And yet, every example
seems to have at least one await statement in them.
Ay caramba.

So, I await task completion because we're gonna do something with it.
I'm pretty sure this rule doesn't change. but some of the usage examples still trip me up.
it's also the order of operations. Does a return automatically wait for a task to complete?
No, if you don't await you return the task itself instead of its results.





TODO:

RENAME Classes and namespaces! =========================== DONE.

DONE ========= MAKE GIT PUBLIC ========== DONE
========= HAND IN.=========

UPDATE README.

DONE========Convert controllers to async.========DONE

I need to be able to test it.
so I need client dummy?
Or can I get this information out of my browser?
Actually. If I've made it async, and it doesn't crash, I'm happy.

Go over the other repos/notes, and try to actually internalize it.

LINK TO DATABASE.

Also, finish dronedash with client stuff.

Add functionalities: replace function. A PUT command?

Improve error handling? Eg. issue details + error object.

Kort README med beskrivelse av endepunkter, parametere og eksempel-requests (tekstlig).

==================================== DONE =======================================
(Valgfritt) Tjenestelag: Legg domenelogikk i et service-lag, slik at Controller forblir tynn.
 Dette gjør asynkron kjeding og senere SQL-støtte enklere. ============= I'm pretty sure this was already done?
 ==================================== DONE =======================================


==============================TO  DO =================================
(Valgfritt) Paging/Filtering: Hvis GET kan returnere mange elementer, støtt spørringsparametre
 for paginering og filtrering.
 --- I can do this by having nullable fields for page number and items per page.
 ---Should I throw errors? or return adjusted elements?
I think I can do this fairly easily, but it's not as important as trying to implement the database support.




(Valgfritt) XUnit Test Prosjekt: Utvid testingen med et testprosjekt som kan kjøre tester mot
 apiet, og se om apiet oppfyller forventet oppførsel.


Sort files:
context seem like it should be categorized as service
But what about the DTOs? is that its own category?
I don't know what their identifiers really are, since they look similar in structure and function to me.


FURTHER READING:
Cancellation tokens.




TodoObject: 
Other possible parameters: PRIORITY: Low
CreationDate
DueDate
LastEdit: DateTime



Async Building: PRIORITY: HIGH.



5) Figure out how cancellation tokens work. PRIORITY: Low




Notes:
I changed the Get to async with await call on the dto.
nothing broke. But why? Don't I need to make the task context async first? No, because the building done by the query
doesn't need to be tasks.





DONE:

1) The controller methods need to be made async.
2) Some await calls probably need to be made.
3) And the usertask methods need to be made async as well and called as tasks?
4) Rename interface and usertasks to have async?
or just add async options ontop of it?
Nah.
I like having them as examples for posterity, but I should just have one commented out.
For reference.
