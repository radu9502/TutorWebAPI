# TutorWebAPI-ASP.NET-Entity-Framework

Documentation:

**Admin API**

**GET /api/Admin/Users**
Get a list of users.
Parameters
None


**GET /api/Admin/Users/{id}**
Get user details by ID.
Parameters
id (path): User ID
authorization (header): Authorization token


**DELETE /api/Admin/DeleteUser/{id}**
Delete a user by ID.
Parameters
id (path): User ID


**GET /api/Admin/Categories**
Get a list of categories.
Parameters
None


**GET /api/Admin/Category/{id}**
Get category details by ID.
Parameters
id (path): Category ID


**DELETE /api/Admin/DeleteCategory/{id}**
Delete a category by ID.
Parameters
id (path): Category ID

**GET /api/Admin/SubCategories**
Get a list of subcategories.
Parameters
None


**GET /api/Admin/SubCategories/{id}**
Get subcategory details by ID.
Parameters
id (path): Subcategory ID

**DELETE /api/Admin/DeleteSubCategory/{id}**
Delete a subcategory by ID.
Parameters
id (path): Subcategory ID

**DELETE /api/Admin/DeleteRequest/{id}**
Delete a request by ID.
Parameters
id (path): Request ID


**Authentication API**

**POST /api/Authentication/Login**
Login with user credentials.

Parameters
userName (query): User's username
password (query): User's password

**POST /api/Authentication/Register**
Register a new user.
Parameters
userName (query): User's username
password (query): User's password
email (query): User's email

**Requests API**

**GET /GetRequests**
Get a list of requests.

Parameters
page (query): Page number
pageSize (query): Number of items per page
category (query): Array of category IDs
difficulty (query): Array of difficulty levels
orderType (query): Order type
orderBy (query): Order by field

**GET /Request/{id}**
Get request details by ID.

Parameters
id (path): Request ID

**POST /CreateRequest**
Create a new request.
Parameters
authorization (header): Authorization token
Request body (application/json):
{
  "requestorId": 0,
  "tutorId": 0,
  "title": "string",
  "categoryId": 0,
  "subCategoryId": 0,
  "details": "string",
  "price": 0,
  "dificulty": 0,
  "publishDate": "2023-08-08T19:16:24.521Z",
  "deleted": true
}

**POST /EditRequest**
Edit an existing request.

Parameters
id (query): Request ID
RequestorId (query): Requestor's ID
TutorId (query): Tutor's ID
Title (query): Request title
CategoryId (query): Category ID
SubCategoryId (query): Subcategory ID
Details (query): Request details
Price (query): Request price
Dificulty (query): Request difficulty
PublishDate (query): Publish date
Deleted (query): Whether the request is deleted
authorization (header): Authorization token

**GET /DeleteRequest**
Delete a request.
Parameters
id (query): Request ID
authorization (header): Authorization token
