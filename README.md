# Dev Blog
*Made by me*

## Description
Dev Blog is a platform where users can share their projects and create posts where other users can share their thoughts.

## Changelog
### v0.6.0
- Added current class diagram

### v0.5.0
- Added dependency injection testing (Console App)

### v0.4.0
- Added unit test
  - Create Account
  - Create Admin Account

### v0.3.0
- Added interfaces
  - Account
  - Category
  - Comment
  - Tag
  - Post (Generic)

### v0.2.0
- Added repositories
  - Account
  - BlogPost
  - Category
  - Comment
  - PortfolioPost
  - Tag

### v0.1.0
- Added models
  - Account
  - BlogPost
  - Category
  - Comment
  - PortfolioPost
  - Post
  - Tag

## ToDo
  - [X] 1. Register
    - [X] 1.1 A user should be able to create a new account
    - [X] 1.2 A user should not be able to create an account with an already existing email
    - [X] 1.3 There should be validation both on front and server backend for the users input
  - [ ] 2. Login (Default page when accessing page the first time)
    - [ ] 2.1 A user should be able to login where something like Id and other important information is saved in session(cookies)
  - [ ] 3. Logout
    - [ ] 3.1 A user should be able to log out to clear the session cookies
  - [ ] 4. Index page
    - [ ] 4.1 Display recent blogposts and be able to click on them to see the details of the blogpost like Author, Title, Images, Tags and Comments
  - [ ] 5. Profile (A page to display a users blogposts and portfolioposts)
    - [ ] 5.1 Blog
      - [ ] 5.1.1 CRUD Blogpost
        - [ ] 5.1.1.1 A user should be able to add tags and categories to their post
    - [ ] 5.2 Portfolio
      - [ ] 5.2.1 A user should be able to add tags and categories to their post
      - [ ] 5.2.2 CRUD Portfoliopost
  - [ ] 6. Optional
    - [ ] 6.1 Admin panel (A page to manage other users and be able to create new admin accounts)
      - [ ] 6.1.1 CRUD Accounts
      - [ ] 6.1.2 CRUD Tags
      - [ ] 6.1.3 CRUD Categories
    - [ ] 6.2 CRUD Comments
  
## Class Diagram
### Current Class Diagram
![image](https://github.com/user-attachments/assets/1234f8e6-0c4f-405e-98bc-2f5fe55af9ce)

### Initial Class Diagram
![image](https://github.com/user-attachments/assets/54b227fa-7a5c-405d-ae3e-13a407c86f79)
