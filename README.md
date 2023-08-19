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
- **LINQ**
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
8. Run dotnet restore


# API Documentation

This API provides endpoints to manage future pets, including cats and dogs, in an animal shelter.

## Base URL
``````
/api/FuturePets
``````

## Endpoints

### Get Future Pets

Retrieve a list of future pets in the shelter.

**Endpoint:** `GET http://localhost:5000/api/FuturePets`

**Query Parameter:**
- `petType` (optional): Filter future pets by pet type. Possible values are "cat" and "dog".

```http://localhost:5000/api/futurepets?pettype=cat```
```http://localhost:5000/api/futurepets?pettype=dog```

- `minAge` (optional): Filter future pets by minimum age.

```http://localhost:5000/api/futurepets?minage=5```



**Response:**
- Status: 200 OK
- Body: List of future pets in the response format.

### Get Future Pet by ID

Retrieve details of a specific future pet by ID.

**Endpoint:** `GET http://localhost:5000/api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to retrieve.

**Response:**
- Status: 200 OK
- Body: Details of the requested future pet in the response format.

### Add a New Future Pet

Add a new future pet to the animal shelter.

**Endpoint:** `POST http://localhost:5000/api/FuturePets`

**Request Body:**
- JSON object representing the new future pet details.

**Response:**
- Status: 201 Created
- Body: Details of the newly created future pet in the response format.

### Update Future Pet

Update details of an existing future pet.

**Endpoint:** `PUT http://localhost:5000/api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to update.

**Request Body:**
- JSON object containing the updated future pet details.

**Response:**
- Status: 204 No Content

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
  "futurePetId": 2,
  "name": "Tuffy",
  "age": 3,
  "breed": "Ragamuffin",
  "coatColor": "Chestnut",
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

## Further Exploration

I decided to try adding CORS to my API. CORS stands for Cross-Origin Resource Sharing and it's used to allow requests from specific origins(domains). Here's a step by step of my process.

1. I installed the Microsoft.AspNetCore.Cors package.
2. I added 
