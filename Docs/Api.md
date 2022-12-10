# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register 
```

#### Register Request
```json
{
    "firstName": "Harry",
    "lastName": "Potter",
    "email": "harry.potter@hogwarts.com",
    "password": "Hedwig123"
}
```
#### Register Response 
```js
200 OK
```
```json
{
    "id": "c1e3aa4d-9844-498e-a21e-fe7dcb0705f7",  
    "firstName": "Harry",
    "lastName": "Potter",
    "email": "harry.potter@hogwarts.com",
    "token": "buD...r"
}
```

### Login
```js
POST {{host}}/auth/login 
```

#### Login Request
```json
{
    "email": "harry.potter@hogwarts.com",
    "password": "Hedwig123"
}
```

#### Login Response 
```js
200 OK
```
```json
{
    "id": "c1e3aa4d-9844-498e-a21e-fe7dcb0705f7",  
    "firstName": "Harry",
    "lastName": "Potter",
    "email": "harry.potter@hogwarts.com",
    "token": "buD...r"
}
```