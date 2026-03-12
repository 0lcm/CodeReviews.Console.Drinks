# Drinks Info
This is a learning project created for and following the requirments set out in [this](https://thecsharpacademy.com/project/15/drinks) webpage.  
This app deals with getting data from [The Cocktail Db's API](https://www.thecocktaildb.com/api.php) and presents it to the user in a nicer Ui. 

# Features
* Features searching mechanics for drinks and drink ingredients, both by name, or by id.  
  ![rum search results part 1](https://i.imgur.com/P8Nt0WG.png) ![rum search results part 2](https://i.imgur.com/QLhxm7B.png)  
* The random cocktail option gives users a way to randomize their searches.  
* When searching drinks an image taken from the API is presented to the user, along with the drink's info. This is also toggleable in settings.  
  ![image of a piña colada](https://i.imgur.com/3PtPbhH.png)  
* The max image width setting allows the user to change the size of images to as small or as big as they could want.  
  ![halloween punch image part 1](https://i.imgur.com/86jrqA7.png) ![halloween punch image part 2](https://i.imgur.com/XA2gfM4.png) ![halloween punch image part 3](https://i.imgur.com/0m6e3Na.png)  
* The favorites feature allows users to save their favorite drinks for quick lookup later.  
  ![favorite drink list](https://i.imgur.com/0xBwRx3.png)  
* The view count leaderboard offers an easy way for the user to see which drinks have been viewed the most. Both storing view counts, and the amount of drinks shown on the leaderboard are toggleable in settings.  
  ![view count leaderboard](https://i.imgur.com/WAz9AXN.png)  
* The settings menu allows the user to change a variety of settings, or reset them to defaults with just a few clicks.  
  ![settings menu](https://i.imgur.com/yWqycv2.png)
* Settings, favorites, and view counts are all stored locally accross app sessions. favorites and view counts are stored in an sqlite file using ef core, and settings are written to a .json file.

# Resources used
[.NET (10.0)](https://learn.microsoft.com/en-us/dotnet/)  
[Spectre.Console (0.54.1-alpha.0.68)](https://spectreconsole.net/cli) - Ui  
[Spectre.Console.ImageSharp (0.54.1-alpha.0.63)](https://spectreconsole.net/cli) - Image creation  
[Microsoft.Extensions.Hosting (11.0.0-preview.1.26104.118)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting?view=net-10.0-pp)  
[Microsoft.Extensions.Http (11.0.0-preview.1.26104.118)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.http?view=net-10.0-pp)  
[Microsoft.EntityFrameworkCore.Sqlite (10.0.0)](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli)  
[Microsoft.EntityFrameworkCore.Design (10.0.0)](https://learn.microsoft.com/en-us/ef/core/cli/services)  
[Microsoft.Extensions.Logging (11.0.0-preview.1.26104.118)](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging/overview?tabs=command-line) - Logging  
[Microsoft.Extensions.Logging.Abstractions (11.0.0-preview.1.26104.118)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.abstractions?view=net-10.0-pp)  
[Microsoft.Extensions.Logging.Console (11.0.0-preview.1.26104.118)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.console?view=net-8.0-pp)  

# Personal thoughts
This project took longer than I had hoped to finish, but I finally got everything up and working and I can finally submit it. Working with APIs for the first time was definitly 
something I hadn't done before, it took a little bit of time to figure it out but afterwards I enjoyed working with it. Seeing my app actually get real world data from a real
website was really exciting, and it made me feel almost suprised as if I was getting closer to being able to make something real. I think the realization that I wasn't working
with test data, or small local data, but real data made me think that what I was making really was evolving and progressing as I move forward and learn more. I'm sure as I continue
to learn this project will start to feel small or of bad quality in comparison to what I'll learn later, but it's nice to see that the things you're making are becoming bigger,
more complex, and can actually show signs of progress, signs that even if you have to take small steps one day you will reach where you need to be. I also really enjoyed the fact
that I didn't have to actually write a thousand different descriptions for drinks. Being able to get the entire backstory of rum or being able to see all the drinks made with a 
certain glass just with a single get request was very cool to experience. I also liked making the settings menu, which was one of the things that I dont think was a requirment,
but I just wanted to make it to try and improve my project. Learning how to save the user's settings to a local .json file was intresting too. I also used entity framework core
for handling an sqlite file of the favorites and view counts, as well as trying to improve the dependancy injection in my Program.cs, which were both really intresting things to
learn. It took me about a week and a half, maybe two weeks to finish this project, which wasn't exactly what I was hoping for, but I'm glad I got it done. I'm excitied to see
what the next project will be, and what I'll be able to learn from that project as well.
