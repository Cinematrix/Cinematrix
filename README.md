# Cinematrix - fastest way to guarantee your movie night.
[![Build status](https://ci.appveyor.com/api/projects/status/lyloapq6alsvlg2d?svg=true)](https://ci.appveyor.com/project/iliangogov/cinematrix)
---------------------------------------------------------------------------------------------------------------------------------

## ASP.NET Web Forms course project 

Web forms aplication using MVP pattern architecture and Unit testing.

This application is giving the chance, existing Cinema to allow registered users to book seats from listed film screenings.
User friendly interface makes choosing seats for certain film screening real pleasure.

Admin part: 
  - Cashiers have adiitional functionality to check up User's bookings and "Print" tickets with info and calculated total price. 
  - Admin can promote Users to Cashiers. Demote Cashiers. Bann incorrect users for furthur bookings. Add new Movies. Add new film screenings.

---------------------------------------------------------------------------------------------------------------------------------

## Links
##### [<img src="https://rawgit.com/Team-Namor/Presentation/master/imgs/youtube.png" height="22"/> Project's Video](https://youtu.be/IpdpdZQzloo)
##### [<img src="http://www.app-trailer.com/appicons/android/100x100/com.telerik.examples.png" height="22"/> Cinematrix in Telerik Showcase](http://best.telerikacademy.com/projects/423/Holiday-Advisor)

---------------------------------------------------------------------------------------------------------------------------------

## Author

|Name              | http://telerikacademy.com profile                           |https://github.com profile                   |
|:----------------:|:-----------------------------------------------------------:|:-------------------------------------------:|
|Ilian Gogov       |[Iliangogov](https://telerikacademy.com/Users/Iliangogov)    |[iliangogov](https://github.com/iliangogov)  |


---------------------------------------------------------------------------------------------------------------------------------

[![Screenshot_4.jpg](https://s27.postimg.org/5nzgcquoj/Screenshot_4.jpg)](https://postimg.org/image/yqdqfkgy7/)

---------------------------------------------------------------------------------------------------------------------------------

## Functionalities
|Role              | Can do                                                                            | Can not do|
|:----------------:|:---------------------------------------------------------------------------------:|:---------:|
|anonymous         |Check up movies library. Check up released filmscreenings. Register. Log in        |Book seats |
|user(logged in)   |Same as anonymous plus Book Seats    |Add movies, add film screenings, proceed payments, manage roles |
|user(banned)      |Same as anonymous               |Book seats, add movies, add film screenings, proceed payments, manage roles |
|cashier           |Same as user plus payment proceeding |Add movies, add film screenings, manage roles |
|admin             |Same as cashier plus Add movies, add film screenings, manage roles |                |
