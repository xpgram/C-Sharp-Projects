# C# Projects

This is where the larger assignments from my time at The Tech Academy are kept.

Each one is its own project file in Visual Studio (2019, I'm pretty sure).

Things are a little jumbled and disorganized, I may fix that. I'll detail the important ones here, though.

## Blackjack

A CLI application that runs a little game of blackjack. Its presentation could be better. I would do different things with the UI, and in some ways I have, but I was also following a guided-tour for building such an application, so there was only so much I could do without going completely off script.

That said, it's playable. And, if you try to bet a negative number, it will ban you from ~grandma's house~ the casino, *and* you can give your name as 'admin' and see a list of all banned boys. Nice.

Um. You could, anyway, if this app built the database it manages before trying to access it. I haven't looked, I have no idea if it even does that. My intuition tells me I set up that database manually, though.

## No-Porsches Insurance

Most notably, a seemingly common issue here: the database does not exist. On my machine it does.

Aside of that, this assignment uses an MVC structure, features a submition form with many fillables, and does some logical calculation to arrive at a probable insurance cost. A quote, if you will. There is also an admin page which lets you see all queries to this quote-calculator *on demand*, *you have the power*.

## Contoso University

This is a direct-from-Microsoft turorial project which demonstrates a code-first approach to database design and interaction.

It is *possible* that this one works without having to setup any database stuff on the machine first. I really can't remember. In any case, only the Students page is set up, but it shows off some fairly general, basic database access and manipulation stuff, including adding demo students so you can see what it all looks like with minimal input.

## Don't worry about these

### NewsletterAppMVC

Supposed to show off some MVC database-access techniques, but it never builds one, so while it works on my home machine, it works on no other. I can't say I care enough to fix it.

### EFCodeFirstDemo

Just look at ContosoUniversityDemo instead.

### StudentManagementSystem

It's, I think, just a barebones new MVC project in Visual Studio. I think they were just showing me how to create one here.

### TechAcadStudentsMVC

Same deal as StudentManagementSystem with minor changes to the site content. Nothing really worth looking at.
