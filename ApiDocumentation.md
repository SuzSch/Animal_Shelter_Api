# Future Pets API Documentation

This API provides endpoints to manage future pets, including cats and dogs, in an animal shelter.

## Base URL
``````
/api/FuturePets
``````

## Endpoints

### Get Future Pets

Retrieve a list of future pets in the shelter.

**Endpoint:** `GET /api/FuturePets`

**Query Parameter:**
- `petType` (optional): Filter future pets by pet type. Possible values are "cat" and "dog".

**Response:**
- Status: 200 OK
- Body: List of future pets in the response format.

### Get Future Pet by ID

Retrieve details of a specific future pet by ID.

**Endpoint:** `GET /api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to retrieve.

**Response:**
- Status: 200 OK
- Body: Details of the requested future pet in the response format.

### Add a New Future Pet

Add a new future pet to the animal shelter.

**Endpoint:** `POST /api/FuturePets`

**Request Body:**
- JSON object representing the new future pet details.

**Response:**
- Status: 201 Created
- Body: Details of the newly created future pet in the response format.

### Update Future Pet

Update details of an existing future pet.

**Endpoint:** `PUT /api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to update.

**Request Body:**
- JSON object containing the updated future pet details.

**Response:**
- Status: 204 No Content

### Delete Future Pet

Delete a future pet from the animal shelter.

**Endpoint:** `DELETE /api/FuturePets/{id}`

**Path Parameter:**
- `id`: ID of the future pet to delete.

**Response:**
- Status: 204 No Content

## Response Format Example

```json
{
  "futurePetId": 1,
  "name": "Fluffy",
  "age": 2,
  "breed": "Siamese",
  "coatColor": "White",
  "fivPositive": true,
  "dogSize": null,
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
