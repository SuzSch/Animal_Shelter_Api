![Picture of two cute dogs with a cute cat between them. The dog on the left is a corgi with a yellow bowtie on. The cat in the middle is grey and they are looking over their sholder at the camera. The dog on the right looks like a huskey cattle dog mix. They are in a meadow of yellow flowers with the sun setting behind them.](https://s.yimg.com/ny/api/res/1.2/lVY6xmuPCl_j6jDFz1PjbA--/YXBwaWQ9aGlnaGxhbmRlcjt3PTY0MDtoPTM2MA--/https://media.zenfs.com/en/dog_time_927/d56c8a78d352ed6a1ea2d506e200e130)
# Animal Shelter API

#### An API for an animal shelter that lists the available cats and dogs at the shelter.
#### By Suzanne Schuber

## Technologies Used

- **ASP.NET Core**
- **Entity Framework Core**
- **Microsoft SQL Server**
- **Swagger**
- **Microsoft.AspNetCore.Mvc**
- **C#** 
- **Git**
- **Postman**

## Setup/Installation Requirements

1. Clone this repo.
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's root directory called "Animal_Shelter_Api.Solutions"
4. Add a .gitignore file to root directory.
5. add obj, bin, and appsettings.json to .gitignore file.
6. Within the production directory "Animal_Shelter_Api", create a new file called appsettings.json.
7. Within appsettings.json, put in the following code, replacing the database, uid and pwd values with your own database name, username and password for MySQL.
``````
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
``````
8. create your initial migration and update the database.
``````
$ dotnet ef migrations add Initial
$ dotnet ef database update
``````
9. Type dotnet run watch in the terminal to launch Swagger to test and use the API.

# API Documentation

This API provides endpoints to manage future pets, including cats and dogs, in an animal shelter.

## Base URL
``````
http://localhost:5000/api/futurepets
``````

## Endpoints

### Get Future Pets

Retrieve a list of future pets in the shelter.

**Endpoint:** `GET http://localhost:5000/api/FuturePets`

**Query Parameter:**
- `petType` (optional): Filter future pets by pet type. Possible values are: 

🐈  "cat"   

and 

🐕   "dog"  
``````
http://localhost:5000/api/futurepets?petType=cat
http://localhost:5000/api/futurepets?petType=dog
``````
- `minAge` (optional): Filter future pets by minimum age.
``````
http://localhost:5000/api/futurepets?minAge=5

``````
It's also possible to include multiple query strings by separating them with an &:
``````
http://localhost:5000/api/futurepets?petType=cat&minAge=3
``````

**Response:**
- Status: 200 OK
- Body: List of future pets in the response format.
<hr>

### Get Future Pet by ID

Retrieve details of a specific future pet by ID.

**Endpoint:** `GET http://localhost:5000/api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to retrieve.

**Response:**
- Status: 200 OK
- Body: Details of the requested future pet in the response format.
<hr>

### Add a New Future Pet

Add a new future pet to the animal shelter.

**Endpoint:** `POST http://localhost:5000/api/futurepets`

When making a POST request to http://localhost:5000/api/futurepets/, you need to include a body. Do not include the futurePetId as that is auto generated upon creation. 

**Request Body:**
- JSON object representing the new future pet details. Eg:
```json
{
  "name": "Tuffy",
  "age": 3,
  "breed": "Ragamuffin",
  "coatColor": "Chestnut",
  "fivPositive": true,
  "petType": "Cat"
}
``````
**Response:**
- Status: 201 Created
- Body: Details of the newly created future pet in the response format.

<hr>

### Update Future Pet

Update details of an existing future pet.

**Endpoint:** `PUT http://localhost:5000/api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to update.

When making a PUT request to http://localhost:5000/api/futurePets/{id}, you need to include a body that includes the pets futurePetId property. Here's an example body in JSON:

```json
{
  "futurePetId": 9,
  "name": "Dale",
  "age": 2,
  "breed": "Dachshund",
  "coatColor": "Cream",
  "dogSize": "Small",
  "petType": "Dog"
}
``````

**Request Body:**
- JSON object containing the updated future pet details.

**Response:**
- Status: 204 No Content
<hr>

### Delete Future Pet

Delete a future pet from the animal shelter.

**Endpoint:** `DELETE http://localhost:5000/api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to delete.

**Response:**
- Status: 204 No Content

## Response Format Example

```json
{
  "futurePetId": 10,
  "name": "Pumpkin",
  "age": 5,
  "breed": "Scottish Fold",
  "coatColor": "Brown",
  "fivPositive": true,
  "petType": "Cat"
}
``````
## Error Responses
### Status: 400 Bad Request
* Body: Invalid pet type or update data.

### Status: 404 Not Found
* Body: The requested future pet was not found.

### Status: 500 Internal Server Error
* Body: An internal server error occurred. Contact the administrator for assistance.

## Known Bugs

None.

<hr>

# Further Exploration

<img src="https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExNXlpbXZoYjNrd3ltZWl0bWtzNWF5MXljMjV6ejhzdm8xNjhneTdrZCZlcD12MV9naWZzX3NlYXJjaCZjdD1n/URoLoCo1s9jm8/200.gif" width="50%" height="50%" />  

 
### I decided to try adding CORS to my API. CORS stands for Cross-Origin Resource Sharing and it's used to allow requests from specific origins(domains). Here's a step by step of my process.

1. I installed the Microsoft.AspNetCore.Cors package.
``````
dotnet add package Microsoft.AspNetCore.Cors
``````
2. I added a CORS policy to my Program.cs using the AddCors() method.
``````
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
``````
3. Added Use CORS middleware to my Program.cs before the mapping controllers

``````
app.UseCors();
``````
4. To test if CORS was working I used a testApp that I made earlier in the week following a tutorial for CORS and made a call to my API.
5. Kept getting a ERR_SSL_PROTOCOL_ERROR and figured out I need to change the FetchRemote to http instead of https from the tutorial.
6. All the data was returned to the test app index page which makes sense since I have the policy set to AllowAnyOrigin.
7. Changed my AddCors method to the following to change to specific origin:
``````
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://example.com") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
``````
8. Got the following error as expected:
``````
Access to fetch at 'http://localhost:5000/api/futurepets' from origin 'https://localhost:8081' has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource. If an opaque response serves your needs, set the request's mode to 'no-cors' to fetch the resource with CORS disabled.
``````
9. Currently the policy is configured to allow any origin, any header, and any HTTP method. This is useful for development but might be overly permissive for production environments. You would adjust the CORS policy to match the application's security requirements after development.

## License
MIT License

Copyright (c) 2023 Suzanne Schuber

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.