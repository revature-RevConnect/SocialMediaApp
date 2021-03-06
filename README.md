# RevConnect

## Project Description

RevConnect is a single page web application with an Angular web application that communicates with a restful ASP.NET API with EF. Users can create an account with a user profile and can view, like, comment and share posts with other users of the site. Our application also implements an instant messaging feature allowing users to start a live chat with another user of their choosing.

## Technologies Used

* ASP.NET Core - version 6.0                        
* Angular version - version 13.0.0                 
* Entity Framework Core - version 6.0
* Microsoft SQL Server 2019
* Docker
* Auth0
* SignalR                                  	
* Sonar Cloud
* Jasmine - version 3.0
* Karma - version 11.18
* xUnit - version 2.4.1

## Getting Started

- `git clone https://github.com/revature-RevConnect/SocialMediaApp.git`
- `npm install -g @angular/cli`
- If running on Windows, also run: `Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned`
- `dotnet tool list --global`
- `dotnet tool list --global dotnet-ef`

- Inside the package manager console, set: 
 `“Default project: RevConnectAPI”`
  then run the command: `update-database`

- `dotnet run ./SocialMediaApp/RevConnectAPP`
- `npm install ./SocialMediaApp/RevConnectAPI`
- `ng serve –-open ./SocialMediaApp/RevConnectAPI`


## Usage
- Create an account 
- Login and log out of account
- Create user profile
- Create a post 
- View posts from all users in Home page
- "Like" a post
- Comment on a post
- Directly message another user, or everyone in the chatroom, in real time 
- Toggle dark mode


## For Future Development
* Adding additional unit tests
* Fixing minor bugs with dark mode

## Contributors

### Team Leads

>  Brian Keener  
>   - Chatroom
    - Comments
    - Dark mode 
    - Documentation 
    - "Like" a post 
    - Post feed
>
> Dan Gagne
>  -  Unit testing
    - Docker
    - Mockaroo
    - SonarCloud
    - Static Web Hosting
>    
> Francis Chung
>  -  Auth0
    - Create a profile
    - Upload a profile picture
    - User profile

### Features

> Post Feed
> - Brian Keener  
> - Kelly Keng
>
> “Like” a Post
> - Brian Keener  
> - Muhammad Amin Rahimi  
> - Jerome Gear  
>
> Chat Room
> - Austin Hickman  
> - Cameron Merkh     
> - Zhixin He  
>
> Dark Mode
> - Kevin Lee  
> - Brian Keener  
>
> Documentation
> - Kevin Lee  
> - Kelly Keng  
> - Jerome Gear  
>
> Comments Section 
> - Anu Thekkekattil  
> - Brian Keener  
>
> Docker 
> - Donald Keita  
> 
> Unit Testing
> - Diego De Los Santos  
> - Jay Camp    
> - Bruk Gella    
>
> Sonar Cloud 
> - Austin Hickman
> - Dan Gagne
>
> Mockaroo 
> - Tryggve Rogness
>
> Static Web Hosting
> - Dan Gagne
>
> Frontend Design (Home, User Profile, Settings)
> - Phirith Pheak
> 
> Auth0
> - Andrew Krisnawan
> - Phirith Pheak
> - Tahereh Rastegarzare
> - Tuan Anh Nguyen
> - Tryggve Rogness
> - Phirith Pheak
> 
> User Profile
> - Aureliano Silva
> - Phirith Pheak
>
> Upload a Profile Picture
> - Christian Cubides
> - Dan Gagne
>
> Settings 
> - Phirith Pheak




