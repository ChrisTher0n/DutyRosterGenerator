Solution developed by Chris Theron

This was done as an assignment for interview
----------------------------------------------------------------------------------------------------
    Task:
    The task is to design and build an on-line duty roster selection mechanism. This should select two 
    employees at random to both complete a half day of support each. 
    For the purposes of this task assume that there are 10 employees. 
    
    Business Rules:
    There are some rules and these are liable to change in the future: 
        ●    An employee can do at most one half day shift in a day.
        ●    No employee can have half day shifts on consecutive days.
        ●    All employees should completed one whole day of support in any 2 week period.

    Deliverables 
    At the end of the task, the following must be included: 
        ●    A Presentation Layer (Front End)
        ●    An API
----------------------------------------------------------------------------------------------------

My solution is delivered in two parts:
- WheelOfFateLib (API)
- WOFWebApp (On-line presentation layer)

Both were build on .NET 4.7.1 using Visual Studio Community 2017.
The Web Application was build using MVC 5 and a basic Razor page.

The WheelOfFateLib exposes a public method called, appropriately, SpinTheWheel(). This returns a tuple with 2 names, one for morning shift, one for afternoon shift.
The WOFWebApp simply uses this library in the ScheduleController to generate to entries for a table. (~/Schedule/Index is the default page).
Each time the page is refreshed or 'Spin Again' clicked the controller will fetch the next two names form the library.

Internally the library generates a list of 10(or two weeks not including weekends) ScheduleDay objects, each containing a randomly chosen engineer for morning and evening shifts.
This is done to ensure the rules put forth in the brief can be met. 
Every time the SpinTheWheel() method is called the next set of engineer's names are returned. When the list gets to the last pair it clears regenerates a new list of 10 days worth shifts.
It uses the shift information of last day from previous set to ensure rules are still applied correctly.

I tried to keep the implementations as simple as possible while still showing at least some of my capability.
I also tried to keep the code clean, well commented and within the SOLID methodology as far as possible.
	