# Pet Shop

#|Title
---|---
1| [requirment](#requirment)
2| [user stories](#user-stories)
3| [domain modeling](#domain-modeling)
4| [wireframes](#wireframes)
5| [Routes](#routes)


## Requirment 
You can find Requirments [HERE](Requirments.md)

## User Stories

As a bet shop owner:

1. I want to have the ability to add and remove pets
2. and i want to have a custom interface to add my product and pets
3. I want to have the ability to add some animal product like food clothes and toys
4. and the ability to create an account and log in
5. and the ability to add save and update the pets medical history

As a customer

1. I want an easy way to find a pet
2. and the ability to know the pets medical history
3. and the ability to buy some different foods and treats for my pets
4. and the ability to create an account and log in
5. and the ability to adapt the bet

## Domain Modeling

## Context Diagram (DFD level 0)

---

![image](./images/Context.png)

## DFD level 1

---

![image](./images/DFD_1.png)

## DFD level 2

---

![image](./images/DFD_2.png)

---

## Wireframes

### Home

---

![image](./images/Home.png)

### Log in

---

![image](./images/login.png)

### Categories

---

![image](./images/Categories.png)

### Products

---

![image](./images/Products.png)

### Animals

---

![image](./images/animals.png)

### About us

---

![image](./images/AboutUs.png)




## Routes

for the routes in our project we have 4 main comtrollers:

 1. **AnimalController**


    **CRUD Endpoint** 

    - **// "POST: api/Animal" (to Create new Animal, take in body JSON of class type `Animal`)** like.
            
    ```
    {
    "animalId": 1,
    "name": "alex",
    "gender": "male",
    "price": 30,
    "dateOfBerth": "2020-05-03T00:00:00",
    "animalType": "cat"
    }
    ```      

    -  **// GET: `api/Animal` (to Get all Animal)**
    -  **// GET: `api/Animal/2` (to Get Animal depend on `key`)**
    -  **// PUT: `api/Animal/2` (to Update Animal depend on  resorse `key` and take in body json of class type `Animal`.**
    -  **// DELETE: `api/Animal/2` (to delete data from Animal depend on resorse `key`)**
    
    **Relation**
    -  **// POST: `api/Animal/3/addEvent` (to Add Event To Animal)**
    -  **// DELETE: `api/Animal/1/Event/1` (to Delete Event)**

    **Search service**
    -  **// GET: `api/Animal` (to Get Animal by `name`)**
    -  **// GET: `api/Animal/2` (to Get Animals By `Type`)**

  
    **comment Service**
    - **//Post: `api/Animal/1/Comment` (to Add comment to the Animal)**
    - **// DELETE: `api/Animal/1/Comment/1` (to Delete comment From the Animal)**

------
2. **CartController**


   **CRUD Endpoint**
    -  **// POST: `api/Cart` (to Create new Cart, take in body JSON of class type `Cart`)** like.
            
     ```
      {
        "cartId": 3
      }
     ```      

     -  **// GET: `api/Cart` (to Get all Cart)**
     -  **// GET: `api/Cart/1` (to Get Cart depend on resorse `key`)**
     -  **// PUT: `api/Cart/1` (to Update Cart depend on  resorse `key` and take in body json of class type `Cart`)**
     -  **// DELETE: `api/Cart/1` (to delete data from Cart depend on resorse `key`)**

    **Relation**
    -  **// POST: `api/Cart/1/Animal/1` (to Add Animal To Cart)**
    -  **// DELETE: `api/Cart/2/Animal/1` (to Delete Animal from Cart)**
    -  **// POST: `api/Cart/1/Product/1` (to Add Product To Cart)**
    -  **// DELETE: `api/Cart/2/Product/1` (to Delete Product from Cart)**

    **buying service**
    
    -  **// GET: `api/Cart/2/Total` (to get Total Amount for the cart)**
    -  **// GET: `api/Cart/1/checkItems` (to check Items in the cart if it stell in the database or another user take it)**
    -  **// DELETE: `api/Cart/2/FixCart` (to fix The Cart and remove the item that another user take it)**
    -  **// DELETE: `api/Cart/2/empty` (to make the Cart empty after buy)**
    -  **// DELETE: `api/Cart/2/buy` (to buy Product that add to the cart)**


-------
3. **EventController**



   **CRUD Endpoint**
     -  **// POST: `api/Event` (to Create new Cart, take in body JSON of class type `Event`)** like.
            
     ```
    {
      "eventId": 1,
      "date": "2020-02-03T00:00:00",
      "title": "vaccine 1",
      "description": "date for vaccine 1",
      "status": true
    }
     ```      

     -  **// GET: `api/Event` (to Get all Event)**
     -  **// GET: `api/Event/1` (to Get Event depend on resorse `key`)**
     -  **// PUT: `api/Event/1` (to Update Event depend on  resorse `key` and take in body json of class type `Event`)**
     -  **// DELETE: `api/Event/1` (to delete data from Event depend on resorse `key`)**



-------
4. **ProductController**



     -  **// POST: `api/Product` (to Create new Cart, take in body JSON of class type `Product`)** like.
            
    ```
    {
      "prodactId": 1,
      "name": "cat food 1",
      "animalType": "cat",
      "price": 20,
      "description": "10k of food for cats",
    }
    ```      

     -  // **GET: `api/Product` (to Get all Products)**
     -  // **GET: `api/Product/1` (to Get Product depend on resorse `key`)**
     -  // **PUT: `api/Product/1` (to Update Product depend on  resorse `key` and take in body json of class type `Product`)**
     -  // **DELETE: `api/Product/1` (to delete data from Product depend on resorse `key`)**

    **Search service**
    -  **// POST: `api/Cart/1/Product/1` (to Add Product To Cart)**
    -  **// DELETE: `api/Cart/2/Product/1` (to Delete Product from Cart)**

    **Rate Service**
    - **//Post: `api/Product/1/Rate/4` (to Add Rating to the Product)**

-------
5. **UsersController**
     -  // **POST: `api/Login` (to login in User data, take in body JSON of class type `LoginData`)** like.
            
     ```
    {
      
     "UserName" = "name",
     "Password"="Aa12345678#"
    }
     ```      

      -  // **POST: `api/Register` (to Register with user account , take in body JSON of class type `RegisterUserDTO`)** like.
            
     ```
    {
      
     "UserName" = "name",
     "Email" = "e.man@gmail.com",
     "Password"="Aa12345678#"
    }
     ```      
   -  // **POST: `api/Logout` (to logout the User)**
